using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class EspecialidadService
    {
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(0, dto.Descripcion);

            especialidadRepository.Add(especialidad);

            dto.IdEspecialidad = especialidad.IdEspecialidad;

            return dto;
        }

        public bool Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.Delete(id);
        }

        public EspecialidadDTO Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = especialidadRepository.Get(id);

            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Descripcion = especialidad.Descripcion,
            };
        }

        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            var especialidades = especialidadRepository.GetAll();

            return especialidades.Select(especialidad => new EspecialidadDTO
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Descripcion = especialidad.Descripcion,
            }).ToList();
        }

        public bool Update(EspecialidadDTO dto)
        {
            var especilidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(dto.IdEspecialidad, dto.Descripcion);
            return especilidadRepository.Update(especialidad);
        }

        public IEnumerable<EspecialidadDTO> GetByCriteria(EspecialidadCriteriaDTO criteriaDTO)
        {
            var especialidadRepository = new EspecialidadRepository();

            // Mapear DTO a Domain Model
            var criteria = new EspecialidadCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var especialidades = especialidadRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return especialidades.Select(e => new EspecialidadDTO
            {
                IdEspecialidad = e.IdEspecialidad,
                Descripcion = e.Descripcion,
            });
        }

    }
}
