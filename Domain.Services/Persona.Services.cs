using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class PersonaService
    {
        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.GetAll().Select(persona => new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Apellido = persona.Apellido,
                Direccion = persona.Direccion,
                Email = persona.Email,
                FechaNacimiento = persona.FechaNacimiento,
                IdPlan = persona.IdPlan,
                Legajo = persona.Legajo,
                Telefono = persona.Telefono,
                TipoPersona = persona.TipoPersona
            }).ToList();
        }
    }
}
