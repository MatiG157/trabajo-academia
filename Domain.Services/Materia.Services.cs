using Data;
using Domain.Model;
using DTOs;

namespace Domain.Services
{
    public class MateriaService
    {
        public async Task<MateriaDTO> Add(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            Materia materia = new Materia(0, dto.Descripcion, dto.HsSemanales, dto.HsTotales);
            materia.SetPlanId(dto.IdPlan);

            await materiaRepository.Add(materia);

            dto.IdMateria = materia.IdMateria;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var materiaRepository = new MateriaRepository();
            return await materiaRepository.Delete(id);
        }

        public async Task<MateriaDTO?> Get(int id)
        {
            var materiaRepository = new MateriaRepository();
            Materia? materia = await materiaRepository.Get(id);

            if (materia == null)
                return null;

            return new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                IdPlan = materia.IdPlan
            };
        }

        public async Task<IEnumerable<MateriaDTO>> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            var materias = await materiaRepository.GetAll();

            return materias.Select(materia => new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                IdPlan = materia.IdPlan
            }).ToList();
        }

        public async Task<bool> Update(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            Materia materia = new Materia(dto.IdMateria, dto.Descripcion, dto.HsSemanales, dto.HsTotales);
            materia.SetPlanId(dto.IdPlan);

            return await materiaRepository.Update(materia);
        }

        public async Task<IEnumerable<MateriaDTO>> GetByCriteria(MateriaCriteriaDTO criteriaDTO)
        {
            var materiaRepository = new MateriaRepository();

            var criteria = new MateriaCriteria(criteriaDTO.Texto);

            var materias = await materiaRepository.GetByCriteria(criteria);

            return materias.Select(m => new MateriaDTO
            {
                IdMateria = m.IdMateria,
                Descripcion = m.Descripcion,
                HsSemanales = m.HsSemanales,
                HsTotales = m.HsTotales,
                IdPlan = m.IdPlan
            });
        }
    }
}

