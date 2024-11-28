using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoAnime.model
{
    [Serializable]
    //Clase padre llamada Anime que va a tener 2 subclases
    public class Anime
    {
        //Atributos privados para poder añadir restricciones
        private string nombre;
        private string genero;
        public int IdImagen {  get; set; }

        //En este no necesitamos restriccion porque debe de ser uno u otro
        public TipoAnime TipoAnime
        { get; set; }

        //Metodo properties el cual contiene la restriccion de si se pasa de 20
        //truncar el nombre o si es nulo vacio no lo mete.
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length <= 20)
                    {
                        nombre = value;
                    }
                    else
                    {
                        string truncado = value.Substring(0, 3) + value.Substring(6, 11);
                        nombre = truncado;
                    }
                }
            }
        }

        public string Genero
        {
            get { return genero; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length <= 20)
                    {
                        genero = value;
                    }
                    else
                    {
                        Console.WriteLine("Genero no válido.");
                    }
                }
            }
        }
        public bool Estado { get; set; }
        //Constructor vacio con datos por defecto
        public Anime()
        {
            TipoAnime = new TipoAnime();
            Nombre = "Sin nombre";
            Genero = "Sin genero";
            Estado = false;
        }
        //Constructor con parametros para serie
        public Anime(string tipoAnime, string nombre, string genero, string estado)
        {
            TipoAnime = getTipoAnime(tipoAnime);
            Nombre = nombre;
            Genero = genero;
            Estado = getEstado(estado);
        }

        //Constructor para cargar archivos de tipo Serie.
        public Anime(TipoAnime tipoAnime, string nombre, string genero, bool estado, int idImagen)
        {
            TipoAnime = tipoAnime;
            Nombre = nombre;
            Genero = genero;
            Estado = estado;
            IdImagen = idImagen;
        }

        public Anime(TipoAnime tipoAnime, string nombre, string genero)
        {
            TipoAnime = tipoAnime;
            Nombre = nombre;
            Genero = genero;
        }

        public Anime(string tipoAnime, string nombre, string genero)
        {
            TipoAnime = getTipoAnime(tipoAnime);
            Nombre = nombre;
            Genero = genero;
        }
        //Metodo que va al constructor para guardar el tipo de anime que es
        private TipoAnime getTipoAnime(string tipoAnime)
        {
            TipoAnime tipo = new TipoAnime();
            switch (tipoAnime)
            {
                case "TV": tipo = TipoAnime.TV; break;
                case "Pelicula": tipo = TipoAnime.Pelicula; break;
                default: Console.WriteLine("Opción no válida."); break;

            }

            return tipo;
        }
        //Metodo que va al constructor para que mediante una cadena guarde en un bool 
        //el estado del anime
        public bool getEstado(string estado)
        {
            bool estadoAnime = false;

            string finalizado = "Finalizado";
            string enEmision = "En Emision";
            if (estado.Equals(enEmision, StringComparison.OrdinalIgnoreCase))
            {
                estadoAnime = true;
            }
            else if (estado.Equals(finalizado, StringComparison.OrdinalIgnoreCase))
            {
                estadoAnime = false;
            }

            return estadoAnime;
        }
        //Metodo toString base.
        public override string ToString()
        {
            string mensaje = Estado ? "En Emision" : "Finalizado";
            return $"\nTipo de Anime: {TipoAnime.ToString()} \nNombre: {nombre} \nGenero: {genero} \nEstado: {mensaje}";
        }

    }
}
