using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ComisionesEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones", () =>
            {
                ComisionService comisionService = new ComisionService();
                var dtos = comisionService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllComisiones")
            .Produces<List<ComisionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}