using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Plan plan)
        {
            using var context = CreateContext();
            context.Planes.Add(plan);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var plan = context.Planes.Find(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Plan? Get(int id)
        {
            using var context = CreateContext();
            return context.Planes
                .Include(p => p.Especialidad)
                .FirstOrDefault(p => p.IdPlan == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Planes
                .Include(p => p.Especialidad)
                .ToList();
        }

        public bool Update(Plan plan)
        {
            using var context = CreateContext();
            var existingPlan = context.Planes.Find(plan.IdPlan);
            if (existingPlan != null)
            {
                existingPlan.IdPlan = plan.IdPlan;
                existingPlan.Descripcion = plan.Descripcion;



                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Plan> GetByCriteria(PlanCriteria criteria)
        {
            const string sql = @"
                SELECT  p.IdPersona, p.Descripcion
                FROM Planes p
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                WHERE p.Descripcion LIKE @SearchTerm";

            var planes = new List<Plan>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var plan = new Plan(
                    reader.GetInt32(0),    // IdPlan
                    reader.GetString(1)   // Descripcion
                );


                // Crear y asignar el Plan
                var Especialidad = new Especialidad(
                    reader.GetInt32(2),    //IdEspecialidad
                    reader.GetString(3)  // Descripcion
                   );
                plan.SetEspecialidadId(reader.GetInt32(10));

                //materia.SetMateria(materia);
                planes.Add(plan);
            }

            return planes;
        }

    }
}