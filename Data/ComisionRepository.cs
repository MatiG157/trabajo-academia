using Domain.Model;

namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Comisiones.ToList();
        }
    }
}