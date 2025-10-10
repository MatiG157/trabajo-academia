using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class PlanService
    {
        public PlanDTO Add(PlanDTO dto)
        {
            var planRepository = new PlanRepository();


            Plan plan = new Plan(0, dto.Descripcion);
            plan.SetEspecialidadId(dto.IdEspecialidad);

            planRepository.Add(plan);

            dto.IdPlan = plan.IdPlan;

            return dto;
        }

        public bool Delete(int id)
        {
            var planRepository = new PlanRepository();
            return planRepository.Delete(id);
        }




        public PlanDTO Get(int id)
        {
            var planRepository = new PlanRepository();
            Plan? plan = planRepository.Get(id);

            if (plan == null)
                return null;

            return new PlanDTO
            {

                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            var planRepository = new PlanRepository();
            var planes = planRepository.GetAll();

            return planes.Select(plan => new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad,
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            Plan plan = new Plan(0, dto.Descripcion);
            plan.SetEspecialidadId(dto.IdEspecialidad);
            return planRepository.Update(plan);
        }



        public IEnumerable<PlanDTO> GetByCriteria(PlanCriteriaDTO criteriaDTO)
        {
            var planRepository = new PlanRepository();

            // Mapear DTO a Domain Model
            var criteria = new PlanCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var planes = planRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return planes.Select(p => new PlanDTO
            {
                IdPlan = p.IdPlan,
                Descripcion = p.Descripcion,
                IdEspecialidad = p.IdEspecialidad,
              
            });
        }
    }
}
