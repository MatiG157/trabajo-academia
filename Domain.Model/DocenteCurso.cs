namespace Domain.Model
{
    public class DocenteCurso
    {

        public int IdAsignacion {  get; set; }
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
                    _cursoId = value.IdCurso; 
                }
            }
        }


        // Atributos para la relacion con Persona ("Docente")

        private int _docenteId;
        private Persona? _docente;

        public int IdDocente
        {
            get => _docente?.IdPersona ?? _docenteId;
            private set => _docenteId = value;
        }

        public Persona? Docente
        {
            get => _docente;
            private set
            {
                _docente = value;
                if (value != null && _docenteId != value.IdPersona)
                {
                    _docenteId = value.IdPersona; 
                }
            }
        }

        public DocenteCurso() { }

        public DocenteCurso(string cargo,int idCurso, int idPersona)
        {
            Cargo = cargo;
            IdCurso = idCurso;
            IdDocente = idPersona;
        }

        public void SetCursoId(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El idCurso debe ser mayor que 0.", nameof(idCurso));

            _cursoId = idCurso;

            if (_curso != null && _curso.IdCurso != idCurso)
            {
                _curso = null; 
            }
        }

        public void SetCurso(Curso curso)
        {
            ArgumentNullException.ThrowIfNull(curso);
            _curso = curso;
            _cursoId = curso.IdCurso;
        }

        public void SetDocenteId(int idDocente)
        {   
            if (idDocente <= 0)
                throw new ArgumentException("El id del Docente debe ser mayor que 0.", nameof(idDocente));

            _docenteId = idDocente;

            if (_docente != null && _docente.IdPersona != idDocente)
            {
                _docente = null; 
            }
        }

        public void SetDocente(Persona docente)
        {
            ArgumentNullException.ThrowIfNull(docente);
            _docente = docente;
            _docenteId = docente.IdPersona;
        }
    }


}

