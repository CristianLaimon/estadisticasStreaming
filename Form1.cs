using estadisticasStreaming.Clases;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace estadisticasStreaming
{
    public partial class Form1 : Form
    {
        private string rutaArchivo;
        private static List<Registro> listaRegistros;

        string[] lineaElementos;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hecho por: Diana Yulissa Sesma Santiago y Kristan Ru�z Lim�n";
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
            buttonSalir.Visible = false;
            panel2.Visible = true;
            ObtenerDatos();
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
            //chart7.Visible = false;
            //chart8.Visible = false;
            buttonCerrar.Visible = false;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�Desea Salir?", "�Salir?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ObtenerRuta()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = openFileDialog1.FileName;
                    ImprimirContenido();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void ObtenerInfo()
        {
            rutaArchivo = openFileDialog1.FileName;
            MessageBox.Show(
                "Ruta del Archivo: " + rutaArchivo + "\r\n\r\n" +
                "Fecha y Hora de Creaci�n: " + File.GetCreationTime(rutaArchivo) + "\r\n\r\n" +
                "Ultima Modificaci�n: " + File.GetLastWriteTime(rutaArchivo) + "\r\n\r\n" +
                "Ultimo Acceso: " + File.GetLastAccessTime(rutaArchivo)
                ,"Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LeerDatos()
        {
            bool compatible = true; //por defecto false
            lineaElementos = null;

            while(!fs.EndOfStream) //Lo leerá hasta que vea que hay un campo en blanco, si es así, dejará de leer y no imprimirá nada.
            {
                using(StreamReader lector = new StreamReader(rutaArchivo)) 
                {
                    string linea = lector.ReadLine();
                    string[] lineaElementos = lineaElementos.Split(',');

                    foreach(string campo in lineaElementos)// Una vez teniendo leida la fila de esta iteración, comprobará en cada una de sus celdas
                    {
                        if(campo == "")
                        {
                           compatible = false;
                           break; //Se sale del foreach
                        }
                    }

                    if(compatible == false) //Se sale del while, porque vio que compatibl es false al haber encontrado un campo en blanco (parará de leer)
                    {
                        break;
                    }

                }
            }

            if(compatible)
            {
                ImprimirContenido(); //Ahora si lo imprime
            }
            else
            {
                MessageBox.Show("Ha seleccionado un archivo con un formato incompatible", "Error", MessageBoxButtons.OK, MessageBoxIcons.Error); //Se pudo haber puesto dentro del while, es cuestión de gusto mio
            }

        }

        private void ImprimirContenido()
        {
            fs.Seek(0, SeekOrigin.Begin); //Debido a que para revisar se leyó el puntero no estará claramente en el principio.
            
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

            Estadisticas.PeliculaPopular = Estadisticas.PeliculasYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key; //Obtiene la pelicula con el valor (contador) m�s alto.
            Estadisticas.SeriePopular = Estadisticas.SeriesYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Estadisticas.PaisMasConsumo = Estadisticas.PaisYCantidad.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

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
            chartTipoProducto.Titles.Add("Tipo de Producto%");

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
            chartAnios.Titles.Add("Productos Estrenados");

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
        }

        private void Reiniciar()
        {
            listaRegistros.Clear();
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
            chartTiposUsuarios.Series.Clear();
            chartTerminaron.Series.Clear();
            chartTipoProducto.Series.Clear();
            chartConsumoGenero.Series.Clear();
            chartAnios.Series.Clear();
            chartConsumoPais.Series.Clear();
            //chart7.Series.Clear();
            //chart8.Series.Clear();
            chartTiposUsuarios.Titles.Clear();
            chartTerminaron.Titles.Clear();
            chartTipoProducto.Titles.Clear();
            chartConsumoGenero.Titles.Clear();
            chartAnios.Titles.Clear();
            chartConsumoPais.Titles.Clear();
            //chart7.Titles.Clear();
            //chart8.Titles.Clear();
            buttonCerrar.Visible = true;
        }
    }
}