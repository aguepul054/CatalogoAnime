using CatalogoAnime.controller;
using CatalogoAnime.model;
using System.ComponentModel;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class PanelPrincipal : Form
    {
        private GestAnime gs = new GestAnime();
        private string rutaImagen;
        private bool isAdding = false;
        private int idRegistro = 0;
        public PanelPrincipal()
        {

            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = true;
        }



        private void PanelPrincipal_Load(object sender, EventArgs e)
        {
            txtTipo.SelectedIndex = 0;
            txtEstado.SelectedIndex = 0;
            txtPeliculaUnica.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                int contImg;
                btnAgregar.Text = "Agregar";
                string nombre = txtNombre.Text;
                string tipo = txtTipo.SelectedItem.ToString();
                string genero = txtGenero.Text;
                string estado = txtEstado.SelectedItem.ToString();

                if (ibAnime.Image == null)
                {
                    contImg = 0;
                }
                else
                {
                    contImg = ++GestAnime.idImagen;
                    gs.GuardarImagen(rutaImagen, contImg);
                }

                if (tipo == "TV")
                {
                    int numCaps = Int32.Parse(txtNumCap.Text);
                    Serie s = new Serie();
                    s.Nombre = nombre;
                    s.TipoAnime = TipoAnime.TV;
                    s.Genero = genero;
                    s.Estado = s.getEstado(estado);
                    s.NumeroCapitulos = numCaps;
                    if (gs.AgregarAnime(s))
                    {
                        MessageBox.Show("Anime a�adido correctamente.", "A�adir", MessageBoxButtons.OK);
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

                    if (gs.AgregarAnime(p))
                    {
                        MessageBox.Show("Anime a�adido correctamente.", "A�adir", MessageBoxButtons.OK);
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                    }
                }
                MostrarPrimero();
                txtNombre.Enabled = false;
                txtGenero.Enabled = false;
                txtTipo.Enabled = false;
                txtEstado.Enabled = false;
                txtNumCap.Enabled = false;
                txtPeliculaUnica.Enabled = false;
                isAdding = false;

            }
            else
            {



                btnAgregar.Text = "Aceptar";
                txtNombre.Enabled = true;
                txtTipo.Enabled = true;
                txtEstado.Enabled = true;
                txtGenero.Enabled = true;
                txtNumCap.Enabled = true;
                txtPeliculaUnica.Enabled = true;
                isAdding = true;

                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
            }

        }


        private void ibAnime_Click(object sender, EventArgs e)
        {

            ofdCargarImagen.Filter = "Archivos de Imagen |*.jpg;*.jpeg";

            if (ofdCargarImagen.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = ofdCargarImagen.FileName;

                System.Drawing.Image img = System.Drawing.Image.FromFile(rutaImagen);
                ibAnime.SizeMode = PictureBoxSizeMode.StretchImage;
                ibAnime.Image = img;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = txtTipo.SelectedItem.ToString();

            if (tipo == "TV")
            {
                txtNumCap.Visible = true;
                lblNumCap.Visible = true;
                txtPeliculaUnica.Visible = false;
                lblPeliculaUnica.Visible = false;

            }
            else if (tipo == "Pelicula")
            {
                txtNumCap.Visible = false;
                lblNumCap.Visible = false;
                txtPeliculaUnica.Visible = true;
                lblPeliculaUnica.Visible = true;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (idRegistro >= gs.ListaAnime.Count - 1)
            {
                DialogResult result = MessageBox.Show("Has llegado al final de la lista. �Deseas agregar un nuevo anime?",
                                                      "Agregar Nuevo Anime", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    CrearNuevoAnimeVacio();
                }
                else
                {
                    MessageBox.Show("No se agregar� un nuevo anime.");
                }



            }
            else
            {
                Anime anime = gs.Siguiente(ref idRegistro);
                if (anime != null)
                {
                    MostrarAnime(anime);
                    MostrarRegistro();
                    btnAnterior.Enabled = true;
                }
            }


        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {

            if (idRegistro <= 0)
            {
                btnAnterior.Enabled = false;

                MessageBox.Show("Est�s en el primer anime.");
            }
            else
            {
                Anime anime = gs.Anterior(ref idRegistro);

                if (anime != null)
                {
                    MostrarAnime(anime);
                    MostrarRegistro();
                }
            }


        }
        private void CrearNuevoAnimeVacio()
        {
            MostrarVacio();

            txtNombre.Enabled = true;
            txtGenero.Enabled = true;
            txtTipo.Enabled = true;
            txtEstado.Enabled = true;
            txtNumCap.Enabled = true;
            txtPeliculaUnica.Enabled = true;

            btnAgregar.Text = "Aceptar";
            isAdding = true;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = false;
        }

        private void MostrarAnime(Anime anime)
        {
            if (anime != null)
            {
                txtNombre.Text = anime.Nombre;
                txtEstado.SelectedIndex = anime.Estado ? 1 : 2;
                txtGenero.Text = anime.Genero;
                if (anime.TipoAnime == TipoAnime.TV)
                {
                    txtTipo.SelectedIndex = 1;
                    Serie s = (Serie)anime;
                    txtNumCap.Text = s.NumeroCapitulos.ToString();
                }
                else if (anime.TipoAnime == TipoAnime.Pelicula)
                {
                    txtTipo.SelectedIndex = 2;
                    Pelicula p = (Pelicula)anime;
                    txtPeliculaUnica.SelectedIndex = p.PeliculaUnica ? 1 : 2;
                }
            }
        }
        private void MostrarPrimero()
        {
            if (gs.ListaAnime.Count > 0)
            {
                idRegistro = 0;
                Anime anime = gs.ListaAnime[0];
                txtNombre.Text = anime.Nombre;
                txtEstado.SelectedIndex = anime.Estado ? 1 : 2;
                txtGenero.Text = anime.Genero;
                
                if (anime is Serie)
                {
                    Serie s = (Serie)anime;
                    txtTipo.SelectedIndex = 1;
                    txtNumCap.Text = s.NumeroCapitulos.ToString();
                }
                else if (anime is Pelicula)
                {
                    Pelicula p = (Pelicula)anime;
                    txtTipo.SelectedIndex = 2;
                    txtPeliculaUnica.SelectedIndex = p.PeliculaUnica ? 1 : 2;
                }
                MostrarRegistro();
                btnAnterior.Enabled = false;
            }
            else
            {
                MostrarVacio();
                MessageBox.Show("No hay animes en la lista.");
            }
        }

        private void MostrarVacio()
        {
            txtNombre.Text = "";
            txtNumCap.Text = "";
            txtGenero.Text = "";
            txtTipo.SelectedIndex = 0;
            txtEstado.SelectedIndex = 0;
            txtPeliculaUnica.SelectedIndex = 0;
        }

        private void MostrarRegistro()
        {

            txtRegistro.Text = $"Registro: {idRegistro+1} / {gs.ListaAnime.Count}";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Anime a = new Anime();

            gs.EliminarAnime(idRegistro);

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�Ordenar por nombre?", "Ordenar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                gs.OrdenarLista("Nombre");
                MostrarPrimero();
            }
            else if (result == DialogResult.Cancel)
            {
                DialogResult result2 = MessageBox.Show("�Ordenar por genero?", "Ordenar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.OK)
                {
                    gs.OrdenarLista("Genero");
                    MostrarPrimero();
                }
                else
                {
                    MessageBox.Show("No se ordenara.");
                }
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Form2 formDataGrid = new Form2(gs.ListaAnime);
            formDataGrid.Show();
        }

        private void CargarAnime_Click(object sender, EventArgs e)
        {
            gs.ListaAnime = gs.CargarArchivo();
        }

        private void GuardarFichero_Click(object sender, EventArgs e)
        {
            gs.GuardarEnArchivo(gs.ListaAnime);
        }
    }
}
