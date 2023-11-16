using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaCurso_Anahi.POO
{
    public class Empleados
    {
        public int NumeroEmpleado { get; set; }
        public string NumeroCedula { get; set; }
        public string NumeroINSS { get; set; }
        public string NumeroRUC { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaCierreContrato { get; set; }
        public decimal SalarioOrdinario { get; set; }
        public bool Activo { get; set; }
    }
}