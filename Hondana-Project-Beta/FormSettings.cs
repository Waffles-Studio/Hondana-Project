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
//Libraries needed to Export
using System.IO;
using System.Xml;
using Newtonsoft.Json;

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
            if (Globales.UserRole == "1")
            {
                label1.Text = "Administrator";
            }
            else
            {
                panel5.Enabled = false;
                label1.Text = "User";
            }
        }
        int seleccion = 0;
        private DataTable DT = new DataTable();
        int iduser=0;
        string consulta = "";
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
            seleccion = 0;
            string cons = "select U.UserName, L.what as What, L.[where] as [Where], CONVERT(varchar, L.[when], 0) AS [When]  " +
                "from Logs AS L INNER JOIN Users AS U ON (L.Who = U.UserID) ";
            consulta = cons;
            llenarGrid(cons);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            //string cons = "SELECT UserID, UserName, UserEmail, UserPassword, Activo FROM Users";
            seleccion = 1;
            string cons = "Select R.RoleDescription, U.UserName, U.UserEmail, CONVERT(VARCHAR, ENCRYPTBYPASSPHRASE('CoviLAB', U.UserPassword)) AS [Password],  " +
                "'No icon' AS Icon, U.Activo " +
                "FROM Users AS U INNER JOIN Roles AS R ON (U.UserRole = R.RoleID)";
            consulta = cons;
            llenarGrid(cons);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            seleccion = 0;
            string cons = "select B.BookTitle, E.EditorialName, B.BookPages, b.BookPages, B.BookISBN, B.BookLanguage, B.BookRating  " +
                "from Books AS B INNER JOIN Editorials AS E ON (B.BookEditorial = E.EditorialId)";
            consulta = cons;
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
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JSON|*.json";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder SB = new StringBuilder();
                        StringWriter SW = new StringWriter(SB);

                        string Query = consulta;

                        Globales.conexion.Open();
                        SqlCommand command = new SqlCommand(Query, Globales.conexion);
                        SqlDataReader reader = command.ExecuteReader();
                        

                        using (JsonWriter jsonWriter = new JsonTextWriter(SW))
                        {
                            jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
                            jsonWriter.WriteStartArray();
                            while (reader.Read())
                            {
                                jsonWriter.WriteStartObject();
                                int fields = reader.FieldCount;
                                for (int i = 0; i < fields; i++)
                                {
                                    jsonWriter.WritePropertyName(reader.GetName(i));
                                    jsonWriter.WriteValue(reader[i]);
                                }
                                jsonWriter.WriteEndObject();
                            }
                            jsonWriter.WriteEndArray();
                            using (StreamWriter streamWriter = new StreamWriter(sfd.FileName))
                            {
                                streamWriter.Write(SB.ToString());
                            }
                        }
                        Globales.conexion.Close();
                        NotificacionWaffle.ShowBalloonTip(100, "Finished", "Json file generated correctly", ToolTipIcon.None);
                    }
                    catch (Exception)
                    {
                        NotificacionWaffle.ShowBalloonTip(100, "Sorry", "An error occurred during the generation of the file.", ToolTipIcon.Warning);
                    }
                }

            }
            if (radioButton2.Checked == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int j = 0;
                        var dt = new DataTable();
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            if (column.Visible)
                            {
                                dt.Columns.Add(dataGridView1.Columns[j].Name);
                                j++;
                            }
                        }
                        j = 0;
                        object[] cellValues = new object[dataGridView1.Columns.Count];
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                cellValues[i] = row.Cells[i].Value;
                            }
                            dt.Rows.Add(cellValues);
                        }

                        DataSet dS = new DataSet();
                        dS.Tables.Add(dt);
                        dS.WriteXml(sfd.FileName);
                        NotificacionWaffle.ShowBalloonTip(100, "Finished", "Xml file generated correctly", ToolTipIcon.None);

                    }
                    catch (Exception)
                    {
                        NotificacionWaffle.ShowBalloonTip(100, "Sorry", "An error occurred during the generation of the file.", ToolTipIcon.Warning);
                    }
                }
            }   
        }

        #endregion

        #region ModificarUsuarioPropio
        private void button2_Click(object sender, EventArgs e)
        {

            textBox3.Visible = true;
            button17.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                string c = "UPDATE Users SET UserName = '" + textBox3.Text + "' WHERE UserID = " + Globales.UserID;
                Updates(c);
                Globales.UserName = textBox3.Text;
                label5.Text = Globales.UserName;
                NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Username changed", ToolTipIcon.None);
            }
            else
            {
                NotificacionWaffle.ShowBalloonTip(100, "Sorry...", "Please enter an acceptable username", ToolTipIcon.Warning);
            }


            textBox3.Visible = false;
            button17.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            button18.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string c = "UPDATE Users SET UserPassword = '" + textBox4.Text + "' WHERE UserID = " + Globales.UserID;
                Updates(c);
                NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Password changed", ToolTipIcon.None);
            }
            else
            {
                NotificacionWaffle.ShowBalloonTip(100, "Sorry...", "Please enter an acceptable password", ToolTipIcon.Warning);
            }

            textBox4.Visible = false;
            button18.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult R =  MessageBox.Show("Are you sure you want to deactivate the account?", "Think wisely", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (R == DialogResult.OK)
            {
                string c = "UPDATE Users SET Activo = '0' WHERE UserID = " + Globales.UserID;
                Updates(c);
                NotificacionWaffle.Visible = false;

                FormWelcome FH = new FormWelcome();
                this.Hide();
                FH.ShowDialog();
                this.Close();

            }
        }
        #endregion

        #region ModificarOtroUsuario
        private void button11_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            button16.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                NotificacionWaffle.ShowBalloonTip(100, "mmm...", "You did not select a user type", ToolTipIcon.Warning);
            }
            else
            {
                if (comboBox1.SelectedItem == "Administrator")
                {
                    string c = "UPDATE Users SET UserRole = '1' WHERE UserEmail = '"+label7.Text+"'";
                    Updates(c);
                    NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Modified user type", ToolTipIcon.None);
                }
                else
                {
                    string c = "UPDATE Users SET UserRole = '2' WHERE UserEmail = '" + label7.Text + "'";
                    Updates(c);
                    NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Modified user type", ToolTipIcon.None);
                }
            }

            comboBox1.Visible = false;
            button16.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button15.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                NotificacionWaffle.ShowBalloonTip(100, "Sorry...", "Please enter an acceptable username", ToolTipIcon.Warning);
            }
            else
            {
                string c = "UPDATE Users SET UserName = '"+textBox1.Text+"' WHERE UserEmail = '" + label7.Text + "'";
                Updates(c);
                NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Username changed", ToolTipIcon.None);
            }

            textBox1.Visible = false;
            button15.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button14.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                NotificacionWaffle.ShowBalloonTip(100, "Sorry...", "Please enter an acceptable password", ToolTipIcon.Warning);
            }
            else
            {
                string c = "UPDATE Users SET UserPassword = '" + textBox2.Text + "' WHERE UserEmail = '" + label7.Text + "'";
                Updates(c);
                NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "Password changed", ToolTipIcon.None);
            }


            textBox2.Visible = false;
            button14.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string r= "";
            DialogResult R = MessageBox.Show("Are you sure you want to activate/deactivate the account?", "Think wisely", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (R == DialogResult.OK)
            {
                using (SqlCommand cmd = new SqlCommand("select Activo from Users WHERE UserEmail = '"+label7.Text+"'", Globales.conexion))
                {
                    Globales.conexion.Open();
                    r = cmd.ExecuteScalar().ToString();
                    //MessageBox.Show(""+ cmd.ExecuteScalar().ToString());
                    Globales.conexion.Close();
                }
                
                if (r == "True")
                {
                    string c = "UPDATE Users SET Activo = '0' WHERE UserEmail = '" + label7.Text + "'"; ;
                    Updates(c);
                    NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "User deactivated", ToolTipIcon.None);
                }
                else
                {
                    string c = "UPDATE Users SET Activo = '1' WHERE UserEmail = '" + label7.Text + "'"; ;
                    Updates(c);
                    NotificacionWaffle.ShowBalloonTip(100, "Changed :)", "User activated", ToolTipIcon.None);
                }            
            }
        }
        #endregion

        #region Updates 
        private void Updates(string c)
        {
            using (SqlCommand cmdchange = new SqlCommand(c, Globales.conexion))
            {
                Globales.conexion.Open();
                cmdchange.ExecuteNonQuery();
                Globales.conexion.Close();
            }
        }
        #endregion

        #region Seleccion DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccion == 1)
            {                
                string correo = dataGridView1.Rows[e.RowIndex].Cells["UserEmail"].Value.ToString();
                if (correo != null)
                {
                    llenareditable(correo);
                }
            }
        }

        private void llenareditable(string c)
        {
            string sqlcon = "select U.UserName, U.UserEmail, R.RoleDescription " +
                "FROM Users AS U INNER JOIN Roles AS R ON (U.UserRole = R.RoleID) " +
                "WHERE UserEmail = '"+c+"'";
            int p = 0;
            using (SqlCommand cmddat = new SqlCommand(sqlcon, Globales.conexion))
            {
                Globales.conexion.Open();
                SqlDataReader reader = cmddat.ExecuteReader();
                
                if (reader.Read())
                {
                    label8.Text = reader[0].ToString();
                    label7.Text = reader[1].ToString();
                    label10.Text = reader[2].ToString();

                    button11.Enabled = true;
                    button7.Enabled = true;
                    button6.Enabled = true;
                    button5.Enabled = true;
                    p = 1;
                }
                Globales.conexion.Close();
                reader.Close();

            }
            if (p == 1)
            {
                string coo = "select UserID From Users WHERE UserEmail = '" +c+ "'";
                using (SqlCommand cmd = new SqlCommand(coo, Globales.conexion))
                {
                    Globales.conexion.Open();
                    iduser = (Int32)cmd.ExecuteScalar();
                    Globales.conexion.Close();
                }
            }
        }
        #endregion
    }
}
