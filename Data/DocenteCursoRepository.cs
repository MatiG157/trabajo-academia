using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class DocenteCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public async Task Add(DocenteCurso docenteCurso)
        {
            await using var context = CreateContext();
            await context.DocentesCursos.AddAsync(docenteCurso);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DocenteCurso?>?> FindByCriteria(DocenteCursoCriteria criteria)
        {
            await using var context = CreateContext();

            return await context.DocentesCursos
                .Where(u => u.IdDocente == criteria.IdDocente)
                .ToListAsync();
        }

        public async Task<bool> Update(DocenteCurso docenteCurso)
        {
            await using var context = CreateContext();
            var existingdocenteCurso = await context.DocentesCursos.FindAsync(docenteCurso.IdAsignacion);
            if (existingdocenteCurso != null)
            {
                existingdocenteCurso.SetCursoId(docenteCurso.IdCurso);
                existingdocenteCurso.SetDocenteId(docenteCurso.IdDocente);
                existingdocenteCurso.Cargo = docenteCurso.Cargo;

                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
