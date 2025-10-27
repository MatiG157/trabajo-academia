using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class CursoService
    {
        public async Task<CursoDTO> Add(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            Curso curso = new Curso(0, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, dto.Cupo);

            await cursoRepository.Add(curso);

            dto.IdCurso = curso.IdCurso;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var cursoRepository = new CursoRepository();
            return await cursoRepository.Delete(id);
        }

        public async Task<CursoDTO?> Get(int id)
        {
            var cursoRepository = new CursoRepository();
            Curso? curso = await cursoRepository.Get(id);

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

        public async Task<IEnumerable<CursoDTO>> GetAll()
        {
            CursoRepository cursoRepository = new CursoRepository();
            var cursos = await cursoRepository.GetAll();

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

        public async Task<bool> Update(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            Curso curso = new Curso(dto.IdCurso, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, dto.Cupo);
            return await cursoRepository.Update(curso);
        }

        public async Task<bool> BajarCupo(CursoDTO dto)
        {
            var cursoRepository = new CursoRepository();

            int cupo = dto.Cupo - 1;
            Curso curso = new Curso(dto.IdCurso, dto.IdMateria, dto.IdComision, dto.Descripcion, dto.AnioCalendario, cupo);
            return await cursoRepository.BajarCupo(curso);
        }

        public async Task<IEnumerable<CursoDTO>> GetByCriteria(CursoCriteriaDTO criteriaDTO)
        {
            var cursoRepository = new CursoRepository();

            var criteria = new CursoCriteria(criteriaDTO.Texto);

            var cursos = await cursoRepository.GetByCriteria(criteria);

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

