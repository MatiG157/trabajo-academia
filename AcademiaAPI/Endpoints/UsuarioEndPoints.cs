using DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Domain.Model;



namespace AcademiaAPI.Endpoints;

    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/usuarios/{id}", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();

                UsuarioDTO dto = usuarioService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/usuarios/{email}/{clave}", async (string email, string clave) =>
            {
                UsuarioService usuarioService = new UsuarioService();

                UsuarioCriteriaDTO criteriaDTO = new UsuarioCriteriaDTO();

                criteriaDTO.Email = email;
                criteriaDTO.Clave = clave;

                var usuario = await usuarioService.Login(criteriaDTO);

                if (usuario == null)
                {
                    return Results.NotFound();
                }

                UsuarioDTO dto = new UsuarioDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    NombreUsuario = usuario.NombreUsuario,
                    Clave = usuario.Clave,
                    Habilitado = usuario.Habilitado,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    CambiaClave = usuario.CambiaClave,
                    IdPersona = usuario.IdPersona
                };

                return Results.Ok(dto);
            })
            .WithName("Login")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();


        app.MapGet("/usuarios", () =>
            {
                UsuarioService usuarioService = new UsuarioService();

                var dtos = usuarioService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            app.MapPost("/usuarios", (UsuarioDTO dto) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();

                    UsuarioDTO usuarioDTO = usuarioService.Add(dto);

                    return Results.Created($"/usuarios/{usuarioDTO.IdUsuario}", usuarioDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapPut("/usuarios/{id}", (UsuarioDTO dto) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();

                    var found = usuarioService.Update(dto);

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
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();

                var deleted = usuarioService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();

            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();



            app.MapGet("/usuarios/criteria", (string texto) =>
            {
                try
                {
                    UsuarioService usuariosService = new UsuarioService();
                    var criteria = new UsuarioCriteriaDTO { Texto = texto };
                    var usuarios = usuariosService.GetByCriteria(criteria);
                    return Results.Ok(usuarios);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
                .WithName("GetUsuariosByCriteria")
                .WithOpenApi();
    
        }
    }
