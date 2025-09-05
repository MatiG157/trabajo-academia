using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UsuarioCriteria
    {
        public string Texto { get; private set; }

        public UsuarioCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
