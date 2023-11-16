using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaCurso_Anahi.POO
{
    public class Nominas
    {
        public int NoNomina { get; set; }
        public int NoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public decimal SalarioBasico { get; set; }
        public decimal Antiguedad { get; set; }
        public decimal PagoRiesgoLaboral { get; set; }
        public decimal PagoNocturnidad { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal SalarioExtraordinario { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal INSSLaboral { get; set; }
        public decimal IR { get; set; }
        public decimal SalarioNeto { get; set; }
        public decimal INSSPatronal { get; set; }
    }
}