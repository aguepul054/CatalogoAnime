using CatalogoAnime.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.controller
{
    public class GestAnime
    {
        // Constantes que definen la cantidad de bytes necesarios para guardar los datos de cada tipo de anime
        private const int BYTES_SERIE = 57;
        private const int BYTES_PELICULA = 54;

        // Variable de control para la posicion dentro de la lista
        private int pos = -1;

        // ID para las imagenes, se utilizara para asegurarse de que cada imagen tiene un ID unico
        public int idImagen = 0;

        // Ruta donde se guardaran las imagenes de los animes
        internal string RUTAIMAGENES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");

        // Lista que contiene los animes cargados
        public List<Anime> ListaAnime { get; set; }

        // Constructor de la clase
        public GestAnime()
        {
            // Verifica si la carpeta de imagenes existe, si no la crea
            if (!Directory.Exists(RUTAIMAGENES))
            {
                Directory.CreateDirectory(RUTAIMAGENES);
            }

            // Inicializa la lista de animes
            ListaAnime = new List<Anime>();

            // Recorrerá la lista de animes para encontrar el ID de imagen más alto
            foreach (var anime in ListaAnime)
            {
                if (idImagen < anime.IdImagen)
                {
                    idImagen = anime.IdImagen;
                }
            }

        }

        // Método para agregar un nuevo anime a la lista
        public bool AgregarAnime(Anime anime)
        {
            bool resultado = false;

            // Verifica si ya existe un anime con el mismo nombre
            Anime? a = ListaAnime.Find(n => n.Nombre == anime.Nombre);
            
            if (a is null)
            {
                // Si no existe, lo agrega a la lista
                ListaAnime.Add(anime);
                resultado = true;
            }
            else
            {
                // Si ya existe, muestra un mensaje de error
                MessageBox.Show(
                    "El Anime Existe",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return resultado;
        }

        // Metodo para modificar un anime en la lista por su indice
        public bool ModificarAnime( Anime anime, int idRegistro)
        {
            bool resultado = false;
            Anime? a = ListaAnime[idRegistro];
            if (a != null)
            {
                // Si el anime existe, lo reemplaza en la lista
                ListaAnime.RemoveAt(idRegistro);
                ListaAnime.Insert(idRegistro, anime);
                resultado = true;
            }
            else
            {
                // Si ocurre un error, muestra un mensaje
                MessageBox.Show("Error al Guardar");
            }
            return resultado;
        }

        // Método para eliminar un anime de la lista y borrar su imagen asociada
        public void EliminarAnime(int id)
        {
            string ruta = RUTAIMAGENES +"\\"+ (id + 1) + ".jpg";
            File.Delete(ruta); 
            // Elimina el anime de la lista
            ListaAnime.RemoveAt(id);
        }




        // Método para guardar un anime en un archivo binario
        public void GuardarAnime(Anime a, BinaryWriter bw)
        {
            // Si es una serie, guarda los datos específicos de la serie
            if (a is Serie)
            {
                Serie serie = (Serie)a;
                bw.Write("S");
                bw.Write(serie.NumeroCapitulos);
                GuardarComun(a, bw);

            }
            // Si es una serie, guarda los datos específicos de la serie
            else if (a is Pelicula)
            {
                Pelicula pelicula = (Pelicula)a;
                bw.Write("P");
                bw.Write(pelicula.PeliculaUnica);
                GuardarComun(a, bw);

            }

        }

        // Método común para guardar los datos comunes de cualquier tipo de anime
        public void GuardarComun(Anime a, BinaryWriter bw)
        {
            bw.Write((int)a.TipoAnime); // Tipo de anime (serie o pelicula)
            bw.Write(a.Nombre.PadRight(20, ' ')); // Nombre del anime con espacio de relleno
            bw.Write(a.Genero.PadRight(20, ' ')); // Genero del anime con espacio de rreleno
            bw.Write(a.Estado); // Estado del anime ( true o false )
            bw.Write(a.IdImagen); // ID de la imagen asociada al anime
        }

        // Método para guardar la lista de animes en un archivo binario
        public bool GuardarEnArchivo(List<Anime> lst)
        {
            bool r = false;
            // Si el archivo ya existe, lo renombra para no sobrescribirlo
            if (File.Exists("catalogo.dat"))
            {
                DateTime dt = DateTime.Now;
                File.Move("catalogo.dat", $"catalogo_{dt.Day}-{dt.Month}-{dt.Year}_{dt.Ticks}_.dat");
            }

            int numGuardados = 0;

            try
            {
                // Abre un flujo de archivo para escribir los animes
                using (var fileStr = new FileStream("catalogo.dat", FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fileStr))
                    {
                        // Guarda cada anime de la lista en el archivo
                        foreach (var anime in lst)
                        {
                            GuardarAnime(anime, bw);
                            numGuardados++;
                        }
                    }
                }

                r = true;
            }
            catch (Exception e)
            {
                // Si ocurre un error durante el guardado, muestra un mensaje
                MessageBox.Show(
                    "ERROR: Error durante el guardado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

            return r;
        }


        // Método para guardar una imagen en la carpeta de imágenes
        public void GuardarImagen(string pathImage, int contImg)
        {
            string imagenNombre = (contImg) + ".jpg";
            string rutaImagen = Path.Combine(RUTAIMAGENES, imagenNombre);
            try
            {
                // Intenta copiar la imagen al directorio de imágenes
                File.Copy(pathImage, rutaImagen, true);
            }
            catch ( Exception e)
            {
                // Si ocurre un error al guardar la imagen, muestra un mensaje
                MessageBox.Show("Error al guardar la imagen: " + e.Message);
            }

        }






        // Métodos para cargar datos desde un archivo binario
        public Serie CargarSerie(BinaryReader br)
        {
            int numCap = br.ReadInt32(); // Numero de capitulos
            TipoAnime tipo = (TipoAnime)(br.ReadInt32()); // Tipo de anime
            string nombre = br.ReadString().Trim(); // Nombre del anime
            string genero = br.ReadString().Trim(); // Genero del anime
            bool estado = br.ReadBoolean(); // Estado del anime
            int idFoto = br.ReadInt32(); // ID de la imagen

            
            // Retorna una nueva instancia de Serie
            return new Serie(tipo, nombre, genero, estado,idFoto, numCap);
        }

        // Cargar datos de una película desde el archivo binario
        public Pelicula CargarPelicula(BinaryReader br)
        {
            bool pelUnica = br.ReadBoolean(); // Si la pelicula es unica o no
            TipoAnime tipo = (TipoAnime)(br.ReadInt32()); // Tipo de anime
            string nombre = br.ReadString().Trim(); // Nombre
            string genero = br.ReadString().Trim(); // Genero
            bool estado = br.ReadBoolean(); // Estado
            int idFoto = Int32.Parse(br.ReadString()); // ID de la imagen

            // Retorna una nueva instancia de Pelicula
            return new Pelicula(tipo, nombre, genero, estado,idFoto ,pelUnica);
        }

        // Metodo para cargar el archivo de animes
        public List<Anime> CargarArchivo()
        {
            var lista = new List<Anime>();
            
         
                try
                {
                    // Abre el archivo para leer los animes
                    using (var fileStr = new FileStream("catalogo.dat", FileMode.OpenOrCreate))
                    {
                        using (BinaryReader br = new BinaryReader(fileStr))
                        {   
                            // Lee los animes en el archivo segun su tipo
                            while (fileStr.Position < fileStr.Length - sizeof(Char))
                            {
                                char marca = br.ReadChar();
                                
                                switch (marca)
                                {
                                    case 'S': // Si es una serie
                                        if (SePuedenLeer(br, BYTES_SERIE - sizeof(Char)))
                                        {
                                            lista.Add(CargarSerie(br));
                                        }

                                        break;
                                    case 'P': // Si es una pelicula
                                        if (SePuedenLeer(br, BYTES_PELICULA - sizeof(Char)))
                                        {
                                            lista.Add(CargarPelicula(br));
                                        }

                                        break;
                                    default: break;
                                }
                            }
                        }
                    }

                    // Actualiza el ID de la imagen mas alta
                    foreach (var anime in lista)
                    {
                        if (idImagen < anime.IdImagen)
                        {
                            idImagen = anime.IdImagen;
                        }
                    }
            }
                catch (Exception ex)
                {
                    // Si ocurre un error durante la carga, muestra un mensaje
                    MessageBox.Show(
                        "ERROR: Error durante la carga.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    Console.WriteLine($"ERROR: Error durante el archivo. {ex.Message}");
                }
            return lista;
        }
        

        // Verifica si hay suficientes bytes para leer
        private static bool SePuedenLeer(BinaryReader br, int numBytes)
        {
            bool sePuede = false;
            if (br != null)
            {
                sePuede = br.BaseStream.Length - br.BaseStream.Position >= numBytes;
            }

            return sePuede;
        }

        // Navega al siguiente anime en la lista
        public Anime Siguiente(ref int idRegistro)
        {
            if (idRegistro < ListaAnime.Count-1)
            {
                // Avanza al siguiente anime y actualiza el indice
                
                idRegistro++;
                Anime anime = ListaAnime[idRegistro];
                return anime;
            }
            else
            {
                // Si hemos llegado al final de la lista, retornamos null
                return null;
            }
        }

        // Navega el anime anterior en la lista
        public Anime Anterior(ref int idRegistro)
        {
            if (ListaAnime.Count == 0) return null; 
            idRegistro = (idRegistro-1+ListaAnime.Count) % ListaAnime.Count;
            return ListaAnime[idRegistro];
        }
        

        // Ordenar la lista de animes por un atributo
        public void OrdenarLista(String elemento)
        {
            switch (elemento)
            {
                case "Nombre": ListaAnime.Sort((a1, a2) => string.Compare(a1.Nombre, a2.Nombre)); break; // Ordenar por nombre
                case "Genero": ListaAnime.Sort((a1, a2) => string.Compare(a1.Genero, a2.Genero)); break; // Ordenar por genero
            }
        }

    }
}
