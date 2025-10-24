using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class DocenteCursoService
    {
        public DocenteCursoDTO Add(DocenteCursoDTO dto)
        {
            var docenteCursoRepository = new DocenteCursoRepository();

            DocenteCurso docenteCurso = new DocenteCurso(dto.Cargo, dto.IdCurso, dto.IdDocente);

            docenteCursoRepository.Add(docenteCurso);

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

    }
   
}
