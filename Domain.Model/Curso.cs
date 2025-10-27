namespace Domain.Model
{
    public class Curso {
    
        public int IdCurso { get; set; }
        public string Descripcion { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }

        // Atributos para la relacion con materia

        private int _materiaId;
        private Materia? _materia;

        public Curso() { }

        public int IdMateria
        {
            get => _materia?.IdMateria ?? _materiaId;
            private set => _materiaId = value;
        }

        public Materia? Materia
        {
            get => _materia;
            private set
            {
                _materia = value;
                if (value != null && _materiaId != value.IdMateria)
                {
                    _materiaId = value.IdMateria; 
                }
            }
        }


        // Atributos para la relacion con comision

        private int _comisionId;
        private Comision? _comision;

        public int IdComision
        {
            get => _comision?.IdComision ?? _comisionId;
            private set => _comisionId = value;
        }

        public Comision? Comision
        {
            get => _comision;
            private set
            {
                _comision = value;
                if (value != null && _comisionId != value.IdComision)
                {
                    _comisionId = value.IdComision; 
                }
            }
        }

        public Curso(int idCurso, int idMateria, int idComision, string descripcion, int anioCalendario, int cupo)
        {
            IdCurso = idCurso;
            IdMateria = idMateria;
            IdComision = idComision;
            Descripcion = descripcion;
            AnioCalendario = anioCalendario;
            Cupo = cupo;
        }

        public void SetComisionId(int idComision)
        {
            if (idComision <= 0)
                throw new ArgumentException("El idComision debe ser mayor que 0.", nameof(idComision));

            _comisionId = idComision;

            // Solo invalidar si hay inconsistencia
            if (_comision != null && _comision.IdComision != idComision)
            {
                _comision = null; 
            }
        }

        public void SetComision(Comision comision)
        {
            ArgumentNullException.ThrowIfNull(comision);
            _comision = comision;
            _comisionId = comision.IdComision;
        }

        public void SetMateriaId(int idMateria)
        {
            if (idMateria <= 0)
                throw new ArgumentException("El idMateria debe ser mayor que 0.", nameof(idMateria));

            _materiaId = idMateria;

            if (_materia != null && _materia.IdMateria != idMateria)
            {
                _materia = null; 
            }
        }

        public void SetMateria(Materia materia)
        {
            ArgumentNullException.ThrowIfNull(materia);
            _materia = materia;
            _materiaId = materia.IdMateria;
        }
    }


}
