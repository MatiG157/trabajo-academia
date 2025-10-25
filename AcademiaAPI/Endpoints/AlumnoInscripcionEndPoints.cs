using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;



namespace AcademiaAPI.Endpoints;
public static class AlumnoInscripcionEndpoints
{
    public static void MapAlumnoInscripcionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/alumnosInscripciones/{id}/{idCurso}", async (int id, int idCurso) =>
        {
            AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

            AlumnoInscripcionDTO dto = await alumnoInscripcionService.Get(id,idCurso);

            if (dto == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(dto);
        })
        .WithName("GetAlumnoInscripcion")
        .Produces<AlumnoInscripcionDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        app.MapGet("/alumnosInscripciones", async () =>
        {
            AlumnoInscripcionService alumnoInscripcioService = new AlumnoInscripcionService();

            var dtos = await alumnoInscripcioService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllAlumnosInscripciones")
        .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/alumnosInscripciones", async (AlumnoInscripcionDTO dto) =>
        {
            try
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

                AlumnoInscripcionDTO alumnoInscripcionDTO = await alumnoInscripcionService.Add(dto);

                return Results.Created($"/alumnosInscripciones/{alumnoInscripcionDTO.IdInscripcion}", alumnoInscripcionDTO);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("AddAlumnoInscripcion")
        .Produces<AlumnoInscripcionDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        app.MapPut("/alumnosInscripciones/{idInscripcion}/{idCurso}", async (int idInscripcion, int idCurso, AlumnoInscripcionDTO dto) =>
        {
            try
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

                dto.IdInscripcion = idInscripcion;
                dto.IdCurso = idCurso;

                var found = await alumnoInscripcionService.Update(dto);

                if (!found)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
       .WithName("UpdateAlumnosInscripciones")
       .Produces(StatusCodes.Status404NotFound)
       .Produces(StatusCodes.Status400BadRequest)
       .WithOpenApi();




        app.MapDelete("/alumnosInscripciones/{id}", async (int id) =>
        {
            AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

            var deleted = await alumnoInscripcionService.Delete(id);

            if (!deleted)
            {
                return Results.NotFound();
            }

            return Results.NoContent();

        })
        .WithName("DeleteAlumnoInscripcion")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

    }
}