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
    public class UsuariosNom
    {
        static string rutaArchivoCsvUsuarios = $"{Calculos.PathArchivos}/usuarios.csv";

        public static List<Usuario> CargarUsuarios()
        {
            try
            {
                List<Usuario> Usuario = new List<Usuario>();
                if (File.Exists(rutaArchivoCsvUsuarios))
                {
                    using (var reader = new StreamReader(rutaArchivoCsvUsuarios))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        Usuario = csv.GetRecords<Usuario>().ToList();
                    }
                }

                return Usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int AgregarUsuario(List<Usuario> Usuario, string Nombre, string UsuarioLogin, string Contraseña)
        {
            try
            {
                Usuario.Add(new Usuario
                {
                    Nombre = Nombre,
                    UsuarioLogin = UsuarioLogin,
                    Contraseña = Contraseña
                });

                if (!File.Exists(rutaArchivoCsvUsuarios))
                {
                    File.Create(rutaArchivoCsvUsuarios).Close();
                }

                using (var writer = new StreamWriter(rutaArchivoCsvUsuarios))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(Usuario);
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