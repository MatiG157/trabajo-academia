using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MateriaAPI.Endpoints
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            {
                app.MapGet("/materias/{id}", (int id) =>
                {
                    MateriaService materiaService = new MateriaService();

                    MateriaDTO dto = materiaService.Get(id);

                    if (dto == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(dto);
                })
                .WithName("GetMateria")
                .Produces<MateriaDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();


                app.MapGet("/materias", () =>
                {
                    MateriaService materiaService = new MateriaService();

                    var dtos = materiaService.GetAll();

                    return Results.Ok(dtos);
                })
                .WithName("GetAllMaterias")
                .Produces<List<MateriaDTO>>(StatusCodes.Status200OK)
                .WithOpenApi();


                app.MapPost("/materias", (MateriaDTO dto) =>
                {
                    try
                    {
                        MateriaService materiaService = new MateriaService();

                        MateriaDTO materiaDTO = materiaService.Add(dto);

                        return Results.Created($"/materias/{materiaDTO.IdMateria}", materiaDTO);
                    }
                    catch (ArgumentException ex)
                    {
                        return Results.BadRequest(new { error = ex.Message });
                    }
                })
                .WithName("AddMateria")
                .Produces<MateriaDTO>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithOpenApi();


                app.MapPut("/materias/{id}", (MateriaDTO dto) =>
                {
                    try
                    {
                        MateriaService materiaService = new MateriaService();

                        var found = materiaService.Update(dto);

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
                .WithName("UpdateMateria")
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest)
                .WithOpenApi();



                app.MapDelete("/materias/{id}", (int id) =>
                {
                    try
                    {
                        MateriaService materiaService = new MateriaService();
                        var deleted = materiaService.Delete(id);

                        if (!deleted)
                            return Results.NotFound();

                        return Results.NoContent();
                    }
                    catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("REFERENCE") == true)
                    {
                        return Results.BadRequest(new { error = "No se puede eliminar la materia porque existen cursos asociados. Elimine primero los cursos relacionados." });
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(new { error = ex.Message });
                    }
                })
                .WithName("DeleteMateria")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();



                app.MapGet("/materias/criteria", (string texto) =>
                {
                    try
                    {
                        MateriaService materiasService = new MateriaService();
                        var criteria = new MateriaCriteriaDTO { Texto = texto };
                        var materias = materiasService.GetByCriteria(criteria);
                        return Results.Ok(materias);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(new { error = ex.Message });
                    }
                })
                    .WithName("GetMateriasByCriteria")
                    .WithOpenApi();

            }
        }
    }
}