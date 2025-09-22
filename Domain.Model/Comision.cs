using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comision
    {
        public int IdComision { get; set; }
        public int AnioEspecialidad {  get; set; }
        public string Descripcion {  get; set; }

        // Atributos para la relacion con plan

        private int _planId;
        private Plan? _plan;

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

        public Comision(int idComision, int anioEspecialidad,string descripcion)
        {
            IdComision = idComision;
            AnioEspecialidad = anioEspecialidad;
            Descripcion = descripcion;
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
