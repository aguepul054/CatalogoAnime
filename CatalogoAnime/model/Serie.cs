using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.model
{
    // Se indica que la clase puede ser serializada, lo que significa que las instancias de esta clase pueden ser convertidas en un flujo de bytes
    [Serializable]
    public class Serie : Anime
    {
        // Atributo privado que representa el número de capítulos de la serie
        private int numeroCapitulos;

        // Propiedad pública que permite acceder y modificar el número de capítulos de la serie
        public int NumeroCapitulos
        {
            get
            {
                return numeroCapitulos;
            }
            set
            {
                // Se asegura de que el número de capítulos sea siempre positivo antes de asignarlo
                if (value > 0)
                {
                    numeroCapitulos = value;
                }
            }
        }

        // Constructor por defecto que establece el número de capítulos en 0
        public Serie()
        {
            NumeroCapitulos = 0;
        }

        // Constructor que permite crear una instancia de 'Serie' usando cadenas de texto
        // Llama al constructor base 'Anime' para inicializar las propiedades comunes
        public Serie(string tipoAnime, string nombre, string genero, string estado, int numeroCapitulos) : base(tipoAnime, nombre, genero, estado)
        {
            // Asigna el número de capítulos de la serie.
            NumeroCapitulos = numeroCapitulos;
        }

        // Constructor que toma parámetros más específicos (tipo de anime, nombre, género, estado, id de imagen)
        // Llama al constructor base para inicializar las propiedades comunes
        // Además, establece el número de capítulos
        public Serie(TipoAnime tipoAnime, string nombre, string genero, bool estado, int idImagen, int numeroCapitulos) : base(tipoAnime, nombre, genero, estado, idImagen)
        {
            // Inicializa la propiedad 'NumeroCapitulos' con el valor proporcionado
            NumeroCapitulos = numeroCapitulos;
        }

        // Método sobrescrito ToString que devuelve una cadena representativa de la serie
        // Incluye la información de la clase base 'Anime' y agrega el número de capítulos de la serie
        public override string ToString()
        {
            return base.ToString() + "\nNumero de capitulos: " + NumeroCapitulos;
        }

        // Método sobrescrito Equals que compara dos objetos para determinar si son iguales
        // Primero compara las propiedades comunes de la clase base 'Anime'
        // Si el objeto también es una instancia de 'Serie', compara el número de capítulos
        public override bool Equals(object? obj)
        {
            // Compara primero las propiedades de la clase base 'Anime'
            if (base.Equals(obj))
            {
                return true;
            }

            // Si el objeto es de tipo 'Serie', compara el número de capítulos
            if (obj is Serie s)
            {
                return NumeroCapitulos == s.NumeroCapitulos;
            }
            return false;
        }

        // Método sobrescrito GetHashCode que devuelve el código hash del objeto
        // Utiliza la implementación de GetHashCode de la clase base 'Anime'
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
