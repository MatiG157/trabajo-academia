using System;
using System.Collections.Generic;
using System.Linq;
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
        public int IdPlan { get; set; }


        public Materia(int idMateria, string descripcion,int hsSemanales, int hsTotales, int idPlan)
        {
            IdMateria=idMateria;
            Descripcion=descripcion;
            HsSemanales=hsSemanales;
            HsTotales=hsTotales;
            IdPlan=idPlan;
        }
    }
}
