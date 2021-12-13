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
    public partial class FormSearch : Form
    {
        #region Inicio y Variables
        public FormSearch()
        {
            InitializeComponent();
            rd7.Checked = true;
            rr7.Checked = true;

        }
        string LibroCon = "";
        int filtro = 7;
        int orden = 7;
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
            NotificacionWaffle.Visible = false;

            FormSettings FH = new FormSettings();
            this.Hide();
            FH.ShowDialog();
            this.Close();
        }
        #endregion

        #region Seleccionar Parametros
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1.Checked == true)
            {
                filtro = 1;
                buscar();
            }
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            if (rd2.Checked == true)
            {
                filtro = 2;
                buscar();
            }
        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            if (rd3.Checked == true)
            {
                filtro = 3;
                buscar();
            }
        }

        private void rd4_CheckedChanged(object sender, EventArgs e)
        {
            if (rd4.Checked == true)
            {
                filtro = 4;
                buscar();
            }
        }

        private void rd5_CheckedChanged(object sender, EventArgs e)
        {
            if (rd5.Checked == true)
            {
                filtro = 5;
                buscar();
            }
        }

        private void rd6_CheckedChanged(object sender, EventArgs e)
        {
            if (rd6.Checked == true)
            {
                filtro = 6;
                buscar();
            }
        }

        private void rd7_CheckedChanged(object sender, EventArgs e)
        {
            if (rd7.Checked == true)
            {
                filtro = 7;
                buscar();
            }
        }

        private void rr1_CheckedChanged(object sender, EventArgs e)
        {
            if (rr1.Checked == true)
            {
                orden = 1;
                buscar();
            }
        }

        private void rr2_CheckedChanged(object sender, EventArgs e)
        {
            if (rr2.Checked == true)
            {
                orden = 2;
                buscar();
            }
        }

        private void rr3_CheckedChanged(object sender, EventArgs e)
        {
            if (rr3.Checked == true)
            {
                orden = 3;
                buscar();
            }
        }

        private void rr4_CheckedChanged(object sender, EventArgs e)
        {
            if (rr4.Checked == true)
            {
                orden = 4;
                buscar();
            }
        }

        private void rr5_CheckedChanged(object sender, EventArgs e)
        {
            if (rr5.Checked == true)
            {
                orden = 5;
                buscar();
            }
        }

        private void rr6_CheckedChanged(object sender, EventArgs e)
        {
            if (rr6.Checked == true)
            {
                orden = 6;
                buscar();
            }
        }

        private void rr7_CheckedChanged(object sender, EventArgs e)
        {
            if (rr7.Checked == true)
            {
                orden = 7;
                buscar();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LibroCon = textBox1.Text;
            buscar();
        }
        #endregion

        #region Llenar y consultar
        private void buscar()
        {
            string wher = ""; 
            string order = "";
            int ejemp = 0;
            int numlet = 0; //0 es numero - 1 es letra 

            if (int.TryParse(LibroCon, out ejemp))
            {
                numlet = 0;
            }
            else
            {
                numlet = 1;
            }

            #region where
            if (filtro == 1)
            {//Numero
                if (numlet == 0)
                {
                    wher = " WHERE B.BookID = " + LibroCon;
                }
                else
                {
                    wher = " WHERE B.BookID = 0";
                }
            }

            if (filtro == 2)
            {
                wher = " WHERE B.BookTitle = '" + LibroCon+"'";
            }

            if (filtro == 3)
            {
                wher = " WHERE B.BookTags = '" + LibroCon + "'";
            }

            if (filtro == 4)
            {
                wher = " WHERE E.EditorialName = '" + LibroCon + "'";
            }
            if (filtro == 5)
            {
                wher = " WHERE B.BookLanguage = '" + LibroCon + "'";
            }
            if (filtro == 6)
            {
                wher = " WHERE B.BookPlace = '" + LibroCon + "'";
            }
            if (filtro == 7)
            {
                wher = " ";
            }
            #endregion

            #region order by
            if (orden == 1)
            {
                order = " ORDER BY B.BookTitle ";
            }

            if (orden == 2)
            {
                order = " ORDER BY B.BookPages";
            }
            if (orden == 3)
            {
                order = " ORDER BY B.BookDate";
            }
            if (orden == 4)
            {
                order = " ORDER BY B.BookRating";
            }
            if (orden == 5)
            {
                order = " ORDER BY B.UsuariosCalificaron";
            }
            if (orden == 6)
            {
                order = " ORDER BY B.BookID";
            }
            if (orden == 6)
            {
                order = " ";
            }
            #endregion


            string sqlLibros = "SELECT B.BookTitle, E.EditorialName, B.BookPages, B.BookRating, B.BookID " +
            "FROM Books AS B " +
            "INNER JOIN Editorials AS E ON (B.BookEditorial = E.EditorialId) " +
            wher + " " + order;

            using (SqlCommand cmdBuscar = new SqlCommand(sqlLibros, Globales.conexion))
            {
                Globales.conexion.Open();
                DataTable DT = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdBuscar);
                adapter.Fill(DT);
                Globales.conexion.Close();

                mostrar(DT);
            }
        }

        public void mostrar(DataTable DT)
        {
            //7 LIBROS MAXIMOS
            int NumL = DT.Rows.Count;
            Globales.FavoritesPos = new int[NumL + 1];

            if (NumL == 0)
            {
                pan1.Visible = false;
                pan2.Visible = false;
                pan3.Visible = false;
                pan4.Visible = false;
                pan5.Visible = false;
                pan6.Visible = false;
                pan7.Visible = false;
            }
            else
            {
                if (NumL >= 1)
                {
                    pan1.Visible = true;
                    pan2.Visible = false;
                    pan3.Visible = false;
                    pan4.Visible = false;
                    pan5.Visible = false;
                    pan6.Visible = false;
                    pan7.Visible = false;

                    l1_1.Text = DT.Rows[0][0].ToString();
                    l1_2.Text = DT.Rows[0][1].ToString();
                    l1_3.Text = DT.Rows[0][2].ToString() + " Pages";
                    l1_4.Text = DT.Rows[0][3].ToString() + "/5";
                    Globales.FavoritesPos[0] = Convert.ToInt32(DT.Rows[0][4]);
                    button12.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[0] + ".jpg");
                }
                if (NumL >= 2)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = false;
                    pan4.Visible = false;
                    pan5.Visible = false;
                    pan6.Visible = false;
                    pan7.Visible = false;

                    l2_1.Text = DT.Rows[1][0].ToString();
                    l2_2.Text = DT.Rows[1][1].ToString();
                    l2_3.Text = DT.Rows[1][2].ToString() + " Pages";
                    l2_4.Text = DT.Rows[1][3].ToString() + "/5";
                    Globales.FavoritesPos[1] = Convert.ToInt32(DT.Rows[1][4]);
                    button13.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[1] + ".jpg");
                }
                if (NumL >= 3)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = true;
                    pan4.Visible = false;
                    pan5.Visible = false;
                    pan6.Visible = false;
                    pan7.Visible = false;

                    l3_1.Text = DT.Rows[2][0].ToString();
                    l3_2.Text = DT.Rows[2][1].ToString();
                    l3_3.Text = DT.Rows[2][2].ToString() + " Pages";
                    l3_4.Text = DT.Rows[2][3].ToString() + "/5";
                    Globales.FavoritesPos[2] = Convert.ToInt32(DT.Rows[2][4]);
                    button14.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[2] + ".jpg");
                }
                if (NumL >= 4)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = true;
                    pan4.Visible = true;
                    pan5.Visible = false;
                    pan6.Visible = false;
                    pan7.Visible = false;

                    l4_1.Text = DT.Rows[3][0].ToString();
                    l4_2.Text = DT.Rows[3][1].ToString();
                    l4_3.Text = DT.Rows[3][2].ToString() + " Pages";
                    l4_4.Text = DT.Rows[3][3].ToString() + "/5";
                    Globales.FavoritesPos[3] = Convert.ToInt32(DT.Rows[3][4]);
                    button15.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[3] + ".jpg");
                }
                if (NumL >= 5)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = true;
                    pan4.Visible = true;
                    pan5.Visible = true;
                    pan6.Visible = false;
                    pan7.Visible = false;

                    l5_1.Text = DT.Rows[4][0].ToString();
                    l5_2.Text = DT.Rows[4][1].ToString();
                    l5_3.Text = DT.Rows[4][2].ToString() + " Pages";
                    l5_4.Text = DT.Rows[4][3].ToString() + "/5";
                    Globales.FavoritesPos[4] = Convert.ToInt32(DT.Rows[4][4]);
                    button16.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[4] + ".jpg");
                }
                if (NumL >= 6)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = true;
                    pan4.Visible = true;
                    pan5.Visible = true;
                    pan6.Visible = true;
                    pan7.Visible = false;

                    l6_1.Text = DT.Rows[5][0].ToString();
                    l6_2.Text = DT.Rows[5][1].ToString();
                    l6_3.Text = DT.Rows[5][2].ToString() + " Pages";
                    l6_4.Text = DT.Rows[5][3].ToString() + "/5";
                    Globales.FavoritesPos[5] = Convert.ToInt32(DT.Rows[5][4]);
                    button18.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[5] + ".jpg");
                }
                if (NumL >= 7)
                {
                    pan1.Visible = true;
                    pan2.Visible = true;
                    pan3.Visible = true;
                    pan4.Visible = true;
                    pan5.Visible = true;
                    pan6.Visible = true;
                    pan7.Visible = true;

                    l7_1.Text = DT.Rows[6][0].ToString();
                    l7_2.Text = DT.Rows[6][1].ToString();
                    l7_3.Text = DT.Rows[6][2].ToString() + " Pages";
                    l7_4.Text = DT.Rows[6][3].ToString() + "/5";
                    Globales.FavoritesPos[6] = Convert.ToInt32(DT.Rows[6][4]);
                    button17.BackgroundImage = Image.FromFile("CoverPage\\" + Globales.FavoritesPos[6] + ".jpg");
                }
            }

        }
        #endregion

        #region Enviar a vistas
        private void mandar()
        {
            FormViewer FV = new FormViewer();
            this.Enabled = false;
            NotificacionWaffle.Visible = false;
            FV.ShowDialog();
            this.Enabled = true;
            NotificacionWaffle.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show(""+Globales.FavoritesPos[0]);
            Globales.LibroLeer = Globales.FavoritesPos[0];
            mandar();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[1];
            mandar();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[2];
            mandar();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[3];
            mandar();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[4];
            mandar();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[5];
            mandar();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Globales.LibroLeer = Globales.FavoritesPos[6];
            mandar();
        }
        #endregion
    }
}
