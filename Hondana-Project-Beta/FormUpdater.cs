using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hondana_Project_Beta
{
    public partial class FormUpdater : Form
    {
        public FormUpdater()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program is updated in the latest version! \n  [!]Hondana Project Open Beta 4 (OB4050) \n  [!]4050.rs.open - beta.20211206 - 2006", "Everything is fine ;)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
