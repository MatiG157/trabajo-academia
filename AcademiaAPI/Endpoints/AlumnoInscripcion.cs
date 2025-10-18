using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;



namespace AcademiaAPI.Endpoints;
public static class AlumnoInscripcionEndpoints
{
    public static void MapAlumnoInscripcionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/alumnosInscripciones/{id}", (int id) =>
        {
            AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

            AlumnoInscripcionDTO dto = alumnoInscripcionService.Get(id);

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


        app.MapGet("/alumnosInscripciones", () =>
        {
            AlumnoInscripcionService alumnoInscripcioService = new AlumnoInscripcionService();

            var dtos = alumnoInscripcioService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllAlumnosInscripciones")
        .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/alumnosinscripciones", (AlumnoInscripcionDTO dto) =>
        {
            try
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

                AlumnoInscripcionDTO alumnoInscripcionDTO = alumnoInscripcionService.Add(dto);

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

        app.MapPut("/alumnosInscripciones/{id}", (AlumnoInscripcionDTO dto) =>
        {
            try
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

                var found = alumnoInscripcionService.Update(dto);

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



        app.MapDelete("/alumnosInscripciones/{id}", (int id) =>
        {
            AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();

            var deleted = alumnoInscripcionService.Delete(id);

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