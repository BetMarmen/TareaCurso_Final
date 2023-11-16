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
    public class IngresosNom
    {
        static string rutaArchivoCsvIngresos = $"{Calculos.PathArchivos}/ingresos.csv";

        public static int AgregarIngresoEmpleado(List<Ingresos> Ingreso, int NoEmpleado, string TipoIngreso, int Cantidad)
        {
            try
            {
                Ingreso.Add(new Ingresos 
                { 
                    NumeroEmpleado = NoEmpleado,
                    TipoIngreso = TipoIngreso,
                    Cantidad = Cantidad,
                    Fecha_Registro = Convert.ToDateTime(DateTime.Now.ToString("d"))
                });

                if (!File.Exists(rutaArchivoCsvIngresos))
                {
                    File.Create(rutaArchivoCsvIngresos).Close();
                }

                using (var writer = new StreamWriter(rutaArchivoCsvIngresos))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Ingreso);
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static List<Ingresos> CargarIngresos()
        {
            try
            {
                List<Ingresos> Ingreso = new List<Ingresos>();
                if (File.Exists(rutaArchivoCsvIngresos))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvIngresos))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        Ingreso = csv.GetRecords<Ingresos>().ToList();
                    }
                }

                return Ingreso;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Ingresos> CargarIngresosEmpleado(int NoEmpleado, string TipoIngreso, DateTime Fecha)
        {
            try
            {
                List<Ingresos> IngresoEmpleado = new List<Ingresos>();
                if (File.Exists(rutaArchivoCsvIngresos))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvIngresos))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        IngresoEmpleado = csv.GetRecords<Ingresos>().Where(x => x.NumeroEmpleado == NoEmpleado && x.TipoIngreso == TipoIngreso && (x.Fecha_Registro >= Fecha && x.Fecha_Registro <= Fecha)).ToList();
                    }
                }

                return IngresoEmpleado;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}