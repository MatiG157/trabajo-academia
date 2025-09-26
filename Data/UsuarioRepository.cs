using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var cliente = context.Usuarios.Find(id);
            if (cliente != null)
            {
                context.Usuarios.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefault(u => u.IdUsuario == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
                .Include(u => u.Persona)
                .ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            var existingUsuario = context.Usuarios.Find(usuario.IdUsuario);
            if (existingUsuario != null)
            {
                existingUsuario.Nombre = usuario.Nombre;
                existingUsuario.Apellido = usuario.Apellido;
                existingUsuario.Email = usuario.Email;
                existingUsuario.Habilitado = usuario.Habilitado;
                existingUsuario.NombreUsuario = usuario.NombreUsuario;
                existingUsuario.SetPersonaId(usuario.IdPersona);


                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.IdUsuario != excludeId.Value);
            }
            return query.Any();
        }

        public IEnumerable<Usuario> GetByCriteria(UsuarioCriteria criteria)
        {
            const string sql = @"
                SELECT  u.IdUsuario, u.NombreUsuario, u.Clave, u.Habilitado, u.Nombre, u.Apellido, u.Email, u.CambiaClave, u.IdPersona,
                      p.Apellido, p.Direccion, p.Email, p.FechaNacimiento, p.IdPlan, p.Legajo, p.Telefono, p.TipoPersona
                FROM Usuarios u
                INNER JOIN Personas p ON u.IdPersona = p.IdPersona
                WHERE u.Nombre LIKE @SearchTerm 
                   OR u.Apellido LIKE @SearchTerm 
                   OR u.Habilitado LIKE @SearchTerm
                   OR u.Email LIKE @SearchTerm
                   OR u.NombreUsuario LIKE @SearchTerm
                ORDER BY u.Nombre, u.Apellido";

            var usuarios = new List<Usuario>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var usuario = new Usuario(
                    reader.GetInt32(0),    // IdUsuario
                    reader.GetString(1),   // NombreUsuario
                    reader.GetString(2),   // Clave
                    reader.GetBoolean(3),  // Habilitado
                    reader.GetString(4),   // Nombre
                    reader.GetString(5),   // Apellido
                    reader.GetString(6),   // Email
                    reader.GetBoolean(7),  // CambiaClave
                    reader.GetInt32(8)     // IdPersona
                );

                // Crear y asignar el Persona
                var persona = new Persona(
                    reader.GetInt32(8),    // IdPersona
                    reader.GetString(10),  // Apellido
                    reader.GetString(11),  // Direccion
                    reader.GetString(12),  // Email
                    reader.GetDateTime(13),// FechaNacimiento
                    reader.GetInt32(15),   // Legajo
                    reader.GetString(16),  // Telefono
                    reader.GetString(17)   // TipoPersona
                   );
                persona.SetPlanId(reader.GetInt32(14));

                usuario.SetPersona(persona);
                usuarios.Add(usuario);
            }

            return usuarios;
        }
        public async Task<Usuario?> FindByCriteria(UsuarioCriteria criteria)
        {
            using var context = CreateContext();

            var query = context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Email))
                query = query.Where(u => u.Email == criteria.Email);

            if (!string.IsNullOrEmpty(criteria.Clave))
                query = query.Where(u => u.Clave == criteria.Clave);

            return await query.FirstOrDefaultAsync();
        }
    }
}
