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

namespace TareaCurso_Anahi.Formularios.Ingreso
{
    public partial class AgregarIngresosEmpleado : Form
    {
        public List<Empleados> Empleado { get; set; }
        public List<Ingresos> Ingreso { get; set; }
        public AgregarIngresosEmpleado()
        {
            InitializeComponent();
        }

        private void Agregar_Ingresos_Empleado_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Empleado = EmpleadosNom.CargarEmpleados().Where(x => x.Activo == true).ToList();
            Ingreso = IngresosNom.CargarIngresos();

            CmbEmpleado.DataSource = Empleado;
            CmbEmpleado.ValueMember = "NumeroEmpleado";
            CmbEmpleado.DisplayMember = "Nombre";
            CmbEmpleado.SelectedIndex = 0;

            List<string> TiposIngresos = new List<string> 
            { 
                "PAGO POR RIESGO LABORAL",
                "PAGO POR NOCTURNIDAD",
                "HORAS EXTRAS"
            };

            CmbTipoIngreso.DataSource = TiposIngresos;
            CmbTipoIngreso.SelectedIndex = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TipoIngreso = CmbTipoIngreso.Text.ToString();
            if (TipoIngreso == "PAGO POR RIESGO LABORAL" || TipoIngreso == "PAGO POR NOCTURNIDAD")
            {
                TxtCantidad.Clear();
                TxtCantidad.Enabled = false;
                TxtValorMonetario.Text = Calculos.CalcularPagoRiesgoLaboral_Nocturnidad((decimal)Empleado.Where(x => x.NumeroEmpleado == (int)CmbEmpleado.SelectedValue).Select(x => x.SalarioOrdinario).FirstOrDefault()).ToString("N2");
            }
            else if (TipoIngreso == "HORAS EXTRAS")
            {
                TxtCantidad.Clear();
                TxtCantidad.Enabled = true;
                TxtValorMonetario.Clear();
            }
        }

        private void CmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbTipoIngreso_SelectedIndexChanged(null, null);
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            decimal SalarioEmpleado = (decimal)Empleado.Where(x => x.NumeroEmpleado == (int)CmbEmpleado.SelectedValue).Select(x => x.SalarioOrdinario).FirstOrDefault();
            if (int.TryParse(TxtCantidad.Text, out int Cantidad) || String.IsNullOrEmpty(TxtCantidad.Text))
            {
                if (String.IsNullOrEmpty(TxtCantidad.Text))
                {
                    TxtValorMonetario.Clear();
                    return;
                }
                TxtValorMonetario.Text = Calculos.CalcularHoraExtraTrabajoEmpleado(SalarioEmpleado, Cantidad).ToString("N2");
            }
            else
            {
                MessageBox.Show("Recuerda que en la cantidad de horas solamente pueden ser valores numéricos enteros!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCantidad.Text = TxtCantidad.Text.Substring(0, TxtCantidad.Text.Length - 1);
                TxtCantidad.SelectionStart = TxtCantidad.Text.Length;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estás seguro de querer aplicarle un ingreso a este empleado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;

                int NoEmpleado = (int)CmbEmpleado.SelectedValue, Cantidad = 0;
                string TipoIngreso = CmbTipoIngreso.Text.ToString();

                if ((TipoIngreso == "PAGO POR RIESGO LABORAL" || TipoIngreso == "PAGO POR NOCTURNIDAD") && !String.IsNullOrEmpty(TxtValorMonetario.Text))
                {
                    Cantidad = 1;
                }
                else if (TipoIngreso == "HORAS EXTRAS" && !String.IsNullOrEmpty(TxtValorMonetario.Text))
                {
                    Cantidad = Convert.ToInt32(TxtCantidad.Text);
                }

                int OkAgregar = IngresosNom.AgregarIngresoEmpleado(Ingreso, NoEmpleado, TipoIngreso, Cantidad);

                if (OkAgregar == 1)
                    MessageBox.Show("El ingreso ha sido registrado exitosamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El ingreso no ha sido registrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}