using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Comision comision)
        {
            await using var context = CreateContext();
            await context.Comisiones.AddAsync(comision);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var comision = await context.Comisiones.FindAsync(id);
            if (comision != null)
            {
                context.Comisiones.Remove(comision);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Comision?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Comisiones
                .Include(c => c.Plan)
                .FirstOrDefaultAsync(c => c.IdComision == id);
        }

        public async Task<IEnumerable<Comision>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Comisiones
                .Include(c => c.Plan)
                .ToListAsync();
        }

        public async Task<bool> Update(Comision comision)
        {
            await using var context = CreateContext();
            var existingComision = await context.Comisiones.FindAsync(comision.IdComision);
            if (existingComision != null)
            {
                existingComision.SetPlanId(comision.IdPlan);
                existingComision.AnioEspecialidad = comision.AnioEspecialidad;
                existingComision.Descripcion = comision.Descripcion;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Comision>> GetByCriteria(ComisionCriteria criteria)
        {
            const string sql = @"
                SELECT com.IdComision, com.AnioEspecialidad, com.Descripcion, com.IdPlan,  
                       p.Descripcion, p.IdEspecialidad
                FROM Comisiones com
                INNER JOIN Planes p ON com.IdPlan = p.IdPlan
                WHERE com.AnioEspecialidad LIKE @SearchTerm
                   OR com.Descripcion LIKE @SearchTerm
                ORDER BY com.AnioEspecialidad, com.Descripcion";

            var comisiones = new List<Comision>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var comision = new Comision(
                    reader.GetInt32(0),    // IdComision
                    reader.GetInt32(1),   // AnioEspecialidad
                    reader.GetString(2)   // Descripcion
                );

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
