    using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class AlumnoInscripcionService
    {
        public async Task<AlumnoInscripcionDTO>  Add(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion(0, dto.Condicion, dto.Nota);
            alumnoInscripcion.SetCursoId(dto.IdCurso);
            alumnoInscripcion.SetAlumnoId(dto.IdAlumno);

            await alumnoInscripcionRepository.Add(alumnoInscripcion);

            dto.IdInscripcion = alumnoInscripcion.IdInscripcion;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            return await alumnoInscripcionRepository.Delete(id);
        }

        public async  Task<AlumnoInscripcionDTO> Get(int id, int idCurso)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            AlumnoInscripcion? alumnoInscripcion = await alumnoInscripcionRepository.Get(id, idCurso);

            if (alumnoInscripcion == null)
                return null;

            return new AlumnoInscripcionDTO
            {
                IdInscripcion = alumnoInscripcion.IdInscripcion,
                Condicion = alumnoInscripcion.Condicion,
                Nota = alumnoInscripcion.Nota,
                IdCurso = alumnoInscripcion.IdCurso,
                IdAlumno = alumnoInscripcion.IdAlumno,
            };
        }

        public async  Task<IEnumerable<AlumnoInscripcionDTO>> GetAll()
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var alumnosInscripciones = await alumnoInscripcionRepository.GetAll();

            return alumnosInscripciones.Select(alumnoInscripcion => new AlumnoInscripcionDTO
            {
                IdInscripcion = alumnoInscripcion.IdInscripcion,
                Condicion = alumnoInscripcion.Condicion,
                Nota = alumnoInscripcion.Nota,
                IdCurso = alumnoInscripcion.IdCurso,
                IdAlumno = alumnoInscripcion.IdAlumno,
            }).ToList();
        }

        public async Task<bool> Update(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            if (dto.Nota == null || dto.Nota < 0 || dto.Nota > 10) { 
                throw new ArgumentException("La nota debe estar entre 0 y 10.");
            }

            string condicion = "Cursando";

            if(dto.Nota >= 6 && dto.Nota <= 10)
            {
                condicion = "Aprobado";
            }
            else if (dto.Nota >= 0 && dto.Nota < 6)
            {
                condicion = "Desaprobado";
            }


            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion(dto.IdInscripcion, condicion, dto.Nota);
            alumnoInscripcion.SetCursoId(dto.IdCurso);
            alumnoInscripcion.SetAlumnoId(dto.IdAlumno);
            return await alumnoInscripcionRepository.Update(alumnoInscripcion);
        }

    }
}
