using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class PersonaService
    {
        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            // Validar que el email no esté duplicado
            if (personaRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe una persona con el Email '{dto.Email}'.");
            }

            Persona persona = new Persona(0, dto.Apellido, dto.Direccion, dto.Email, dto.FechaNacimiento, dto.Apellido, dto.IdPlan, dto.Legajo, dto.Telefono, dto.TipoPersona);

            personaRepository.Add(persona);

            dto.IdPersona = persona.IdPersona;

            return dto;
        }

        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.Delete(id);
        }




        public PersonaDTO Get(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.Get(id);

            if (persona == null)
                return null;

            return new PersonaDTO
            {

                IdPersona = persona.IdPersona,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                IdPlan = persona.IdPlan,
                Legajo = persona.Legajo,
                Telefono = persona.Telefono,
                TipoPersona = persona.TipoPersona,
            };
        }

        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var persona = personaRepository.GetAll();

            return personas.Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                IdPlan = persona.IdPlan,
                Legajo = persona.Legajo,
                Telefono = persona.Telefono,
                TipoPersona = persona.TipoPersona,
            }).ToList();
        }

        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();

            // Validar que el email no esté duplicado (excluyendo el usuario actual)
            if (personaRepository.EmailExists(dto.Email, dto.IdPersona)
            {
                throw new ArgumentException($"Ya existe otro persona con el Email '{dto.Email}'.");
            }

            Persona persona = new Persona(dto.Apellido, dto.Direccion, dto.Email, dto.FechaNacimiento, dto.Apellido, dto.IdPlan, dto.Legajo, dto.Telefono, dto.TipoPersona);

            return personaRepository.Update(persona);
        }



        public IEnumerable<PersonaDTO> GetByCriteria(PersonaCriteriaDTO criteriaDTO)
        {
            var personaRepository = new PersonaRepository();

            // Mapear DTO a Domain Model
            var criteria = new PersonaCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var personas = personaRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return personas.Select(u => new PersonaDTO
            {
                IdPersona = u.IdPersona;
                Apellido = u.Apellido;
                Direccion = u.Direccion;
                Email = u.Email;
                FechaNacimiento = u.FechaNacimiento;
                IdPlan = u.IdPlan;
                Legajo = u.Legajo;
                Telefono = u.Telefono;
                TipoPersona = u.TipoPersona;
            });
        }
    }
}
