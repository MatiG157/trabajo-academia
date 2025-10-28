using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class DocenteCursoService
    {
        public async Task<DocenteCursoDTO> Add(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            DocenteCurso docenteCurso = new DocenteCurso(dto.Cargo, dto.IdCurso, dto.IdDocente);

            await docenteCursoRepository.Add(docenteCurso);

            dto.IdCurso = docenteCurso.IdCurso;
            dto.IdDocente = docenteCurso.IdDocente;

            return dto;
        }

        public async Task<IEnumerable<DocenteCursoDTO>> GetByCriteria(DocenteCursoCriteriaDTO criteriaDto)
        {
            var criteria = new DocenteCursoCriteria
            {
                IdDocente = criteriaDto.IdDocente
            };

            var docenteCursoRepository = new DocenteCursoRepository();

            var entidades = await docenteCursoRepository.FindByCriteria(criteria);

            var dtos = entidades.Select(dc => new DocenteCursoDTO
            {
                IdCurso = dc.IdCurso,
                IdDocente = dc.IdDocente,
                Cargo = dc.Cargo
            }).ToList();

            return dtos;
        }
        /*
        public async Task<bool> Update(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            DocenteCurso docenteCurso = new DocenteCurso(dto.Cargo, dto.IdDocente, dto.IdAsignacion); //Que va aca?
            docenteCurso.SetCursoId(dto.IdCurso);
            docenteCurso.SetDocenteId(dto.IdDocente);
            return await docenteCursoRepository.Update(docenteCurso);
        }*/
        public async Task<bool> UpdateByCursoDocente(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            // Buscar la asignación existente por IdCurso e IdDocente
            var criterios = new DocenteCursoCriteria { IdCurso = dto.IdCurso, IdDocente = dto.IdDocente };
            var existentes = await docenteCursoRepository.FindByCriteria(criterios);
            var existente = existentes?.FirstOrDefault();

            if (existente == null)
                return false;

            existente.Cargo = dto.Cargo;
            // Si quieres permitir cambiar el docente o curso, puedes actualizar los IDs aquí

            return await docenteCursoRepository.Update(existente);
        }

    }
}
