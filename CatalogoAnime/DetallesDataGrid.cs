using CatalogoAnime.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class DetallesDataGrid : Form
    {
        private DataGridView dataGridView; // Componente DataGridView para mostrar los animes
        private List<Anime> lstAnime;  // Lista original de animes

        // Constructor de la clase, recibe una lista de animes
        public DetallesDataGrid(List<Anime> lstAnime)
        {
            InitializeComponent(); // Inicializamos los componentes del form

            this.lstAnime = lstAnime;  // Asignamos la lista original a la variable

            // Asignar la lista original al DataGridView
            dataGridView.DataSource = lstAnime;
        }

        // Evento que se ejecuta cuando se presiona el boton de filtrar
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        // Metodo que realiza el filtrado de la lista 
        private void Filtrar()
        {
            try
            {
                // Obtener los valores de los filtros
                string nombreFiltro = txtNombre.Text.Trim();
                string generoFiltro = txtGenero.Text.Trim();
                string tipoFiltro = cmbTipo.SelectedItem?.ToString();  // Se asegura de que no sea null
                string estadoFiltro = cmbEstado.SelectedItem?.ToString();  // Se asegura de que no sea null

                // Filtrar la lista original basándonos en los filtros
                var listaFiltrada = lstAnime.Where(anime =>
                    // Filtrar por nombre si no está vacío
                    (string.IsNullOrEmpty(nombreFiltro) || anime.Nombre.Contains(nombreFiltro, StringComparison.OrdinalIgnoreCase)) &&
                    // Filtrar por género si no está vacío
                    (string.IsNullOrEmpty(generoFiltro) || anime.Genero.Contains(generoFiltro, StringComparison.OrdinalIgnoreCase)) &&
                    // Filtrar por tipo de anime si se ha seleccionado un tipo
                    (string.IsNullOrEmpty(tipoFiltro) || tipoFiltro == "Seleccione..." ||
                        (tipoFiltro == "TV" && anime.TipoAnime == TipoAnime.TV) ||
                        (tipoFiltro == "Pelicula" && anime.TipoAnime == TipoAnime.Pelicula)) &&
                    // Filtrar por estado si se ha seleccionado un estado
                    (string.IsNullOrEmpty(estadoFiltro) || estadoFiltro == "Seleccione..." || anime.Estado == (estadoFiltro == "En Emisión"))
                ).ToList();  // Convertir a List<Anime> para que podamos usar Count()

                // Actualizar el DataGridView con la lista filtrada
                dataGridView.DataSource = listaFiltrada;

                // Verificar si hay resultados
                if (listaFiltrada.Count == 0)
                {
                    // Mostrar un mensaje si no se encuentran resultados
                    MessageBox.Show("No se encontraron resultados para los filtros aplicados.");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el filtrado
                MessageBox.Show("Error al aplicar el filtro: " + ex.Message);
            }
        }
    }
}
