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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void BtnLibrary_Click(object sender, EventArgs e)
        {

        }

        private void BtnFavorites_Click(object sender, EventArgs e)
        {
            FormFavorites FF = new FormFavorites();
            FF.ShowDialog();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FormSearch FS = new FormSearch();
            FS.ShowDialog();
        }

        private void BtnForums_Click(object sender, EventArgs e)
        {
            FormForums FFO = new FormForums();
            FFO.ShowDialog();
        }

        private void BtnNewsletter_Click(object sender, EventArgs e)
        {
            FormNewsletter FN = new FormNewsletter();
            FN.ShowDialog();
        }
    }
}
