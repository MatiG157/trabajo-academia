using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Plan
    {
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }

        // Atributos para la relacion con especialidad

        public Plan() { }

        private int _especialidadId;
        private Especialidad? _especialidad;

        public int IdEspecialidad
        {
            get => _especialidad?.IdEspecialidad ?? _especialidadId;
            private set => _especialidadId = value;
        }

        public Especialidad? Especialidad
        {
            get => _especialidad;
            private set
            {
                _especialidad = value;
                if (value != null && _especialidadId != value.IdEspecialidad)
                {
                    _especialidadId = value.IdEspecialidad; // Sincronizar automáticamente
                }
            }
        }

        public Plan(int idPlan, string descripcion)
        {
            IdPlan = idPlan;
            Descripcion = descripcion;
        }

        public void SetEspecialidadId(int idEspecialidad)
        {
            if (idEspecialidad <= 0)
                throw new ArgumentException("El idEspecialidad debe ser mayor que 0.", nameof(idEspecialidad));

            _especialidadId = idEspecialidad;

            // Solo invalidar si hay inconsistencia
            if (_especialidad != null && _especialidad.IdEspecialidad != idEspecialidad)
            {
                _especialidad = null; // Invalidar navigation property
            }
        }

        public void SetEspecialidad(Especialidad especialidad)
        {
            ArgumentNullException.ThrowIfNull(especialidad);
            _especialidad = especialidad;
            _especialidadId = especialidad.IdEspecialidad;
        }
    }
}
