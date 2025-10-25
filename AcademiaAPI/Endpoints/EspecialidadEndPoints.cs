using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace EspecialidadAPI.Endpoints
{
    public static class EspecialidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app)
        {
            app.MapGet("/especialidades/{id}", async (int id) =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                EspecialidadDTO dto = await especialidadService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            app.MapGet("/especialidades", async () =>
            {
                EspecialidadService especialidadService = new EspecialidadService();

                var dtos = await especialidadService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllEspecialidad")
            .Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            app.MapPost("/especialidades", async (EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    EspecialidadDTO especialidadDTO = await especialidadService.Add(dto);

                    return Results.Created($"/especialidades/{especialidadDTO.IdEspecialidad}", especialidadDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEspecialidad")
            .Produces<EspecialidadDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapPut("/especialidades/{id}", async (EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    var found = await especialidadService.Update(dto);

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
            .WithName("UpdateEspecialidad")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/especialidades/{id}", async (int id) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();
                    var deleted = await especialidadService.Delete(id);

                    if (!deleted)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeleteEspecialidad")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


            app.MapGet("/especialidades/criteria", async (string texto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();
                    var criteria = new EspecialidadCriteriaDTO { Texto = texto };
                    var especialidades = await especialidadService.GetByCriteria(criteria);
                    return Results.Ok(especialidades);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetEspecialidadByCriteria")
            .WithOpenApi();
        }
    }
}
