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
        #region Inicio
        public FormHome()
        {
            InitializeComponent();
        }
        #endregion

        #region Abrir Formas
        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void BtnFavorites_Click(object sender, EventArgs e)
        {
            FormFavorites FF = new FormFavorites();
            this.Hide();
            FF.ShowDialog();
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FormSearch FS = new FormSearch();
            this.Hide();
            FS.ShowDialog();
            this.Close();
        }

        private void BtnForums_Click(object sender, EventArgs e)
        {
            FormForums FFO = new FormForums();
            this.Hide();
            FFO.ShowDialog();
            this.Close();           
            
        }

        private void BtnNewsletter_Click(object sender, EventArgs e)
        {
            FormNewsletter FN = new FormNewsletter();
            this.Hide();
            FN.ShowDialog();
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            FormWelcome fw = new FormWelcome();
            this.Hide();
            fw.ShowDialog();
            this.Close();
        }
        #endregion
    }
}
