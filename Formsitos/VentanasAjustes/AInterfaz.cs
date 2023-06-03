using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estadisticasStreaming.Formsitos.VentanasAjustes
{
    public partial class AInterfaz : Form
    {
        public AInterfaz()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image imagen = Image.FromFile(openFileDialog1.FileName);
                Form1.Instancia.BackgroundImage = imagen;
            }
        }

        private void pictureBoxOpcion1_Click(object sender, EventArgs e)
        {
            Form1.Instancia.BackgroundImage = pictureBoxOpcion1.Image;
        }

        private void pictureOpcion2_Click(object sender, EventArgs e)
        {
            Form1.Instancia.BackgroundImage = pictureOpcion2.Image;
        }

        private void AInterfaz_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes|*.jpg;*.png;";
        }
    }
}
