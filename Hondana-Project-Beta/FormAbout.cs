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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        #region envio de formas

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormSearch FH = new FormSearch();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormHome FH = new FormHome();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnFavorites_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormFavorites FH = new FormFavorites();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnForums_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormForums FH = new FormForums();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnNewsletter_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormNewsletter FH = new FormNewsletter();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnUpdates_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormAbout FH = new FormAbout();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormWelcome FH = new FormWelcome();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormSupport FH = new FormSupport();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormSettings FH = new FormSettings();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }
        #endregion
    }
}
