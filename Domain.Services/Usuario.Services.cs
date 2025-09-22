using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class UsuarioService
    {

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar que el email no esté duplicado
            if (usuarioRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            Usuario usuario = new Usuario(0, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.Nombre, dto.Apellido, dto.Email, dto.CambiaClave, dto.IdPersona);

            usuarioRepository.Add(usuario);

            dto.IdUsuario = usuario.IdUsuario;

            return dto;
        }

        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }




        public UsuarioDTO Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
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
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();

            return usuarios.Select(usuario => new UsuarioDTO
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


            }).ToList();
        }

        public bool Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            // Validar que el email no esté duplicado (excluyendo el usuario actual)
            if (usuarioRepository.EmailExists(dto.Email, dto.IdUsuario))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            Usuario usuario = new Usuario(dto.IdUsuario, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.Nombre, dto.Apellido, dto.Email, dto.CambiaClave, dto.IdPersona);

            return usuarioRepository.Update(usuario);
        }



        public IEnumerable<UsuarioDTO> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var usuarioRepository = new UsuarioRepository();

            // Mapear DTO a Domain Model
            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var usuarios = usuarioRepository.GetByCriteria(criteria);

            // Mapear Domain Model a DTO
            return usuarios.Select(u => new UsuarioDTO
            {
                IdUsuario = u.IdUsuario,
                NombreUsuario = u.NombreUsuario,
                Clave = u.Clave,
                Habilitado = u.Habilitado,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                CambiaClave = u.CambiaClave,
                IdPersona = u.IdPersona
            });
        }


    }
}
