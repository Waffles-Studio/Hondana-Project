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

        #region Variables
        Globales Glb = new Globales();

        #endregion

        #region Inicio
        public FormWelcome()
        {
            InitializeComponent();
            add();
        }
        #endregion

        #region Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Glb.conexion = new SqlConnection("Data Source=" + cmbserv.SelectedItem + ";Initial Catalog=HondanaDB;Integrated Security=True");
            try
            {
                Glb.conexion.Open();
                Glb.conexion.Close();
                FormLoginSignup FLS = new FormLoginSignup();
                FLS.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Please connect to your server first", ":(");
            }



        }
        #endregion

        #region conectarse
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Glb.conexion = new SqlConnection("Data Source=" + cmbserv.SelectedItem + ";Initial Catalog=HondanaDB;Integrated Security=True");

            try
            {
                Glb.conexion.Open();
                MessageBox.Show("Established connection", ":)");
                Glb.conexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect. \nCheck your server name", ":(");
                Glb.conexion.Close();
            }
        }
        #endregion

        #region AgregarServers
        private void txtaddserver_Click(object sender, EventArgs e)
        {
            StreamWriter agregar = File.AppendText("ConDB.txt");
            agregar.WriteLine(cmbserv.Text);
            agregar.Close();

            add();
        }
        #endregion

        #region combobox
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
