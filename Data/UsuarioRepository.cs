using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Usuario usuario)
        {
            await using var context = CreateContext();
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var cliente = await context.Usuarios.FindAsync(id);
            if (cliente != null)
            {
                context.Usuarios.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Usuario?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Usuarios
                .Include(u => u.Persona)
                .ToListAsync();
        }

        public async Task<bool> Update(Usuario usuario)
        {
            await using var context = CreateContext();
            var existingUsuario = await context.Usuarios.FindAsync(usuario.IdUsuario);
            if (existingUsuario != null)
            {
                existingUsuario.Nombre = usuario.Nombre;
                existingUsuario.Apellido = usuario.Apellido;
                existingUsuario.Email = usuario.Email;
                existingUsuario.Habilitado = usuario.Habilitado;
                existingUsuario.NombreUsuario = usuario.NombreUsuario;
                existingUsuario.SetPersonaId(usuario.IdPersona);

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExists(string email, int? excludeId = null)
        {
            await using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.IdUsuario != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByCriteria(UsuarioCriteria criteria)
        {
            const string sql = @"
                SELECT  u.IdUsuario, u.NombreUsuario, u.Clave, u.Habilitado, u.Nombre, u.Apellido, u.Email, u.CambiaClave, u.IdPersona,
                      p.Direccion, p.FechaNacimiento, p.IdPlan, p.Legajo, p.Telefono, p.TipoPersona
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

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
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
                    reader.GetString(9),  // Direccion
                    reader.GetDateTime(10),// FechaNacimiento
                    reader.GetInt32(12),   // Legajo
                    reader.GetString(13),  // Telefono
                    reader.GetString(14)   // TipoPersona
                   );
                persona.SetPlanId(reader.GetInt32(11));

                usuario.SetPersona(persona);
                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public async Task<Usuario?> FindByCriteria(UsuarioCriteria criteria)
        {
            await using var context = CreateContext();

            var query = context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Email))
                query = query.Where(u => u.Email == criteria.Email);

            if (!string.IsNullOrEmpty(criteria.Clave))
                query = query.Where(u => u.Clave == criteria.Clave);

            return await query.FirstOrDefaultAsync();
        }
    }
}
