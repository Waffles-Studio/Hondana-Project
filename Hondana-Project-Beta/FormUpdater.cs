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
        #region Inicio & Variables
        int conteo;
        public FormUpdater()
        {
            InitializeComponent();
        }
        #endregion

        #region "Actualizacion"
        private void button1_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.ShowBalloonTip(100, "Looking for Update", "Please wait", ToolTipIcon.Info);
            timer1.Start();

            

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo++;
            if (conteo == 60)
            {

                MessageBox.Show("You are in the latest version", "Oh...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Stop();
                conteo = 0;
            }

        }
        #endregion

        #region Cambio de pestañas
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
            this.Refresh();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormAbout FH = new FormAbout();
            this.Hide();
            FH.ShowDialog();
            this.Close();
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormSearch FH = new FormSearch();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }
        #endregion


    }
}
