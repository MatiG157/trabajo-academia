using System;

namespace Domain.Model
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Legajo { get; set; }
        public string Telefono { get; set; }
        public string TipoPersona { get; set; }


        // Atributos para la relacion con plan

        private int _planId;
        private Plan? _plan;

        public Persona() { }

        public int IdPlan
        {
            get => _plan?.IdPlan ?? _planId;
            private set => _planId = value;
        }

        public Plan? Plan
        {
            get => _plan;
            private set
            {
                _plan = value;
                if (value != null && _planId != value.IdPlan)
                {
                    _planId = value.IdPlan; // Sincronizar automáticamente
                }
            }
        }


        public Persona(int idPersona,string direccion, DateTime fechaNacimiento, int legajo,string telefono, string tipoPersona)
        {
            IdPersona = idPersona;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Legajo = legajo;
            Telefono = telefono;
            TipoPersona = tipoPersona;
        }

        public void SetPlanId(int idPlan)
        {
            if (idPlan <= 0)
                throw new ArgumentException("El idPlan debe ser mayor que 0.", nameof(idPlan));

            _planId = idPlan;

            // Solo invalidar si hay inconsistencia
            if (_plan != null && _plan.IdPlan != idPlan)
            {
                _plan = null; // Invalidar navigation property
            }
        }

        public void SetPlan(Plan plan)
        {
            ArgumentNullException.ThrowIfNull(plan);
            _plan = plan;
            _planId = plan.IdPlan;
        }

    }
}
