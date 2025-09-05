using Data;
using DTOs;

namespace Application.Services
{
    public class ComisionService
    {
        public IEnumerable<ComisionDTO> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.GetAll().Select(comision => new ComisionDTO
            {
                IdComision = comision.IdComision,
                AnioEspecialidad = comision.AnioEspecialidad,
                Descripcion = comision.Descripcion,
                IdPlan = comision.IdPlan
            }).ToList();
        }
    }
}