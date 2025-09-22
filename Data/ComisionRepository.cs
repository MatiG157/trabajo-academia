
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Comision comision)
        {
            using var context = CreateContext();
            context.Comisiones.Add(comision);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var comision = context.Comisiones.Find(id);
            if (comision != null)
            {
                context.Comisiones.Remove(comision);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Comision? Get(int id)
        {
            using var context = CreateContext();
            return context.Comisiones
                .Include(c => c.Plan)
                .FirstOrDefault(c => c.IdComision == id);
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Comisiones
                .Include(c => c.Plan)
                .ToList();
        }

        public bool Update(Comision comision)
        {
            using var context = CreateContext();
            var existingComision = context.Comisiones.Find(comision.IdComision);
            if (existingComision != null)
            {
                existingComision.SetPlanId(comision.IdPlan);
                existingComision.AnioEspecialidad = comision.AnioEspecialidad;
                existingComision.Descripcion = comision.Descripcion;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Comision> GetByCriteria(ComisionCriteria criteria)
        {
            const string sql = @"
                SELECT com.IdComision, com.AnioEspecialidad, com.Descripcion, com.IdPlan,  
                       p.Descripcion, p.IdEspecialidad,
                FROM Comisiones com
                INNER JOIN Planes p ON com.IdPlan = p.IdPlan
                WHERE com.AnioEspecialidad LIKE @SearchTerm
                   OR com.Descripcion LIKE @SearchTerm
                ORDER BY com.AnioEspecialidad, com.Descripcion";


            var comisiones = new List<Comision>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var comision = new Comision(
                    reader.GetInt32(0),    // IdComision
                    reader.GetInt32(1),   // AnioEspecialidad
                    reader.GetString(2)   // Descripcion
                );

                // Crear y asignar el plan
                var plan = new Plan(
                    reader.GetInt32(3), // idPlan
                    reader.GetString(4) // descripcion
                    );
                plan.SetEspecialidadId(reader.GetInt32(5));
                comision.SetPlan(plan);

                comisiones.Add(comision);
            }

            return comisiones;
        }

    }
}