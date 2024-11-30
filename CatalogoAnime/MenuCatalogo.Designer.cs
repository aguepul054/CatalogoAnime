using AxWMPLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace CatalogoAnime
{
    public partial class PanelPrincipal : Form
    {


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelPrincipal));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnAgregar = new Button();
            CargarAnime = new Button();
            GuardarFichero = new Button();
            btnBorrar = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnOrdenar = new Button();
            btnDetalles = new Button();
            lblNombre = new Label();
            lblTIpo = new Label();
            lblEstado = new Label();
            lblGenero = new Label();
            ibAnime = new PictureBox();
            lblFoto = new Label();
            ofdCargarImagen = new OpenFileDialog();
            txtTipo = new ComboBox();
            lblNumCap = new Label();
            txtNumCap = new TextBox();
            lblPeliculaUnica = new Label();
            txtPeliculaUnica = new ComboBox();
            txtNombre = new TextBox();
            txtGenero = new TextBox();
            txtEstado = new ComboBox();
            txtRegistro = new Label();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ibAnime).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.titulo1;
            pictureBox1.Location = new Point(245, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 62);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.titulo2;
            pictureBox2.Location = new Point(660, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(186, 58);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = Properties.Resources.titulo3;
            pictureBox3.Location = new Point(525, 27);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 104);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(60, 164, 60);
            btnAgregar.Font = new Font("Tahoma", 10F);
            btnAgregar.ForeColor = SystemColors.ControlLightLight;
            btnAgregar.Location = new Point(12, 538);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(138, 52);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // CargarAnime
            // 
            CargarAnime.BackColor = Color.FromArgb(236, 52, 48);
            CargarAnime.Font = new Font("Tahoma", 10F);
            CargarAnime.ForeColor = SystemColors.ControlLightLight;
            CargarAnime.Location = new Point(990, 461);
            CargarAnime.Name = "CargarAnime";
            CargarAnime.Size = new Size(138, 52);
            CargarAnime.TabIndex = 7;
            CargarAnime.Text = "Cargar";
            CargarAnime.UseVisualStyleBackColor = false;
            CargarAnime.Click += CargarAnime_Click;
            // 
            // GuardarFichero
            // 
            GuardarFichero.BackColor = Color.FromArgb(60, 164, 60);
            GuardarFichero.Font = new Font("Tahoma", 10F);
            GuardarFichero.ForeColor = SystemColors.ControlLightLight;
            GuardarFichero.Location = new Point(834, 461);
            GuardarFichero.Name = "GuardarFichero";
            GuardarFichero.Size = new Size(138, 52);
            GuardarFichero.TabIndex = 6;
            GuardarFichero.Text = "Guardar";
            GuardarFichero.UseVisualStyleBackColor = false;
            GuardarFichero.Click += GuardarFichero_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.FromArgb(236, 52, 48);
            btnBorrar.Font = new Font("Tahoma", 10F);
            btnBorrar.ForeColor = SystemColors.ControlLightLight;
            btnBorrar.Location = new Point(179, 538);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(138, 52);
            btnBorrar.TabIndex = 4;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackColor = Color.FromArgb(236, 52, 48);
            btnSiguiente.Font = new Font("Tahoma", 10F);
            btnSiguiente.ForeColor = SystemColors.ControlLightLight;
            btnSiguiente.Location = new Point(834, 538);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(138, 52);
            btnSiguiente.TabIndex = 8;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = Color.FromArgb(60, 164, 60);
            btnAnterior.Enabled = false;
            btnAnterior.Font = new Font("Tahoma", 10F);
            btnAnterior.ForeColor = SystemColors.ControlLightLight;
            btnAnterior.Location = new Point(990, 538);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(138, 52);
            btnAnterior.TabIndex = 9;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = Color.FromArgb(60, 164, 60);
            btnOrdenar.Font = new Font("Tahoma", 10F);
            btnOrdenar.ForeColor = SystemColors.ControlLightLight;
            btnOrdenar.Location = new Point(323, 558);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(107, 32);
            btnOrdenar.TabIndex = 10;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnDetalles
            // 
            btnDetalles.BackColor = Color.FromArgb(60, 164, 60);
            btnDetalles.Font = new Font("Tahoma", 10F);
            btnDetalles.ForeColor = SystemColors.ControlLightLight;
            btnDetalles.Location = new Point(721, 558);
            btnDetalles.Name = "btnDetalles";
            btnDetalles.Size = new Size(107, 32);
            btnDetalles.TabIndex = 11;
            btnDetalles.Text = "Detalles";
            btnDetalles.UseVisualStyleBackColor = false;
            btnDetalles.Click += btnDetalles_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.BorderStyle = BorderStyle.Fixed3D;
            lblNombre.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblNombre.ForeColor = Color.WhiteSmoke;
            lblNombre.Location = new Point(270, 141);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(160, 41);
            lblNombre.TabIndex = 12;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTIpo
            // 
            lblTIpo.AutoSize = true;
            lblTIpo.BackColor = Color.Transparent;
            lblTIpo.BorderStyle = BorderStyle.Fixed3D;
            lblTIpo.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblTIpo.ForeColor = Color.WhiteSmoke;
            lblTIpo.Location = new Point(272, 204);
            lblTIpo.Name = "lblTIpo";
            lblTIpo.Size = new Size(101, 41);
            lblTIpo.TabIndex = 13;
            lblTIpo.Text = "Tipo:";
            lblTIpo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.BackColor = Color.Transparent;
            lblEstado.BorderStyle = BorderStyle.Fixed3D;
            lblEstado.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblEstado.ForeColor = Color.WhiteSmoke;
            lblEstado.Location = new Point(270, 286);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(139, 41);
            lblEstado.TabIndex = 14;
            lblEstado.Text = "Estado:";
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.BackColor = Color.Transparent;
            lblGenero.BorderStyle = BorderStyle.Fixed3D;
            lblGenero.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblGenero.ForeColor = Color.WhiteSmoke;
            lblGenero.Location = new Point(270, 365);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(147, 41);
            lblGenero.TabIndex = 15;
            lblGenero.Text = "Género:";
            lblGenero.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ibAnime
            // 
            ibAnime.BackColor = Color.Transparent;
            ibAnime.BackgroundImage = (Image)resources.GetObject("ibAnime.BackgroundImage");
            ibAnime.BackgroundImageLayout = ImageLayout.Stretch;
            ibAnime.BorderStyle = BorderStyle.Fixed3D;
            ibAnime.Location = new Point(37, 152);
            ibAnime.Name = "ibAnime";
            ibAnime.Size = new Size(204, 305);
            ibAnime.SizeMode = PictureBoxSizeMode.StretchImage;
            ibAnime.TabIndex = 16;
            ibAnime.TabStop = false;
            ibAnime.Click += ibAnime_Click;
            // 
            // lblFoto
            // 
            lblFoto.AutoSize = true;
            lblFoto.BackColor = Color.FromArgb(60, 164, 60);
            lblFoto.BorderStyle = BorderStyle.Fixed3D;
            lblFoto.ForeColor = SystemColors.ControlLightLight;
            lblFoto.Location = new Point(37, 460);
            lblFoto.Name = "lblFoto";
            lblFoto.Size = new Size(212, 17);
            lblFoto.TabIndex = 21;
            lblFoto.Text = "Haz click en la imagen para añadir una";
            // 
            // txtTipo
            // 
            txtTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            txtTipo.Enabled = false;
            txtTipo.FormattingEnabled = true;
            txtTipo.Items.AddRange(new object[] { "Seleccione...", "TV", "Pelicula" });
            txtTipo.Location = new Point(414, 221);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(121, 23);
            txtTipo.TabIndex = 22;
            txtTipo.SelectedIndexChanged += txtTipo_SelectedIndexChanged;
            // 
            // lblNumCap
            // 
            lblNumCap.AutoSize = true;
            lblNumCap.BackColor = Color.Transparent;
            lblNumCap.BorderStyle = BorderStyle.Fixed3D;
            lblNumCap.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblNumCap.ForeColor = Color.WhiteSmoke;
            lblNumCap.Location = new Point(270, 440);
            lblNumCap.Name = "lblNumCap";
            lblNumCap.Size = new Size(176, 41);
            lblNumCap.TabIndex = 23;
            lblNumCap.Text = "Num caps";
            lblNumCap.TextAlign = ContentAlignment.MiddleLeft;
            lblNumCap.Visible = false;
            // 
            // txtNumCap
            // 
            txtNumCap.Enabled = false;
            txtNumCap.Location = new Point(458, 454);
            txtNumCap.Name = "txtNumCap";
            txtNumCap.Size = new Size(100, 23);
            txtNumCap.TabIndex = 24;
            txtNumCap.Visible = false;
            // 
            // lblPeliculaUnica
            // 
            lblPeliculaUnica.AutoSize = true;
            lblPeliculaUnica.BackColor = Color.Transparent;
            lblPeliculaUnica.BorderStyle = BorderStyle.Fixed3D;
            lblPeliculaUnica.Font = new Font("Tahoma", 24F, FontStyle.Bold);
            lblPeliculaUnica.ForeColor = Color.WhiteSmoke;
            lblPeliculaUnica.Location = new Point(272, 440);
            lblPeliculaUnica.Name = "lblPeliculaUnica";
            lblPeliculaUnica.Size = new Size(244, 41);
            lblPeliculaUnica.TabIndex = 25;
            lblPeliculaUnica.Text = "Pelicula Unica";
            lblPeliculaUnica.TextAlign = ContentAlignment.MiddleLeft;
            lblPeliculaUnica.Visible = false;
            // 
            // txtPeliculaUnica
            // 
            txtPeliculaUnica.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPeliculaUnica.Enabled = false;
            txtPeliculaUnica.FormattingEnabled = true;
            txtPeliculaUnica.Items.AddRange(new object[] { "Seleccione...", "Si", "No" });
            txtPeliculaUnica.Location = new Point(525, 454);
            txtPeliculaUnica.Name = "txtPeliculaUnica";
            txtPeliculaUnica.Size = new Size(121, 23);
            txtPeliculaUnica.TabIndex = 26;
            txtPeliculaUnica.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(445, 152);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 27;
            // 
            // txtGenero
            // 
            txtGenero.Enabled = false;
            txtGenero.Location = new Point(445, 383);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(100, 23);
            txtGenero.TabIndex = 29;
            // 
            // txtEstado
            // 
            txtEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            txtEstado.Enabled = false;
            txtEstado.FormattingEnabled = true;
            txtEstado.Items.AddRange(new object[] { "Seleccione...", "En Emision", "Finalizado" });
            txtEstado.Location = new Point(437, 303);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(121, 23);
            txtEstado.TabIndex = 30;
            // 
            // txtRegistro
            // 
            txtRegistro.AutoSize = true;
            txtRegistro.BackColor = Color.Transparent;
            txtRegistro.Location = new Point(12, 9);
            txtRegistro.Name = "txtRegistro";
            txtRegistro.Size = new Size(62, 15);
            txtRegistro.TabIndex = 31;
            txtRegistro.Text = "Registro: 0/0";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(60, 164, 60);
            btnModificar.Font = new Font("Tahoma", 10F);
            btnModificar.ForeColor = SystemColors.ControlLightLight;
            btnModificar.Location = new Point(12, 538);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(138, 52);
            btnModificar.TabIndex = 32;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Visible = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // PanelPrincipal
            // 
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.backgroundPantallaPrincipal;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 602);
            Controls.Add(btnModificar);
            Controls.Add(txtRegistro);
            Controls.Add(txtEstado);
            Controls.Add(txtGenero);
            Controls.Add(txtNombre);
            Controls.Add(txtPeliculaUnica);
            Controls.Add(lblPeliculaUnica);
            Controls.Add(txtNumCap);
            Controls.Add(lblNumCap);
            Controls.Add(txtTipo);
            Controls.Add(lblFoto);
            Controls.Add(ibAnime);
            Controls.Add(lblGenero);
            Controls.Add(lblEstado);
            Controls.Add(lblTIpo);
            Controls.Add(lblNombre);
            Controls.Add(btnDetalles);
            Controls.Add(btnOrdenar);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(CargarAnime);
            Controls.Add(GuardarFichero);
            Controls.Add(btnBorrar);
            Controls.Add(btnAgregar);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PanelPrincipal";
            Load += PanelPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ibAnime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button btnAgregar;
        private Button CargarAnime;
        private Button GuardarFichero;
        private Button btnBorrar;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnOrdenar;
        private Button btnDetalles;
        private Label lblNombre;
        private Label lblTIpo;
        private Label lblEstado;
        private Label lblGenero;
        private PictureBox ibAnime;
        private Label lblFoto;
        private OpenFileDialog ofdCargarImagen;
        private ComboBox txtTipo;
        private Label lblNumCap;
        private TextBox txtNumCap;
        private Label lblPeliculaUnica;
        private ComboBox txtPeliculaUnica;
        private TextBox txtNombre;
        private TextBox txtGenero;
        private ComboBox txtEstado;
        private Label txtRegistro;
        private Button btnModificar;
    }
    
}
