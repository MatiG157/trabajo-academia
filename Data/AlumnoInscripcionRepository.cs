
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


namespace Data
{
    public class AlumnoInscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            context.AlumnosInscripciones.Add(alumnoInscripcion);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var alumnoInscripcion = context.AlumnosInscripciones.Find(id);
            if (alumnoInscripcion != null)
            {
                context.AlumnosInscripciones.Remove(alumnoInscripcion);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public AlumnoInscripcion? Get(int id, int idCurso)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(c => c.Alumno)
                .Include(c => c.Curso)
                .FirstOrDefault(c => c.IdInscripcion == id && c.IdCurso == idCurso);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(c => c.Alumno)
                .Include(c => c.Curso)
                .ToList();
        }

        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            var existingAlumnoInscripcion = context.AlumnosInscripciones.Find(alumnoInscripcion.IdInscripcion);
            if (existingAlumnoInscripcion != null)
            {
                existingAlumnoInscripcion.Nota = alumnoInscripcion.Nota;
                existingAlumnoInscripcion.Condicion = alumnoInscripcion.Condicion;

                context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}