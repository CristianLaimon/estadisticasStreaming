using estadisticasStreaming.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace estadisticasStreaming.Formsitos.VentanasAjustes
{
    public partial class AOtros : Form
    {
        public AOtros()
        {
            InitializeComponent();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Pastel")
            {
                Estadisticas.TipoGrafica = "Pastel";
                this.Close();
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("No ha seleccionado nada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
