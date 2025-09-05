using Domain.Model;

namespace Data
{
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materias.ToList();
        }
    }
}