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
                //JSON
                string path = @"D:\users-backup.json";
                try
                {
                    StringBuilder SB = new StringBuilder();
                    StringWriter SW = new StringWriter(SB);
                    string Query = "SELECT * FROM Users";
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
                        using (StreamWriter streamWriter = new StreamWriter(path))
                        {
                            streamWriter.Write(SB.ToString());
                        }
                    }
                    MessageBox.Show("[!] The JSON file was successfully generated, File path: " + path);
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("[!] An error occurred during the generation of the file.");
                }
            }
            if (radioButton2.Checked == true)
            {
                //XML
                string path = @"D:\users-backup.xml";
                try
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            xmlWriter.WriteElementString(dataGridView1.Columns[i].Name, dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
                        }
                        xmlWriter.WriteEndElement();
                        xmlWriter.Flush();
                    }
                    MessageBox.Show("[!] The XML file was successfully generated, File path: " + path);
                }
                catch (Exception ex5)
                {
                    MessageBox.Show("[!] An error occurred during the generation of the file.");
                }
            }
            else
            {
                MessageBox.Show("[!] Please select a format. JSON and XML available.");
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
            textBox4.Visible = false;
            button18.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desactivar blablabla...", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
            textBox2.Visible = false;
            button14.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desactivar blablabla...", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }
        #endregion
    }
}
