using CatalogoAnime.controller;
using CatalogoAnime.model;
using System.ComponentModel;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class PanelPrincipal : Form
    {
        private GestAnime gs;
        private string rutaImagen;
        private bool isAdding = false;
        private bool isModify = false;
        private int idRegistro = 0;
        public PanelPrincipal()
        {
            gs = new GestAnime();
            InitializeComponent();
            ibAnime.Enabled = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = true;


        }

        // Evento al cargar el formulario
        private void PanelPrincipal_Load(object sender, EventArgs e)
        {
            // Establecer valores predeterminados en los comboBox
            txtTipo.SelectedIndex = 0;
            txtEstado.SelectedIndex = 0;
            txtPeliculaUnica.SelectedIndex = 0;
        }

        // Evento para el botón Agregar (se activa para agregar un nuevo anime)
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (isAdding)
            {
                // Proceso para agregar un nuevo anime
                int contImg;
                string nombre = txtNombre.Text;
                string tipo = txtTipo.SelectedItem.ToString();
                string genero = txtGenero.Text;
                string estado = txtEstado.SelectedItem.ToString();

                // Control de la imagen
                if (ibAnime.Image == null)
                {
                    contImg = 0; // Si no hay imagen por defecto sera 0
                }
                else
                {
                    contImg = ++gs.idImagen; // SI hay imagen, incrementar el ID de la imagen
                    gs.GuardarImagen(rutaImagen, contImg); // Guardamos imagen
                }

                // Creación de un nuevo anime basado en el tipo ( TV o Pelicula)
                if (tipo == "TV")
                {
                    int numCaps = Int32.Parse(txtNumCap.Text);
                    Serie s = new Serie();
                    s.Nombre = nombre;
                    s.TipoAnime = TipoAnime.TV;
                    s.Genero = genero;
                    s.Estado = s.getEstado(estado);
                    s.NumeroCapitulos = numCaps;
                    s.IdImagen = gs.idImagen;
                        if (gs.AgregarAnime(s)) // Agregar anime de tipo Serie
                        {
                            MessageBox.Show("Anime añadido correctamente.", "Añadir", MessageBoxButtons.OK);
                            btnSiguiente.Enabled = true;
                            btnAnterior.Enabled = true;
                        }
                    
                }
                else if (tipo == "Pelicula")
                {
                    string peliculaUnica = txtPeliculaUnica.SelectedItem.ToString();
                    Pelicula p = new Pelicula();
                    p.Nombre = nombre;
                    p.TipoAnime = TipoAnime.Pelicula;
                    p.Estado = p.getEstado(estado);
                    p.Genero = txtGenero.Text;
                    p.PeliculaUnica = p.getPeliculaUnica(peliculaUnica);
                    p.IdImagen = gs.idImagen;

                    if (gs.AgregarAnime(p)) // Agregar anime de tipo Pelicula
                    {
                        MessageBox.Show("Anime añadido correctamente.", "Añadir", MessageBoxButtons.OK);
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                    }
                }

                // Limpiamos campos y deshabilitamos los controles
                MostrarPrimero();
                DeshabilitarCampos();
                isAdding = false;
            }
            else
            {
                // Cambiar el estado a "Agregar"
                btnAgregar.Text = "Aceptar";
                HabilitarCampos();
                ibAnime.Enabled = true;
                isAdding = true;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
            }


        }
        // Metodo para habilitar campos
        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtTipo.Enabled = true;
            txtEstado.Enabled = true;
            txtGenero.Enabled = true;
            txtNumCap.Enabled = true;
            txtPeliculaUnica.Enabled = true;
        }
        // Metodo para deshabilitar campos
        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtGenero.Enabled = false;
            txtTipo.Enabled = false;
            txtEstado.Enabled = false;
            txtNumCap.Enabled = false;
            txtPeliculaUnica.Enabled = false;
        }

        // Evento para el botón Modificar ( para editar un anime )
        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (isModify)
            {
                // Proceso de modificación del anime
                int contImg;
                string nombre = txtNombre.Text;
                string tipo = txtTipo.SelectedItem.ToString();
                string genero = txtGenero.Text;
                string estado = txtEstado.SelectedItem.ToString();

                // Control de la imagen
                if (ibAnime.Image == null)
                {
                    contImg = 0; // Si no hay imagen, se le pondra por defecto o como valor principal 0
                }
                else
                {
                    contImg = ++gs.idImagen; // Incrementamos id si se le proporciona una nueva imagen
                    gs.GuardarImagen(rutaImagen, contImg); // Guardamos imagen
                }

                // Modificar segun tipo
                if (tipo == "TV")
                {
                    int numCaps = Int32.Parse(txtNumCap.Text);
                    Serie s = new Serie();
                    s.Nombre = nombre;
                    s.TipoAnime = TipoAnime.TV;
                    s.Genero = genero;
                    s.Estado = s.getEstado(estado);
                    s.NumeroCapitulos = numCaps;
                    s.IdImagen = gs.idImagen;

                    if (gs.ModificarAnime(s, idRegistro)) // Modificar el anime de tipo Serie
                    {
                        MessageBox.Show("Anime modificado correctamente.", "Modificar", MessageBoxButtons.OK);
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                    }
                }
                else if (tipo == "Pelicula")
                {
                    string peliculaUnica = txtPeliculaUnica.SelectedItem.ToString();
                    Pelicula p = new Pelicula();
                    p.Nombre = nombre;
                    p.TipoAnime = TipoAnime.Pelicula;
                    p.Estado = p.getEstado(estado);
                    p.Genero = txtGenero.Text;
                    p.PeliculaUnica = p.getPeliculaUnica(peliculaUnica);
                    p.IdImagen = gs.idImagen;

                    if (gs.ModificarAnime(p, idRegistro)) // Modificar anime de tipo Pelicula
                    {
                        MessageBox.Show("Anime modificado correctamente.", "Modificar", MessageBoxButtons.OK);
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                    }
                }
                MostrarPrimero();
                DeshabilitarCampos();
                isModify = false;
            }
            else
            {

                btnModificar.Text = "Aceptar";
                ibAnime.Enabled = true;
                HabilitarCampos();
                isModify = true;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
            }
        }

        // Evento para Borrar ( eliminar un anime ) 
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Anime a = new Anime();
            ibAnime.Image.Dispose(); // Liberar la imagen cargada
            ibAnime.Image = null; // Establecer imagen a null para que no haya nada
            gs.EliminarAnime(idRegistro); // Eliminar anime de la lista
            MostrarPrimero(); // Mostramos el primer anime despues de eliminar
        }

        // Evento para el boton Ordenar ( ordenar animes por el nombre o genero ) 
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Ordenar por nombre?", "Ordenar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                gs.OrdenarLista("Nombre"); // Ordenar por nombre
                MostrarPrimero();
            }
            else if (result == DialogResult.Cancel)
            {
                DialogResult result2 = MessageBox.Show("¿Ordenar por genero?", "Ordenar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.OK)
                {
                    gs.OrdenarLista("Genero"); // Ordenar por género
                    MostrarPrimero();
                }
                else
                {
                    MessageBox.Show("No se ordenara.");
                }
            }
        }

        // Evento para ver los detalles en un DataGrid
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            DetallesDataGrid formDataGrid = new DetallesDataGrid(gs.ListaAnime);
            formDataGrid.Show();
        }


        // Evento para cuando presionamos el boton Siguiente ( pasamos al siguiente anime )
        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            // Verificar si es el ultimo registro
            if (idRegistro >= gs.ListaAnime.Count - 1)
            {
                // Si estamos en el final, preguntar si agregar un nuevo anime
                DialogResult result = MessageBox.Show("Has llegado al final de la lista. ¿Deseas agregar un nuevo anime?",
                                                      "Agregar Nuevo Anime", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CrearNuevoAnimeVacio(); // Crear un nuevo anime vacio
                }
                else
                {
                    MessageBox.Show("No se agregará un nuevo anime.");
                }



            }
            else
            {
                // Si no estamos al final, obtener el siguiente anime
                Anime anime = gs.Siguiente(ref idRegistro);
                if (anime != null)
                {
                    MostrarAnime(anime); // Mostrar los detalles del anime
                    string rutaImagen = Path.Combine(gs.RUTAIMAGENES, anime.IdImagen + ".jpg");
                    
                    // Cargar la imagen si existe
                    if (File.Exists(rutaImagen))
                    {
                        ibAnime.Image = Image.FromFile(rutaImagen);
                    }
                    MostrarRegistro(); // Actualizar la informacion del registro
                    btnAnterior.Enabled = true; // Habilitar el botón "Anterior"
                }
            }


        }

        // Metodo que se ejecuta cuando se presiona el boton "Anterior"
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Verificar si estamos en el primer registro
            if (idRegistro <= 0)
            {
                btnAnterior.Enabled = false; // Deshabilitar el boton "Anterior"
                MessageBox.Show("Estás en el primer anime."); 
            }
            else
            {
                // Si no estamos en el primer anime, obtener el anime anterior
                Anime anime = gs.Anterior(ref idRegistro);

                if (anime != null)
                {
                    MostrarAnime(anime); // Mostrar los detalles del anime
                    string rutaImagen = Path.Combine(gs.RUTAIMAGENES, anime.IdImagen + ".jpg");

                    // Cargar la imagen si existe
                    if (File.Exists(rutaImagen))
                    {
                        ibAnime.Image = Image.FromFile(rutaImagen);
                    }
                    MostrarRegistro(); // Actualizar la información del registro
                }
            }


        }

        
        // Metodo para cargar una nueva imagen en el PictureBox
        private void ibAnime_Click(object sender, EventArgs e)
        {


            // Filtrar solo imagenes jpg y jpeg
            ofdCargarImagen.Filter = "Archivos de Imagen |*.jpg;*.jpeg";

            // Si se selecciona una imagen, cargarla en el PictureBox
            if (ofdCargarImagen.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = ofdCargarImagen.FileName;

                // Cargar y mostrar la imagen seleccionada
                System.Drawing.Image img = System.Drawing.Image.FromFile(rutaImagen);
                ibAnime.SizeMode = PictureBoxSizeMode.StretchImage;
                ibAnime.Image = img;
            }

        }

        // Metodo que se ejecuta cuando se cambia el tipo de anime
        private void txtTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = txtTipo.SelectedItem.ToString();

            // Mostrar el campo de numero de capitulos si el tipo es TV
            if (tipo == "TV")
            {
                txtNumCap.Visible = true;
                lblNumCap.Visible = true;
                txtPeliculaUnica.Visible = false;
                lblPeliculaUnica.Visible = false;

            }

            // Mostrar el campo de pelicula unica si el tipo es Pelicula
            else if (tipo == "Pelicula")
            {
                txtNumCap.Visible = false;
                lblNumCap.Visible = false;
                txtPeliculaUnica.Visible = true;
                lblPeliculaUnica.Visible = true;
            }
        }

       
        // Metodo para crear un nuevo anime vacio ( cuando se agrega uno nuevo )
        private void CrearNuevoAnimeVacio()
        {
            MostrarVacio(); // Limpiar los campos

            btnAgregar.Visible = true; // Mostrar el boton de agregar
            btnModificar.Visible = false; // Ocultar el boton de modificar
            // Habilitar los campos para que el usuario ingrese los datos
            txtNombre.Enabled = true;
            txtGenero.Enabled = true;
            txtTipo.Enabled = true;
            txtEstado.Enabled = true;
            txtNumCap.Enabled = true;
            txtPeliculaUnica.Enabled = true;
            ibAnime.Enabled = true;

            ibAnime.Image = null; // Limpiar la imagen cargada
            isAdding = true; // Cambiar el estado a agregar
            btnSiguiente.Enabled = false; // Deshabilitar los botones de navegacion
            btnAnterior.Enabled = false;
        }

        // Metodo para mostrar los detalles de un anime
        private void MostrarAnime(Anime anime)
        {
            if (anime != null)
            {
                // Llenar los campos con los detalles del anime
                txtNombre.Text = anime.Nombre;
                txtEstado.SelectedIndex = anime.Estado ? 1 : 2;
                txtGenero.Text = anime.Genero;

                // Si el anime es de tipo "TV"
                if (anime.TipoAnime == TipoAnime.TV)
                {
                    txtTipo.SelectedIndex = 1;
                    Serie s = (Serie)anime;
                    txtNumCap.Text = s.NumeroCapitulos.ToString();
                }
                // Si el anime es de tipo "Pelicula"
                else if (anime.TipoAnime == TipoAnime.Pelicula)
                {
                    txtTipo.SelectedIndex = 2;
                    Pelicula p = (Pelicula)anime;
                    txtPeliculaUnica.SelectedIndex = p.PeliculaUnica ? 1 : 2;
                }
            }
        }

        // Metodo para mostrar el primer anime de la lista
        private void MostrarPrimero()
        {
            if (gs.ListaAnime.Count > 0)
            {
                btnAgregar.Visible = false; // Ocultar el boton de agregar
                btnModificar.Visible = true; // Mostrar el boton de modificar
                idRegistro = 0; // Establecer el indice del primer registro
                Anime anime = gs.ListaAnime[0]; // Obtener el primer

                // Mostrar los detalles del primer anime
                txtNombre.Text = anime.Nombre;
                txtEstado.SelectedIndex = anime.Estado ? 1 : 2;
                txtGenero.Text = anime.Genero;

                // Cargar la imagen si existe
                string rutaImagen = Path.Combine(gs.RUTAIMAGENES, anime.IdImagen + ".jpg");
                if (File.Exists(rutaImagen))
                {
                    ibAnime.Image = Image.FromFile(rutaImagen);
                }

                // Si el anime es de tipo Serie
                if (anime is Serie)
                {
                    Serie s = (Serie)anime;
                    txtTipo.SelectedIndex = 1;
                    txtNumCap.Text = s.NumeroCapitulos.ToString();
                }
                // Si el anime es de tipo Pelicula
                else if (anime is Pelicula)
                {
                    Pelicula p = (Pelicula)anime;
                    txtTipo.SelectedIndex = 2;
                    txtPeliculaUnica.SelectedIndex = p.PeliculaUnica ? 1 : 2;
                }
                MostrarRegistro(); // Mostrar el registro actual
                btnAnterior.Enabled = false; // Deshabilitar el boton de "Anterior"
            }
            else
            {
                MostrarVacio(); // Limpiar los campos si no hay animes
                MessageBox.Show("No hay animes en la lista.");
            }
        }

        // Método para limpiar los campos y mostrar un estado vacío
        private void MostrarVacio()
        {
            ibAnime.Image = null;
            txtNombre.Text = "";
            txtNumCap.Text = "";
            txtGenero.Text = "";
            txtTipo.SelectedIndex = 0;
            txtEstado.SelectedIndex = 0;
            txtPeliculaUnica.SelectedIndex = 0;
        }

        // Método para mostrar la información del registro actual
        private void MostrarRegistro()
        {

            txtRegistro.Text = $"Registro: {idRegistro + 1} / {gs.ListaAnime.Count}";
        }


        // Método para cargar el archivo de animes desde el disco
        private void CargarAnime_Click(object sender, EventArgs e)
        {

            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;

            // Si la lista de animes está vacía, cargar el archivo
            if (gs.ListaAnime.Count == 0)
            {
                gs.ListaAnime = gs.CargarArchivo(); // Cargar los animes
                btnAgregar.Visible = false; // Ocultar el boton de agregar

            }
            else
            {
                MessageBox.Show("No ha sido posible cargar archivo.");
            }

            MostrarPrimero(); // Mostrar el primer anime despues de cargar
        }

        // Metodo para guardar los animes en el archivo
        private void GuardarFichero_Click(object sender, EventArgs e)
        {
            if (gs.GuardarEnArchivo(gs.ListaAnime)) // Guardar la lista de animes
            {
                MessageBox.Show("Fichero guardado con éxito", "Guardar");
            }
        }

        
    }
}
