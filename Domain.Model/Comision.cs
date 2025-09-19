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
        public int IdPlan {  get; set; }

        public Comision(int idComision, int anioEspecialidad,string descripcion, int idPlan)
        {
            IdComision = idComision;
            AnioEspecialidad = anioEspecialidad;
            Descripcion = descripcion;
            IdPlan = idPlan;
        }
    }
}
