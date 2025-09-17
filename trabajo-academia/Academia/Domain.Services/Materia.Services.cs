using Data;
using DTOs;


namespace Domain.Services
{
    public class MateriaService
    {
        public IEnumerable<MateriaDTO> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.GetAll().Select(materia => new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                IdPlan = materia.IdPlan
            }).ToList();
        }
    }
}
