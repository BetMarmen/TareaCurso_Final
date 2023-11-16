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
    public partial class Mostrar_Empleados : Form
    {
        public List<Empleados> Empleado { get; set; }
        public Mostrar_Empleados()
        {
            InitializeComponent();
        }

        private void Mostrar_Empleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            Empleado = EmpleadosNom.CargarEmpleados();
            bindingSourceEmpleados.DataSource = Empleado;
        }

        private void EditarEmpleado_Click(object sender, EventArgs e)
        {
            if (DgvEmpleados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = DgvEmpleados.SelectedRows[0];

                if (filaSeleccionada.Cells[0].Value != null)
                {
                    int numeroEmpleado = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                    AgregarEmpleado agregarEmpleado = new AgregarEmpleado();
                    agregarEmpleado.NumEmpleado = numeroEmpleado;
                    agregarEmpleado.ShowDialog(this);
                    agregarEmpleado.Dispose();
                    CargarEmpleados();
                }
            }
        }

        private void DgvEmpleados_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && e.RowIndex >= 0)
            {
                contextMenuStripEmpleado.Show(DgvEmpleados, DgvEmpleados.PointToClient(Cursor.Position));
            }
        }
    }
}