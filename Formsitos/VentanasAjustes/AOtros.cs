using estadisticasStreaming.Clases;
using estadisticasStreaming.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

        private void AOtros_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            comboBox1.Text = "Barras";
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Pastel")
            {
                label1.Text = "Aplicado";
                timer1.Start();
                MessageBox.Show("Actualiza las gráficas para ver el cambio\r\nNota: Puedes presionar una gráfica para verlo o\r\ncerrar y abrir la pestaña gráficas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Estadisticas.TipoGrafica = "Pastel";
            }
            else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Barras")
            {
                label1.Text = "Aplicado";
                MessageBox.Show("Actualiza las gráficas para ver el cambio\r\nNota: Puedes presionar una gráfica para verlo o\r\ncerrar y abrir la pestaña gráficas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Start();
                Estadisticas.TipoGrafica = "Barras";
            }

            else if (comboBox1.SelectedItem == null) MessageBox.Show("No ha seleccionado nada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "";
            timer1.Stop();
        }
    }
}
