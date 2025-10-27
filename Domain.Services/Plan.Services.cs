using Domain.Model;
using Data;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PlanService
    {
        public async Task<PlanDTO> Add(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            Plan plan = new Plan(0, dto.Descripcion);
            plan.SetEspecialidadId(dto.IdEspecialidad);

            await planRepository.Add(plan);

            dto.IdPlan = plan.IdPlan;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var planRepository = new PlanRepository();
            return await planRepository.Delete(id);
        }

        public async Task<PlanDTO> Get(int id)
        {
            var planRepository = new PlanRepository();
            Plan? plan = await planRepository.Get(id);

            if (plan == null)
                return null;

            return new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
            };
        }

        public async Task<IEnumerable<PlanDTO>> GetAll()
        {
            var planRepository = new PlanRepository();
            var planes = await planRepository.GetAll();

            return planes.Select(plan => new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
            }).ToList();
        }

        public async Task<bool> Update(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            Plan plan = new Plan(dto.IdPlan, dto.Descripcion);
            plan.SetEspecialidadId(dto.IdEspecialidad);
            return await planRepository.Update(plan);
        }

        public async Task<IEnumerable<PlanDTO>> GetByCriteria(PlanCriteriaDTO criteriaDTO)
        {
            var planRepository = new PlanRepository();

            var criteria = new PlanCriteria(criteriaDTO.Texto);

            var planes = await planRepository.GetByCriteria(criteria);

            return planes.Select(p => new PlanDTO
            {
                IdPlan = p.IdPlan,
                Descripcion = p.Descripcion,
                IdEspecialidad = p.IdEspecialidad,
            });
        }
    }
}
