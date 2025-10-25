using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class EspecialidadRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Especialidad especialidad)
        {
            await using var context = CreateContext();
            await context.Especialidades.AddAsync(especialidad);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var especialidad = await context.Especialidades.FindAsync(id);
            if (especialidad != null)
            {
                context.Especialidades.Remove(especialidad);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Especialidad?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Especialidades
                .FirstOrDefaultAsync(e => e.IdEspecialidad == id);
        }

        public async Task<IEnumerable<Especialidad>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Especialidades
                .ToListAsync();
        }

        public async Task<bool> Update(Especialidad especialidad)
        {
            await using var context = CreateContext();
            var existingEspecialidad = await context.Especialidades.FindAsync(especialidad.IdEspecialidad);
            if (existingEspecialidad != null)
            {
                existingEspecialidad.Descripcion = especialidad.Descripcion;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Especialidad>> GetByCriteria(EspecialidadCriteria criteria)
        {
            const string sql = @"
                SELECT e.IdEspecialidad, e.Descripcion
                FROM Especialidades e             
                WHERE e.Descripcion LIKE @SearchTerm";

            var especialidades = new List<Especialidad>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            await using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var especialidad = new Especialidad(
                    reader.GetInt32(0),    // IdEspecialidad
                    reader.GetString(1)    // Descripcion
                );
                especialidades.Add(especialidad);
            }

            return especialidades;
        }
    }
}
