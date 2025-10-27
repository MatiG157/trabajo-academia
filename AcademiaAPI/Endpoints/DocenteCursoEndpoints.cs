using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace DocenteCursoAPI.Endpoints
{
    public static class DocenteCursoEndpoints
    {
        public static void MapDocenteCursoEndpoints(this WebApplication app)
        {
            app.MapPost("/docentesCursos", async (DocenteCursoDTO dto) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();

                    DocenteCursoDTO docenteCursoDTO = await docenteCursoService.Add(dto);

                    return Results.Created(
                        $"/docentesCursos/{docenteCursoDTO.IdDocente}/{docenteCursoDTO.IdCurso}",
                        docenteCursoDTO
                    );

                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddDocenteCurso")
            .Produces<DocenteCursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapGet("/docentesCursos/criteria", async (int idDocente) =>
            {
                try
                {
                    DocenteCursoService docenteCursoService = new DocenteCursoService();
                    var criteria = new DocenteCursoCriteriaDTO { IdDocente = idDocente };
                    var docentesCursos = await docenteCursoService.GetByCriteria(criteria);
                    return Results.Ok(docentesCursos);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetDocenteCursoByCriteria")
            .WithOpenApi();


            //    app.MapPut("/docentesCursos/{id}", async (DocenteCursoDTO dto) =>
            //    {
            //        try
            //        {
            //            DocenteCursoService docenteCursoService = new DocenteCursoService();

            //            var found = await docenteCursoService.Update(dto);

            //            if (!found)
            //            {
            //                return Results.NotFound();
            //            }

            //            return Results.NoContent();
            //        }
            //        catch (ArgumentException ex)
            //        {
            //            return Results.BadRequest(new { error = ex.Message });
            //        }
            //    })
            //    .WithName("UpdateDocenteCurso")
            //    .Produces(StatusCodes.Status404NotFound)
            //    .Produces(StatusCodes.Status400BadRequest)
            //    .WithOpenApi();
        }
    }
}
