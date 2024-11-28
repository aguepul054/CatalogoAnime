using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.model
{
    [Serializable]
    public class Serie : Anime
    {
        private int numeroCapitulos;

        public int NumeroCapitulos
        {
            get
            {
                return numeroCapitulos;
            }
            set
            {
                if (value > 0)
                {
                    numeroCapitulos = value;
                }
            }
        }

        public Serie()
        {
            NumeroCapitulos = 0;
        }

        public Serie(string tipoAnime, string nombre, string genero, string estado, int numeroCapitulos) : base(tipoAnime, nombre, genero, estado)
        {
            NumeroCapitulos = numeroCapitulos;
        }
        public Serie(TipoAnime tipoAnime, string nombre, string genero, bool estado,int idImagen, int numeroCapitulos) : base(tipoAnime, nombre, genero, estado, idImagen)
        {
            NumeroCapitulos = numeroCapitulos;
        }

        public override string ToString()
        {
            return base.ToString() + "\nNumero de capitulos: " + NumeroCapitulos;
        }

        public override bool Equals(object? obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }

            if (obj is Serie s)
            {
                return NumeroCapitulos == s.NumeroCapitulos;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
