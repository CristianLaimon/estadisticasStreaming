using estadisticasStreaming.Clases;
using estadisticasStreaming.Forms;
using estadisticasStreaming.Formsitos;
using System.Windows.Forms.DataVisualization.Charting;

namespace estadisticasStreaming
{
    public partial class Form1 : Form
    {
        public static Form1 Instancia { get; set; } 
        private string rutaArchivo, rutaAnterior;
        private static List<Registro> listaRegistros;

        public Form1()
        {
            InitializeComponent();
            Instancia = this;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hecho por: Diana Yulissa Sesma Santiago y Kristan Ruiz Limon";
            openFileDialog1.Filter = "Archivos de texto(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, "Data");
            listaRegistros = new List<Registro>();
            buttonInformacion.Enabled = false;
            buttonEstadisticas.Enabled = false;
            buttonCerrar.Visible = false;
            panel2.Visible = false;
            chartTiposUsuarios.Visible = false;
            chartTerminaron.Visible = false;
            chartTipoProducto.Visible = false;
            chartConsumoGenero.Visible = false;
            chartAnios.Visible = false;
            chartConsumoPais.Visible = false;
            chartPeliculaMasPopular.Visible = false;
            chartSerieMasPopular.Visible = false;
        }

        #region ChartsClicks
        private void chartTiposUsuarios_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "tiposUsuarios";
            AbrirForm2();
        }

        private void chartTerminaron_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "terminaron";
            AbrirForm2();
        }

        private void chartTipoProducto_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "tipoProducto";
            AbrirForm2();
        }

        private void chartConsumoGenero_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "consumoGenero";
            AbrirForm2();
        }

        private void chartAnios_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "anios";
            AbrirForm2();
        }

        private void chartConsumoPais_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "consumoPais";
            AbrirForm2();
        }

        private void chartPeliculaMasPopular_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "peliculaMasPopular";
            AbrirForm2();
        }

        private void chartSerieMasPopular_Click(object sender, EventArgs e)
        {
            Estadisticas.TipoChart = "serieMasPopular";
            AbrirForm2();
        }
        #endregion

        #region ClickEventos
        private void buttonSeleccionar_Click(object sender, EventArgs e) => ObtenerRuta();

        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();

        private void buttonInformacion_Click(object sender, EventArgs e) => ObtenerInfo();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!AjustesForm.AlreadyOpened)
            {
                var ajustesForm = new AjustesForm();
                ajustesForm.StartPosition = FormStartPosition.CenterScreen;
                ajustesForm.Show();
                ajustesForm.BringToFront();
            }
            else
            {
                AjustesForm.Instancia.BringToFront();
            }
        }
        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            EsconderBotones();
            Estadisticas.ReiniciarEstadisticas();
            ReiniciarCharts();
            Estadisticas.ObtenerEstadisticas(rutaArchivo, listaRegistros);
            MostrarGraficas();
        }

        private void buttonTotalTipoUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Startes: " + Estadisticas.NoStarters + "\r\n\r\n" +
                "Watchers: " + Estadisticas.NoWatchers + "\r\n\r\n" +
                "Completers: " + Estadisticas.NoCompleters,
                "Total Tipos de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonTotalTerminaron_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si Terminaron: " + Estadisticas.VerCompleto + "\r\n\r\n" +
                "No Terminaron: " + Estadisticas.VerIncompleto + "\r\n\r\n",
                "Total Terminaron", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPaisMasConsumo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pais: " + Estadisticas.PaisMasConsumo, "Pais que Mas Consume", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPeliculaMasPopular_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pelicula: " + Estadisticas.PeliculaPopular, "Pelicula Mas Popular", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSerieMasPopular_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Serie: " + Estadisticas.SeriePopular, "Serie Mas Popular", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            buttonCerrar.Visible = false;
            buttonInformacion.Visible = true;
            buttonEstadisticas.Visible = true;
            buttonSeleccionar.Visible = true;
            buttonSalir.Visible = true;
            chartTiposUsuarios.Visible = false;
            chartTerminaron.Visible = false;
            chartTipoProducto.Visible = false;
            chartConsumoGenero.Visible = false;
            chartAnios.Visible = false;
            chartConsumoPais.Visible = false;
            chartPeliculaMasPopular.Visible = false;
            chartSerieMasPopular.Visible = false;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea Salir?", "¿Salir?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) Application.Exit();
        }
        #endregion

        #region Funcionalidades
        private void EsconderBotones()
        {
            buttonInformacion.Visible = false;
            buttonEstadisticas.Visible = false;
            buttonSeleccionar.Visible = false;
            buttonSalir.Visible = false;
            panel2.Visible = true;
            buttonTotalTipoUsuario.Visible = false;
            buttonTotalTerminaron.Visible = false;
            buttonPaisMasConsumo.Visible = false;
            buttonPeliculaMasPopular.Visible = false;
            buttonSerieMasPopular.Visible = false;
        }
        private void ObtenerRuta()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (rutaAnterior == null)
                {
                    rutaAnterior = openFileDialog1.FileName;
                }

                rutaArchivo = openFileDialog1.FileName;
                ValidarDatos();
                //Estadisticas.Activar = true;
            }
        }
        private void ObtenerInfo()
        {
            MessageBox.Show(
                "Ruta del Archivo: " + rutaArchivo + "\r\n\r\n" +
                "Fecha y Hora de Creacion: " + File.GetCreationTime(rutaArchivo) + "\r\n\r\n" +
                "Ultima Modificacion: " + File.GetLastWriteTime(rutaArchivo) + "\r\n\r\n" +
                "Ultimo Acceso: " + File.GetLastAccessTime(rutaArchivo)
                , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ReiniciarCharts()
        {
            listaRegistros.Clear();
            buttonCerrar.Visible = true;
            chartSerieMasPopular.Series.Clear();
            chartTiposUsuarios.Titles.Clear();
            chartPeliculaMasPopular.Series.Clear();
            chartTerminaron.Titles.Clear();
            chartTipoProducto.Titles.Clear();
            chartConsumoGenero.Titles.Clear();
            chartAnios.Titles.Clear();
            chartConsumoPais.Titles.Clear();
            chartPeliculaMasPopular.Titles.Clear();
            chartTiposUsuarios.Series.Clear();
            chartTerminaron.Series.Clear();
            chartTipoProducto.Series.Clear();
            chartConsumoGenero.Series.Clear();
            chartAnios.Series.Clear();
            chartConsumoPais.Series.Clear();
            chartSerieMasPopular.Titles.Clear();

        }

        public void AbrirForm2()
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(this.Location.X + 25, this.Location.Y + 25);
            form2.ShowDialog();
        }

        #endregion

        #region Datos
        private void ValidarDatos()
        {
            bool compatible = true;
            string[] lineaElementos;

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    lineaElementos = linea.Split(',');

                    if (lineaElementos.Length != 11)
                    {
                        compatible = false;
                        break;
                    }
                }
            }
            if (compatible) ImprimirDatos();
            else
            {
                rutaArchivo = rutaAnterior;
                buttonInformacion.Enabled = false;
                buttonEstadisticas.Enabled = false;
                MessageBox.Show("Ha seleccionado un archivo con un formato incompatible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirDatos()
        {
            dataGridView1.Rows.Clear();
            buttonInformacion.Enabled = true;
            buttonEstadisticas.Enabled = true;
            toolStripStatusLabel1.Text = rutaArchivo;
            int fila = 0;

            using (StreamReader lector = new StreamReader(rutaArchivo)) //Esta es la segunda vez que lo lee ahora si completo ya habiendo verificado que podrá leerlo completo
            {
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    string[] lineaElementos = linea.Split(',');
                    dataGridView1.Rows.Add();

                    for (int i = 0; i < lineaElementos.Length; i++)
                    {
                        dataGridView1.Rows[fila].Cells[i].Value = lineaElementos[i];
                    }
                    fila++;
                }
            }
        }
        #endregion


        private void MostrarGraficas()
        {
            if (Estadisticas.TipoGrafica == "")
            {
                chartTiposUsuarios.Visible = true;
                string[] series = { "Startes", "Watchers", "Completers" };
                int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
                chartTiposUsuarios.Titles.Add("Tipos de Usuarios%");

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = chartTiposUsuarios.Series.Add(series[i]);
                    serie.Label = puntos[i].ToString();
                    serie.Points.Add(puntos[i]);
                }

                chartTerminaron.Visible = true;
                string[] series2 = { "Completo", "Incompleto" };
                int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
                chartTerminaron.Titles.Add("Terminaron%");

                for (int i = 0; i < series2.Length; i++)
                {
                    Series serie2 = chartTerminaron.Series.Add(series2[i]);
                    serie2.Label = puntos2[i].ToString();
                    serie2.Points.Add(puntos2[i]);
                }

                chartTipoProducto.Visible = true;
                string[] series3 = { "Peliculas", "Series" };
                int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
                chartTipoProducto.Titles.Add("Consumo Tipo de Producto%");

                for (int i = 0; i < series3.Length; i++)
                {
                    Series serie3 = chartTipoProducto.Series.Add(series3[i]);
                    serie3.Label = puntos3[i].ToString();
                    serie3.Points.Add(puntos3[i]);
                }

                chartConsumoGenero.Visible = true;
                string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
                int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
                chartConsumoGenero.Titles.Add("Consumo por Genero%");

                for (int i = 0; i < series4.Length; i++)
                {
                    Series serie4 = chartConsumoGenero.Series.Add(series4[i]);
                    serie4.Label = puntos4[i].ToString();
                    serie4.Points.Add(puntos4[i]);
                }

                chartAnios.Visible = true;
                string[] series5 = { "2020", "2021", "2022", "2023" };
                int[] puntos5 = { Estadisticas.Anio2020 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2021 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2022 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2023 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023) };
                chartAnios.Titles.Add("#Productos Estrenados");

                for (int i = 0; i < series5.Length; i++)
                {
                    Series serie5 = chartAnios.Series.Add(series5[i]);
                    serie5.Label = puntos5[i].ToString();
                    serie5.Points.Add(puntos5[i]);
                }

                chartConsumoPais.Visible = true;
                string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
                int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
                chartConsumoPais.Titles.Add("Consumo por Pais%");

                for (int i = 0; i < series6.Length; i++)
                {
                    Series serie6 = chartConsumoPais.Series.Add(series6[i]);
                    serie6.Label = puntos6[i].ToString();
                    serie6.Points.Add(puntos6[i]);
                }

                chartPeliculaMasPopular.Visible = true;
                string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
                int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
                chartPeliculaMasPopular.Titles.Add("#Peliculas");

                for (int i = 0; i < series7.Length; i++)
                {
                    Series serie7 = chartPeliculaMasPopular.Series.Add(series7[i]);
                    serie7.Label = puntos7[i].ToString();
                    serie7.Points.Add(puntos7[i]);
                }

                chartSerieMasPopular.Visible = true;
                string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
                int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
                chartSerieMasPopular.Titles.Add("#Series");

                for (int i = 0; i < series8.Length; i++)
                {
                    Series serie8 = chartSerieMasPopular.Series.Add(series8[i]);
                    serie8.Label = puntos8[i].ToString();
                    serie8.Points.Add(puntos8[i]);
                }
            }

            if (Estadisticas.TipoGrafica == "Pastel")
            {
                chartTiposUsuarios.Visible = true;
                string[] series = { "Startes", "Watchers", "Completers" };
                int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                    Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                    Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
                chartTiposUsuarios.Titles.Add("Tipos de Usuarios%");

                Series serie = new Series();
                serie.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series.Length; i++)
                {
                    serie.Points.Add(new DataPoint(0, puntos[i]) { LegendText = series[i], Label = puntos[i].ToString() + "%" });
                }
                chartTiposUsuarios.Series.Add(serie);

                chartTerminaron.Visible = true;
                string[] series2 = { "Completo", "Incompleto" };
                int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
                chartTerminaron.Titles.Add("Terminaron%");

                Series serie2 = new Series();
                serie2.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series2.Length; i++)
                {
                    serie2.Points.Add(new DataPoint(0, puntos2[i]) { LegendText = series2[i], Label = puntos2[i].ToString() + "%" });
                }
                chartTerminaron.Series.Add(serie2);

                chartTipoProducto.Visible = true;
                string[] series3 = { "Peliculas", "Series" };
                int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
                chartTipoProducto.Titles.Add("Consumo Tipo de Producto%");

                Series serie3 = new Series();
                serie3.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series3.Length; i++)
                {
                    serie3.Points.Add(new DataPoint(0, puntos3[i]) { LegendText = series3[i], Label = puntos3[i].ToString() + "%" });
                }
                chartTipoProducto.Series.Add(serie3);

                chartConsumoGenero.Visible = true;
                string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
                int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
                chartConsumoGenero.Titles.Add("Consumo por Genero%");

                Series serie4 = new Series();
                serie4.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series4.Length; i++)
                {
                    serie4.Points.Add(new DataPoint(0, puntos4[i]) { LegendText = series4[i], Label = puntos4[i].ToString() + "%" });
                }
                chartConsumoGenero.Series.Add(serie4);

                chartAnios.Visible = true;
                string[] series5 = { "2020", "2021", "2022", "2023" };
                int[] puntos5 = { Estadisticas.Anio2020 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2021 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2022 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2023 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023) };
                chartAnios.Titles.Add("#Productos Estrenados");

                Series serie5 = new Series();
                serie5.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series5.Length; i++)
                {
                    serie5.Points.Add(new DataPoint(0, puntos5[i]) { LegendText = series5[i], Label = puntos5[i].ToString() + "%" });
                }
                chartAnios.Series.Add(serie5);

                chartConsumoPais.Visible = true;
                string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
                int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
                chartConsumoPais.Titles.Add("Consumo por Pais%");

                Series serie6 = new Series();
                serie6.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series6.Length; i++)
                {
                    serie6.Points.Add(new DataPoint(0, puntos6[i]) { LegendText = series6[i], Label = puntos6[i].ToString() + "%" });
                }
                chartConsumoPais.Series.Add(serie6);

                chartPeliculaMasPopular.Visible = true;
                string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
                int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
                chartPeliculaMasPopular.Titles.Add("#Peliculas");

                Series serie7 = new Series();
                serie7.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series7.Length; i++)
                {
                    serie7.Points.Add(new DataPoint(0, puntos7[i]) { LegendText = series7[i], Label = puntos7[i].ToString() + "%" });
                }
                chartPeliculaMasPopular.Series.Add(serie7);

                chartSerieMasPopular.Visible = true;
                string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
                int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
                chartSerieMasPopular.Titles.Add("#Series");

                Series serie8 = new Series();
                serie8.ChartType = SeriesChartType.Pie;

                for (int i = 0; i < series8.Length; i++)
                {
                    serie8.Points.Add(new DataPoint(0, puntos8[i]) { LegendText = series8[i], Label = puntos8[i].ToString() + "%" });
                }
                chartSerieMasPopular.Series.Add(serie8);
            }
            else if (Estadisticas.TipoGrafica == "Barras")
            {
                chartTiposUsuarios.Visible = true;
                string[] series = { "Startes", "Watchers", "Completers" };
                int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters),
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
                chartTiposUsuarios.Titles.Add("Tipos de Usuarios%");

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = chartTiposUsuarios.Series.Add(series[i]);
                    serie.Label = puntos[i].ToString();
                    serie.Points.Add(puntos[i]);
                }

                chartTerminaron.Visible = true;
                string[] series2 = { "Completo", "Incompleto" };
                int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
                chartTerminaron.Titles.Add("Terminaron%");

                for (int i = 0; i < series2.Length; i++)
                {
                    Series serie2 = chartTerminaron.Series.Add(series2[i]);
                    serie2.Label = puntos2[i].ToString();
                    serie2.Points.Add(puntos2[i]);
                }

                chartTipoProducto.Visible = true;
                string[] series3 = { "Peliculas", "Series" };
                int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
                chartTipoProducto.Titles.Add("Consumo Tipo de Producto%");

                for (int i = 0; i < series3.Length; i++)
                {
                    Series serie3 = chartTipoProducto.Series.Add(series3[i]);
                    serie3.Label = puntos3[i].ToString();
                    serie3.Points.Add(puntos3[i]);
                }

                chartConsumoGenero.Visible = true;
                string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
                int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
                chartConsumoGenero.Titles.Add("Consumo por Genero%");

                for (int i = 0; i < series4.Length; i++)
                {
                    Series serie4 = chartConsumoGenero.Series.Add(series4[i]);
                    serie4.Label = puntos4[i].ToString();
                    serie4.Points.Add(puntos4[i]);
                }

                chartAnios.Visible = true;
                string[] series5 = { "2020", "2021", "2022", "2023" };
                int[] puntos5 = { Estadisticas.Anio2020 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2021 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2022 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023),
                Estadisticas.Anio2023 * 100 / (Estadisticas.Anio2020 + Estadisticas.Anio2021 + Estadisticas.Anio2022 + Estadisticas.Anio2023) };
                chartAnios.Titles.Add("#Productos Estrenados");

                for (int i = 0; i < series5.Length; i++)
                {
                    Series serie5 = chartAnios.Series.Add(series5[i]);
                    serie5.Label = puntos5[i].ToString();
                    serie5.Points.Add(puntos5[i]);
                }

                chartConsumoPais.Visible = true;
                string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
                int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
                chartConsumoPais.Titles.Add("Consumo por Pais%");

                for (int i = 0; i < series6.Length; i++)
                {
                    Series serie6 = chartConsumoPais.Series.Add(series6[i]);
                    serie6.Label = puntos6[i].ToString();
                    serie6.Points.Add(puntos6[i]);
                }

                chartPeliculaMasPopular.Visible = true;
                string[] series7 = Estadisticas.PeliculasYCantidad.Keys.ToArray();
                int[] puntos7 = Estadisticas.PeliculasYCantidad.Values.ToArray();
                chartPeliculaMasPopular.Titles.Add("#Peliculas");

                for (int i = 0; i < series7.Length; i++)
                {
                    Series serie7 = chartPeliculaMasPopular.Series.Add(series7[i]);
                    serie7.Label = puntos7[i].ToString();
                    serie7.Points.Add(puntos7[i]);
                }

                chartSerieMasPopular.Visible = true;
                string[] series8 = Estadisticas.SeriesYCantidad.Keys.ToArray();
                int[] puntos8 = Estadisticas.SeriesYCantidad.Values.ToArray();
                chartSerieMasPopular.Titles.Add("#Series");

                for (int i = 0; i < series8.Length; i++)
                {
                    Series serie8 = chartSerieMasPopular.Series.Add(series8[i]);
                    serie8.Label = puntos8[i].ToString();
                    serie8.Points.Add(puntos8[i]);
                }
            }
        }
    }
}