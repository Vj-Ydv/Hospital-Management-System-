using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Drawing.Imaging;
namespace Hospital_management_system
{
    public partial class Form6BloodSearch : Form
    {
        public Form6BloodSearch()
        {
            InitializeComponent();
            load_table();
        }


        DataTable dbdataset;
        void load_table()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select* from hospital.bloodbank ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;
                dataGridView1.AllowUserToAddRows = false;

                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                //  dataGridView1.Columns["Image"].Visible = false;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[9];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = String.Format("bloodgroup LIKE '%{0}%'", comboBox1.Text);
            dataGridView1.DataSource = DV;
            int c = dataGridView1.Rows.Count;
            label35.Text = c.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form6BloodSearch_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load_table();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
         
            label35.Text = "0";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\photo2.jpg");
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay  ";
                string Query = "select * from hospital.bloodbank where contactno='" + textBox4.Text + "' ; ";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {


                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {
                        string sgender = myReader.GetString("gender");
                        string sname = myReader.GetString("name");
                        string sContact = myReader.GetString("contactno");
                        string sAddress = myReader.GetString("address");
                        string semail = myReader.GetString("emailid");
                      

                        textBox1.Text = sgender;
                        textBox2.Text = sname;
                        textBox4.Text = sContact;
                        textBox3.Text = sAddress;
                        textBox5.Text = semail;
                        


                        byte[] imgg = (byte[])(myReader["Image"]);
                        if (imgg == null)
                            pictureBox1.Image = null;
                        else
                        {
                            MemoryStream mstream = new MemoryStream(imgg);
                            pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        }


                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage("vjphotos101@gmail.com", textBox5.Text, "Urgent request for blood.", "Your blood group is matched and required by a patient at LIFEcare Hospital urgently. If you could help, it will save a life. For any query contact our staff.");
                //mail.Attachments.Add(new Attachment(textBox1.Text.ToString()));
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("vjphotos101@gmail.com", "dark");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Mail successfully sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
