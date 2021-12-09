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
    public partial class FormLoginSignup : Form
    {

        #region inicio
        public FormLoginSignup()
        {
            InitializeComponent();
        }
        #endregion

        #region Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int res = login();
            if (res == 1)
            {
                this.Hide();
                FormHome FH = new FormHome();
                FH.ShowDialog();
            }
            else
            {
                if (res == 2)
                {
                    MessageBox.Show("User is disabled. \nPlease contact an administrator or re - register.", ":(");
                }
                else
                {

                    MessageBox.Show("Incorrect user or password. \nTry again.", ":(");
                }
            }
        }

        public int login()
        {            
            Globales.conexion.Open();
            int logcheck = 0;
            string sqlLogin = "SELECT UserID, UserRole, UserName, UserIcon, Activo FROM Users "+
                "WHERE UserEmail = @mail AND UserPassword = @pass";

            using (SqlCommand logreq = new SqlCommand(sqlLogin, Globales.conexion))
            {
                logreq.Parameters.AddWithValue("@mail", TxtLoginEmail.Text);
                logreq.Parameters.AddWithValue("@pass", TxtLoginPassword.Text);
                SqlDataReader user = logreq.ExecuteReader();

                if (user.Read())
                {
                    Globales.UserID = user["UserID"].ToString();
                    Globales.UserRole = user["UserRole"].ToString();
                    Globales.UserName = user["UserName"].ToString();
                    Globales.UserEmail = TxtLoginEmail.Text;
                    Globales.UserIcon = user["UserIcon"].ToString();

                    if (user["Activo"].ToString() == "True")
                    {
                        logcheck = 1;
                    }
                    else
                    {
                        logcheck = 2;
                    }

                    
                }
                else
                {
                    logcheck = 0;
                }
            }

            Globales.conexion.Close();
            return logcheck;
        }
        #endregion

        #region textbox selected
        private void TxtLoginEmail_Click(object sender, EventArgs e)
        {
            if (TxtLoginEmail.Text == "someone@example.com")
            {
                TxtLoginEmail.Text = "";
            }
            if (TxtLoginPassword.Text == "")
            {
                TxtLoginPassword.Text = "• •••••••••";
            }
        }

        private void TxtLoginPassword_Click(object sender, EventArgs e)
        {
            if (TxtLoginPassword.Text == "• •••••••••")
            {
                TxtLoginPassword.Text = "";
            }
            if (TxtLoginEmail.Text == "")
            {
                TxtLoginEmail.Text = "someone@example.com";
            }
        }

        private void TxtSignupName_Click(object sender, EventArgs e)
        {
            if (TxtSignupName.Text == "Your name")
            {
                TxtSignupName.Text = "";
            }
            if (TxtSignupEmail.Text == "")
            {
                TxtSignupEmail.Text = "someone@example.com";
            }
            if (TxtSignupPassword.Text == "")
            {
                TxtSignupPassword.Text = "•••";
            }
            if (TxtSignupConfirm.Text == "")
            {
                TxtSignupConfirm.Text = "•••";
            }
        }

        private void TxtSignupEmail_Click(object sender, EventArgs e)
        {
            if (TxtSignupName.Text == "")
            {
                TxtSignupName.Text = "Your name";
            }
            if (TxtSignupEmail.Text == "someone@example.com")
            {
                TxtSignupEmail.Text = "";
            }
            if (TxtSignupPassword.Text == "")
            {
                TxtSignupPassword.Text = "•••";
            }
            if (TxtSignupConfirm.Text == "")
            {
                TxtSignupConfirm.Text = "•••";
            }
        }

        private void TxtSignupPassword_Click(object sender, EventArgs e)
        {
            if (TxtSignupName.Text == "")
            {
                TxtSignupName.Text = "Your name";
            }
            if (TxtSignupEmail.Text == "")
            {
                TxtSignupEmail.Text = "someone@example.com";
            }
            if (TxtSignupPassword.Text == "•••")
            {
                TxtSignupPassword.Text = "";
            }
            if (TxtSignupConfirm.Text == "")
            {
                TxtSignupConfirm.Text = "•••";
            }
        }

        private void TxtSignupConfirm_Click(object sender, EventArgs e)
        {
            if (TxtSignupName.Text == "")
            {
                TxtSignupName.Text = "Your name";
            }
            if (TxtSignupEmail.Text == "")
            {
                TxtSignupEmail.Text = "someone@example.com";
            }
            if (TxtSignupPassword.Text == "")
            {
                TxtSignupPassword.Text = "•••";
            }
            if (TxtSignupConfirm.Text == "•••")
            {
                TxtSignupConfirm.Text = "";
            }
        }
        #endregion

        #region Registrarse
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            if (TxtSignupPassword.Text == TxtSignupConfirm.Text)
            {
                int bien = 0;
                Globales.conexion.Open();
                try
                {

                    string sp = "SPABRUsuarios";
                    using (SqlCommand cmdInserta = new SqlCommand(sp, Globales.conexion))
                    {
                        cmdInserta.CommandType = CommandType.StoredProcedure;
                        cmdInserta.Parameters.Clear();

                        byte[] imagen = new byte[10];
                        int rol = 2;
                        cmdInserta.Parameters.AddWithValue("@UserRole", rol);
                        cmdInserta.Parameters.AddWithValue("@UserName", TxtSignupName.Text);
                        cmdInserta.Parameters.AddWithValue("@UserEmail", TxtSignupEmail.Text);
                        cmdInserta.Parameters.AddWithValue("@UserPassword", TxtSignupPassword.Text);
                        cmdInserta.Parameters.AddWithValue("@UserIcon", imagen);
                        cmdInserta.Parameters.AddWithValue("@Activo", "True");
                        cmdInserta.Parameters.AddWithValue("@CRUD", "Alta");
                        cmdInserta.Parameters.AddWithValue("@Status", SqlDbType.Bit).Direction = ParameterDirection.Output;

                        cmdInserta.ExecuteNonQuery();
                        bien = Convert.ToInt32(cmdInserta.Parameters["@Status"].Value);
                        MessageBox.Show(""+bien);
                    }
                }
                catch (Exception b)
                {
                    MessageBox.Show("Fail everything that could fail \n"+b, "Ups....");
                }
                finally
                {
                    if (bien == 1)
                    {
                        MessageBox.Show("User successfully registered. \nNow you can login", ":)");
                    }
                    else
                    {
                        MessageBox.Show("This email is already used in another account. \nPlease use another or login. ", ":(");
                    }
                }
            }
            else
            {
                MessageBox.Show("Your passwords do not match. \nPlease correct it", ":(");
            }
            Globales.conexion.Close();
        }
        #endregion

    }
}
