using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPlan { get; set; }
        public int Legajo { get; set; }
        public string Telefono { get; set; }
        public string TipoPersona { get; set; }
    }
}
