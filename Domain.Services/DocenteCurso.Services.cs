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

        public async Task<IEnumerable<DocenteCurso?>> GetByCriteria(DocenteCursoCriteriaDTO criteriaDto)
        {
            var criteria = new DocenteCursoCriteria
            {
                IdDocente = criteriaDto.IdDocente
            };

            var docenteCursoRepository = new DocenteCursoRepository();

            return await docenteCursoRepository.FindByCriteria(criteria);
        }

    }
   
}
