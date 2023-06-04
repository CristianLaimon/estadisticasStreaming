using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using estadisticasStreaming.Clases;
using estadisticasStreaming.Formsitos.VentanasAjustes;

namespace estadisticasStreaming.Formsitos
{
    public partial class AjustesForm : Form
    {
        private static bool alreadyOpened;
        private static AjustesForm instancia;


        public AjustesForm()
        {
            InitializeComponent();
            AlreadyOpened = true;
            instancia = this;
        }
        public static bool AlreadyOpened { get => alreadyOpened; set => alreadyOpened = value; }
        public static AjustesForm Instancia { get => instancia; set => instancia = value; }

        private void buttonInterfaz_Click(object sender, EventArgs e)
        {
            var interfazForm = new AInterfaz();

            interfazForm.TopLevel = false;
            panelPrincipal.Controls.Add(interfazForm);
            interfazForm.Dock = DockStyle.Fill;
            interfazForm.FormBorderStyle = FormBorderStyle.None;
            interfazForm.BringToFront();
            interfazForm.Show();
        }

        private void AjustesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AlreadyOpened = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var otrosForm = new AOtros();

            otrosForm.TopLevel = false;
            panelPrincipal.Controls.Add(otrosForm);
            otrosForm.Dock = DockStyle.Fill;
            otrosForm.FormBorderStyle = FormBorderStyle.None;
            otrosForm.BringToFront();
            otrosForm.Show();
        }
    }
}
