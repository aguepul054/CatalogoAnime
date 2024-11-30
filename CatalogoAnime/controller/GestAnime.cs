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
        private const int BYTES_SERIE = 57;
        private const int BYTES_PELICULA = 54;
        private int pos = -1;
        public int idImagen = 0;
        internal string RUTAIMAGENES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
        public List<Anime> ListaAnime { get; set; }
        public GestAnime()
        {
            if (!Directory.Exists(RUTAIMAGENES))
            {
                Directory.CreateDirectory(RUTAIMAGENES);
            }

            ListaAnime = new List<Anime>();

            foreach (var anime in ListaAnime)
            {
                if (idImagen < anime.IdImagen)
                {
                    idImagen = anime.IdImagen;
                }
            }

        }

        //AGREGAR ANIMES
        public bool AgregarAnime(Anime anime)
        {
            bool resultado = false;
            Anime? a = ListaAnime.Find(n => n.Nombre == anime.Nombre);
            
            if (a is null)
            {
                
                ListaAnime.Add(anime);
                resultado = true;
            }
            else
            {
                MessageBox.Show(
                    "El Anime Existe",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return resultado;
        }
        public bool ModificarAnime( Anime anime, int idRegistro)
        {
            bool resultado = false;
            Anime? a = ListaAnime[idRegistro];
            if (a != null)
            {
                
                ListaAnime.RemoveAt(idRegistro);
                ListaAnime.Insert(idRegistro, anime);
                resultado = true;
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }
            return resultado;
        }

        //Borrar animes controlando para un posible filtrado con varios resultados.
        public void EliminarAnime(int id)
        {
            string ruta = RUTAIMAGENES +"\\"+ (id + 1) + ".jpg";
            File.Delete(ruta);
            ListaAnime.RemoveAt(id);
        }

        
        

        //GUARDAR DATOS EN FICHERO

        //Terminar este metodo
        public void GuardarAnime(Anime a, BinaryWriter bw)
        {
            if (a is Serie)
            {
                Serie serie = (Serie)a;
                bw.Write("S");
                bw.Write(serie.NumeroCapitulos);
                GuardarComun(a, bw);

            }
            else if (a is Pelicula)
            {
                Pelicula pelicula = (Pelicula)a;
                bw.Write("P");
                bw.Write(pelicula.PeliculaUnica);
                GuardarComun(a, bw);

            }

        }

        public void GuardarComun(Anime a, BinaryWriter bw)
        {
            bw.Write((int)a.TipoAnime);
            bw.Write(a.Nombre.PadRight(20, ' '));
            bw.Write(a.Genero.PadRight(20, ' '));
            bw.Write(a.Estado);
            bw.Write(a.IdImagen);
        }

        //Guardar en archivo

        public bool GuardarEnArchivo(List<Anime> lst)
        {
            bool r = false;
            if (File.Exists("catalogo.dat"))
            {
                DateTime dt = DateTime.Now;
                File.Move("catalogo.dat", $"catalogo_{dt.Day}-{dt.Month}-{dt.Year}_{dt.Ticks}_.dat");
            }

            int numGuardados = 0;

            try
            {
                using (var fileStr = new FileStream("catalogo.dat", FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fileStr))
                    {
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
                MessageBox.Show(
                    "ERROR: Error durante el guardado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

            return r;
        }

        public void GuardarImagen(string pathImage, int contImg)
        {
            string imagenNombre = (contImg) + ".jpg";
            string rutaImagen = Path.Combine(RUTAIMAGENES, imagenNombre);
            try
            {
                File.Copy(pathImage, rutaImagen, true);
            }
            catch ( Exception e)
            {
                MessageBox.Show("Error al guardar la imagen: " + e.Message);
            }

        }
        
        




        //CARGAR FICHERO


        public Serie CargarSerie(BinaryReader br)
        {
            int numCap = br.ReadInt32();
            TipoAnime tipo = (TipoAnime)(br.ReadInt32());
            string nombre = br.ReadString().Trim();
            string genero = br.ReadString().Trim();
            bool estado = br.ReadBoolean();
            int idFoto = br.ReadInt32();

            

            return new Serie(tipo, nombre, genero, estado,idFoto, numCap);
        }

        public Pelicula CargarPelicula(BinaryReader br)
        {
            bool pelUnica = br.ReadBoolean();
            TipoAnime tipo = (TipoAnime)(br.ReadInt32());
            string nombre = br.ReadString().Trim();
            string genero = br.ReadString().Trim();
            bool estado = br.ReadBoolean();
            int idFoto = Int32.Parse(br.ReadString());

            
            return new Pelicula(tipo, nombre, genero, estado,idFoto ,pelUnica);
        }

        public List<Anime> CargarArchivo()
        {
            var lista = new List<Anime>();
            
         
                try
                {
                    using (var fileStr = new FileStream("catalogo.dat", FileMode.OpenOrCreate))
                    {
                        using (BinaryReader br = new BinaryReader(fileStr))
                        {
                            while (fileStr.Position < fileStr.Length - sizeof(Char))
                            {
                                char marca = br.ReadChar();
                                
                                switch (marca)
                                {
                                    case 'S':
                                        if (SePuedenLeer(br, BYTES_SERIE - sizeof(Char)))
                                        {
                                            lista.Add(CargarSerie(br));
                                        }

                                        break;
                                    case 'P':
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
        
        private static bool SePuedenLeer(BinaryReader br, int numBytes)
        {
            bool sePuede = false;
            if (br != null)
            {
                sePuede = br.BaseStream.Length - br.BaseStream.Position >= numBytes;
            }

            return sePuede;
        }


        public List<Anime> DevolverAnimes()
        {
            return ListaAnime;
        }

        

        public Anime Siguiente(ref int idRegistro)
        {
            if (idRegistro < ListaAnime.Count-1)
            {
                // Retornar el siguiente anime y actualizar el índice
                
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

        public Anime Anterior(ref int idRegistro)
        {
            if (ListaAnime.Count == 0) return null;
            idRegistro = (idRegistro-1+ListaAnime.Count) % ListaAnime.Count;
            return ListaAnime[idRegistro];
        }
        

        public void OrdenarLista(String elemento)
        {
            switch (elemento)
            {
                case "Nombre": ListaAnime.Sort((a1, a2) => string.Compare(a1.Nombre, a2.Nombre)); break;
                case "Genero": ListaAnime.Sort((a1, a2) => string.Compare(a1.Genero, a2.Genero)); break;
            }
        }

    }
}
