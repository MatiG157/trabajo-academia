using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int HsSemanales { get; set; }
        public int HsTotales { get; set; }


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

        public Materia(int idMateria, string descripcion,int hsSemanales, int hsTotales)
        {
            IdMateria=idMateria;
            Descripcion=descripcion;
            HsSemanales=hsSemanales;
            HsTotales=hsTotales;
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
