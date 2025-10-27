using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Persona persona)
        {
            await using var context = CreateContext();
            await context.Personas.AddAsync(persona);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var persona = await context.Personas.FindAsync(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Persona?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Personas
                .Include(p => p.Plan)
                .FirstOrDefaultAsync(p => p.IdPersona == id);
        }

        public async Task<IEnumerable<Persona>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Personas
                .Include(p => p.Plan)
                .ToListAsync();
        }

        public async Task<bool> Update(Persona persona)
        {
            await using var context = CreateContext();
            var existingPersona = await context.Personas.FindAsync(persona.IdPersona);
            if (existingPersona != null)
            {
                existingPersona.IdPersona = persona.IdPersona;
                existingPersona.Direccion = persona.Direccion;
                existingPersona.FechaNacimiento = persona.FechaNacimiento;
                existingPersona.SetPlanId(persona.IdPlan);
                existingPersona.Legajo = persona.Legajo;
                existingPersona.Telefono = persona.Telefono;
                existingPersona.TipoPersona = persona.TipoPersona;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Persona>> GetByCriteria(PersonaCriteria criteria)
        {
            const string sql = @"
                SELECT  p.IdPersona, p.Direccion, p.FechaNacimiento, p.IdPlan, p.Legajo, p.Telefono, p.TipoPersona, plan.descripcion, plan.IdEspecialidad
                FROM Personas p
                INNER JOIN Planes p ON m.IdPlan = p.IdPlan
                WHERE p.Apellido LIKE @SearchTerm 
                WHERE p.Direccion LIKE @SearchTerm 
                WHERE p.Email LIKE @SearchTerm 
                WHERE p.FechaNacimiento LIKE @SearchTerm 
                ORDER BY p.Apellido";

            var personas = new List<Persona>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var persona = new Persona(
                    reader.GetInt32(0),    // IdPersona
                    reader.GetString(1),   // Direccion
                    reader.GetDateTime(2),   // FechaNacimiento
                    reader.GetInt32(4),    // Legajo
                    reader.GetString(5),    // Telefono
                    reader.GetString(6)    // TipoPErsonas
                );

                // Crear y asignar el Plan
                var plan = new Plan(
                    reader.GetInt32(3),    //IdPlan 
                    reader.GetString(7)  // Descripcion
                   );
                plan.SetEspecialidadId(reader.GetInt32(10));

                personas.Add(persona);
            }

            return personas;
        }
    }
}
