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
        }

        private void button1_Click(object sender, EventArgs e) => ObtenerRuta();
        private void abrirNuevoArchivoToolStripMenuItem_Click(object sender, EventArgs e) => ObtenerRuta();
        private void abrirConsumotxtToolStripMenuItem_Click(object sender, EventArgs e) => rutaArchivo = Path.Combine(Application.StartupPath, "Data", "consumo.txt");

        private void ObtenerRuta()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog1.FileName;
            }
        }

        private void LeerArchivo()
        {
            if (rutaArchivo != null)
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.ReadWrite))
                {
                    var br = new BinaryReader(fs);
                    var bw = new BinaryWriter(fs);

                    string rawText = 

                }

            }
            else
            {
                MessageBox.Show("Todavía no ha seleccionado un archivo para leer", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            }
        }


    }
}