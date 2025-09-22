using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;

namespace AcademiaAPI.Endpoints
{
    public static class PersonaEndPoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();

                PersonaDTO dto = personaService.Get(id);

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


            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();

                var dtos = personaService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            app.MapPost("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();

                    PersonaDTO personaDTO = personaService.Add(dto);

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


            app.MapPut("/personas/{id}", (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();

                    var found = personaService.Update(dto);

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


            app.MapDelete("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();

                var deleted = personaService.Delete(id);

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

            app.MapGet("/personas/criteria", (string texto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var criteria = new PersonaCriteriaDTO { Texto = texto };
                    var personas = personaService.GetByCriteria(criteria);
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
