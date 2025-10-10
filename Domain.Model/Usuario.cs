using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {


        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool CambiaClave { get; set; }

        private int _personaId;
        //public int IdPersona { get; private set; }
        private Persona? _persona;
        public Usuario() { }

        public int IdPersona
        {
            get => _persona?.IdPersona ?? _personaId;
            set => _personaId = value;
        }

        public Persona? Persona
        {
            get => _persona;
            private set
            {
                _persona = value;
                if (value != null)
                {
                    _personaId = value.IdPersona;
                }
            }
        }



        public Usuario(int idUsuario, string nombreUsuario, string clave, bool habilitado, string nombre, string apellido, string email, bool cambiaClave, int idPersona)
        {

            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Habilitado = habilitado;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            CambiaClave = cambiaClave;
            IdPersona = idPersona;

        }

        public void SetPersonaId(int idPersona)
        {
            if (idPersona <= 0)
                throw new ArgumentException("El idPersona debe ser mayor que 0.", nameof(idPersona));

            _personaId = idPersona;

            // Solo invalidar si hay inconsistencia
            if (_persona != null && _persona.IdPersona != idPersona)
            {
                _persona = null; // Invalidar navigation property
            }
        }

        public void SetPersona(Persona persona)
        {
            ArgumentNullException.ThrowIfNull(persona);
            _persona = persona;
            _personaId = persona.IdPersona;
        }

    }


}


