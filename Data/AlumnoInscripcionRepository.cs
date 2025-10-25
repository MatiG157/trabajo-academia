using Data;
using Domain.Model;
using Microsoft.EntityFrameworkCore;


public class AlumnoInscripcionRepository
{
    private TPIContext CreateContext()
    {
        return new TPIContext();
    }

    public async Task Add(AlumnoInscripcion alumnoInscripcion)
    {
        await using var context = CreateContext();
        await context.AlumnosInscripciones.AddAsync(alumnoInscripcion);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        await using var context = CreateContext();
        var alumnoInscripcion = await context.AlumnosInscripciones.FindAsync(id);
        if (alumnoInscripcion != null)
        {
            context.AlumnosInscripciones.Remove(alumnoInscripcion);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<AlumnoInscripcion?> Get(int id, int idCurso)
    {
        await using var context = CreateContext();
        return await context.AlumnosInscripciones
            .Include(c => c.Alumno)
            .Include(c => c.Curso)
            .FirstOrDefaultAsync(c => c.IdInscripcion == id && c.IdCurso == idCurso);
    }

    public async Task<IEnumerable<AlumnoInscripcion>> GetAll()
    {
        await using var context = CreateContext();
        return await context.AlumnosInscripciones
            .Include(c => c.Alumno)
            .Include(c => c.Curso)
            .ToListAsync();
    }

    public async Task<bool> Update(AlumnoInscripcion alumnoInscripcion)
    {
        await using var context = CreateContext();
        var existingAlumnoInscripcion = await context.AlumnosInscripciones.FindAsync(alumnoInscripcion.IdInscripcion);
        if (existingAlumnoInscripcion != null)
        {
            existingAlumnoInscripcion.Nota = alumnoInscripcion.Nota;
            existingAlumnoInscripcion.Condicion = alumnoInscripcion.Condicion;

            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
