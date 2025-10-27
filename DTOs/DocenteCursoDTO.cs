using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DocenteCursoDTO
    {
        public int IdAsignacion {  get; set; }
        public string Cargo { get; set; }
        public int IdCurso { get; set; }
        public int IdDocente { get; set; }
    }
}
