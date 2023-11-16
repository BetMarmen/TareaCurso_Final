using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi.Negocio
{
    public class NominaNom
    {
        static string rutaArchivoCsvNominas = $"{Calculos.PathArchivos}/nominas.csv";
        static string rutaArchivoCsvDetallesNominas = $"{Calculos.PathArchivos}/detalles_nominas.csv";

        public static List<MostrarNominas> CargarNominasCreadas()
        {
            try
            {
                List<MostrarNominas> Nomina = new List<MostrarNominas>();
                if (File.Exists(rutaArchivoCsvNominas))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvNominas))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        Nomina = csv.GetRecords<MostrarNominas>().ToList();
                    }
                }

                return Nomina;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Nominas> CargarDetallesNominas()
        {
            try
            {
                List<Nominas> DetallesNominas = new List<Nominas>();
                if (File.Exists(rutaArchivoCsvDetallesNominas))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvDetallesNominas))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        DetallesNominas = csv.GetRecords<Nominas>().ToList();
                    }
                }

                return DetallesNominas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Nominas> CrearNomina(List<MostrarNominas> Nominas)
        {
            List<Empleados> Empleado = EmpleadosNom.CargarEmpleados().Where(x => x.Activo == true).ToList();
            List<Ingresos> Ingreso = IngresosNom.CargarIngresos().Where(x => x.Fecha_Registro.Month == DateTime.Now.Month && x.Fecha_Registro.Year == DateTime.Now.Year).ToList();
            List<Nominas> Nomina = new List<Nominas>();

            decimal Antiguedad, PagoRiesgoLaboral, PagoNocturnidad, HorasExtras, SalarioExtraordinario, SalarioBruto, INSSLaboral, IR, SalarioNeto, INSSPatronal;
            foreach (var n in Empleado)
            {
                Antiguedad = Convert.ToDecimal(Calculos.CalcularAntiguedad(n.SalarioOrdinario, n.FechaContratacion).ToString("N2"));
                PagoRiesgoLaboral = Convert.ToDecimal(((int)Ingreso.Where(x => x.TipoIngreso == "PAGO POR RIESGO LABORAL" && x.NumeroEmpleado == n.NumeroEmpleado).Sum(x => x.Cantidad) * Calculos.CalcularPagoRiesgoLaboral_Nocturnidad(n.SalarioOrdinario)).ToString("N2"));
                PagoNocturnidad = Convert.ToDecimal(((int)Ingreso.Where(x => x.TipoIngreso == "PAGO POR NOCTURNIDAD" && x.NumeroEmpleado == n.NumeroEmpleado).Sum(x => x.Cantidad) * Calculos.CalcularPagoRiesgoLaboral_Nocturnidad(n.SalarioOrdinario)).ToString("N2"));
                HorasExtras = Convert.ToDecimal((Calculos.CalcularHoraExtraTrabajoEmpleado(n.SalarioOrdinario, (int)Ingreso.Where(x => x.TipoIngreso == "HORAS EXTRAS" && x.NumeroEmpleado == n.NumeroEmpleado).Sum(x => x.Cantidad))).ToString("N2"));
                SalarioExtraordinario = Antiguedad + PagoRiesgoLaboral + PagoNocturnidad + HorasExtras;
                SalarioBruto = n.SalarioOrdinario + SalarioExtraordinario;
                INSSLaboral = Convert.ToDecimal(Calculos.CalcularINSSLaboral(SalarioBruto).ToString("N2"));
                IR = Convert.ToDecimal(Calculos.CalcularIR((SalarioBruto - INSSLaboral)).ToString("N2"));
                SalarioNeto = SalarioBruto - INSSLaboral - IR;
                INSSPatronal = Convert.ToDecimal(Calculos.CalcularINSSPatronal(SalarioBruto).ToString("N2"));

                Nomina.Add(new Nominas {
                    NoNomina = Nominas.Count,
                    NoEmpleado = n.NumeroEmpleado,
                    NombreEmpleado = n.Nombre,
                    SalarioBasico = Convert.ToDecimal(n.SalarioOrdinario.ToString("N2")),
                    Antiguedad = Antiguedad,
                    PagoRiesgoLaboral = PagoRiesgoLaboral,
                    PagoNocturnidad = PagoNocturnidad,
                    HorasExtras = HorasExtras,
                    SalarioExtraordinario = SalarioExtraordinario,
                    SalarioBruto = SalarioBruto,
                    INSSLaboral = INSSLaboral,
                    IR = IR,
                    SalarioNeto = SalarioNeto,
                    INSSPatronal = INSSPatronal
                });
            }

            return Nomina;
        }

        public static int GuardarNomina(List<MostrarNominas> Mostrar_Nominas, List<Nominas> DetallesNominas)
        {
            try
            {
                Mostrar_Nominas.Add(new MostrarNominas
                {
                    NoNomina = (Mostrar_Nominas.Count + 1),
                    Fecha_Registro = DateTime.Now,
                    Mes = DateTime.Now.ToString("MMMM").ToUpper(),
                    Año = DateTime.Now.Year,
                    Activo = true
                });

                if (!File.Exists(rutaArchivoCsvNominas))
                {
                    File.Create(rutaArchivoCsvNominas).Close();
                }

                using (var writer = new StreamWriter(rutaArchivoCsvNominas))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Mostrar_Nominas);
                }

                List<Nominas> NuevaNomina = CrearNomina(Mostrar_Nominas);

                foreach (var n in NuevaNomina)
                {
                    DetallesNominas.Add(new Nominas
                    {
                        NoNomina = n.NoNomina,
                        NoEmpleado = n.NoEmpleado,
                        NombreEmpleado = n.NombreEmpleado,
                        SalarioBasico = n.SalarioBasico,
                        Antiguedad = n.Antiguedad,
                        PagoRiesgoLaboral = n.PagoRiesgoLaboral,
                        PagoNocturnidad = n.PagoNocturnidad,
                        HorasExtras = n.HorasExtras,
                        SalarioExtraordinario = n.SalarioExtraordinario,
                        SalarioBruto = n.SalarioBruto,
                        INSSLaboral = n.INSSLaboral,
                        IR = n.IR,
                        SalarioNeto = n.SalarioNeto,
                        INSSPatronal = n.INSSPatronal
                    });
                }

                if (!File.Exists(rutaArchivoCsvDetallesNominas))
                {
                    File.Create(rutaArchivoCsvDetallesNominas).Close();
                }

                using (var writer = new StreamWriter(rutaArchivoCsvDetallesNominas))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(DetallesNominas);
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int DesactivarNomina(List<MostrarNominas> Nomina, int NoNomina)
        {
            try
            {
                MostrarNominas N = Nomina.FirstOrDefault(x => x.NoNomina == NoNomina);

                if (N != null)
                {
                    N.Activo = false;
                }

                using (var writer = new StreamWriter(rutaArchivoCsvNominas))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Nomina);
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