using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AcademiaAPI.Endpoints;
public static class PlanEndpoints
{
    public static void MapPlanEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/planes/{id}", async (int id) =>
        {
            PlanService planService = new PlanService();

            PlanDTO dto = await planService.Get(id);

            if (dto == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(dto);
        })
        .WithName("GetPlan")
        .Produces<PlanDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        app.MapGet("/planes", async () =>
        {
            PlanService planService = new PlanService();

            var dtos = await planService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllPlanes")
        .Produces<List<PlanDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/planes", async (PlanDTO dto) =>
        {
            try
            {
                PlanService planService = new PlanService();

                PlanDTO planDTO = await planService.Add(dto);

                return Results.Created($"/planes/{planDTO.IdPlan}", planDTO);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("AddPlan")
        .Produces<PlanDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();


        app.MapPut("/planes/{id}", async (PlanDTO dto) =>
        {
            try
            {
                PlanService planService = new PlanService();

                var found = await planService.Update(dto);

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
        .WithName("UpdatePlan")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();


        app.MapDelete("/planes/{id}", async (int id) =>
        {
            PlanService planService = new PlanService();

            var deleted = await planService.Delete(id);

            if (!deleted)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
        .WithName("DeletePlan")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        app.MapGet("/planes/criteria", async (string texto) =>
        {
            try
            {
                PlanService planService = new PlanService();
                var criteria = new PlanCriteriaDTO { Texto = texto };
                var planes = await planService.GetByCriteria(criteria);
                return Results.Ok(planes);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("GetPlanesByCriteria")
        .WithOpenApi();
    }
}
