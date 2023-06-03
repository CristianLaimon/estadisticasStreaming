using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estadisticasStreaming.Formsitos
{
    public partial class AjustesForm : Form
    {
        public AjustesForm()
        {
            InitializeComponent();
        }

        private void AjustesForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
