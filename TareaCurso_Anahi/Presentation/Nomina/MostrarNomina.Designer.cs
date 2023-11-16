
namespace TareaCurso_Anahi.Formularios.Nomina
{
    partial class MostrarNomina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvNominas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceNominas = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStripNomina = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verCálculosDeNóminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.desactivarNóminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNominas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNominas)).BeginInit();
            this.contextMenuStripNomina.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvNominas
            // 
            this.DgvNominas.AllowUserToAddRows = false;
            this.DgvNominas.AllowUserToDeleteRows = false;
            this.DgvNominas.AllowUserToResizeColumns = false;
            this.DgvNominas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvNominas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvNominas.AutoGenerateColumns = false;
            this.DgvNominas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvNominas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvNominas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvNominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNominas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DgvNominas.DataSource = this.bindingSourceNominas;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvNominas.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvNominas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvNominas.Location = new System.Drawing.Point(0, 0);
            this.DgvNominas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DgvNominas.Name = "DgvNominas";
            this.DgvNominas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvNominas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvNominas.RowHeadersWidth = 62;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvNominas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvNominas.RowTemplate.Height = 28;
            this.DgvNominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNominas.Size = new System.Drawing.Size(707, 244);
            this.DgvNominas.TabIndex = 0;
            this.DgvNominas.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvNominas_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NoNomina";
            this.Column1.HeaderText = "Número de Nómina";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 113;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Mes";
            this.Column2.HeaderText = "Mes de Registro";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Año";
            this.Column3.HeaderText = "Año de Registro";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 99;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Fecha_Registro";
            this.Column4.HeaderText = "Fecha de Registro";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 109;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Activo";
            this.Column5.HeaderText = "Activo";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 62;
            // 
            // contextMenuStripNomina
            // 
            this.contextMenuStripNomina.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripNomina.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCálculosDeNóminaToolStripMenuItem,
            this.toolStripSeparator1,
            this.desactivarNóminaToolStripMenuItem});
            this.contextMenuStripNomina.Name = "contextMenuStripNomina";
            this.contextMenuStripNomina.Size = new System.Drawing.Size(232, 58);
            // 
            // verCálculosDeNóminaToolStripMenuItem
            // 
            this.verCálculosDeNóminaToolStripMenuItem.Name = "verCálculosDeNóminaToolStripMenuItem";
            this.verCálculosDeNóminaToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.verCálculosDeNóminaToolStripMenuItem.Text = "Ver cálculos de nómina";
            this.verCálculosDeNóminaToolStripMenuItem.Click += new System.EventHandler(this.verCálculosDeNóminaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // desactivarNóminaToolStripMenuItem
            // 
            this.desactivarNóminaToolStripMenuItem.Name = "desactivarNóminaToolStripMenuItem";
            this.desactivarNóminaToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.desactivarNóminaToolStripMenuItem.Text = "Desactivar nómina";
            this.desactivarNóminaToolStripMenuItem.Click += new System.EventHandler(this.desactivarNóminaToolStripMenuItem_Click);
            // 
            // Mostrar_Nomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(707, 244);
            this.Controls.Add(this.DgvNominas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Mostrar_Nomina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nóminas registradas";
            ((System.ComponentModel.ISupportInitialize)(this.DgvNominas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNominas)).EndInit();
            this.contextMenuStripNomina.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvNominas;
        private System.Windows.Forms.BindingSource bindingSourceNominas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNomina;
        private System.Windows.Forms.ToolStripMenuItem verCálculosDeNóminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem desactivarNóminaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}