using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class CursoRepository
    {
        public async Task<List<CursoCountDTO>> GetCursosConCantidadAlumnosAsync()
        {
            var result = new List<CursoCountDTO>();

            const string sql = @"
                SELECT c.IdCurso,
                       c.Descripcion,
                       COUNT(ai.IdInscripcion) AS Alumnos
                FROM Cursos c
                LEFT JOIN AlumnosInscripciones ai ON ai.IdCurso = c.IdCurso
                GROUP BY c.IdCurso, c.Descripcion
                ORDER BY Alumnos DESC, c.Descripcion;
            ";

            await using var conn = new SqlConnection("Server=DESKTOP-U0T0E2H\\SQLEXPRESS;Database=puto;Trusted_Connection=True;TrustServerCertificate=True;");
            await conn.OpenAsync();

            await using var cmd = new SqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new CursoCountDTO
                {
                    IdCursoCount = reader.GetInt32(reader.GetOrdinal("IdCurso")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Cantidad = reader.GetInt32(reader.GetOrdinal("Alumnos"))
                });
            }

            return result;
        }

        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(Curso curso)
        {
            await using var context = CreateContext();
            await context.Cursos.AddAsync(curso);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = CreateContext();
            var curso = await context.Cursos.FindAsync(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Curso?> Get(int id)
        {
            await using var context = CreateContext();
            return await context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(c => c.IdCurso == id);
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            await using var context = CreateContext();
            return await context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .ToListAsync();
        }

        public async Task<bool> Update(Curso curso)
        {
            await using var context = CreateContext();
            var existingCurso = await context.Cursos.FindAsync(curso.IdCurso);
            if (existingCurso != null)
            {
                existingCurso.SetMateriaId(curso.IdMateria);
                existingCurso.SetComisionId(curso.IdComision);
                existingCurso.AnioCalendario = curso.AnioCalendario;
                existingCurso.Descripcion = curso.Descripcion;
                existingCurso.Cupo = curso.Cupo;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> BajarCupo(Curso curso)
        {
            await using var context = CreateContext();
            var existingCurso = await context.Cursos.FindAsync(curso.IdCurso);
            if (existingCurso != null)
            {
                existingCurso.SetMateriaId(curso.IdMateria);
                existingCurso.SetComisionId(curso.IdComision);
                existingCurso.AnioCalendario = curso.AnioCalendario;
                existingCurso.Descripcion = curso.Descripcion;
                existingCurso.Cupo = curso.Cupo;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Curso>> GetByCriteria(CursoCriteria criteria)
        {
            const string sql = @"
                SELECT c.IdCurso, c.IdMateria, c.IdComision, c.Descripcion, c.AnioCalendario, c.Cupo, 
                       com.AnioEspecialidad, com.Descripcion, com.IdPlan,
                       m.Descripcion, m.HsSemanales, m.HsTotales, m.IdPlan
                FROM Cursos c
                INNER JOIN Materias m ON c.IdMateria = m.IdMateria
                INNER JOIN Comisiones com ON c.IdComision = com.IdComision
                WHERE c.AnioCalendario LIKE @SearchTerm
                   OR c.Cupo LIKE @SearchTerm
                ORDER BY c.AnioCalendario, c.Cupo";

            var cursos = new List<Curso>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var curso = new Curso(
                    reader.GetInt32(0),    // IdCurso
                    reader.GetInt32(1),   // IdMateria
                    reader.GetInt32(2),   // IdComision
                    reader.GetString(3),   // Descripcion
                    reader.GetInt32(4),   // AnioCalendario
                    reader.GetInt32(5)    // Cupo
                );

                // Crear y asignar la comision
                var comision = new Comision(
                    reader.GetInt32(2), // idComision
                    reader.GetInt32(6), // anioEspecialidad
                    reader.GetString(7) // Descripcion
                    );
                comision.SetPlanId(reader.GetInt32(8));

                curso.SetComision(comision);

                // Crear y asignar la materia
                var materia = new Materia(
                    reader.GetInt32(1), // idMateria
                    reader.GetString(9), // descripcion
                    reader.GetInt32(10), // hsSemanales
                    reader.GetInt32(11) // hsTotales
                    );
                materia.SetPlanId(reader.GetInt32(12));
                curso.SetMateria(materia);

                cursos.Add(curso);
            }

            return cursos;
        }
    }
}
