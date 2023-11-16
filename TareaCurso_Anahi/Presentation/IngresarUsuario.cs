using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaCurso_Anahi.Negocio;

namespace TareaCurso_Anahi.Formularios
{
    public partial class IngresarUsuario : Form
    {
        public IngresarUsuario()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {
                MessageBox.Show("El nombre no puede ser nulo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TxtUsuario.Text))
            {
                MessageBox.Show("El usuario no puede ser nulo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(TxtContraseña.Text))
            {
                MessageBox.Show("La contraseña no puede ser nula!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var n in UsuariosNom.CargarUsuarios())
            {
                if (n.UsuarioLogin == TxtUsuario.Text.ToUpper())
                {
                    MessageBox.Show("Ya existe alguien con este usuario!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int OkIngresar = UsuariosNom.AgregarUsuario(UsuariosNom.CargarUsuarios(), TxtNombre.Text, TxtUsuario.Text.ToUpper(), TxtContraseña.Text);
            if (OkIngresar == 1)
            {
                MessageBox.Show("El usuario ha sido registrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario no se registró!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
