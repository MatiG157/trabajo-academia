using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Especialidad
    {
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }

        public Especialidad() { }

        public Especialidad(int idEspecialidad,string descripcion)
        {
            IdEspecialidad = idEspecialidad;
            Descripcion = descripcion;
        }
    }
}
