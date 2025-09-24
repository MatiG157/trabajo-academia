using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PersonaCriteria
    {
        public string Texto { get; private set; }

        public PersonaCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
