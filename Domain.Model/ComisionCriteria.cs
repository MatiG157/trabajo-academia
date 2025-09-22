using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ComisionCriteria
    {
        public string Texto { get; private set; }

        public ComisionCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
