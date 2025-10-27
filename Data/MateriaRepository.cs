using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Materia materia)
        {
            await using var context = CreateContext();
            await context.Materias.AddAsync(materia);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            Console.WriteLine("entro al repository");
            var cliente = await context.Materias.FindAsync(id);
            if (cliente != null)
            {
                context.Materias.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Materia?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Materias
                .Include(m => m.Plan)
                .FirstOrDefaultAsync(u => u.IdMateria == id);
        }

        public async Task<IEnumerable<Materia>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Materias
                .Include(m => m.Plan)
                .ToListAsync();
        }

        public async Task<bool> Update(Materia materia)
        {
            await using var context = CreateContext();
            var existingMateria = await context.Materias.FindAsync(materia.IdMateria);
            if (existingMateria != null)
            {
                existingMateria.IdMateria = materia.IdMateria;
                existingMateria.Descripcion = materia.Descripcion;
                existingMateria.HsSemanales = materia.HsSemanales;
                existingMateria.HsTotales = materia.HsTotales;
                existingMateria.SetPlanId(materia.IdPlan);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Materia>> GetByCriteria(MateriaCriteria criteria)
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

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
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

                materias.Add(materia);
            }

            return materias;
        }
    }
}
