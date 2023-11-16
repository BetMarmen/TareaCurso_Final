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
    public partial class MostrarNomina : Form
    {
        public List<MostrarNominas> Nomina { get; set; }
        public MostrarNomina()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            Nomina = NominaNom.CargarNominasCreadas();
            bindingSourceNominas.DataSource = Nomina;
        }

        private void DgvNominas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && e.RowIndex >= 0)
            {
                contextMenuStripNomina.Show(DgvNominas, DgvNominas.PointToClient(Cursor.Position));

                int NoNomina = Convert.ToInt32(DgvNominas.SelectedRows[0].Cells[0].Value);
                bool Activo = Convert.ToBoolean(Nomina.Where(x => x.NoNomina == NoNomina).Select(x => x.Activo).FirstOrDefault());
                if (Activo == true)
                {
                    desactivarNóminaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    desactivarNóminaToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void verCálculosDeNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvNominas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = DgvNominas.SelectedRows[0];

                if (filaSeleccionada.Cells[0].Value != null)
                {
                    int numeroNomina = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                    RealizarNomina Form = new RealizarNomina();
                    Form.NumeroNomina = numeroNomina;
                    Form.ShowDialog(this);
                    Form.Dispose();
                }
            }
        }

        private void desactivarNóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvNominas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = DgvNominas.SelectedRows[0];

                if (filaSeleccionada.Cells[0].Value != null)
                {
                    int numeroNomina = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                    if (MessageBox.Show("¿Está seguro de desactivar esta nómina? \nLos cambios no son reversibles!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    int OkDesactivar = NominaNom.DesactivarNomina(Nomina, numeroNomina);

                    if (OkDesactivar == 1)
                    {
                        MessageBox.Show("Se desactivó la nómina exitosamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo desactivar la nómina!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}