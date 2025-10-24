using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DocenteCursoAPI.Endpoints
{
    public static class DocenteCursoEndpoints
    {
        public static void MapDocenteCursoEndpoints(this WebApplication app)
        {
            {
              
                app.MapGet("/docentesCursos/criteria", (int idDocente) =>
                {
                    try
                    {
                        DocenteCursoService docenteCursoService = new DocenteCursoService();
                        var criteria = new DocenteCursoCriteriaDTO { IdDocente = idDocente };
                        var docentesCursos = docenteCursoService.GetByCriteria(criteria);
                        return Results.Ok(docentesCursos);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(new { error = ex.Message });
                    }
                })
                    .WithName("GetDocenteCursoByCriteria")
                    .WithOpenApi();

            }
        }
    }
}