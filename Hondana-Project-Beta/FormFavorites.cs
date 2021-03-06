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
    public partial class FormFavorites : Form
    {
        #region inicio
        public FormFavorites()
        {
            InitializeComponent();
            llenarfav();
        }
        #endregion

        #region Variables
        public DataTable DT = new DataTable();

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

            FormHome FH = new FormHome();
            this.Hide();
            FH.ShowDialog();
            this.Close();

        }

        private void BtnFavorites_Click(object sender, EventArgs e)
        {
            this.Refresh();
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
            NotificacionWaffle.Visible = false;

            FormSettings FH = new FormSettings();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }
        #endregion

        #region Llenar de libros
        public void llenarfav()
        {
            string sqllibros = "SELECT B.BookTitle, E.EditorialName, B.BookPages, B.BookRating, B.BookID " +
                "FROM Favorites AS F " +
                "INNER JOIN Users AS U ON (F.UserId = U.UserID) " +
                "INNER JOIN Books AS B ON (F.BookID = B.BookID) " +
                "INNER JOIN Editorials AS E ON (B.BookEditorial = E.EditorialId) " +
                "WHERE F.UserId = @user ";

            using (SqlCommand cmdlib = new SqlCommand(sqllibros, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdlib.Parameters.AddWithValue("user", Globales.UserID);

                
                SqlDataAdapter adapter = new SqlDataAdapter(cmdlib);
                adapter.Fill(DT);
                int Num = DT.Rows.Count;

                Globales.conexion.Close();

                if (Num != 0)
                {
                    fondo1.Visible = false;
                    fondo2.Visible = false;
                    fondo3.Visible = false;
                    if (Num == 1)
                    {
                        pan1.Visible = true;
                        pan2.Visible = false;
                        pan3.Visible = false;
                        pan4.Visible = false;
                        pan5.Visible = false;
                        pan6.Visible = false;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(1);
                    }
                    if (Num == 2)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = false;
                        pan4.Visible = false;
                        pan5.Visible = false;
                        pan6.Visible = false;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(2);
                    }
                    if (Num == 3)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = false;
                        pan5.Visible = false;
                        pan6.Visible = false;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(3);
                    }
                    if (Num == 4)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = true;
                        pan5.Visible = false;
                        pan6.Visible = false;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(4);
                    }
                    if (Num == 5)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = true;
                        pan5.Visible = true;
                        pan6.Visible = false;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(5);
                    }
                    if (Num == 6)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = true;
                        pan5.Visible = true;
                        pan6.Visible = true;
                        pan7.Visible = false;
                        pan8.Visible = false;

                        llenar(6);
                    }
                    if (Num == 7)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = true;
                        pan5.Visible = true;
                        pan6.Visible = true;
                        pan7.Visible = true;
                        pan8.Visible = false;

                        llenar(7);
                    }
                    if (Num == 8)
                    {
                        pan1.Visible = true;
                        pan2.Visible = true;
                        pan3.Visible = true;
                        pan4.Visible = true;
                        pan5.Visible = true;
                        pan6.Visible = true;
                        pan7.Visible = true;
                        pan8.Visible = true;

                        llenar(8);
                    }
                }
                else
                {
                    fondo1.Visible = true;
                    fondo2.Visible = true;
                    fondo3.Visible = true;

                    pan1.Visible = false;
                    pan2.Visible = false;
                    pan3.Visible = false;
                    pan4.Visible = false;
                    pan5.Visible = false;
                    pan6.Visible = false;
                    pan7.Visible = false;
                    pan8.Visible = false;
                }

            }
            
        }

        public void llenar(int p)
        {
            Globales.FavoritesPos = new int[p];
            if (p >= 1)
            {
                lbl1_1.Text = DT.Rows[0][0].ToString();
                lbl1_2.Text = DT.Rows[0][1].ToString();
                lbl1_3.Text = DT.Rows[0][2].ToString() + " Pages";
                lbl1_4.Text = DT.Rows[0][3].ToString() + "/5";
                Globales.FavoritesPos[0] = Convert.ToInt32(DT.Rows[0][4]);
                button12.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[0] + ".jpg");
            }
            if (p >= 2)
            {
                lbl2_1.Text = DT.Rows[1][0].ToString();
                lbl2_2.Text = DT.Rows[1][1].ToString();
                lbl2_3.Text = DT.Rows[1][2].ToString() + " Pages";
                lbl2_4.Text = DT.Rows[1][3].ToString() + "/5";
                Globales.FavoritesPos[1] = Convert.ToInt32(DT.Rows[1][4]);
                button1.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[1] + ".jpg");
            }
            if (p >= 3)
            {
                lbl3_1.Text = DT.Rows[2][0].ToString();
                lbl3_2.Text = DT.Rows[2][1].ToString();
                lbl3_3.Text = DT.Rows[2][2].ToString() + " Pages";
                lbl3_4.Text = DT.Rows[2][3].ToString() + "/5";
                Globales.FavoritesPos[2] = Convert.ToInt32(DT.Rows[2][4]);
                button2.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[2] + ".jpg");
            }
            if (p >= 4)
            {
                lbl4_1.Text = DT.Rows[3][0].ToString();
                lbl4_2.Text = DT.Rows[3][1].ToString();
                lbl4_3.Text = DT.Rows[3][2].ToString() + " Pages";
                lbl4_4.Text = DT.Rows[3][3].ToString() + "/5";
                Globales.FavoritesPos[3] = Convert.ToInt32(DT.Rows[3][4]);
                button3.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[3] + ".jpg");
            }
            if (p >= 5)
            {
                lbl5_1.Text = DT.Rows[4][0].ToString();
                lbl5_2.Text = DT.Rows[4][1].ToString();
                lbl5_3.Text = DT.Rows[4][2].ToString() + " Pages";
                lbl5_4.Text = DT.Rows[4][3].ToString() + "/5";
                Globales.FavoritesPos[4] = Convert.ToInt32(DT.Rows[4][4]);
                button4.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[4] + ".jpg");
            }
            if (p >= 6)
            {
                lbl6_1.Text = DT.Rows[5][0].ToString();
                lbl6_2.Text = DT.Rows[5][1].ToString();
                lbl6_3.Text = DT.Rows[5][2].ToString() + " Pages";
                lbl6_4.Text = DT.Rows[5][3].ToString() + "/5";
                Globales.FavoritesPos[5] = Convert.ToInt32(DT.Rows[5][4]);
                button5.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[5] + ".jpg");
            }
            if (p >= 7)
            {
                lbl7_1.Text = DT.Rows[6][0].ToString();
                lbl7_2.Text = DT.Rows[6][1].ToString();
                lbl7_3.Text = DT.Rows[6][2].ToString() + " Pages";
                lbl7_4.Text = DT.Rows[6][3].ToString() + "/5";
                Globales.FavoritesPos[6] = Convert.ToInt32(DT.Rows[6][4]);
                button6.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[6] + ".jpg");
            }
            if (p >= 8)
            {
                lbl8_1.Text = DT.Rows[7][0].ToString();
                lbl8_2.Text = DT.Rows[7][1].ToString();
                lbl8_3.Text = DT.Rows[7][2].ToString() + " Pages";
                lbl8_4.Text = DT.Rows[7][3].ToString() + "/5";
                Globales.FavoritesPos[7] = Convert.ToInt32(DT.Rows[7][4]);
                button7.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[7] + ".jpg");
            }
        }

        #endregion

        #region Envio a vistas
        private void button12_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[0];
            mandar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[1];
            mandar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[2];
            mandar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[3];
            mandar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[4];
            mandar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[5];
            mandar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[6];
            mandar();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[8];
            mandar();
        }

        private void mandar()
        {
            FormViewer FV = new FormViewer();
            this.Enabled = false;
            NotificacionWaffle.Visible = false;
            FV.ShowDialog();
            this.Enabled = true;
            NotificacionWaffle.Visible = true;
        }
        #endregion


    }
}
