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
        private static bool activar = false;

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
        public static bool Activar { get => activar; set => activar = value; }

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

            Estadisticas.TotalUsuarios = listaRegistros.Count;

            foreach (Registro r in listaRegistros)
            {
                if (r.MinutosVistos <= (short)(r.Duracion * 0.1)) Estadisticas.NoStarters++;
                else if (r.MinutosVistos < (short)(r.Duracion * .9)) Estadisticas.NoWatchers++;
                else if (r.MinutosVistos >= (short)(r.Duracion * .9)) Estadisticas.NoCompleters++;

                if (r.MinutosVistos == r.Duracion) Estadisticas.VerCompleto++;
                else Estadisticas.VerIncompleto++;

                if (r.Tipo == "PELICULA")
                {
                    Estadisticas.Peliculas++;
                    if (Estadisticas.PeliculasYCantidad.ContainsKey(r.ProductoVisto)) Estadisticas.PeliculasYCantidad[r.ProductoVisto]++;
                    else Estadisticas.PeliculasYCantidad.Add(r.ProductoVisto, 1);
                }
                else
                {
                    Estadisticas.Series++;
                    if (Estadisticas.SeriesYCantidad.ContainsKey(r.ProductoVisto)) Estadisticas.SeriesYCantidad[r.ProductoVisto]++;
                    else Estadisticas.SeriesYCantidad.Add(r.ProductoVisto, 1);
                }

                switch (r.Genero)
                {
                    case "ROMANCE":
                        Estadisticas.Romance++;
                        break;

                    case "DRAMA":
                        Estadisticas.Drama++;
                        break;

                    case "TERROR":
                        Estadisticas.Terror++;
                        break;

                    case "SUSPENSO":
                        Estadisticas.Suspenso++;
                        break;

                    case "ACCION":
                        Estadisticas.Accion++;
                        break;
                }

                switch (r.AnioEstreno)
                {
                    case "2020":
                        Estadisticas.Anio2020++;
                        break;

                    case "2021":
                        Estadisticas.Anio2021++;
                        break;

                    case "2022":
                        Estadisticas.Anio2022++;
                        break;

                    case "2023":
                        Estadisticas.Anio2023++;
                        break;
                }

                switch (r.Pais)
                {
                    case "MEXICO":
                        Estadisticas.Mexico++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "EU":
                        Estadisticas.Eu++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "CANADA":
                        Estadisticas.Canada++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "COLOMBIA":
                        Estadisticas.Colombia++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "CUBA":
                        Estadisticas.Cuba++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;

                    case "COSTA RICA":
                        Estadisticas.CostaRica++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais)) Estadisticas.PaisYCantidad[r.Pais]++;
                            else Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                        }
                        break;
                }
            }

            Estadisticas.PeliculaPopular = Estadisticas.PeliculasYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Estadisticas.SeriePopular = Estadisticas.SeriesYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Estadisticas.PaisMasConsumo = Estadisticas.PaisYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        }

        public static void ReiniciarEstadisticas()
        {
            Estadisticas.NoStarters = 0;
            Estadisticas.NoWatchers = 0;
            Estadisticas.NoCompleters = 0;
            Estadisticas.VerCompleto = 0;
            Estadisticas.VerIncompleto = 0;
            Estadisticas.Peliculas = 0;
            Estadisticas.Series = 0;
            Estadisticas.Romance = 0;
            Estadisticas.Drama = 0;
            Estadisticas.Terror = 0;
            Estadisticas.Suspenso = 0;
            Estadisticas.Accion = 0;
            Estadisticas.Anio2020 = 0;
            Estadisticas.Anio2021 = 0;
            Estadisticas.Anio2022 = 0;
            Estadisticas.Anio2023 = 0;
            Estadisticas.Mexico = 0;
            Estadisticas.Eu = 0;
            Estadisticas.Canada = 0;
            Estadisticas.Colombia = 0;
            Estadisticas.Cuba = 0;
            Estadisticas.CostaRica = 0;
            Estadisticas.PeliculaPopular = "";
            Estadisticas.SeriePopular = "";
            Estadisticas.PaisMasConsumo = "";
            Estadisticas.PeliculasYCantidad.Clear();
            Estadisticas.SeriesYCantidad.Clear();
        }

        public static void Test()
        {
            //------------------------------------------------------------------------------------------------------
            chartTiposUsuarios.Visible = true;
            string[] series = { "Startes", "Watchers", "Completers" };
            int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
            chartTiposUsuarios.Titles.Add("Tipos de Usuarios%");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartTerminaron.Visible = true;
            string[] series2 = { "Completo", "Incompleto" };
            int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
                Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
            chartTerminaron.Titles.Add("Terminaron%");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartTipoProducto.Visible = true;
            string[] series3 = { "Peliculas", "Series" };
            int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
                Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
            chartTipoProducto.Titles.Add("Consumo Tipo de Producto%");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartConsumoGenero.Visible = true;
            string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
            int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
            chartConsumoGenero.Titles.Add("Consumo por Genero%");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartAnios.Visible = true;
            string[] series5 = { "2020", "2021", "2022", "2023" };
            int[] puntos5 = { Estadisticas.Anio2020 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2021 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2022 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2023 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023) };
            chartAnios.Titles.Add("#Productos Estrenados");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartConsumoPais.Visible = true;
            string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
            int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
                Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
                Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
                Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
                Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
                Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
            chartConsumoPais.Titles.Add("Consumo por Pais%");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartPeliculaMasPopular.Visible = true;
            string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
            int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
            chartPeliculaMasPopular.Titles.Add("#Peliculas");
            //------------------------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------------------
            chartSerieMasPopular.Visible = true;
            string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
            int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
            chartSerieMasPopular.Titles.Add("#Series");
            //------------------------------------------------------------------------------------------------------
        }
    }
}
