using estadisticasStreaming.Clases;

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

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader lector = new StreamReader(fs))
                {
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
            }
        }

        private void ObtenerDatos() 
        {
            listaRegistros.Clear();

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                listaRegistros.Add(new Registro(fila.Cells[0].Value.ToString(), (byte)fila.Cells[1].Value, fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), fila.Cells[0].Value.ToString(), (short)fila.Cells[0].Value, (short)fila.Cells[0].Value));
            }

            Estadisticas.TotalUsuarios = listaRegistros.Count;

            foreach (Registro r in listaRegistros) //Entre el 70% y el 90% no cuenta para ninguno de estos? omg
            {
                if(r.MinutosVistos <= 10) Estadisticas.NoStarters++;
                else if(r.MinutosVistos <= (short)(r.Duracion*.7)) Estadisticas.NoWatchers++; 
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
                    case "2020": Estadisticas.Anio20201++;
                        break;
                    case "2021": Estadisticas.Anio20211++;
                        break;
                    case "2022": Estadisticas.Anio20221++;
                        break;
                    case "2023": Estadisticas.Anio20231++;
                        break;

                }
            }











        }



    }
}