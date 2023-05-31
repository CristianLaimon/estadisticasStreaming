namespace estadisticasStreaming
{
    public partial class Form1 : Form
    {
        private string rutaArchivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hecho por: Diana Yulissa Sesma Santiago y Kristan Ruíz Limón";
            openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, "Data");
        }

        private void button1_Click(object sender, EventArgs e) => ObtenerRuta();
        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();

        private void abrirConsumotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rutaArchivo = Path.Combine(Application.StartupPath, "Data", "consumo.txt");
            LeerArchivo();
        }
        

        private void ObtenerRuta()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog1.FileName;
                LeerArchivo();
            }
        }

        private void LeerArchivo()
        {
            if (rutaArchivo != null)
            {
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
            else
            {
                MessageBox.Show("Todavía no ha seleccionado un archivo para leer", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }



    }
}