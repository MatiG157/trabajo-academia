using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Materia materia)
        {
            using var context = CreateContext();
            context.Materias.Add(materia);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            Console.WriteLine("entro al repository");
            var cliente = context.Materias.Find(id);
            if (cliente != null)
            {
                context.Materias.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Materia? Get(int id)
        {
            using var context = CreateContext();
            return context.Materias
                .Include(m => m.Plan)
                .FirstOrDefault(u => u.IdMateria == id);
        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materias
                .Include(m => m.Plan)
                .ToList();
        }

        public bool Update(Materia materia)
        {
            using var context = CreateContext();
            var existingMateria = context.Materias.Find(materia.IdMateria);
            if (existingMateria != null)
            {
                existingMateria.IdMateria = materia.IdMateria;
                existingMateria.Descripcion = materia.Descripcion;
                existingMateria.HsSemanales = materia.HsSemanales;
                existingMateria.HsTotales = materia.HsTotales;
                existingMateria.SetPlanId(materia.IdPlan);


                context.SaveChanges();
                return true;
            }
            return false;
        }

    

        public IEnumerable<Materia> GetByCriteria(MateriaCriteria criteria)
        {
            const string sql = @"
                SELECT  m.IdMateria, m.Descripcion, m.HsSemanales, m.HsTotales, m.IdPlan,
                     p.Descripcion, p.IdEspecialidad
                FROM Materias m
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                WHERE m.Descripcion LIKE @SearchTerm 
                ORDER BY m.Descripcion";

            var materias = new List<Materia>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var materia = new Materia(
                    reader.GetInt32(0),    // IdMateria
                    reader.GetString(1),   // Descripcion
                    reader.GetInt32(2),   // HsSemanales
                    reader.GetInt32(3)  // HsTotales
                );


                // Crear y asignar el Plan
                var plan = new Plan(
                    reader.GetInt32(4),    //IdPlan 
                    reader.GetString(5)  // Descripcion
                   );
                plan.SetEspecialidadId(reader.GetInt32(6));

                //materia.SetMateria(materia);
                materias.Add(materia);
            }

            return materias;
        }

    }
}