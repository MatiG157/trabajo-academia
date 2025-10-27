using Domain.Model;
using Data;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ComisionService
    {
        public async Task<ComisionDTO> Add(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            Comision comision = new Comision(0, dto.AnioEspecialidad, dto.Descripcion);
            comision.SetPlanId(dto.IdPlan);

            await comisionRepository.Add(comision);

            dto.IdComision = comision.IdComision;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var comisionRepository = new ComisionRepository();
            return await comisionRepository.Delete(id);
        }

        public async Task<ComisionDTO> Get(int id)
        {
            var comisionRepository = new ComisionRepository();
            Comision? comision = await comisionRepository.Get(id);

            if (comision == null)
                return null;

            return new ComisionDTO
            {
                IdComision = comision.IdComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion,
                IdPlan = comision.IdPlan,
            };
        }

        public async Task<IEnumerable<ComisionDTO>> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            var comisiones = await comisionRepository.GetAll();

            return comisiones.Select(comision => new ComisionDTO
            {
                IdComision = comision.IdComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion,
                IdPlan = comision.IdPlan,
            }).ToList();
        }

        public async Task<bool> Update(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            Comision comision = new Comision(dto.IdComision, dto.AnioEspecialidad, dto.Descripcion);
            comision.SetPlanId(dto.IdPlan);
            return await comisionRepository.Update(comision);
        }

        public async Task<IEnumerable<ComisionDTO>> GetByCriteria(ComisionCriteriaDTO criteriaDTO)
        {
            var comisionRepository = new ComisionRepository();

            var criteria = new ComisionCriteria(criteriaDTO.Texto);

            var comisiones = await comisionRepository.GetByCriteria(criteria);

            return comisiones.Select(c => new ComisionDTO
            {
                IdComision = c.IdComision,
                AnioEspecialidad = c.AnioEspecialidad,
                Descripcion = c.Descripcion,
                IdPlan = c.IdPlan,
            });
        }
    }
}
