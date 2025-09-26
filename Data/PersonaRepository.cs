using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas
                .Include(p => p.Plan)
                .FirstOrDefault(p => p.IdPersona == id);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas
                .Include(p => p.Plan)
                .ToList();
        }

        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.IdPersona);
            if (existingPersona != null)
            {
                existingPersona.IdPersona = persona.IdPersona;
                existingPersona.Apellido = persona.Apellido;
                existingPersona.Direccion = persona.Direccion;
                existingPersona.Email = persona.Email;
                existingPersona.FechaNacimiento = persona.FechaNacimiento;
                existingPersona.SetPlanId(persona.IdPlan);
                existingPersona.Legajo = persona.Legajo;
                existingPersona.Telefono = persona.Telefono;
                existingPersona.TipoPersona = persona.TipoPersona;


                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.IdPersona != excludeId.Value);
            }
            return query.Any();
        }

        public IEnumerable<Persona> GetByCriteria(PersonaCriteria criteria)
        {
            const string sql = @"
                SELECT  p.IdPersona, p.Apellido, p.Direccion, p.Email, p.FechaNacimiento, p.IdPlan, p.Legajo, p.Telefono, p.TipoPersona, plan.descripcion, plan.IdEspecialidad
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

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var persona = new Persona(
                    reader.GetInt32(0),    // IdPersona
                    reader.GetString(1),   // Apellido
                    reader.GetString(2),   // Direccion
                    reader.GetString(3),   // Email
                    reader.GetDateTime(4),   // FechaNacimiento
                    reader.GetInt32(6),    // Legajo
                    reader.GetString(7),    // Telefono
                    reader.GetString(8)    // TipoPErsonas
                );
                

                // Crear y asignar el Plan
                var plan = new Plan(
                    reader.GetInt32(5),    //IdPlan 
                    reader.GetString(9)  // Descripcion
                   );
                plan.SetEspecialidadId(reader.GetInt32(10));

                //materia.SetMateria(materia);
                personas.Add(persona);
            }

            return personas;
        }

    }
}