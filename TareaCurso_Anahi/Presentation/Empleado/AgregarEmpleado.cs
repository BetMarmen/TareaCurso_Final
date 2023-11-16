using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaCurso_Anahi.Negocio;
using TareaCurso_Anahi.POO;

namespace TareaCurso_Anahi.Formularios.Empleado
{
    public partial class AgregarEmpleado : Form
    {
        public List<Empleados> Empleado { get; set; }
        public int NumEmpleado { get; set; }
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private void Agregar_Empleado_Load(object sender, EventArgs e)
        {
            CargarDatos();
            if (Empleado != null)
            {
                TxtNoEmpleado.Text = (Empleado.Count + 1).ToString();
            }
            DtpFechaNacimiento.Value = DateTime.Now;
            DtpFechaContratacion.Value = DateTime.Now;
            DtpFechaCierreContrato.Value = DateTime.Now.AddYears(1);

            if (NumEmpleado != 0)
            {
                this.Text = "Editar empleado";
                label15.Visible = true;
                CbActivo.Visible = true;

                var DatosEmpleado = Empleado.Where(x => x.NumeroEmpleado == NumEmpleado).FirstOrDefault();
                TxtNoEmpleado.Text = DatosEmpleado.NumeroEmpleado.ToString();
                TxtNoCedula.Text = DatosEmpleado.NumeroCedula.ToString();
                TxtNoINSS.Text = DatosEmpleado.NumeroINSS.ToString();
                TxtNoRUC.Text = DatosEmpleado.NumeroRUC.ToString();
                TxtNombre.Text = DatosEmpleado.Nombre.ToString();
                TxtTelefono.Text = DatosEmpleado.Telefono.ToString();
                TxtCelular.Text = DatosEmpleado.Celular.ToString();
                TxtDireccion.Text = DatosEmpleado.Direccion.ToString();
                int Sexo = CmbSexo.FindString(DatosEmpleado.Sexo.ToString());
                CmbSexo.SelectedIndex = Sexo;
                int EstadoCivil = CmbEstadoCivil.FindString(DatosEmpleado.EstadoCivil.ToString());
                CmbEstadoCivil.SelectedIndex = EstadoCivil;
                DtpFechaNacimiento.Value = DatosEmpleado.FechaNacimiento;
                DtpFechaContratacion.Value = DatosEmpleado.FechaContratacion;
                DtpFechaCierreContrato.Value = DatosEmpleado.FechaCierreContrato;
                TxtSalarioOrdinario.Text = DatosEmpleado.SalarioOrdinario.ToString("N2");
                CbActivo.Checked = Convert.ToBoolean(DatosEmpleado.Activo);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacionesCampos();

                int NoEmpleado = Convert.ToInt32(TxtNoEmpleado.Text);
                string NoCedula = TxtNoCedula.Text.ToUpper().ToString();
                string NoINSS = TxtNoINSS.Text.ToString();
                string NoRUC = TxtNoRUC.Text.ToUpper().ToString();
                string Nombre = TxtNombre.Text.ToUpper().ToString();
                string Telefono = TxtTelefono.Text.ToUpper().ToString();
                string Celular = TxtCelular.Text.ToUpper().ToString();
                string Direccion = TxtDireccion.Text.ToUpper().ToString();
                string Sexo = CmbSexo.Text.ToUpper().ToString();
                string EstadoCivil = CmbEstadoCivil.Text.ToUpper().ToString();
                DateTime FechaNacimiento = Convert.ToDateTime(DtpFechaNacimiento.Value.ToString("d"));
                DateTime FechaContratacion = Convert.ToDateTime(DtpFechaContratacion.Value.ToString("d"));
                DateTime FechaCierreContrato = Convert.ToDateTime(DtpFechaCierreContrato.Value.ToString("d"));
                decimal SalarioOrdinario = Convert.ToDecimal(TxtSalarioOrdinario.Text.ToString());
                bool Activo = Convert.ToBoolean(CbActivo.Checked);

                if (NumEmpleado == 0)
                {
                    if (MessageBox.Show("¿Está seguro de guardar este empleado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                    int OkAgregar = EmpleadosNom.AgregarEmpleado(Empleado, NoEmpleado, NoCedula, NoINSS, NoRUC, Nombre, Telefono, Celular, Direccion, Sexo, EstadoCivil, SalarioOrdinario, FechaNacimiento, FechaContratacion, FechaCierreContrato);

                    if (OkAgregar == 1)
                    {
                        MessageBox.Show("El empleado ha sido registrado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El empleado no ha sido registrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro de editar este empleado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                    int OkEditar = EmpleadosNom.EditarEmpleado(Empleado, NoEmpleado, NoCedula, NoINSS, NoRUC, Nombre, Telefono, Celular, Direccion, Sexo, EstadoCivil, SalarioOrdinario, FechaNacimiento, FechaContratacion, FechaCierreContrato, Activo);

                    if (OkEditar == 1)
                    {
                        MessageBox.Show("El empleado ha sido editado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El empleado no ha sido editado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            Empleado = EmpleadosNom.CargarEmpleados();

            List<string> Sexos = new List<string> { 
                "Masculino",
                "Femenino"
            };
            CmbSexo.DataSource = Sexos;
            CmbSexo.SelectedIndex = 0;

            List<string> EstadosCiviles = new List<string> { 
                "Soltero(a)",
                "Casado",
                "Divorciado",
                "Viudo(a)"
            };

            CmbEstadoCivil.DataSource = EstadosCiviles;
            CmbEstadoCivil.SelectedIndex = 0;
        }

        private void ValidacionesCampos()
        {
            foreach (GroupBox G in this.Controls.OfType<GroupBox>().Cast<GroupBox>())
            {
                foreach (Control T in G.Controls)
                {
                    if (T is TextBox)
                    {
                        if (String.IsNullOrEmpty(T.Text))
                        {
                            throw new ArgumentException("Los campos no pueden ser nulos!");
                        }
                    }
                    if (T is MaskedTextBox)
                    {
                        MaskedTextBox t = T as MaskedTextBox;
                        string mask = t.Mask;
                        t.Mask = "";
                        if (String.IsNullOrEmpty(t.Text))
                        {
                            t.Mask = mask;
                            throw new ArgumentException("Los campos no pueden ser nulos!");
                        }
                        t.Mask = mask;

                        if (t.Name == "TxtSalarioOrdinario" && !decimal.TryParse(t.Text, out decimal x))
                            throw new ArgumentException("El Salario Ordinario solamente debe llevar carácteres numéricos!");
                    }
                }
            }
            if (Convert.ToDateTime(DtpFechaNacimiento.Value) >= Convert.ToDateTime(DtpFechaContratacion.Value))
            {
                throw new ArgumentException("La fecha de nacimiento no puede ser mayor o igual a la de contratación!");
            }
            if (Convert.ToDateTime(DtpFechaContratacion.Value) >= Convert.ToDateTime(DtpFechaCierreContrato.Value))
            {
                throw new ArgumentException("La fecha de contratación no puede ser mayor o igual a la de cierre de contrato!");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (GroupBox G in this.Controls.OfType<GroupBox>().Cast<GroupBox>())
            {
                foreach (Control T in G.Controls)
                {
                    if (T is TextBox || T is MaskedTextBox)
                        if (T.Name != "TxtNoEmpleado")
                            T.Text = "";
                }
            }
        }

        private void CbActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (CbActivo.Checked)
                CbActivo.Text = "Activo";
            else
                CbActivo.Text = "Inactivo";
        }

        private void TxtNoCedula_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(TxtNoCedula.Text.Substring(4, 6), "ddMMyy", null, DateTimeStyles.None, out DateTime fechaNacimiento))
            {
                DtpFechaNacimiento.Value = fechaNacimiento;
            }
        }
    }
}