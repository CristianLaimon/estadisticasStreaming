using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estadisticasStreaming.Clases
{
    internal static class Estadisticas
    {
        private static int totalUsuarios = 0; //Igual al numero de registros
        private static int noStarters = 0;
        private static int noWatchers = 0;
        private static int noCompleters = 0;
        private static int verCompleto = 0;
        private static int verIncompleto = 0;
        private static int series = 0;
        private static int peliculas = 0;
        private static int romance = 0;
        private static int drama = 0;
        private static int terror = 0;
        private static int suspenso = 0;
        private static int accion = 0;
        private static int anio2020 = 0;
        private static int anio2021 = 0;
        private static int anio2022 = 0;
        private static int anio2023 = 0;
        private static int mexico = 0;
        private static int eu = 0;
        private static int canada = 0;
        private static int colombia = 0;
        private static int cuba = 0;
        private static int costaRica = 0;
        private static string peliculaPopular = "";
        private static string seriePopular = "";

        public static int TotalUsuarios { get => totalUsuarios; set => totalUsuarios = value; }
        public static int NoStarters { get => noStarters; set => noStarters = value; }
        public static int NoWatchers { get => noWatchers; set => noWatchers = value; }
        public static int NoCompleters { get => noCompleters; set => noCompleters = value; }
        public static int VerCompleto { get => verCompleto; set => verCompleto = value; }
        public static int VerIncompleto { get => verIncompleto; set => verIncompleto = value; }
        public static int Series { get => series; set => series = value; }
        public static int Peliculas { get => peliculas; set => peliculas = value; }
        public static int Romance { get => romance; set => romance = value; }
        public static int Drama { get => drama; set => drama = value; }
        public static int Terror { get => terror; set => terror = value; }
        public static int Suspenso { get => suspenso; set => suspenso = value; }
        public static int Accion { get => accion; set => accion = value; }
        public static int Anio2020 { get => anio2020; set => anio2020 = value; }
        public static int Anio2021 { get => anio2021; set => anio2021 = value; }
        public static int Anio2022 { get => anio2022; set => anio2022 = value; }
        public static int Anio2023 { get => anio2023; set => anio2023 = value; }
        public static int Mexico { get => mexico; set => mexico = value; }
        public static int Eu { get => eu; set => eu = value; }
        public static int Canada { get => canada; set => canada = value; }
        public static int Colombia { get => colombia; set => colombia = value; }
        public static int Cuba { get => cuba; set => cuba = value; }
        public static int CostaRica { get => costaRica; set => costaRica = value; }
        public static string PeliculaPopular { get => peliculaPopular; set => peliculaPopular = value; }
        public static string SeriePopular { get => seriePopular; set => seriePopular = value; }
    }
}
