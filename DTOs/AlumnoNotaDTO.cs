using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AlumnoNotaDTO
    {
        public int IdInscripcion { get; set; }
        public int IdCurso   { get; set; }
        public string NombreCompleto { get; set; }
        public int? Nota { get; set; }
        public string Condicion { get; set; }
        public int Legajo { get; set; }
    }
}
