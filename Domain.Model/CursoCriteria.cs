using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CursoCriteria
    {
        public string Texto { get; private set; }

        public CursoCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}