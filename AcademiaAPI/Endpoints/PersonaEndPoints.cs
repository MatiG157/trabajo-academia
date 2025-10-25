using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AcademiaAPI.Endpoints
{
    public static class PersonaEndPoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas/{id}", async (int id) =>
            {
                PersonaService personaService = new PersonaService();

                PersonaDTO dto = await personaService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPersona")
            .Produces<PersonaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/personas", async () =>
            {
                PersonaService personaService = new PersonaService();

                var dtos = await personaService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/personas", async (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();

                    PersonaDTO personaDTO = await personaService.Add(dto);

                    return Results.Created($"/personas/{personaDTO.IdPersona}", personaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPersona")
            .Produces<PersonaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/personas/{id}", async (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();

                    var found = await personaService.Update(dto);

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
            .WithName("UpdatePersona")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/personas/{id}", async (int id) =>
            {
                PersonaService personaService = new PersonaService();

                var deleted = await personaService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();

            })
            .WithName("DeletePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/personas/criteria", async (string texto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var criteria = new PersonaCriteriaDTO { Texto = texto };
                    var personas = await personaService.GetByCriteria(criteria);
                    return Results.Ok(personas);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetPersonasByCriteria")
            .WithOpenApi();
        }
    }
}
