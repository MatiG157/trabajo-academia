using Microsoft.AspNetCore.OpenApi;
using Domain.Services;
using Domain.Model;
using DTOs;
using AcademiaAPI.Endpoints;
//using WebAPI;
using Data;
using MateriaAPI.Endpoints;
using EspecialidadAPI.Endpoints;
using DocenteCursoAPI.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });


builder.WebHost.UseUrls(
    "http://localhost:5077",
    "https://localhost:7238",
    "http://localhost:5210",
    "https://localhost:7254"
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}



app.MapCursoEndpoints();
app.MapUsuarioEndpoints();
app.MapMateriaEndpoints();
app.MapPersonaEndpoints();
app.MapComisionEndpoints();
app.MapPlanEndpoints();
app.MapEspecialidadEndpoints();
app.MapAlumnoInscripcionEndpoints();
app.MapDocenteCursoEndpoints();



app.Run();