using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi.Negocio
{
    public class EmpleadosNom
    {
        static string rutaArchivoCsvEmpleados = $"{Calculos.PathArchivos}/empleados.csv";

        public static List<Empleados> CargarEmpleados()
        {
            try
            {
                List<Empleados> Empleado = new List<Empleados>();
                if (File.Exists(rutaArchivoCsvEmpleados))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvEmpleados))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        Empleado = csv.GetRecords<Empleados>().ToList();
                    }
                }

                return Empleado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int AgregarEmpleado(List<Empleados> Empleado, int NoEmpleado, string NoCedula, string NoINSS, string NoRUC, string Nombre, string Telefono, string Celular, string Direccion, string Sexo, string EstadoCivil, decimal SalarioOrdinario, DateTime FechaNacimiento, DateTime FechaContratacion, DateTime FechaCierreContrato)
        {
            try
            {
                Empleado.Add(new Empleados
                {
                    NumeroEmpleado = NoEmpleado,
                    NumeroCedula = NoCedula,
                    NumeroINSS = NoINSS,
                    NumeroRUC = NoRUC,
                    Nombre = Nombre,
                    Telefono = Telefono,
                    Celular = Celular,
                    Direccion = Direccion,
                    Sexo = Sexo,
                    EstadoCivil = EstadoCivil,
                    SalarioOrdinario = Convert.ToDecimal(SalarioOrdinario.ToString("N2")),
                    FechaNacimiento = FechaNacimiento,
                    FechaContratacion = FechaContratacion,
                    FechaCierreContrato = FechaCierreContrato,
                    Activo = true
                });

                if (!File.Exists(rutaArchivoCsvEmpleados))
                {
                    File.Create(rutaArchivoCsvEmpleados).Close();
                }

                using (var writer = new StreamWriter(rutaArchivoCsvEmpleados))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Empleado);
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int EditarEmpleado(List<Empleados> Empleado, int NoEmpleado, string NoCedula, string NoINSS, string NoRUC, string Nombre, string Telefono, string Celular, string Direccion, string Sexo, string EstadoCivil, decimal SalarioOrdinario, DateTime FechaNacimiento, DateTime FechaContratacion, DateTime FechaCierreContrato, bool Activo)
        {
            try
            {
                Empleados E = Empleado.FirstOrDefault(x => x.NumeroEmpleado == NoEmpleado);

                if (E != null)
                {
                    E.NumeroEmpleado = NoEmpleado;
                    E.NumeroCedula = NoCedula;
                    E.NumeroINSS = NoINSS;
                    E.NumeroRUC = NoRUC;
                    E.Nombre = Nombre;
                    E.Telefono = Telefono;
                    E.Celular = Celular;
                    E.Direccion = Direccion;
                    E.Sexo = Sexo;
                    E.EstadoCivil = EstadoCivil;
                    E.SalarioOrdinario = Convert.ToDecimal(SalarioOrdinario.ToString("N2"));
                    E.FechaNacimiento = FechaNacimiento;
                    E.FechaContratacion = FechaContratacion;
                    E.FechaCierreContrato = FechaCierreContrato;
                    E.Activo = Activo;
                }

                using (var writer = new StreamWriter(rutaArchivoCsvEmpleados))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Empleado);
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}