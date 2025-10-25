using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AcademiaAPI.Endpoints;
public static class ComisionEndpoints
{
    public static void MapComisionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/comisiones/{id}", async (int id) =>
        {
            ComisionService comisionService = new ComisionService();

            ComisionDTO dto = await comisionService.Get(id);

            if (dto == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(dto);
        })
        .WithName("GetComisiones")
        .Produces<ComisionDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        app.MapGet("/comisiones", async () =>
        {
            ComisionService comisionService = new ComisionService();

            var dtos = await comisionService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllComisiones")
        .Produces<List<ComisionDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/comisiones", async (ComisionDTO dto) =>
        {
            try
            {
                ComisionService comisionService = new ComisionService();

                ComisionDTO comisionDTO = await comisionService.Add(dto);

                return Results.Created($"/comisiones/{comisionDTO.IdComision}", comisionDTO);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("AddComision")
        .Produces<ComisionDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();


        app.MapPut("/comisiones/{id}", async (ComisionDTO dto) =>
        {
            try
            {
                ComisionService comisionService = new ComisionService();

                var found = await comisionService.Update(dto);

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
        .WithName("UpdateComisiones")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();


        app.MapDelete("/comisiones/{id}", async (int id) =>
        {
            ComisionService comisionService = new ComisionService();

            var deleted = await comisionService.Delete(id);

            if (!deleted)
            {
                return Results.NotFound();
            }

            return Results.NoContent();

        })
        .WithName("DeleteComision")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        app.MapGet("/comisiones/criteria", async (string texto) =>
        {
            try
            {
                ComisionService comisionService = new ComisionService();
                var criteria = new ComisionCriteriaDTO { Texto = texto };
                var cursos = await comisionService.GetByCriteria(criteria);
                return Results.Ok(cursos);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("GetComisionesByCriteria")
        .WithOpenApi();
    }
}

