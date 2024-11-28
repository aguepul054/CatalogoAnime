using CatalogoAnime.model;
using System;
using System.Collections.Generic;
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
        public static int idImagen = 0;
        internal string RUTAIMAGENES = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
        public List<Anime> ListaAnime { get; set; }
        public GestAnime()
        {
            if (!Directory.Exists(RUTAIMAGENES))
            {
                Directory.CreateDirectory(RUTAIMAGENES);
            }
            ListaAnime = CargarArchivo();

            foreach (var anime in ListaAnime)
            {
                if(idImagen < anime.IdImagen)
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
                idImagen++;
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

        //Borrar animes controlando para un posible filtrado con varios resultados.
        public void EliminarAnime(int id)
        {
            ListaAnime.RemoveAt(id);
        }

        //LISTAR ANIMES
        public void ListarAnime(List<Anime> lst)
        {
            if (lst.Count == 0)
            {
                MessageBox.Show(
                    "No hay animes para mostrar"
                    );
                Console.WriteLine("No hay animes.");
            }
            else
            {
                foreach (Anime a in lst)
                {
                    Console.WriteLine(a.ToString());
                }
            }
        }
        public List<Anime> BuscarAnime(Dictionary<string, string> dic)
        {
            List<Anime> lstFiltrada = new List<Anime>(ListaAnime);

            List<Anime> filtroActual = new List<Anime>();

            // Filtrar por tipo si existe
            if (dic.ContainsKey("Tipo"))
            {
                string tipoBuscado = dic["Tipo"];
                if (tipoBuscado == "TV")
                {
                    filtroActual = lstFiltrada.Where(a => a.TipoAnime == TipoAnime.TV).ToList();
                }
                else if (tipoBuscado == "PELICULA")
                {
                    filtroActual = lstFiltrada.Where(a => a.TipoAnime == TipoAnime.Pelicula).ToList();
                }
                else
                {
                    Console.WriteLine("Tipo no válido. Se procederá sin filtrado por tipo.");
                    filtroActual = lstFiltrada;
                }

                // Aplicar filtros adicionales
                filtroActual = FiltrarAComunes(filtroActual, dic);

                // Filtrar por número de capítulos si es tipo TV
                if (tipoBuscado == "TV" && dic.ContainsKey("NumCap"))
                {
                    int numCap = Int32.Parse(dic["NumCap"]);
                    if (numCap > 0)
                    {
                        List<Serie> lstSerieFiltrada = filtroActual.OfType<Serie>().ToList();
                        lstSerieFiltrada = lstSerieFiltrada.Where(a => a.NumeroCapitulos == numCap).ToList();
                        filtroActual = lstSerieFiltrada.OfType<Anime>().ToList();
                    }
                }
                // Filtrar por película única si es tipo Película
                else if (tipoBuscado == "PELICULA" && dic.ContainsKey("PelUnica"))
                {
                    string peliculaUnica = dic["PelUnica"];
                    if (!string.IsNullOrEmpty(peliculaUnica))
                    {
                        List<Pelicula> lstPeliculaFiltrada = filtroActual.OfType<Pelicula>().ToList();
                        lstPeliculaFiltrada = lstPeliculaFiltrada.Where(a => a.getPeliculaUnica(peliculaUnica)).ToList();
                        filtroActual = lstPeliculaFiltrada.OfType<Anime>().ToList();
                    }
                }
            }
            else
            {
                filtroActual = FiltrarAComunes(lstFiltrada, dic);
            }

            Console.WriteLine("Lista final de animes filtrados:");
            foreach (var anime in filtroActual)
            {
                Console.WriteLine($"{anime.Nombre} - {anime.TipoAnime}");
            }

            return filtroActual;
        }

        public List<Anime> FiltrarAComunes(List<Anime> lstFiltrada, Dictionary<string, string> dic)
        {
            if (dic.ContainsKey("Nombre"))
            {
                string nombre = dic["Nombre"];
                lstFiltrada = lstFiltrada.Where(a => a.Nombre.Contains(nombre)).ToList();
            }

            if (dic.ContainsKey("Genero"))
            {
                string genero = dic["Genero"];
                lstFiltrada = lstFiltrada.Where(a => a.Genero == genero).ToList();
            }

            if (dic.ContainsKey("Estado"))
            {
                string estado = dic["Estado"];
                if (estado == "En emision")
                {
                    lstFiltrada = lstFiltrada.Where(a => a.Estado).ToList();
                }
                else if (estado == "Finalizado")
                {
                    lstFiltrada = lstFiltrada.Where(a => a.Estado == false).ToList();
                }
            }

            return lstFiltrada;
        }


        //GUARDAR DATOS EN FICHERO

        //Terminar este metodo
        public void GuardarAnime(Anime a, BinaryWriter bw)
        {
            if (a is Serie)
            {
                Serie serie = (Serie)a;
                bw.Write("S");
                GuardarComun(a, bw);
                bw.Write(serie.NumeroCapitulos);

            }
            else if (a is Pelicula)
            {
                Pelicula pelicula = (Pelicula)a;
                bw.Write("P");
                GuardarComun(a, bw);
                bw.Write(pelicula.PeliculaUnica);

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
            string imagenNombre = (idImagen) + ".jpg";
            string rutaImagen = Path.Combine(RUTAIMAGENES, imagenNombre);
            File.Copy(pathImage, rutaImagen, true);

        }




        //CARGAR FICHERO


        public Serie CargarSerie(BinaryReader br)
        {
            TipoAnime tipo = (TipoAnime)(br.ReadInt32());
            string nombre = br.ReadString().Trim();
            string genero = br.ReadString().Trim();
            bool estado = br.ReadBoolean();
            int numCap = br.ReadInt32();
            int idFoto = br.ReadInt32();
            

            return new Serie(tipo, nombre, genero, estado,idFoto, numCap);
        }

        public Pelicula CargarPelicula(BinaryReader br)
        {
            TipoAnime tipo = (TipoAnime)(br.ReadInt32());
            string nombre = br.ReadString().Trim();
            string genero = br.ReadString().Trim();
            bool estado = br.ReadBoolean();
            bool pelUnica = br.ReadBoolean();
            int idFoto = br.ReadInt32();
            

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
