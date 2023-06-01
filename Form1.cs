using estadisticasStreaming.Clases;

namespace estadisticasStreaming
{
    public partial class Form1 : Form
    {
        private string rutaArchivo;
        private static List<Registro> listaRegistros;
        Dictionary<string, int> contenidoYVeces = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hecho por: Diana Yulissa Sesma Santiago y Kristan Ru�z Lim�n";
            openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, "Data");
            listaRegistros = new List<Registro>();
        }

        private void button1_Click(object sender, EventArgs e) => ObtenerRuta();
        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();


        private void ObtenerRuta()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog1.FileName;
                ImprimirContenido();
            }
        }

        private void ImprimirContenido()
        {
            toolStripStatusLabel1.Text = rutaArchivo;
            int fila = 0;


            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    string[] lineaElementos = linea.Split(','); 
                    dataGridView1.Rows.Add();

                    for (int i = 0; i < lineaElementos.Length; i++) //Es -1 para que se consideren los �ndices de las filas, ya que estos empiezan en 0 y no en 1.
                    {
                        dataGridView1.Rows[fila].Cells[i].Value = lineaElementos[i];
                    }

                    fila++;
                }
            
            }

            ObtenerDatos(); //Es solo para probar
        }

        private void ObtenerDatos() 
        {
            listaRegistros.Clear();

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



            foreach (Registro r in listaRegistros) //Entre el 70% y el 90% no cuenta para ninguno de estos? omg //Comentario nuevo: Esto ya est� corregido...
            {
                if(r.MinutosVistos <= (short)(r.Duracion*0.1)) Estadisticas.NoStarters++;
                else if(r.MinutosVistos < (short)(r.Duracion*.9)) Estadisticas.NoWatchers++; 
                else if (r.MinutosVistos >= (short)(r.Duracion * .9)) Estadisticas.NoCompleters++;

                if (r.MinutosVistos == r.Duracion) Estadisticas.VerCompleto++;
                else Estadisticas.VerIncompleto++;

                if (r.Tipo == "PELICULA") Estadisticas.Peliculas++;
                else Estadisticas.Series++;


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
                        break;
                    case "EU": Estadisticas.Eu++;
                        break;
                    case "CANADA": Estadisticas.Canada++;
                        break;
                    case "COLOMBIA": Estadisticas.Colombia++;
                        break;
                    case "CUBA": Estadisticas.Cuba++;
                        break;
                    case "COSTA RICA": Estadisticas.CostaRica++;
                        break;
                }

                if (contenidoYVeces.ContainsKey(r.ProductoVisto)) //Si ya existe la llave (la pelicula o serie), se le suma 1 al valor de la llave a su contador.
                {
                    contenidoYVeces[r.ProductoVisto]++;
                }
                else
                {
                    contenidoYVeces.Add(r.ProductoVisto, 1); //Si no existe la llave, se crea y se le asigna el valor de 1.
                }

            }

            Estadisticas.PeliculaPopular = contenidoYVeces.Aggregate((l, r) => l.Value > r.Value ? l : r).Key; //Obtiene la llave con el valor m�s alto.

        }
    }
}