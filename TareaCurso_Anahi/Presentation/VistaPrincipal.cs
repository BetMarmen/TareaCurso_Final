using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaCurso_Anahi.POO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using TareaCurso_Anahi.Formularios;
using TareaCurso_Anahi.Formularios.Empleado;
using TareaCurso_Anahi.Formularios.Ingreso;
using TareaCurso_Anahi.Negocio;
using TareaCurso_Anahi.Formularios.Nomina;

namespace TareaCurso_Anahi
{
    public partial class VistaPrincipal : Form
    {
        public List<Empleados> Empleados { get; set; }
        public List<Ingresos> Ingresos { get; set; }
        public List<MostrarNominas> Nominas { get; set; }
        public List<Nominas> DetallesNominas { get; set; }
        public VistaPrincipal()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region Metodos Varios
        private bool ComprobarFormulario(Form form)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name && child.Text == form.Text)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        private void CargarDatos()
        {
            Empleados = EmpleadosNom.CargarEmpleados();
            Ingresos = IngresosNom.CargarIngresos();
            Nominas = NominaNom.CargarNominasCreadas();
            DetallesNominas = NominaNom.CargarDetallesNominas();
        }
        #endregion

        private void mostrarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            if (Empleados != null && Empleados.Count != 0)
            {
                Mostrar_Empleados mostrar_Empleados = new Mostrar_Empleados();
                if (ComprobarFormulario(mostrar_Empleados)) return;
                mostrar_Empleados.Empleado = Empleados;
                mostrar_Empleados.MdiParent = this;
                mostrar_Empleados.Show();
            }
            else MessageBox.Show("No se encuentra ningún empleado que mostrar!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            AgregarEmpleado agregarEmpleado = new AgregarEmpleado();
            if (ComprobarFormulario(agregarEmpleado)) return;
            agregarEmpleado.Empleado = Empleados;
            agregarEmpleado.MdiParent = this;
            agregarEmpleado.Show();
        }

        private void aplicarIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            if (Empleados != null && Empleados.Count != 0)
            {
                AgregarIngresosEmpleado agregarIngresosEmpleado = new AgregarIngresosEmpleado();
                if (ComprobarFormulario(agregarIngresosEmpleado)) return;
                agregarIngresosEmpleado.Empleado = Empleados;
                agregarIngresosEmpleado.Ingreso = Ingresos;
                agregarIngresosEmpleado.MdiParent = this;
                agregarIngresosEmpleado.Show();
            }
            else MessageBox.Show("No se encuentra ningún empleado al que aplicarle un ingreso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void realizarNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            if (Empleados != null && Empleados.Count != 0)
            {
                RealizarNomina realizarNomina = new RealizarNomina();
                if (ComprobarFormulario(realizarNomina)) return;
                realizarNomina.Empleado = Empleados;
                realizarNomina.Ingreso = Ingresos;
                realizarNomina.Nominas = Nominas;
                realizarNomina.DetalleNomina = DetallesNominas;
                realizarNomina.MdiParent = this;
                realizarNomina.Show();
            }
            else MessageBox.Show("No se encuentra ningún empleado para realizar la nómina!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mostrarNóminasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            if (Nominas != null && Nominas.Count != 0)
            {
                MostrarNomina mostrarNomina = new MostrarNomina();
                if (ComprobarFormulario(mostrarNomina)) return;
                mostrarNomina.Nomina = Nominas;
                mostrarNomina.MdiParent = this;
                mostrarNomina.Show();
            }
            else MessageBox.Show("No se encuentra ningún nómina registrada anteriormente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}