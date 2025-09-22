using Data;
using Domain.Model;
using DTOs;


namespace Domain.Services
{
    public class MateriaService
    {
        public MateriaDTO Add(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            Materia materia = new Materia(0, dto.Descripcion, dto.HsSemanales, dto.HsTotales);
            materia.SetPlanId(dto.IdPlan);

            materiaRepository.Add(materia);

            dto.IdMateria = materia.IdMateria;

            return dto;
        }

        public bool Delete(int id)
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.Delete(id);
        }

        public MateriaDTO Get(int id)
        {
            var materiaRepository = new MateriaRepository();
            Materia? materia = materiaRepository.Get(id);

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

        public IEnumerable<MateriaDTO> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            var materias = materiaRepository.GetAll();

            return materias.Select(materia => new MateriaDTO
            {
                IdMateria = materia.IdMateria,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                IdPlan = materia.IdPlan
            }).ToList();
        }

        public bool Update(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            Materia materia = new Materia(dto.IdMateria, dto.Descripcion, dto.HsSemanales, dto.HsTotales);
            materia.SetPlanId(dto.IdPlan);

            return materiaRepository.Update(materia);
        }

        public IEnumerable<MateriaDTO> GetByCriteria(MateriaCriteriaDTO criteriaDTO)
        {
            var materiaRepository = new MateriaRepository();

            // Mapear DTO a Domain Model
            var criteria = new MateriaCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var materias = materiaRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
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
