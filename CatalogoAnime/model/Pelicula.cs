using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.model
{
    [Serializable]
    public class Pelicula : Anime
    {
        private bool peliculaUnica;

        public bool PeliculaUnica { get; set; }

        public Pelicula()
        {
            peliculaUnica = false;
        }
        public Pelicula(string tipoAnime, string nombre, string genero, string peliculaUnica) : base(
            tipoAnime, nombre, genero)
        {
            PeliculaUnica = getPeliculaUnica(peliculaUnica);
        }

        public Pelicula(TipoAnime tipoAnime, string nombre, string genero, bool estado,int idImagen, bool peliculaUnica) : base(tipoAnime, nombre, genero, estado, idImagen)
        {
            PeliculaUnica = peliculaUnica;
        }

        public bool getPeliculaUnica(string peliculaUnica)
        {
            bool unica = false;
            switch (peliculaUnica)
            {
                case "Si":
                    unica = true;
                    break;
                case "No":
                    unica = false;
                    break;
                default: return false;
            }

            return unica;
        }


        public override string ToString()
        {
            return base.ToString() + "Pelicula Unica: " + PeliculaUnica;
        }

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }

            if (obj is Pelicula pelicula)
            {
                return PeliculaUnica == pelicula.PeliculaUnica;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
