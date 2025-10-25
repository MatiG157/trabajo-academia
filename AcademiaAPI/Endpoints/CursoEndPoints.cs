using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AcademiaAPI.Endpoints;
public static class CursoEndpoints
{
    public static void MapCursoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/cursos/{id}", async (int id) =>
        {
            CursoService cursoService = new CursoService();

            CursoDTO dto = await cursoService.Get(id);

            if (dto == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(dto);
        })
        .WithName("GetCurso")
        .Produces<CursoDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        app.MapGet("/cursos", async () =>
        {
            CursoService cursoService = new CursoService();

            var dtos = await cursoService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllCursos")
        .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();

        app.MapPost("/cursos", async (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                CursoDTO cursoDTO = await cursoService.Add(dto);

                return Results.Created($"/cursos/{cursoDTO.IdCurso}", cursoDTO);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("AddCurso")
        .Produces<CursoDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        app.MapPut("/cursos/{id}", async (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                var found = await cursoService.Update(dto);

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
        .WithName("UpdateCurso")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        app.MapPut("/cursos/bajarCupo/{id}", async (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                var found = await cursoService.BajarCupo(dto);

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
        .WithName("BajarCupoCurso")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        app.MapDelete("/cursos/{id}", async (int id) =>
        {
            CursoService cursoService = new CursoService();

            var deleted = await cursoService.Delete(id);

            if (!deleted)
            {
                return Results.NotFound();
            }

            return Results.NoContent();

        })
        .WithName("DeleteCurso")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        app.MapGet("/cursos/criteria", async (string texto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();
                var criteria = new CursoCriteriaDTO { Texto = texto };
                var cursos = await cursoService.GetByCriteria(criteria);
                return Results.Ok(cursos);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("GetCursosByCriteria")
        .WithOpenApi();
    }
}
