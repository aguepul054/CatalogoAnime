using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.model
{
    // Indica que la clase puede ser serializada, es decir, sus instancias pueden ser convertidas en un flujo de bytes para guardarlas en un archivo
    [Serializable]
    public class Pelicula : Anime
    {
        // Propiedad privada que indica si la película es única o no
        private bool peliculaUnica;

        // Propiedad pública que permite acceder a la propiedad privada 'peliculaUnica'
        public bool PeliculaUnica { get; set; }

        // Constructor por defecto, establece que la película no es única
        public Pelicula()
        {
            peliculaUnica = false;
        }

        // Constructor que permite inicializar una película a partir de una cadena que indica si es única o no
        // Utiliza el constructor de la clase base 'Anime' para inicializar los atributos comunes
        public Pelicula(string tipoAnime, string nombre, string genero, string peliculaUnica) : base(
            tipoAnime, nombre, genero)
        {
            // Convierte la cadena a un valor booleano (Sí o No)
            PeliculaUnica = getPeliculaUnica(peliculaUnica);
        }

        // Constructor que toma parámetros más específicos (tipo de anime, nombre, estado, id de imagen)
        // Llama al constructor base para inicializar los atributos comunes
        public Pelicula(TipoAnime tipoAnime, string nombre, string genero, bool estado, int idImagen, bool peliculaUnica) : base(tipoAnime, nombre, genero, estado, idImagen)
        {
            // Inicializa la propiedad 'PeliculaUnica' con el valor proporcionado
            PeliculaUnica = peliculaUnica;
        }

        // Método que convierte una cadena ("Si" o "No") a un valor booleano
        public bool getPeliculaUnica(string peliculaUnica)
        {
            bool unica = false;
            // Verifica si el valor es "Si" o "No" para determinar si la película es única
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

        // Método que sobrescribe el método ToString() para mostrar información detallada de la película
        // Combina la información de la clase base 'Anime' con la propiedad 'PeliculaUnica'
        public override string ToString()
        {
            return base.ToString() + "Pelicula Unica: " + PeliculaUnica;
        }

        // Sobrescribe el método Equals() para comparar dos objetos 'Pelicula' por su propiedad 'PeliculaUnica'
        // También utiliza la implementación de Equals() de la clase base 'Anime' para comparar los atributos comunes
        public override bool Equals(object? obj)
        {
            // Primero compara la clase base 'Anime'
            if (base.Equals(obj))
            {
                return true;
            }

            // Si el objeto es de tipo 'Pelicula', compara el valor de 'PeliculaUnica'
            if (obj is Pelicula pelicula)
            {
                return PeliculaUnica == pelicula.PeliculaUnica;
            }

            return false;
        }

        // Sobrescribe el método GetHashCode() para garantizar que las instancias de 'Pelicula' tengan un código de hash único
        // Utiliza el código de hash de la clase base 'Anime'
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
