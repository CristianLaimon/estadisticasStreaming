using estadisticasStreaming.Clases;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace estadisticasStreaming
{
    public partial class Form1 : Form
    {
        private string rutaArchivo;
        private static List<Registro> listaRegistros;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hecho por: Diana Yulissa Sesma Santiago y Kristan Ruíz Limón";
            openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, "Data");
            listaRegistros = new List<Registro>();
            buttonInformacion.Enabled = false;
            buttonEstadisticas.Enabled = false;
            buttonCerrar.Visible = false;
            panel2.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            //chart7.Visible = false;
            //chart8.Visible = false;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e) => ObtenerRuta();

        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();

        private void buttonInformacion_Click(object sender, EventArgs e) => ObtenerInfo();

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            buttonInformacion.Visible = false;
            buttonEstadisticas.Visible = false;
            buttonSeleccionar.Visible = false;
            panel2.Visible = true;
            ObtenerDatos();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            buttonInformacion.Visible = true;
            buttonEstadisticas.Visible = true;
            buttonSeleccionar.Visible = true;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            //chart7.Visible = false;
            //chart8.Visible = false;
            buttonCerrar.Visible = false;
        }

        private void ObtenerRuta()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog1.FileName;
                ImprimirContenido();
            }
        }

        private void ObtenerInfo()
        {
            rutaArchivo = openFileDialog1.FileName;
            MessageBox.Show(
                "Ruta del Archivo: " + rutaArchivo + "\r\n\r\n" +
                "Fecha y Hora de Creación: " + File.GetCreationTime(rutaArchivo) + "\r\n\r\n" +
                "Ultima Modificación: " + File.GetLastWriteTime(rutaArchivo) + "\r\n\r\n" +
                "Ultimo Acceso: " + File.GetLastAccessTime(rutaArchivo)
                , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImprimirContenido()
        {
            buttonInformacion.Enabled = true;
            buttonEstadisticas.Enabled = true;
            toolStripStatusLabel1.Text = rutaArchivo;
            int fila = 0;
            
            using (StreamReader lector = new StreamReader(rutaArchivo))
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

        private void ObtenerDatos() 
        {
            Reiniciar();

            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
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

                    if (Estadisticas.PeliculasYCantidad.ContainsKey(r.ProductoVisto)) //Si ya existe la llave (la pelicula), se le suma 1 al valor de la llave a su contador.
                    {
                        Estadisticas.PeliculasYCantidad[r.ProductoVisto]++;
                    }
                    else
                    {
                        Estadisticas.PeliculasYCantidad.Add(r.ProductoVisto, 1); //Si no existe la llave, se crea y se le asigna el valor de 1.
                    }
                }
                else
                {
                    Estadisticas.Series++;

                    if (Estadisticas.SeriesYCantidad.ContainsKey(r.ProductoVisto)) 
                    { 
                        Estadisticas.SeriesYCantidad[r.ProductoVisto]++;
                    }
                    else
                    {
                        Estadisticas.SeriesYCantidad.Add(r.ProductoVisto, 1);
                    }
                }

                switch (r.Genero)
                {
                    case "ROMANCE": Estadisticas.Romance++;
                        break;
                    case "DRAMA": Estadisticas.Drama++;
                        break;
                    case "TERROR": Estadisticas.Terror++;
                        break;
                    case "SUSPENSO": Estadisticas.Suspenso++;
                        break;
                    case "ACCION": Estadisticas.Accion++;
                        break;
                }

                switch (r.AnioEstreno)
                {
                    case "2020": Estadisticas.Anio2020++;
                        break;
                    case "2021": Estadisticas.Anio2021++;
                        break;
                    case "2022": Estadisticas.Anio2022++;
                        break;
                    case "2023": Estadisticas.Anio2023++;
                        break;
                }

                switch (r.Pais)
                {
                    case "MEXICO": Estadisticas.Mexico++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                    case "EU": Estadisticas.Eu++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                    case "CANADA": Estadisticas.Canada++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                    case "COLOMBIA": Estadisticas.Colombia++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                    case "CUBA": Estadisticas.Cuba++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                    case "COSTA RICA": Estadisticas.CostaRica++;
                        {
                            if (Estadisticas.PaisYCantidad.ContainsKey(r.Pais))
                            {
                                Estadisticas.PaisYCantidad[r.Pais]++;
                            }
                            else
                            {
                                Estadisticas.PaisYCantidad.Add(r.Pais, 1);
                            }
                        }
                        break;
                }
            }

            Estadisticas.PeliculaPopular = Estadisticas.PeliculasYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key; //Obtiene la pelicula con el valor (contador) más alto.
            Estadisticas.SeriePopular = Estadisticas.SeriesYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Estadisticas.PaisMasConsumo = Estadisticas.PaisYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            chart1.Visible = true;
            string[] series = { "No Startes", "No Watchers", "No Completers" };
            int[] puntos = { Estadisticas.NoStarters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters), 
                Estadisticas.NoWatchers * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters), 
                Estadisticas.NoCompleters * 100 / (Estadisticas.NoStarters + Estadisticas.NoWatchers + Estadisticas.NoCompleters) };
            chart1.Palette = ChartColorPalette.Chocolate;
            chart1.Titles.Add("Terminaron");

            for (int i = 0; i < series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);
                serie.Label = puntos[i].ToString();
                serie.Points.Add(puntos[i]);
            }

            chart2.Visible = true;
            string[] series2 = { "Completo", "Incompleto" };
            int[] puntos2 = { Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto),
            Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto) };
            chart2.Palette = ChartColorPalette.Chocolate;
            chart2.Titles.Add("Com o In");

            for (int i = 0; i < series2.Length; i++)
            {
                Series serie2 = chart2.Series.Add(series2[i]);
                serie2.Label = puntos2[i].ToString();
                serie2.Points.Add(puntos2[i]);
            }

            chart3.Visible = true;
            string[] series3 = { "Peliculas", "Series" };
            int[] puntos3 = { Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series),
            Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series) };
            chart3.Palette = ChartColorPalette.Chocolate;
            chart3.Titles.Add("Pel o Ser");

            for (int i = 0; i < series3.Length; i++)
            {
                Series serie3 = chart3.Series.Add(series3[i]);
                serie3.Label = puntos3[i].ToString();
                serie3.Points.Add(puntos3[i]);
            }

            chart4.Visible = true;
            string[] series4 = { "Romance", "Drama", "Terror", "Suspenso", "Accion" };
            int[] puntos4 = { Estadisticas.Romance * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Drama * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Terror * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Suspenso * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion),
                Estadisticas.Accion * 100 / (Estadisticas.Romance + Estadisticas.Drama + Estadisticas.Terror + Estadisticas.Suspenso + Estadisticas.Accion) };
            chart4.Palette = ChartColorPalette.Chocolate;
            chart4.Titles.Add("Categorias");

            for (int i = 0; i < series4.Length; i++)
            {
                Series serie4 = chart4.Series.Add(series4[i]);
                serie4.Label = puntos4[i].ToString();
                serie4.Points.Add(puntos4[i]);
            }

            chart5.Visible = true;
            string[] series5 = { "2020", "2021", "2022", "2023" };
            int[] puntos5 = { Estadisticas.Anio2020, Estadisticas.Anio2021, Estadisticas.Anio2022, Estadisticas.Anio2023 };
            chart5.Palette = ChartColorPalette.Chocolate;
            chart5.Titles.Add("Años");

            for (int i = 0; i < series5.Length; i++)
            {
                Series serie5 = chart5.Series.Add(series5[i]);
                serie5.Label = puntos5[i].ToString();
                serie5.Points.Add(puntos5[i]);
            }

            chart6.Visible = true;
            string[] series6 = { "Mexico", "EU", "Canada", "Colombia", "Cuba", "Costa Rica" };
            int[] puntos6 = { Estadisticas.Mexico * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Eu * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Canada * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Colombia * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.Cuba * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica),
            Estadisticas.CostaRica * 100 / (Estadisticas.Mexico + Estadisticas.Eu + Estadisticas.Canada + Estadisticas.Colombia + Estadisticas.Cuba + Estadisticas.CostaRica)};
            chart6.Palette = ChartColorPalette.Chocolate;
            chart6.Titles.Add("Paises");

            for (int i = 0; i < series6.Length; i++)
            {
                Series serie6 = chart6.Series.Add(series6[i]);
                serie6.Label = puntos6[i].ToString();
                serie6.Points.Add(puntos6[i]);
            }

            //MessageBox.Show("Pelicula+: " + Estadisticas.PeliculaPopular);
            //MessageBox.Show("Serie+: " + Estadisticas.SeriePopular);
        }

        private void Reiniciar()
        {
            listaRegistros.Clear();
            Estadisticas.NoStarters = 0;
            Estadisticas.NoWatchers = 0;
            Estadisticas.NoCompleters = 0;
            Estadisticas.Romance = 0;
            Estadisticas.Drama = 0;
            Estadisticas.Terror = 0;
            Estadisticas.Suspenso = 0;
            Estadisticas.Accion = 0;
            Estadisticas.Anio2020 = 0;
            Estadisticas.Anio2021 = 0;
            Estadisticas.Anio2022 = 0;
            Estadisticas.Anio2023 = 0;
            buttonCerrar.Visible = true;
            //Reinicar graficas***PENDIENTE***
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea Salir?", "¿Salir?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}