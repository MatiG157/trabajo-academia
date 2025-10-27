using Domain.Model;
using Data;
using DTOs;

namespace Domain.Services
{
    public class UsuarioService
    {
        public async Task<UsuarioDTO> Add(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (await usuarioRepository.EmailExists(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            Usuario usuario = new Usuario(0, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.Nombre, dto.Apellido, dto.Email, dto.CambiaClave, dto.IdPersona);

            await usuarioRepository.Add(usuario);

            dto.IdUsuario = usuario.IdUsuario;

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return await usuarioRepository.Delete(id);
        }

        public async Task<UsuarioDTO?> Get(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = await usuarioRepository.Get(id);

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

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = await usuarioRepository.GetAll();

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

        public async Task<bool> Update(UsuarioDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();

            if (await usuarioRepository.EmailExists(dto.Email, dto.IdUsuario))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            Usuario usuario = new Usuario(dto.IdUsuario, dto.NombreUsuario, dto.Clave, dto.Habilitado, dto.Nombre, dto.Apellido, dto.Email, dto.CambiaClave, dto.IdPersona);

            return await usuarioRepository.Update(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var usuarioRepository = new UsuarioRepository();

            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            var usuarios = await usuarioRepository.GetByCriteria(criteria);

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

        public async Task<Usuario?> Login(UsuarioCriteriaDTO criteriaDto)
        {
            var criteria = new UsuarioCriteria
            {
                Email = criteriaDto.Email,
                Clave = criteriaDto.Clave
            };

            var usuarioRepository = new UsuarioRepository();
            return await usuarioRepository.FindByCriteria(criteria);
        }
    }
}
