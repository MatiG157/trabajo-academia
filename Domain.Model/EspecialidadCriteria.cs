using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EspecialidadCriteria
    {
        public string Texto { get; private set; }

        public EspecialidadCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
