using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data.SqlClient;

namespace Hondana_Project_Beta
{
    public partial class FormWelcome : Form
    {
        #region Inicio
        public FormWelcome()
        {
            InitializeComponent();
            add();

            cmbserv.Text = "BA-PC\\SQLEXPRESS";
        }
        #endregion

        #region Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                Globales.conexion = new SqlConnection("Data Source=" + cmbserv.SelectedItem + ";Initial Catalog=HondanaDB;Integrated Security=True");
                Globales.conexion.Open();
                Globales.conexion.Close();
                NotificacionWaffle.Visible = false;

                FormLoginSignup FLS = new FormLoginSignup();
                this.Hide();
                FLS.ShowDialog();
                this.Close();
            }
            catch (Exception b)
            {
                NotificacionWaffle.ShowBalloonTip(100, "Failed to connect.", "Check your server name", ToolTipIcon.Warning);
            }

        }
        #endregion

        #region Test
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Globales.conexion = new SqlConnection("Data Source=" + cmbserv.SelectedItem + ";Initial Catalog=HondanaDB;Integrated Security=True");
            try
            {
                Globales.conexion.Open();
                NotificacionWaffle.ShowBalloonTip(100, "The connection was successful", "All went well", ToolTipIcon.None);
                Globales.conexion.Close();
            }
            catch (Exception)
            {
                NotificacionWaffle.ShowBalloonTip(100, "Failed to connect.", "Check your server name", ToolTipIcon.Warning);
            }
        }
        #endregion

        #region AgregarServers
        private void txtaddserver_Click(object sender, EventArgs e)
        {
            StreamWriter agregar = File.AppendText("ConDB.txt");
            agregar.WriteLine(cmbserv.Text);
            agregar.Close();
            NotificacionWaffle.ShowBalloonTip(100, "Added server", "It is now on your server list", ToolTipIcon.None);

            add();
        }

        private void add()
        {
            cmbserv.Items.Clear();
            StreamReader con = new StreamReader("ConDB.txt");
            string s = con.ReadLine();
            while (s != null)
            {
                cmbserv.Items.Add(s);
                s = con.ReadLine();
            }
            con.Close();
        }
        #endregion
    }
}

