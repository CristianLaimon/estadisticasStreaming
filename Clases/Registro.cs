using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estadisticasStreaming.Clases
{
    internal class Registro
    {
        private string cuenta, pais, productoVisto, tipo, anioEstreno, genero, director, clasificacion;
        private byte edad;
        private short duracion, minutosVistos;

        public Registro(string cuenta, byte edad, string pais, string productoVisto, string tipo, string anioEstreno,
            string genero, string director, string clasificacion, short duracion, short minutosVistos)
        {
            this.cuenta = cuenta;
            this.edad = edad;
            this.pais = pais;
            this.productoVisto = productoVisto;
            this.tipo = tipo;
            this.anioEstreno = anioEstreno;
            this.genero = genero;
            this.director = director;
            this.clasificacion = clasificacion;
            this.duracion = duracion;
            this.minutosVistos = minutosVistos;

        }

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
