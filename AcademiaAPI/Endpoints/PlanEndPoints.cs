using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;



namespace AcademiaAPI.Endpoints;
public static class PlanEndpoints
{
    public static void MapPlanEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/planes/{id}", (int id) =>
        {
            PlanService planService = new PlanService();

            PlanDTO dto = planService.Get(id);

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


        app.MapGet("/planes", () =>
        {
            PlanService planService = new PlanService();

            var dtos = planService.GetAll();

            return Results.Ok(dtos);
        })
        .WithName("GetAllPlanes")
        .Produces<List<PlanDTO>>(StatusCodes.Status200OK)
        .WithOpenApi();


        app.MapPost("/planes", (PlanDTO dto) =>
        {
            try
            {
                PlanService planService = new PlanService();

                PlanDTO planDTO = planService.Add(dto);

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


        app.MapPut("/planes/{id}", (PlanDTO dto) =>
        {
            try
            {
                PlanService planService = new PlanService();

                var found = planService.Update(dto);

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


        app.MapDelete("/planes/{id}", (int id) =>
        {
            PlanService planService = new PlanService();

            var deleted = planService.Delete(id);

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

        app.MapGet("/planes/criteria", (string texto) =>
        {
            try
            {
                PlanService planService = new PlanService();
                var criteria = new PlanCriteriaDTO { Texto = texto };
                var planes = planService.GetByCriteria(criteria);
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