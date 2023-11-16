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
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi.Formularios.Nomina
{
    public partial class RealizarNomina : Form
    {
        public List<Empleados> Empleado { get; set; }
        public List<Ingresos> Ingreso { get; set; }
        public List<MostrarNominas> Nominas { get; set; }
        public List<Nominas> DetalleNomina { get; set; }
        public int NumeroNomina { get; set; }
        public RealizarNomina()
        {
            InitializeComponent();
        }

        private void CargarNomina()
        {
            Empleado = EmpleadosNom.CargarEmpleados();
            Ingreso = IngresosNom.CargarIngresos();
            Nominas = NominaNom.CargarNominasCreadas();
            DetalleNomina = NominaNom.CrearNomina(Nominas);
            bindingSourceNomina.DataSource = DetalleNomina;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Nominas = NominaNom.CargarNominasCreadas();
            DetalleNomina = NominaNom.CargarDetallesNominas();

            foreach (var n in Nominas)
            {
                if ((n.Mes == DateTime.Now.ToString("MMMM").ToUpper() && n.Año == DateTime.Now.Year) && n.Activo == true)
                {
                    MessageBox.Show("Una nómina ya fue guardada para este mes!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show("¿Está seguro de guardar esta nómina?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            int OkNomina = NominaNom.GuardarNomina(Nominas, DetalleNomina);

            if (OkNomina == 1)
            {
                MessageBox.Show("La nómina se guardó exitosamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("La nómina no se guardó!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Realizar_Nomina_Load(object sender, EventArgs e)
        {
            if (NumeroNomina == 0)
            {
                this.Text = $"Realizar nómina para el mes {DateTime.Now:MMMM} del año {DateTime.Now.Year}";
                CargarNomina();
            }
            else
            {
                var Nomina = NominaNom.CargarNominasCreadas().Where(x => x.NoNomina == NumeroNomina).FirstOrDefault();
                this.Text = $"Mostrar cálculos de nómina realizada el mes {Nomina.Mes.ToLower()} del año {Nomina.Año}";
                this.DgvNomina.Dock = DockStyle.Fill;
                this.BtnGuardar.Visible = false;
                this.BtnCancelar.Visible = false;
                DetalleNomina = NominaNom.CargarDetallesNominas().Where(x => x.NoNomina == NumeroNomina).ToList();
                bindingSourceNomina.DataSource = DetalleNomina;
            }
        }
    }
}