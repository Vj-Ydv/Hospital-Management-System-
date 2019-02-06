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
namespace Hospital_management_system
{
    public partial class newaccess : Form
    {
        public newaccess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox4.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("insert into hospital.login (username,password,Image) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "',@IMG)", conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                   cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("New authorization successfully created.");
                    while (myReader.Read())
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Your password in both fields didn't match. ");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\place your photo here1.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String picPath = dlg.FileName.ToString();
                textBox4.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void newaccess_Load(object sender, EventArgs e)
        {

        }
    }
}
