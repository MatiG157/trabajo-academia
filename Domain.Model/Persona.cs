using System;

namespace Domain.Model
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPlan { get; set; }
        public int Legajo { get; set; }
        public string Telefono { get; set; }
        public string TipoPersona { get; set; }


        public Persona(int idPersona, string apellido,string direccion, string email, DateTime fechaNacimiento, int idPlan, int legajo,string telefono, string tipoPersona)
        {
            IdPersona = idPersona;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            FechaNacimiento=fechaNacimiento;
            IdPlan=idPlan;
            Legajo=legajo;
            Telefono=telefono;
            TipoPersona = tipoPersona;
        }
    }
}
