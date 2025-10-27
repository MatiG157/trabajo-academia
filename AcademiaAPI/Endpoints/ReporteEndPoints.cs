using DTOs;
using Domain.Services;
using Data;
using ReporteCursos;
using ReportePlanes;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AcademiaAPI.Endpoints;

public static class ReporteEndpoints
{
    public static void MapReporteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/reportes/cursos", async () =>
        {
            try
            {
                var repo = new CursoRepository();
                var data = await repo.GetCursosConCantidadAlumnosAsync();

                var doc = new ReporteCursosDocument(data);
                var pdfBytes = doc.GeneratePdf();

                var fileName = $"Reporte_Cursos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                
                return Results.File(pdfBytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = $"Error al generar el reporte: {ex.Message}" });
            }
        })
        .WithName("GetReporteCursos")
        .Produces<byte[]>(StatusCodes.Status200OK, "application/pdf")
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        app.MapGet("/reportes/planes", async () =>
        {
            try
            {
                var repo = new PlanRepository();
                var data = await repo.GetPlanesConMateriasAsync();

                var doc = new ReportePlanesMateriasDocument(data);
                var pdfBytes = doc.GeneratePdf();

                var fileName = $"Reporte_Planes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                
                return Results.File(pdfBytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = $"Error al generar el reporte: {ex.Message}" });
            }
        })
        .WithName("GetReportePlanes")
        .Produces<byte[]>(StatusCodes.Status200OK, "application/pdf")
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();
    }
}