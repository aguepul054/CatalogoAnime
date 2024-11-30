using CatalogoAnime.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class DetallesDataGrid : Form
    {
        private DataGridView dataGridView;
        private BindingSource bindingSource;

        // Controles para el filtrado
        private TextBox txtNombre;
        private ComboBox cmbTipo;
        private ComboBox cmbEstado;
        private Button btnFiltrar;

        public DetallesDataGrid(List<Anime> lstAnime)
        {
            InitializeComponent();

            // Inicializar BindingSource
            bindingSource = new BindingSource();
            bindingSource.DataSource = lstAnime;

            // Asignar el DataGridView al formulario
            dataGridView.DataSource = bindingSource;
        }

        private void InitializeComponent()
        {
            // Crear los controles y asignar propiedades
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridView
            // 
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.AutoGenerateColumns = true;
            this.dataGridView.Height = 200;
            this.dataGridView.ReadOnly = true; // No permitir edición
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(20, 220);
            this.txtNombre.Width = 200;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Location = new System.Drawing.Point(240, 220);
            this.cmbTipo.Width = 150;
            this.cmbTipo.Items.Add("TV");
            this.cmbTipo.Items.Add("Pelicula");
            this.cmbTipo.SelectedIndex = 0; // Valor predeterminado
            // 
            // cmbEstado
            // 
            this.cmbEstado.Location = new System.Drawing.Point(400, 220);
            this.cmbEstado.Width = 150;
            this.cmbEstado.Items.Add("En Emisión");
            this.cmbEstado.Items.Add("Finalizado");
            this.cmbEstado.SelectedIndex = 0; // Valor predeterminado
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(580, 220);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new EventHandler(this.btnFiltrar_Click);

            // Agregar controles al formulario
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnFiltrar);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            try
            {
                // Obtener los valores de los filtros
                string nombreFiltro = txtNombre.Text;
                string tipoFiltro = cmbTipo.SelectedItem.ToString();
                string estadoFiltro = cmbEstado.SelectedItem.ToString();

                // Crear la expresión de filtro
                string filtro = "Nombre LIKE '%" + nombreFiltro + "%'";

                if (!string.IsNullOrEmpty(tipoFiltro))
                    filtro += " AND TipoAnime = '" + tipoFiltro + "'";

                // Asegúrate de que Estado se evalúe correctamente
                bool estadoBool = estadoFiltro == "En Emisión"; // Verifica que el filtro sea un booleano
                filtro += " AND Estado = " + (estadoBool ? "True" : "False");

                // Aplicar el filtro al BindingSource
                bindingSource.Filter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar el filtro: " + ex.Message);
            }
        }
    }
}
