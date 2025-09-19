using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class CursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Curso curso)
        {
            using var context = CreateContext();
            context.Cursos.Add(curso);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Curso? Get(int id)
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .FirstOrDefault(c => c.IdCurso == id);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Comision)
                .Include(c => c.Materia)
                .ToList();
        }

        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.IdCurso);
            if (existingCurso != null)
            {
                existingCurso.SetMateriaId(curso.IdMateria);
                existingCurso.SetComisionId(curso.IdComision);
                existingCurso.AnioCalendario = curso.AnioCalendario;
                existingCurso.Cupo = curso.Cupo;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        /*public bool EmailExists(string email, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Clientes.Where(c => c.Email.ToLower() == email.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }*/

        public IEnumerable<Curso> GetByCriteria(CursoCriteria criteria)
        {
            const string sql = @"
                SELECT c.IdCurso, c.IdMateria, c.IdComision, c.AnioCalendario, c.Cupo, 
                       com.anioEspecialidad, com.Descripcion, com.idPlan,
                       m.descripcion, m.hsSemanales, m.hsTotales, m.idPlan
                FROM Cursos c
                INNER JOIN Materias m ON c.IdMateria = m.IdMateria
                INNER JOIN Comisiones com ON c.IdComision = com.IdComision
                WHERE c.AnioCalendario LIKE @SearchTerm
                   OR c.Cupo LIKE @SearchTerm
                ORDER BY c.AnioCalendario, c.Cupo";


            var cursos = new List<Curso>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var curso = new Curso(
                    reader.GetInt32(0),    // IdCurso
                    reader.GetInt32(1),   // IdMateria
                    reader.GetInt32(2),   // IdComision
                    reader.GetInt32(3),   // AnioCalendario
                    reader.GetInt32(4)    // Cupo
                );

                // Crear y asignar la comision
                var comision = new Comision(
                    reader.GetInt32(2), // idComision
                    reader.GetInt32(5), // anioEspecialidad
                    reader.GetString(6), // descripcion
                    reader.GetInt32(7)); // idPlan
                curso.SetComision(comision);

                // Crear y asignar la materia
                var materia = new Materia(
                    reader.GetInt32(1), // idMateria
                    reader.GetString(8), // descripcion
                    reader.GetInt32(9), // hsSemanales
                    reader.GetInt32(10), // hsTotales
                    reader.GetInt32(11)); // idPlan
                curso.SetMateria(materia);

                cursos.Add(curso);
            }

            return cursos;
        }

    }
}