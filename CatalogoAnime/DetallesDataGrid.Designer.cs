using AxWMPLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace CatalogoAnime
{
    using model;
    partial class DetallesDataGrid : Form
    {
        
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
       
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            btnFiltrar = new Button();
            txtNombre = new TextBox();
            cmbTipo = new ComboBox();
            cmbEstado = new ComboBox();
            txtGenero = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(839, 200);
            dataGridView.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(709, 220);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 220);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Items.AddRange(new object[] { "Seleccione...", "TV", "Pelicula" });
            cmbTipo.Location = new Point(386, 221);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(150, 23);
            cmbTipo.SelectedIndex = 0;
            cmbTipo.TabIndex = 0;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.AddRange(new object[] { "Seleccione...", "En Emisión", "Finalizado" });
            cmbEstado.Location = new Point(542, 220);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.SelectedIndex = 0;
            cmbEstado.TabIndex = 0;
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(242, 220);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(138, 23);
            txtGenero.TabIndex = 5;
            // 
            // DetallesDataGrid
            // 
            ClientSize = new Size(839, 263);
            Controls.Add(txtGenero);
            Controls.Add(dataGridView);
            Controls.Add(txtNombre);
            Controls.Add(cmbTipo);
            Controls.Add(cmbEstado);
            Controls.Add(btnFiltrar);
            Name = "DetallesDataGrid";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnFiltrar;
        private TextBox txtNombre;
        private ComboBox cmbTipo;
        private ComboBox cmbEstado;
        private TextBox txtGenero;

    }
}