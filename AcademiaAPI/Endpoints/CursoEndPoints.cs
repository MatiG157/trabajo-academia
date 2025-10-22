using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;



namespace AcademiaAPI.Endpoints;
public static class CursoEndpoints
{
    public static void MapCursoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/cursos/{id}", (int id) =>
        {
            CursoService cursoService = new CursoService();

            CursoDTO dto = cursoService.Get(id);

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


        app.MapGet("/cursos", () =>
        {
            CursoService cursoService = new CursoService();

            var dtos = cursoService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllCursos")
        .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/cursos", (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                CursoDTO cursoDTO = cursoService.Add(dto);

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


        app.MapPut("/cursos/{id}", (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                var found = cursoService.Update(dto);

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


        app.MapPut("/cursos/bajarCupo/{id}", (CursoDTO dto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();

                var found = cursoService.BajarCupo(dto);

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


        app.MapDelete("/cursos/{id}", (int id) =>
        {
            CursoService cursoService = new CursoService();

            var deleted = cursoService.Delete(id);

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

        app.MapGet("/cursos/criteria", (string texto) =>
        {
            try
            {
                CursoService cursoService = new CursoService();
                var criteria = new CursoCriteriaDTO { Texto = texto };
                var cursos = cursoService.GetByCriteria(criteria);
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