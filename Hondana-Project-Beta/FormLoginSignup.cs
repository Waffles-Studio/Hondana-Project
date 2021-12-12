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
            Globales.MensajeBienvendia = 0;
        }
        #endregion

        #region Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int res = login();
            if (res == 1)
            {
                insertlog();
                NotificacionWaffle.Visible = false;

                Globales.MensajeBienvendia = 1;
                FormHome FH = new FormHome();
                this.Hide();
                FH.ShowDialog();
                this.Close();
            }
            else
            {
                if (res == 2)
                {
                    NotificacionWaffle.ShowBalloonTip(100, "User is disabled", "Please contact an administrator or re - register.", ToolTipIcon.Warning);
                }
                else
                {
                    NotificacionWaffle.ShowBalloonTip(100, "Incorrect user or password.", "Try again", ToolTipIcon.Warning);
                }
            }
        }

        public void insertlog()
        {
            Globales.conexion.Open();
            string sqlinsert = "INSERT INTO Logs (Who, [what], [where], [when]) VALUES(@who, @what, @where, @when)";

            using (SqlCommand cmdins = new SqlCommand(sqlinsert, Globales.conexion))
            {
                cmdins.Parameters.AddWithValue("@who", Globales.UserID);
                cmdins.Parameters.AddWithValue("@what", "Login");
                cmdins.Parameters.AddWithValue("@where", "Hondana Project Beta");
                cmdins.Parameters.AddWithValue("@when", DateTime.Now);
                cmdins.ExecuteNonQuery();
            }
            Globales.conexion.Close();
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
            if (TxtSignupName.Text != "Your name" && TxtSignupEmail.Text != "someone@example.com" && TxtSignupPassword.Text != "•••" && TxtSignupConfirm.Text != "•••")
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
                            MessageBox.Show("" + bien);
                        }
                    }
                    catch (Exception )
                    {
                        NotificacionWaffle.ShowBalloonTip(100, "Fail everything that could fail", "check the... sp?", ToolTipIcon.Warning);
                    }
                    finally
                    {
                        if (bien == 1)
                        {
                            NotificacionWaffle.ShowBalloonTip(100, "User successfully registered.", "Now you can login", ToolTipIcon.None);
                        }
                        else
                        {
                            NotificacionWaffle.ShowBalloonTip(100, "Please use another or login.", "This email is already used in another account.", ToolTipIcon.Warning);
                        }
                    }
                }
                else
                {
                    NotificacionWaffle.ShowBalloonTip(100, "Your passwords do not match.", "Please correct it", ToolTipIcon.Warning);
                }
            }
            else
            {
                NotificacionWaffle.ShowBalloonTip(100, "Information is missing", "Please fill in all the fields", ToolTipIcon.Warning);
            }

            Globales.conexion.Close();
        }
        #endregion

        #region Proximamente
        private void LblLoginForgot_Click(object sender, EventArgs e)
        {
            NotificacionWaffle.ShowBalloonTip(100, "Ups", "Coming soon....", ToolTipIcon.Warning);
        }
        #endregion
    }
}
