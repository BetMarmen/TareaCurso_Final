using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi.Negocio
{
    public class Calculos
    {
        public static string PathArchivos = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))).Replace("\\", "/");
        public static decimal CalcularHoraExtraTrabajoEmpleado(decimal Salario, int Horas)
        {
            decimal SalarioxHora = (decimal)(((Salario / 30) / 8) * 2);

            return (decimal)(SalarioxHora * Horas);
        }

        public static decimal CalcularPagoRiesgoLaboral_Nocturnidad(decimal Salario)
        {
            return Salario * (decimal)0.2;
        }

        public static decimal CalcularAntiguedad(decimal Salario, DateTime FechaContratacion)
        {
            try
            {
                int AñosTrabajados = DateTime.Now.Year - FechaContratacion.Year;
                decimal Antiguedad = 0;
                if (FechaContratacion > DateTime.Now.AddYears(-AñosTrabajados))
                {
                    AñosTrabajados--;
                }

                if (AñosTrabajados == 0)
                {
                    Antiguedad = 0;
                }
                else if (AñosTrabajados >= 1 && AñosTrabajados <= 5)
                {
                    Antiguedad = Salario * (decimal)0.05;
                }
                else if (AñosTrabajados >= 6 && AñosTrabajados <= 10)
                {
                    Antiguedad = Salario * (decimal)0.1;
                }
                else if (AñosTrabajados >= 11 && AñosTrabajados <= 15)
                {
                    Antiguedad = Salario * (decimal)0.15;
                }
                else if (AñosTrabajados >= 16 && AñosTrabajados <= 20)
                {
                    Antiguedad = Salario * (decimal)0.2;
                }
                else if (AñosTrabajados >= 21 && AñosTrabajados <= 25)
                {
                    Antiguedad = Salario * (decimal)0.25;
                }
                else if (AñosTrabajados >= 26 && AñosTrabajados <= 30)
                {

                    Antiguedad = Salario * (decimal)0.3;
                }
                else if (AñosTrabajados >= 31 && AñosTrabajados <= 35)
                {
                    Antiguedad = Salario * (decimal)0.35;
                }
                else if (AñosTrabajados >= 36 && AñosTrabajados <= 40)
                {
                    Antiguedad = Salario * (decimal)0.4;
                }
                else if (AñosTrabajados >= 41 && AñosTrabajados <= 45)
                {
                    Antiguedad = Salario * (decimal)0.45;

                }
                else if (AñosTrabajados >= 46 && AñosTrabajados <= 50)
                {
                    Antiguedad = Salario * (decimal)0.5;
                }

                return Antiguedad;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal CalcularINSSLaboral(decimal SalarioBruto)
        {
            try
            {
                return SalarioBruto * (decimal)0.07;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal CalcularIR(decimal SalarioBruto)
        {
            try
            {
                decimal IR = 0, SalarioAnual = SalarioBruto * 12;
                
                if (SalarioAnual >= (decimal)0.01 && SalarioAnual <= (decimal)100000)
                {
                    IR = 0;
                }
                else if (SalarioAnual >= (decimal)100000.01 && SalarioAnual <= (decimal)200000)
                {
                    SalarioAnual -= 100000;
                    IR = SalarioAnual * (decimal)0.15;
                }
                else if (SalarioAnual >= (decimal)200000.01 && SalarioAnual <= (decimal)350000)
                {
                    SalarioAnual -= 200000;
                    IR = SalarioAnual * (decimal)0.2;
                    IR += 15000;
                }
                else if (SalarioAnual >= (decimal)350000.01 && SalarioAnual <= (decimal)500000)
                {
                    SalarioAnual -= 350000;
                    IR = SalarioAnual * (decimal)0.25;
                    IR += 45000;
                }
                else if (SalarioAnual >= (decimal)500000.01)
                {
                    SalarioAnual -= 500000;
                    IR = SalarioAnual * (decimal)0.3;
                    IR += 82500;
                }

                IR /= 12;
                return IR;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal CalcularINSSPatronal(decimal SalarioBruto)
        {
            try
            {
                return SalarioBruto * (decimal)0.225;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}