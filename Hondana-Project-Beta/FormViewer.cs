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
    public partial class FormViewer : Form
    {
        #region Inicio y Fin
        public FormViewer()
        {
            InitializeComponent();
            Globales.Cargados = 0;
            existe();
            iniciar();
            radiollenar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.Visible = false;
            this.Close();
        }
        #endregion

        #region Mostrar datos
        private void iniciar()
        {
            string sqlcon = "SELECT BookTitle, EditorialName, BookPages, BookISBN, BookLanguage, BookTags, BookRating " +
                "FROM Books INNER JOIN Editorials ON (Books.BookEditorial = Editorials.EditorialId) " +
                "WHERE BookID = @libro";
            using (SqlCommand cmdLibro = new SqlCommand(sqlcon, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdLibro.Parameters.AddWithValue("@libro", Globales.LibroLeer);

                SqlDataAdapter adapter = new SqlDataAdapter(cmdLibro);
                DataTable DT = new DataTable();
                adapter.Fill(DT);

                lbl1.Text = DT.Rows[0][0].ToString();
                lbl2.Text = DT.Rows[0][1].ToString();
                lbl3.Text = DT.Rows[0][2].ToString() + " Pages";
                lbl4.Text = DT.Rows[0][3].ToString();
                lbl5.Text = DT.Rows[0][4].ToString();
                lbl6.Text = DT.Rows[0][5].ToString();
                lbl7.Text = DT.Rows[0][6].ToString() + "/5";
                Globales.conexion.Close();
            }
        }
        #endregion

        #region Comprovar favoritos
        private void existe()
        {
            string sql = "select *from Favorites where UserId = @libro AND BookID = @usuario";
            int vlr = 0;
            using (SqlCommand cmdexiste = new SqlCommand(sql, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdexiste.Parameters.AddWithValue("@libro", Globales.UserID);
                cmdexiste.Parameters.AddWithValue("@usuario", Globales.LibroLeer);
                SqlDataReader reader = cmdexiste.ExecuteReader();
                if (reader.Read())
                {
                    vlr = 1;
                }
                else
                {
                    vlr = 0;
                }
                Globales.conexion.Close();
            }
            if (vlr == 0)
            {
                string sql2 = "INSERT INTO Favorites (BookID, UserId, FavoriteReader, FavoriteRating) VALUES (@libro, @usuario, 0, 0)";
                using (SqlCommand cmdexiste2 = new SqlCommand(sql2, Globales.conexion))
                {
                    
                    Globales.conexion.Open();
                    cmdexiste2.Parameters.AddWithValue("@libro", Globales.LibroLeer);
                    cmdexiste2.Parameters.AddWithValue("@usuario", Globales.UserID);
                    cmdexiste2.ExecuteNonQuery();
                    Globales.conexion.Close();
                    MessageBox.Show("si entra al insert");
                }
            }
        }
        #endregion
        
        #region cambio de libro leido
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string l = "UPDATE Favorites " +
                    "SET UserId = @user, BookID = @libro, FavoriteReader = 1 " +
                    "WHERE UserId = @user AND BookID = @libro";
                leerono(l);
                if (Globales.Cargados == 1)
                {
                    NotificacionWaffle.ShowBalloonTip(100, "The book was marked", "Added to your read books", ToolTipIcon.None);
                }
                
            }            
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                string l = "UPDATE Favorites " +
                    "SET UserId = @user, BookID = @libro, FavoriteReader = 0 " +
                    "WHERE UserId = @user AND BookID = @libro";
                leerono(l);
                if (Globales.Cargados == 1)
                {
                    NotificacionWaffle.ShowBalloonTip(100, "The book was marked", "Added to your unread books", ToolTipIcon.None);
                }
                
            }            
        }

        private void leerono(string sqlleero)
        {
            using (SqlCommand cmdleer = new SqlCommand(sqlleero, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdleer.Parameters.AddWithValue("@user", Globales.UserID);
                cmdleer.Parameters.AddWithValue("@libro", Globales.LibroLeer);
                cmdleer.ExecuteNonQuery();
                Globales.conexion.Close();
            }
        }
        #endregion
        
        #region llenar radio buttons
        private void radiollenar()
        {
            string sqlcon = "Select FavoriteReader, FavoriteRating from Favorites where UserId = @user and BookID = @libro";
            using (SqlCommand sqlcom = new SqlCommand(sqlcon, Globales.conexion))
            {
                Globales.conexion.Open();
                sqlcom.Parameters.AddWithValue("@user", Globales.UserID);
                sqlcom.Parameters.AddWithValue("@libro", Globales.LibroLeer);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcom);
                DataTable DT = new DataTable();
                adapter.Fill(DT);

                int red = Convert.ToInt32(DT.Rows[0][0]);
                int pun = Convert.ToInt32(DT.Rows[0][1]);
                Globales.conexion.Close();

                if (red == 1)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

                if (pun >= 1)
                {
                    groupBox1.Enabled = false;

                    if (pun == 1)
                    {
                        radioButton3.Checked = true;
                    }
                    if (pun == 2)
                    {
                        radioButton4.Checked = true;
                    }
                    if (pun == 3)
                    {
                        radioButton5.Checked = true;
                    }
                    if (pun == 4)
                    {
                        radioButton6.Checked = true;
                    }
                    if (pun == 5)
                    {
                        radioButton7.Checked = true;
                    }
                }
            }

            Globales.Cargados = 1;
        }
        #endregion

        #region votar

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            int v = 1;
            votar(v);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            int v = 2;
            votar(v);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            int v = 3;
            votar(v);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            int v = 4;
            votar(v);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            int v = 5;
            votar(v);
        }

        private void votar(int v)
        {
            groupBox1.Enabled = false;
            string sqlvotar = "UPDATE Favorites " +
                "SET UserId = @user, BookID = @libro, FavoriteRating = @cal " +
                "WHERE UserId = @user AND BookID = @libro ";

            using (SqlCommand cmdcali = new SqlCommand(sqlvotar, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdcali.Parameters.AddWithValue("@user", Globales.UserID);
                cmdcali.Parameters.AddWithValue("@libro", Globales.LibroLeer );
                cmdcali.Parameters.AddWithValue("@cal", v);
                cmdcali.ExecuteNonQuery();
                Globales.conexion.Close();
            }
            if (Globales.Cargados == 1)
            {
                NotificacionWaffle.ShowBalloonTip(100, "Thanks for voting", "Your qualification was saved", ToolTipIcon.None);
            }
            
        }
        #endregion


    }
}
