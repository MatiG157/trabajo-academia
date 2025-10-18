//namespace Domain.Model
//{
//    public class ModuloUsuario
//    {

//        //NO ESTA TERMINADO

//        public bool PermiteAlta { get; set; }
//        public bool PermiteBaja { get; set; }
//        public bool PermiteConsulta { get; set; }
//        public bool PermiteModificacion { get; set; }

//        // Atributos para la relacion con modulo

//        private int _moduloId;
//        private Modulo? mnodulo;

//        public int IdModulo
//        {
//            get => modulo?.IdModulo ?? _moduloId;
//            private set => _moduloId = value;
//        }

//        public Modulo? Modulo
//        {
//            get => _modulo;
//            private set
//            {
//                _modulo = value;
//                if (value != null && _moduloId != value.IdModulo)
//                {
//                    _moduloId = value.IdModulo; // Sincronizar automáticamente
//                }
//            }
//        }


//        // Atributos para la relacion con Persona ("Docente")

//        private int _comisionId;
//        private Comision? _comision;

//        public int IdComision
//        {
//            get => _comision?.IdComision ?? _comisionId;
//            private set => _comisionId = value;
//        }

//        public Comision? Comision
//        {
//            get => _comision;
//            private set
//            {
//                _comision = value;
//                if (value != null && _comisionId != value.IdComision)
//                {
//                    _comisionId = value.IdComision; // Sincronizar automáticamente
//                }
//            }
//        }

//        public AlumnoInscripcion(string cargo, int idCurso, int idMateria)
//        {
//            Cargo = cargo;
//            IdCurso = idCurso;
//            IdMateria = idMateria;
//        }

//        public void SetModuloId(int idModulo)
//        {
//            if (idModulo <= 0)
//                throw new ArgumentException("El idModulo debe ser mayor que 0.", nameof(idModulo));

//            _moduloId = idModulo;

//            // Solo invalidar si hay inconsistencia
//            if (_modulo != null && _modulo.IdModulo != idModulo)
//            {
//                _modulo = null; // Invalidar navigation property
//            }
//        }

//        public void SetModulo(Modulo curso)
//        {
//            ArgumentNullException.ThrowIfNull(curso);
//            _curso = curso;
//            _cursoId = curso.IdModulo;
//        }

//        public void SetMateriaId(int idMateria)
//        {
//            if (idMateria <= 0)
//                throw new ArgumentException("El idMateria debe ser mayor que 0.", nameof(idMateria));

//            _materiaId = idMateria;

//            // Solo invalidar si hay inconsistencia
//            if (_materia != null && _materia.IdMateria != idMateria)
//            {
//                _materia = null; // Invalidar navigation property
//            }
//        }

//        public void SetMateria(Materia materia)
//        {
//            ArgumentNullException.ThrowIfNull(materia);
//            _materia = materia;
//            _materiaId = materia.IdMateria;
//        }
//    }


//}

