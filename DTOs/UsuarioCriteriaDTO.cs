using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioCriteriaDTO
    {
        public string Texto { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Clave { get; set; }
    }
}
