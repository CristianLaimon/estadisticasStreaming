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
        private static Dictionary<string, int> peliculasYCantidad = new Dictionary<string, int>();
        private static Dictionary<string, int> seriesYCantidad = new Dictionary<string, int>();
        private static string peliculaPopular = "";
        private static string seriePopular = "";
        private static string paisMasConsumo = "";
        private static Dictionary<string, int> paisYCantidad = new Dictionary<string, int>();
        private static string tipoChart = "";
        private static string tipoGrafica = "";

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
        public static Dictionary<string, int> PeliculasYCantidad { get => peliculasYCantidad; set => peliculasYCantidad = value; }
        public static Dictionary<string, int> SeriesYCantidad { get => seriesYCantidad; set => seriesYCantidad = value; }
        public static string PaisMasConsumo { get => paisMasConsumo; set => paisMasConsumo = value; }
        public static Dictionary<string, int> PaisYCantidad { get => paisYCantidad; set => paisYCantidad = value; }
        public static string TipoChart { get => tipoChart; set => tipoChart = value; }
        public static string TipoGrafica { get => tipoGrafica; set => tipoGrafica = value; }

        public static void ObtenerEstadisticas(string rutaArchivo, List<Registro> listaRegistros)
        {
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                lector.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    string[] lineaElementos = linea.Split(',');
                    listaRegistros.Add(new Registro(
                        lineaElementos[0],
                      byte.Parse(lineaElementos[1]),
                      lineaElementos[2],
                      lineaElementos[3],
                      lineaElementos[4],
                      lineaElementos[5],
                      lineaElementos[6],
                      lineaElementos[7],
                      lineaElementos[8],
                      short.Parse(lineaElementos[9]),
                      short.Parse(lineaElementos[10])));
                }
            }

            TotalUsuarios = listaRegistros.Count;

            foreach (Registro r in listaRegistros)
            {
                if (r.MinutosVistos <= (short)(r.Duracion * 0.1)) NoStarters++;
                else if (r.MinutosVistos < (short)(r.Duracion * .9)) NoWatchers++;
                else if (r.MinutosVistos >= (short)(r.Duracion * .9)) NoCompleters++;

                if (r.MinutosVistos == r.Duracion) VerCompleto++;
                else VerIncompleto++;

                if (r.Tipo == "PELICULA")
                {
                    Peliculas++;
                    if (PeliculasYCantidad.ContainsKey(r.ProductoVisto)) PeliculasYCantidad[r.ProductoVisto]++;
                    else PeliculasYCantidad.Add(r.ProductoVisto, 1);
                }
                else
                {
                    Series++;
                    if (SeriesYCantidad.ContainsKey(r.ProductoVisto)) SeriesYCantidad[r.ProductoVisto]++;
                    else SeriesYCantidad.Add(r.ProductoVisto, 1);
                }

                switch (r.Genero)
                {
                    case "ROMANCE":
                        Romance++;
                        break;

                    case "DRAMA":
                        Drama++;
                        break;

                    case "TERROR":
                        Terror++;
                        break;

                    case "SUSPENSO":
                        Suspenso++;
                        break;

                    case "ACCION":
                        Accion++;
                        break;
                }

                switch (r.AnioEstreno)
                {
                    case "2020":
                        Anio2020++;
                        break;

                    case "2021":
                        Anio2021++;
                        break;

                    case "2022":
                        Anio2022++;
                        break;

                    case "2023":
                        Anio2023++;
                        break;
                }

                switch (r.Pais)
                {
                    case "MEXICO":
                        Mexico++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "EU":
                        Eu++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "CANADA":
                        Canada++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "COLOMBIA":
                        Colombia++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "CUBA":
                        Cuba++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "COSTA RICA":
                        CostaRica++;
                        {
                            if (PaisYCantidad.ContainsKey(r.Pais)) PaisYCantidad[r.Pais]++;
                            else PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;
                }
            }
            
            PeliculaPopular = PeliculasYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            SeriePopular = SeriesYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            PaisMasConsumo = PaisYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public static void ReiniciarEstadisticas()
        {
            NoStarters = 0;
            NoWatchers = 0;
            NoCompleters = 0;
            VerCompleto = 0;
            VerIncompleto = 0;
            Peliculas = 0;
            Series = 0;
            Romance = 0;
            Drama = 0;
            Terror = 0;
            Suspenso = 0;
            Accion = 0;
            Anio2020 = 0;
            Anio2021 = 0;
            Anio2022 = 0;
            Anio2023 = 0;
            Mexico = 0;
            Eu = 0;
            Canada = 0;
            Colombia = 0;
            Cuba = 0;
            CostaRica = 0;
            PeliculaPopular = "";
            SeriePopular = "";
            PaisMasConsumo = "";
            PeliculasYCantidad.Clear();
            SeriesYCantidad.Clear();
        }
    }
}
