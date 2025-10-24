using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class DocenteCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        
        public async Task<IEnumerable<DocenteCurso?>?> FindByCriteria(DocenteCursoCriteria criteria)
        {
            using var context = CreateContext();

            return await context.DocentesCursos
                .Where(u => u.IdDocente == criteria.IdDocente)
                .ToListAsync();
        }
    }
}
