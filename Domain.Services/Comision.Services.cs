using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class ComisionService
    {
        public ComisionDTO Add(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            Comision comision = new Comision(0, dto.AnioEspecialidad, dto.Descripcion);
            comision.SetPlanId(dto.IdPlan);

            comisionRepository.Add(comision);

            dto.IdComision = comision.IdComision;

            return dto;
        }

        public bool Delete(int id)
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.Delete(id);
        }

        public ComisionDTO Get(int id)
        {
            var comisionRepository = new ComisionRepository();
            Comision? comision = comisionRepository.Get(id);

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

        public IEnumerable<ComisionDTO> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            var comisiones = comisionRepository.GetAll();

            return comisiones.Select(comision => new ComisionDTO
            {
                IdComision = comision.IdComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion,
                IdPlan = comision.IdPlan,
            }).ToList();
        }

        public bool Update(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();

            Comision comision = new Comision(dto.IdComision, dto.AnioEspecialidad, dto.Descripcion);
            comision.SetPlanId(dto.IdPlan);
            return comisionRepository.Update(comision);
        }

        public IEnumerable<ComisionDTO> GetByCriteria(ComisionCriteriaDTO criteriaDTO)
        {
            var comisionRepository = new ComisionRepository();

            // Mapear DTO a Domain Model
            var criteria = new ComisionCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var comisiones = comisionRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
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
