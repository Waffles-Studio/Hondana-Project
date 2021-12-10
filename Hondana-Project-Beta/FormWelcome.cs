﻿using System;
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
            
            /*if (Globales.conexion != null )
            {
                Globales.conexion.Open();
                Globales.conexion.Close();

                FormLoginSignup FLS = new FormLoginSignup();
                this.Hide();
                FLS.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please connect to your server first", ":(");
            }*/
            try
            {
                Globales.conexion = new SqlConnection("Data Source=" + cmbserv.SelectedItem + ";Initial Catalog=HondanaDB;Integrated Security=True");
                Globales.conexion.Open();
                Globales.conexion.Close();

                FormLoginSignup FLS = new FormLoginSignup();
                this.Hide();
                FLS.ShowDialog();
                this.Close();
            }
            catch (Exception b)
            {
                MessageBox.Show("Fail everything that could fail \n" + b, "Ups....");
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
                MessageBox.Show("Established connection", ":)");
                Globales.conexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect. \nCheck your server name", ":(");
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
