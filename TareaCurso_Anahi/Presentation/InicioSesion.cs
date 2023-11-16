using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaCurso_Anahi.Formularios;
using TareaCurso_Anahi.Negocio;
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi
{
    public partial class InicioSesion : Form
    {
        List<Usuario> Usuarios = new List<Usuario>();
        int contador = 3;
        public InicioSesion()
        {
            InitializeComponent();
            CargarDatos();

            if (Usuarios == null || Usuarios.Count == 0)
            {
                MessageBox.Show("No se encuentra ningún usuario registrado \nDebes ingresar uno inmediatamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                IngresarUsuario ingresarUsuario = new IngresarUsuario();
                ingresarUsuario.ShowDialog(this);
                ingresarUsuario.Dispose();
            }
        }

        private void CargarDatos()
        {
            Usuarios = UsuariosNom.CargarUsuarios();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            string nombre = "";
            bool Si = false;
            foreach (var n in Usuarios)
            {
                if (n.UsuarioLogin == TxtUsuario.Text.ToUpper() && n.Contraseña == TxtContraseña.Text)
                {
                    nombre = n.Nombre;
                    Si = true;
                }
            }

            if (Si)
            {
                MessageBox.Show($"Bienvenido al sistema, {nombre}!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;

                VistaPrincipal vistaPrincipal = new VistaPrincipal();
                vistaPrincipal.ShowDialog(this);
                vistaPrincipal.Dispose();
                this.Close();
            }
            else
            {
                contador--;
                if (contador > 0)
                {
                    MessageBox.Show($"Usuario o contraseña incorrectos! \nTiene {contador} intento(s) más", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"El sistema se cerrará debido a la falla de diversos intentos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void LinkLblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IngresarUsuario ingresarUsuario = new IngresarUsuario();
            ingresarUsuario.ShowDialog(this);
            ingresarUsuario.Dispose();
        }
    }
}