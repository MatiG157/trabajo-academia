    namespace Domain.Model
{
    public class AlumnoInscripcion
    {
        public int IdInscripcion { get; set; }
        public string Condicion { get; set; }
        public int? Nota { get; set; }

        // Atributos para la relacion con curso

        private int _cursoId;
        private Curso? _curso;

        public AlumnoInscripcion() { }

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


        // Atributos para la relacion con Persona ("Alumno")

        private int _alumnoId;
        private Persona? _alumno;

        public int IdAlumno
        {
            get => _alumno?.IdPersona ?? _alumnoId;
            private set => _alumnoId = value;
        }

        public Persona? Alumno
        {
            get => _alumno;
            private set
            {
                _alumno = value;
                if (value != null && _alumnoId != value.IdPersona)
                {
                    _alumnoId = value.IdPersona; // Sincronizar automáticamente
                }
            }
        }

        public AlumnoInscripcion(int idInscripcion,string condicion, int? nota)
        {
            IdInscripcion = idInscripcion;
            Condicion = condicion;
            Nota = nota;
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

        public void SetAlumnoId(int idAlumno)
        {
            if (idAlumno <= 0)
                throw new ArgumentException("El idAlumno debe ser mayor que 0.", nameof(idAlumno));

            _alumnoId = idAlumno;

            // Solo invalidar si hay inconsistencia
            if (_alumno != null && _alumno.IdPersona != idAlumno)
            {
                _alumno = null; // Invalidar navigation property
            }
        }
        public void SetAlumno(Persona alumno)
        {
            ArgumentNullException.ThrowIfNull(alumno);
            _alumno = alumno;
            _alumnoId = alumno.IdPersona;
        }
    }


}


