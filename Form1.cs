using estadisticasStreaming.Clases;
using System.Diagnostics.CodeAnalysis;

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
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e) => ObtenerRuta();

        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();

        private void buttonInformacion_Click(object sender, EventArgs e) => ObtenerInfo();

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

            MessageBox.Show("No Startes: " + Estadisticas.NoStarters);
            MessageBox.Show("No Watchers: " + Estadisticas.NoWatchers);
            MessageBox.Show("No Completers: " + Estadisticas.NoCompleters);
            MessageBox.Show("Completo: " + (Estadisticas.VerCompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto)));
            MessageBox.Show("Incompleto: " + (Estadisticas.VerIncompleto * 100 / (Estadisticas.VerCompleto + Estadisticas.VerIncompleto)));
            MessageBox.Show("Pelicula: " + (Estadisticas.Peliculas * 100 / (Estadisticas.Peliculas + Estadisticas.Series)));
            MessageBox.Show("Serie: " + (Estadisticas.Series * 100 / (Estadisticas.Peliculas + Estadisticas.Series)));
            MessageBox.Show("Romance: " + Estadisticas.Romance);
            MessageBox.Show("Drama: " + Estadisticas.Drama);
            MessageBox.Show("Terror: " + Estadisticas.Terror);
            MessageBox.Show("Suspenso: " + Estadisticas.Suspenso);
            MessageBox.Show("Accion: " + Estadisticas.Accion);
            MessageBox.Show("2020: " + Estadisticas.Anio2020);
            MessageBox.Show("2021: " + Estadisticas.Anio2021);
            MessageBox.Show("2022: " + Estadisticas.Anio2022);
            MessageBox.Show("2023: " + Estadisticas.Anio2023);
            MessageBox.Show("Pais+: " + Estadisticas.PaisMasConsumo);
            MessageBox.Show("Pelicula+: " + Estadisticas.PeliculaPopular);
            MessageBox.Show("Serie+: " + Estadisticas.SeriePopular);
        }

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        { 
            ObtenerDatos();
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
        }
    }
}