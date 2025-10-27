using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class PersonaService
    {
        public async Task<PersonaDTO> Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            Persona persona = new Persona(0, dto.Direccion, dto.FechaNacimiento, dto.Legajo, dto.Telefono, dto.TipoPersona);
            persona.SetPlanId(dto.IdPlan);

            await personaRepository.Add(persona);

            dto.IdPersona = persona.IdPersona;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return await personaRepository.Delete(id);
        }

        public async Task<PersonaDTO?> Get(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = await personaRepository.Get(id);

            if (persona == null)
                return null;

            return new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento,
                IdPlan = persona.IdPlan,
                Legajo = persona.Legajo,
                Telefono = persona.Telefono,
                TipoPersona = persona.TipoPersona,
            };
        }

        public async Task<IEnumerable<PersonaDTO>> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var personas = await personaRepository.GetAll();

            return personas.Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento,
                IdPlan = persona.IdPlan,
                Legajo = persona.Legajo,
                Telefono = persona.Telefono,
                TipoPersona = persona.TipoPersona,
            }).ToList();
        }

        public async Task<bool> Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            Persona persona = new Persona(dto.IdPersona, dto.Direccion, dto.FechaNacimiento, dto.Legajo, dto.Telefono, dto.TipoPersona);
            persona.SetPlanId(dto.IdPlan);
            return await personaRepository.Update(persona);
        }

        public async Task<IEnumerable<PersonaDTO>> GetByCriteria(PersonaCriteriaDTO criteriaDTO)
        {
            var personaRepository = new PersonaRepository();

            // Mapear DTO a Domain Model
            var criteria = new PersonaCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var personas = await personaRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return personas.Select(u => new PersonaDTO
            {
                IdPersona = u.IdPersona,
                Direccion = u.Direccion,
                FechaNacimiento = u.FechaNacimiento,
                IdPlan = u.IdPlan,
                Legajo = u.Legajo,
                Telefono = u.Telefono,
                TipoPersona = u.TipoPersona
            });
        }
    }
}
