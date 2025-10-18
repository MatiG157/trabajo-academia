namespace Domain.Model
{
    public class DocenteCurso
    {

        public string Cargo { get; set; }

        // Atributos para la relacion con curso

        private int _cursoId;
        private Curso? _curso;

        public int IdCurso
        {
            get => _curso?.IdCurso ?? _cursoId;
            private set => _cursoId = value;
        }

        public Curso? Curso
        {
            get => _curso;
            private set
            {
                _curso = value;
                if (value != null && _cursoId != value.IdCurso)
                {
                    _cursoId = value.IdCurso; // Sincronizar automáticamente
                }
            }
        }


        // Atributos para la relacion con Persona ("Docente")

        private int _personaId;
        private Persona? _persona;

        public int IdPersona
        {
            get => _persona?.IdPersona ?? _personaId;
            private set => _personaId = value;
        }

        public Persona? Persona
        {
            get => _persona;
            private set
            {
                _persona = value;
                if (value != null && _personaId != value.IdPersona)
                {
                    _personaId = value.IdPersona; // Sincronizar automáticamente
                }
            }
        }

        public DocenteCurso(string cargo,int idCurso, int idPersona)
        {
            Cargo = cargo;
            IdCurso = idCurso;
            IdPersona = idPersona;
        }

        public void SetCursoId(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El idCurso debe ser mayor que 0.", nameof(idCurso));

            _cursoId = idCurso;

            // Solo invalidar si hay inconsistencia
            if (_curso != null && _curso.IdCurso != idCurso)
            {
                _curso = null; // Invalidar navigation property
            }
        }

        public void SetCurso(Curso curso)
        {
            ArgumentNullException.ThrowIfNull(curso);
            _curso = curso;
            _cursoId = curso.IdCurso;
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

