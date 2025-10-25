using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task<List<PlanMateriaDTO>> GetPlanesConMateriasAsync()
        {
            var result = new List<PlanMateriaDTO>();

            const string sql = @"
                SELECT 
                    p.IdPlan,
                    p.Descripcion AS PlanDescripcion,
                    m.IdMateria,
                    m.Descripcion AS MateriaDescripcion,
                    m.HsSemanales,
                    m.HsTotales
                FROM Materias m
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                ORDER BY p.IdPlan, m.Descripcion;
            ";

            await using var conn = new SqlConnection("Server=DESKTOP-U0T0E2H\\SQLEXPRESS;Database=puto;Trusted_Connection=True;TrustServerCertificate=True;");
            await conn.OpenAsync();

            await using var cmd = new SqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new PlanMateriaDTO
                {
                    IdPlan = reader.GetInt32(reader.GetOrdinal("IdPlan")),
                    PlanDescripcion = reader.GetString(reader.GetOrdinal("PlanDescripcion")),
                    IdMateria = reader.GetInt32(reader.GetOrdinal("IdMateria")),
                    MateriaDescripcion = reader.GetString(reader.GetOrdinal("MateriaDescripcion")),
                    HsSemanales = reader.GetInt32(reader.GetOrdinal("HsSemanales")),
                    HsTotales = reader.GetInt32(reader.GetOrdinal("HsTotales"))
                });
            }

            return result;
        }

        public async Task Add(Plan plan)
        {
            await using var context = CreateContext();
            await context.Planes.AddAsync(plan);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var plan = await context.Planes.FindAsync(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Plan?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Planes
                .Include(p => p.Especialidad)
                .FirstOrDefaultAsync(p => p.IdPlan == id);
        }

        public async Task<IEnumerable<Plan>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Planes
                .Include(p => p.Especialidad)
                .ToListAsync();
        }

        public async Task<bool> Update(Plan plan)
        {
            await using var context = CreateContext();
            var existingPlan = await context.Planes.FindAsync(plan.IdPlan);
            if (existingPlan != null)
            {
                existingPlan.IdPlan = plan.IdPlan;
                existingPlan.Descripcion = plan.Descripcion;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Plan>> GetByCriteria(PlanCriteria criteria)
        {
            const string sql = @"
                SELECT p.IdPlan, p.Descripcion, e.IdEspecialidad, e.Descripcion AS EspecialidadDescripcion
                FROM Planes p
                INNER JOIN Especialidades e ON p.IdEspecialidad = e.IdEspecialidad
                WHERE p.Descripcion LIKE @SearchTerm
            ";

            var planes = new List<Plan>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var plan = new Plan(
                    reader.GetInt32(0),    // IdPlan
                    reader.GetString(1)    // Descripcion
                );

                var especialidad = new Especialidad(
                    reader.GetInt32(2),    // IdEspecialidad
                    reader.GetString(3)     // Descripcion
                );

                plan.SetEspecialidadId(especialidad.IdEspecialidad);

                planes.Add(plan);
            }

            return planes;
        }
    }
}
