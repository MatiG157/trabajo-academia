using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AcademiaAPI.Endpoints
{
    public static class PersonaEndPoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
