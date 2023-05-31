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
            StreamReader lector;

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                lector = new StreamReader(fs);

                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    string[] lineaElementos = linea.Split(','); 
                    dataGridView1.Rows.Add();

                    for (int i = 0; i < lineaElementos.Length; i++) //Es -1 para que se consideren los índices de las filas, ya que estos empiezan en 0 y no en 1.
                    {
                        dataGridView1.Rows[fila].Cells[i].Value = lineaElementos[i];
                    }

                    fila++;
                }
            }
            lector.Close();
        }

        private void ObtenerDatos() //Los obtiene de la tabla. El proceso de análisis de datos está totalmente separado del proceso de lectura e impresión de los mismos.
        {

        }



    }
}