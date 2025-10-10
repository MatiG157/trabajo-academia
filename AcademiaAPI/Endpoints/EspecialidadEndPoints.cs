using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EspecialidadAPI.Endpoints
{
    public static class EspecilidadEndpoints
    {
        public static void MapEspecialidadEndpoints(this WebApplication app)
        {
            {
                app.MapGet("/especialidades/{id}", (int id) =>
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    EspecialidadDTO dto = especialidadService.Get(id);

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


                app.MapGet("/especialidades", () =>
                {
                    EspecialidadService especialidadService = new EspecialidadService();

                    var dtos = especialidadService.GetAll();

                    return Results.Ok(dtos);
                })
                .WithName("GetAllEspecialidad")
                .Produces<List<EspecialidadDTO>>(StatusCodes.Status200OK)
                .WithOpenApi();


                app.MapPost("/especialidad", (EspecialidadDTO dto) =>
                {
                    try
                    {
                        EspecialidadService especialidadService = new EspecialidadService();

                        EspecialidadDTO especialidadDTO = especialidadService.Add(dto);

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


                app.MapPut("/especialidades/{id}", (EspecialidadDTO dto) =>
                {
                    try
                    {
                        EspecialidadService especialidadService = new EspecialidadService();

                        var found = especialidadService.Update(dto);

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



                app.MapDelete("/especialidades/{id}", (int id) =>
                {
                    try
                    {
                        EspecialidadService especialidadService = new EspecialidadService();
                        var deleted = especialidadService.Delete(id);

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



                app.MapGet("/especialidades/criteria", (string texto) =>
                {
                    try
                    {
                        EspecialidadService especialidadService = new EspecialidadService();
                        var criteria = new EspecialidadCriteriaDTO { Texto = texto };
                        var especialidades = especialidadService.GetByCriteria(criteria);
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
}