using Domain.Model;
using Data;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EspecialidadService
    {
        public async Task<EspecialidadDTO> Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(0, dto.Descripcion);

            await especialidadRepository.Add(especialidad);

            dto.IdEspecialidad = especialidad.IdEspecialidad;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            return await especialidadRepository.Delete(id);
        }

        public async Task<EspecialidadDTO> Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = await especialidadRepository.Get(id);

            if (especialidad == null)
                return null;

            return new EspecialidadDTO
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Descripcion = especialidad.Descripcion,
            };
        }

        public async Task<IEnumerable<EspecialidadDTO>> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            var especialidades = await especialidadRepository.GetAll();

            return especialidades.Select(especialidad => new EspecialidadDTO
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Descripcion = especialidad.Descripcion,
            }).ToList();
        }

        public async Task<bool> Update(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();

            Especialidad especialidad = new Especialidad(dto.IdEspecialidad, dto.Descripcion);
            return await especialidadRepository.Update(especialidad);
        }

        public async Task<IEnumerable<EspecialidadDTO>> GetByCriteria(EspecialidadCriteriaDTO criteriaDTO)
        {
            var especialidadRepository = new EspecialidadRepository();

            var criteria = new EspecialidadCriteria(criteriaDTO.Texto);

            var especialidades = await especialidadRepository.GetByCriteria(criteria);

            return especialidades.Select(e => new EspecialidadDTO
            {
                IdEspecialidad = e.IdEspecialidad,
                Descripcion = e.Descripcion,
            });
        }
    }
}
