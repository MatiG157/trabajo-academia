using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class CursoService
    {
        public CursoDTO Add(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            Curso curso = new Curso(0, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, dto.Cupo);

            cursoRepository.Add(curso);

            dto.IdCurso = curso.IdCurso;

            return dto;
        }

        public bool Delete(int id)
        {
            var cursoRepository = new CursoRepository();
            return cursoRepository.Delete(id);
        }

        public CursoDTO Get(int id)
        {
            var cursoRepository = new CursoRepository();
            Curso? curso = cursoRepository.Get(id);

            if (curso == null)
                return null;

            return new CursoDTO
            {
                IdCurso = curso.IdCurso,
                IdMateria = curso.IdMateria,
                IdComision = curso.IdComision,
                AnioCalendario = curso.AnioCalendario,
                Descripcion = curso.Descripcion,
                Cupo = curso.Cupo
            };
        }

        public IEnumerable<CursoDTO> GetAll()
        {
            CursoRepository cursoRepository = new CursoRepository();
            var cursos = cursoRepository.GetAll();

            return cursos.Select(curso => new CursoDTO
            {
                IdCurso = curso.IdCurso,
                IdMateria = curso.IdMateria,
                IdComision = curso.IdComision,
                Descripcion = curso.Descripcion,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo
            }).ToList();
        }

        public bool Update(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            Curso curso = new Curso(dto.IdCurso, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, dto.Cupo);
            return cursoRepository.Update(curso);
        }


        public bool BajarCupo(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            int cupo = dto.Cupo - 1;
            Curso curso = new Curso(dto.IdCurso, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, cupo);
            return cursoRepository.BajarCupo(curso);
        }

        public IEnumerable<CursoDTO> GetByCriteria(CursoCriteriaDTO criteriaDTO)
        {
            var cursoRepository = new CursoRepository();

            // Mapear DTO a Domain Model
            var criteria = new CursoCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var cursos = cursoRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return cursos.Select(c => new CursoDTO
            {
                IdCurso = c.IdCurso,
                IdMateria = c.IdMateria,
                IdComision = c.IdComision,
                Descripcion = c.Descripcion,
                AnioCalendario = c.AnioCalendario,
                Cupo = c.Cupo
            });
        }

    }
}
