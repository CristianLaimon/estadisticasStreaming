using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estadisticasStreaming
{
    internal class Registro
    {
        private static List<Registro> listaRegistros = new List<Registro>();
        private string cuenta, pais, productoVisto, tipo, anioEstreno, genero, director, clasificacion;
        private byte edad;
        private short duracion, minutosVistos;

        public Registro()
        {
            Cuenta = string.Empty;
            Pais = string.Empty;
            ProductoVisto = string.Empty;
            Tipo = string.Empty;
            AnioEstreno = string.Empty;
            Genero = string.Empty;
            Director = string.Empty;
            Clasificacion = string.Empty;
            Edad = 0;
            Duracion = 0;
            MinutosVistos = 0;
        }

        internal static List<Registro> ListaRegistros { get => listaRegistros; set => listaRegistros = value; }
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public string Pais { get => pais; set => pais = value; }
        public string ProductoVisto { get => productoVisto; set => productoVisto = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string AnioEstreno { get => anioEstreno; set => anioEstreno = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Director { get => director; set => director = value; }
        public string Clasificacion { get => clasificacion; set => clasificacion = value; }
        public byte Edad { get => edad; set => edad = value; }
        public short Duracion { get => duracion; set => duracion = value; }
        public short MinutosVistos { get => minutosVistos; set => minutosVistos = value; }
    }
}
