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
    public partial class FormForums : Form
    {

        #region Inicio
        private void FormForums_Load(object sender, EventArgs e)
        {
            
        }
        public FormForums()
        {
            InitializeComponent();
            Globales.GrupoSel = 1;
            llenarMen();
        }
        #endregion

        #region Envio de formas
        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;

            FormHome FH = new FormHome();
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
            this.Refresh();
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
            NotificacionWaffle.Visible = false;

            FormSettings FH = new FormSettings();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }
        #endregion

        #region Seleccionar Grupo
        private void button1_Click(object sender, EventArgs e)
        {
            Globales.GrupoSel = 1;
            llenarMen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globales.GrupoSel = 2;
            llenarMen();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Globales.GrupoSel = 3;
            llenarMen();
        }
        #endregion

        #region Mostrar Mensajes
        private void llenarMen()
        {
            int grupo = Globales.GrupoSel;
            Globales.conexion.Open();
            string sqlMens = "SELECT TOP(5) U.UserName AS [NombreUsuario], M.MessageContent AS [Mensaje], CONVERT(VARCHAR, M.MessageDate, 106) AS [Fecha Mensaje] " +
                "FROM Messages AS M " +
                "INNER JOIN Users AS U ON (M.UserID = U.UserID) " +
                "INNER JOIN Communities AS C ON (M.GroupID = C.GroupID) " +
                "WHERE C.GroupID = @group " +
                "ORDER BY M.MessageDate DESC ";
            using (SqlCommand cmdInsert = new SqlCommand(sqlMens, Globales.conexion))
            {
                cmdInsert.Parameters.AddWithValue("@group", grupo);

                DataTable DT = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdInsert);
                adapter.Fill(DT);

                int Num = DT.Rows.Count;

                #region paneles
                if (Num == 1)
                {
                    panel11.Visible = false;
                    panel15.Visible = false;
                    panel16.Visible = false;
                    panel17.Visible = false;
                    panel18.Visible = true;

                    prs5.Text = DT.Rows[0][0].ToString();
                    msng5.Text = DT.Rows[0][1].ToString();
                    tm5.Text = DT.Rows[0][2].ToString();


                }
                if (Num == 2)
                {
                    panel11.Visible = false;
                    panel15.Visible = false;
                    panel16.Visible = false;
                    panel17.Visible = true;
                    panel18.Visible = true;

                    prs5.Text = DT.Rows[0][0].ToString();
                    msng5.Text = DT.Rows[0][1].ToString();
                    tm5.Text = DT.Rows[0][2].ToString();

                    prs4.Text = DT.Rows[1][0].ToString();
                    msng4.Text = DT.Rows[1][1].ToString();
                    tm4.Text = DT.Rows[1][2].ToString();
                }
                if (Num == 3)
                {
                    panel11.Visible = false;
                    panel15.Visible = false;
                    panel16.Visible = true;
                    panel17.Visible = true;
                    panel18.Visible = true;

                    prs5.Text = DT.Rows[0][0].ToString();
                    msng5.Text = DT.Rows[0][1].ToString();
                    tm5.Text = DT.Rows[0][2].ToString();

                    prs4.Text = DT.Rows[1][0].ToString();
                    msng4.Text = DT.Rows[1][1].ToString();
                    tm4.Text = DT.Rows[1][2].ToString();

                    prs3.Text = DT.Rows[2][0].ToString();
                    msng3.Text = DT.Rows[2][1].ToString();
                    tm3.Text = DT.Rows[2][2].ToString();

                }
                if (Num == 4)
                {
                    panel11.Visible = false;
                    panel15.Visible = true;
                    panel16.Visible = true;
                    panel17.Visible = true;
                    panel18.Visible = true;

                    prs5.Text = DT.Rows[0][0].ToString();
                    msng5.Text = DT.Rows[0][1].ToString();
                    tm5.Text = DT.Rows[0][2].ToString();

                    prs4.Text = DT.Rows[1][0].ToString();
                    msng4.Text = DT.Rows[1][1].ToString();
                    tm4.Text = DT.Rows[1][2].ToString();

                    prs3.Text = DT.Rows[2][0].ToString();
                    msng3.Text = DT.Rows[2][1].ToString();
                    tm3.Text = DT.Rows[2][2].ToString();

                    prs2.Text = DT.Rows[3][0].ToString();
                    msng2.Text = DT.Rows[3][1].ToString();
                    tm2.Text = DT.Rows[3][2].ToString();
                }
                if (Num >= 5)
                {
                    panel11.Visible = true;
                    panel15.Visible = true;
                    panel16.Visible = true;
                    panel17.Visible = true;
                    panel18.Visible = true;

                    prs5.Text = DT.Rows[0][0].ToString();
                    msng5.Text = DT.Rows[0][1].ToString();
                    tm5.Text = DT.Rows[0][2].ToString();

                    prs4.Text = DT.Rows[1][0].ToString();
                    msng4.Text = DT.Rows[1][1].ToString();
                    tm4.Text = DT.Rows[1][2].ToString();

                    prs3.Text = DT.Rows[2][0].ToString();
                    msng3.Text = DT.Rows[2][1].ToString();
                    tm3.Text = DT.Rows[2][2].ToString();

                    prs2.Text = DT.Rows[3][0].ToString();
                    msng2.Text = DT.Rows[3][1].ToString();
                    tm2.Text = DT.Rows[3][2].ToString();

                    prs1.Text = DT.Rows[4][0].ToString();
                    msng1.Text = DT.Rows[4][1].ToString();
                    tm1.Text = DT.Rows[4][2].ToString();

                }
                if (Num == 0)
                {
                    panel11.Visible = false;
                    panel15.Visible = false;
                    panel16.Visible = false;
                    panel17.Visible = false;
                    panel18.Visible = false;
                }
                #endregion
            }
            Globales.conexion.Close();
        }
        #endregion

        #region Enviar Mensaje
        private void button2_Click(object sender, EventArgs e)
        {
            string sqlinsmes = "INSERT INTO Messages VALUES (@user, @grupo, @fecha, @mensaje)";
            Globales.conexion.Open();

            using (SqlCommand cmdmes = new SqlCommand(sqlinsmes, Globales.conexion))
            {
                cmdmes.Parameters.AddWithValue("@user", Globales.UserID);
                cmdmes.Parameters.AddWithValue("@grupo", Globales.GrupoSel);
                cmdmes.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmdmes.Parameters.AddWithValue("@mensaje", textBox1.Text);
                cmdmes.ExecuteNonQuery();
            }
            Globales.conexion.Close();
            textBox1.Text = "";
            llenarMen();

        }
        #endregion
    }
}
