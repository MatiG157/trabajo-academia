using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace WebAPI
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materia", () =>
            {
                MateriaService materiaService = new MateriaService();
                var dtos = materiaService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllMaterias")
            .Produces<List<MateriaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}