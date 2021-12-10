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
            if (Globales.MensajeBienvendia == 1)
            {
                Globales.MensajeBienvendia = 0;
                NotifiacionWaffle.ShowBalloonTip(100, "Hi!", "Welcome "+Globales.UserName, ToolTipIcon.None); 
            }
        }
        #endregion

        #region Abrir Formas
        private void BtnUpdates_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormUpdater FF = new FormUpdater();
            this.Hide();
            FF.ShowDialog();
            this.Close();
        }

        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void BtnFavorites_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormFavorites FF = new FormFavorites();
            this.Hide();
            FF.ShowDialog();
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormSearch FS = new FormSearch();
            this.Hide();
            FS.ShowDialog();
            this.Close();
        }

        private void BtnForums_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormForums FFO = new FormForums();
            this.Hide();
            FFO.ShowDialog();
            this.Close();           
            
        }

        private void BtnNewsletter_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormNewsletter FN = new FormNewsletter();
            this.Hide();
            FN.ShowDialog();
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormWelcome fw = new FormWelcome();
            this.Hide();
            fw.ShowDialog();
            this.Close();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormAbout FA = new FormAbout();
            this.Hide();
            FA.ShowDialog();
            this.Close();
        }
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormSupport FS = new FormSupport();
            this.Hide();
            FS.ShowDialog();
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            NotifiacionWaffle.Visible = false;

            FormSettings FS = new FormSettings();
            this.Hide();
            FS.ShowDialog();
            this.Close();
        }


        #endregion

    }
}
