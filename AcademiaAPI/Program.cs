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
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

QuestPDF.Settings.License = LicenseType.Community;

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

// Inicializa la base de datos si no existe
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TPIContext>();
    context.Database.EnsureCreated();
}

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