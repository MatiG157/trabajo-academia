using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AlumnoInscripcionDTO
    {
        public int IdInscripcion { get; set; }
        public string Condicion { get; set; }
        public int? Nota {  get; set; }
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
    }
}
