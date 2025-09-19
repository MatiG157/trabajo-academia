using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas
                .ToList();
        }
    }
}
