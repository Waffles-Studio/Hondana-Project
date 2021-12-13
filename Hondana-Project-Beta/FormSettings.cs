using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hondana_Project_Beta
{
    public partial class FormSettings : Form
    {
        #region Inicio & Variables
        public FormSettings()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            label5.Text = Globales.UserName;
            label6.Text = Globales.UserEmail;
            label8.Text = Globales.UserName;
            label7.Text = Globales.UserEmail;
            if (Globales.UserRole == "1")
            {
                label1.Text = "Administrator";
                label10.Text = "Administrator";
            }
            else
            {
                panel5.Enabled = false;
                label1.Text = "User";
                label10.Text = "User";
            }
        }

        private DataTable DT = new DataTable();
        #endregion

        #region Envio de formas
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

            FormWelcome FH = new FormWelcome();
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

            FormUpdater FH = new FormUpdater();
            this.Hide();
            FH.ShowDialog();
            this.Close();
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
            this.Refresh();
        }
        #endregion

        #region Llenar DataGrid & DataTable

        private void button9_Click(object sender, EventArgs e)
        {
            string cons = "select U.UserName, L.what as What, L.[where] as [Where], CONVERT(varchar, L.[when], 0) AS [When]  " +
                "from Logs AS L INNER JOIN Users AS U ON (L.Who = U.UserID) ";
            llenarGrid(cons);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string cons = "Select R.RoleDescription, U.UserName, U.UserEmail, CONVERT(VARCHAR, ENCRYPTBYPASSPHRASE('CoviLAB', U.UserPassword)) AS [Password],  " +
                "'No icon' AS Icon, U.Activo " +
                "FROM Users AS U INNER JOIN Roles AS R ON (U.UserRole = R.RoleID)";
            llenarGrid(cons);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string cons = "select B.BookTitle, E.EditorialName, B.BookPages, b.BookPages, B.BookISBN, B.BookLanguage, B.BookRating  " +
                "from Books AS B INNER JOIN Editorials AS E ON (B.BookEditorial = E.EditorialId)";
            llenarGrid(cons);
        }

        private void llenarGrid(string cons)
        {
            using (SqlCommand cmdLogs = new SqlCommand(cons, Globales.conexion))
            {
                DT.Clear();
                DT.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                Globales.conexion.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmdLogs);
                adaptador.Fill(DT);

                Globales.conexion.Close();
                dataGridView1.DataSource = DT;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (DT.Rows.Count >= 1)
            {
                button13.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }

        #endregion

        #region Exportar
        private void button13_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) 
            {
                //EXCEL
            }
            if (radioButton2.Checked == true)
            {
                //XML
            }
        }
        #endregion
    }
}
