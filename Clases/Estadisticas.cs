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
        private static int Anio2020 = 0;
        private static int Anio2021 = 0;
        private static int Anio2022 = 0;
        private static int Anio2023 = 0;

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
        public static int Anio20201 { get => Anio2020; set => Anio2020 = value; }
        public static int Anio20211 { get => Anio2021; set => Anio2021 = value; }
        public static int Anio20221 { get => Anio2022; set => Anio2022 = value; }
        public static int Anio20231 { get => Anio2023; set => Anio2023 = value; }
    }
}
