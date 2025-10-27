using Microsoft.AspNetCore.OpenApi;
using Domain.Services;
using Domain.Model;
using DTOs;
using AcademiaAPI.Endpoints;
using Data;
using MateriaAPI.Endpoints;
using EspecialidadAPI.Endpoints;
using DocenteCursoAPI.Endpoints;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5210", "https://localhost:7254")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.WebHost.UseUrls(
    "http://localhost:5077",
    "https://localhost:7238"
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}


app.UseCors("AllowBlazorClient");



app.MapCursoEndpoints();
app.MapUsuarioEndpoints();
app.MapMateriaEndpoints();
app.MapPersonaEndpoints();
app.MapComisionEndpoints();
app.MapPlanEndpoints();
app.MapEspecialidadEndpoints();
app.MapAlumnoInscripcionEndpoints();
app.MapDocenteCursoEndpoints();
app.MapReporteEndpoints();



app.Run();