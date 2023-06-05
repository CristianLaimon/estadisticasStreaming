using estadisticasStreaming.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace estadisticasStreaming.Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Estadisticas.TipoGrafica == "Pastel") GraficaPastel(Estadisticas.TipoChart);
            else MostrarGrafica(Estadisticas.TipoChart);
        }

        private void MostrarGrafica(string chart)
        {
            if (chart == "tiposUsuarios")
            {
                chart1.Visible = true;
                string[] series = { "Startes", "Watchers", "Completers" };
                int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
                chart1.Titles.Add("Tipos de Usuarios%");

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = chart1.Series.Add(series[i]);
                    serie.Label = puntos[i].ToString();
                    serie.Points.Add(puntos[i]);
                }
            }
            if (chart == "terminaron")
            {
                chart1.Visible = true;
                string[] series2 = { "Completo", "Incompleto" };
                int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
                chart1.Titles.Add("Terminaron%");

                for (int i = 0; i < series2.Length; i++)
                {
                    Series serie2 = chart1.Series.Add(series2[i]);
                    serie2.Label = puntos2[i].ToString();
                    serie2.Points.Add(puntos2[i]);
                }
            }
            if (chart == "tipoProducto")
            {
                chart1.Visible = true;
                string[] series3 = { "Peliculas", "Series" };
                int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
                chart1.Titles.Add("Consumo Tipo de Producto%");

                for (int i = 0; i < series3.Length; i++)
                {
                    Series serie3 = chart1.Series.Add(series3[i]);
                    serie3.Label = puntos3[i].ToString();
                    serie3.Points.Add(puntos3[i]);
                }
            }
            if (chart == "consumoGenero")
            {
                chart1.Visible = true;
                string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
                int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
                chart1.Titles.Add("Consumo por Genero%");

                for (int i = 0; i < series4.Length; i++)
                {
                    Series serie4 = chart1.Series.Add(series4[i]);
                    serie4.Label = puntos4[i].ToString();
                    serie4.Points.Add(puntos4[i]);
                }
            }
            if (chart == "anios")
            {
                chart1.Visible = true;
                string[] series5 = { "2020", "2021", "2022", "2023" };
                int[] puntos5 = { Estadisticas.Anio2020, Estadisticas.Anio2021, Estadisticas.Anio2022, Estadisticas.Anio2023 };
                chart1.Titles.Add("#Productos Estrenados");

                for (int i = 0; i < series5.Length; i++)
                {
                    Series serie5 = chart1.Series.Add(series5[i]);
                    serie5.Label = puntos5[i].ToString();
                    serie5.Points.Add(puntos5[i]);
                }
            }
            if (chart == "consumoPais")
            {
                chart1.Visible = true;
                string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
                int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
                chart1.Titles.Add("Consumo por Pais%");

                for (int i = 0; i < series6.Length; i++)
                {
                    Series serie6 = chart1.Series.Add(series6[i]);
                    serie6.Label = puntos6[i].ToString();
                    serie6.Points.Add(puntos6[i]);
                }
            }
            if (chart == "peliculaMasPopular")
            {
                chart1.Visible = true;
                string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
                int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
                chart1.Titles.Add("#Peliculas");

                for (int i = 0; i < series7.Length; i++)
                {
                    Series serie7 = chart1.Series.Add(series7[i]);
                    serie7.Label = puntos7[i].ToString();
                    serie7.Points.Add(puntos7[i]);
                }
            }
            if (chart == "serieMasPopular")
            {
                chart1.Visible = true;
                string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
                int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
                chart1.Titles.Add("#Series");

                for (int i = 0; i < series8.Length; i++)
                {
                    Series serie8 = chart1.Series.Add(series8[i]);
                    serie8.Label = puntos8[i].ToString();
                    serie8.Points.Add(puntos8[i]);
                }
            }
        }

        private void GraficaPastel(string chart)
        {
            if (chart == "tiposUsuarios")
            {
                chart1.Visible = true;
                string[] series = { "Startes", "Watchers", "Completers" };
                int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
                chart1.Titles.Add("Tipos de Usuarios%");

                Series serie = new Series();
                serie.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series.Length; i++)
                {
                    serie.Points.Add(new DataPoint(0, puntos[i]) { LegendText = series[i], Label = puntos[i].ToString() + "%" });
                }
                chart1.Series.Add(serie);
            }
            if (chart == "terminaron")
            {
                chart1.Visible = true;
                string[] series2 = { "Completo", "Incompleto" };
                int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
                chart1.Titles.Add("Terminaron%");

                Series serie2 = new Series();
                serie2.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series2.Length; i++)
                {
                    serie2.Points.Add(new DataPoint(0, puntos2[i]) { LegendText = series2[i], Label = puntos2[i].ToString() + "%" });
                }
                chart1.Series.Add(serie2);
            }
            if (chart == "tipoProducto")
            {
                chart1.Visible = true;
                string[] series3 = { "Peliculas", "Series" };
                int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
                chart1.Titles.Add("Consumo Tipo de Producto%");

                Series serie3 = new Series();
                serie3.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series3.Length; i++)
                {
                    serie3.Points.Add(new DataPoint(0, puntos3[i]) { LegendText = series3[i], Label = puntos3[i].ToString() + "%" });
                }
                chart1.Series.Add(serie3);
            }
            if (chart == "consumoGenero")
            {
                chart1.Visible = true;
                string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
                int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
                chart1.Titles.Add("Consumo por Genero%");

                Series serie4 = new Series();
                serie4.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series4.Length; i++)
                {
                    serie4.Points.Add(new DataPoint(0, puntos4[i]) { LegendText = series4[i], Label = puntos4[i].ToString() + "%" });
                }
                chart1.Series.Add(serie4);
            }
            if (chart == "anios")
            {
                chart1.Visible = true;
                string[] series5 = { "2020", "2021", "2022", "2023" };
                int[] puntos5 = { Estadisticas.Anio2020, Estadisticas.Anio2021, Estadisticas.Anio2022,Estadisticas.Anio2023 };
                chart1.Titles.Add("#Productos Estrenados");

                Series serie5 = new Series();
                serie5.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series5.Length; i++)
                {
                    serie5.Points.Add(new DataPoint(0, puntos5[i]) { LegendText = series5[i], Label = puntos5[i].ToString() });
                }
                chart1.Series.Add(serie5);
            }
            if (chart == "consumoPais")
            {
                chart1.Visible = true;
                string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
                int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
                chart1.Titles.Add("Consumo por Pais%");

                Series serie6 = new Series();
                serie6.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series6.Length; i++)
                {
                    serie6.Points.Add(new DataPoint(0, puntos6[i]) { LegendText = series6[i], Label = puntos6[i].ToString() + "%" });
                }
                chart1.Series.Add(serie6);
            }
            if (chart == "peliculaMasPopular")
            {
                chart1.Visible = true;
                string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
                int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
                chart1.Titles.Add("#Peliculas");

                Series serie7 = new Series();
                serie7.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series7.Length; i++)
                {
                    serie7.Points.Add(new DataPoint(0, puntos7[i]) { LegendText = series7[i], Label = puntos7[i].ToString() });
                }
                chart1.Series.Add(serie7);
            }
            if (chart == "serieMasPopular")
            {
                chart1.Visible = true;
                string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
                int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
                chart1.Titles.Add("#Series");

                Series serie8 = new Series();
                serie8.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series8.Length; i++)
                {
                    serie8.Points.Add(new DataPoint(0, puntos8[i]) { LegendText = series8[i], Label = puntos8[i].ToString() });
                }
                chart1.Series.Add(serie8);
            }
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
