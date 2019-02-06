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
    public partial class Form2 : Form
    {
        public Form2(string str_value1)
        {
            InitializeComponent();
            label4.Text = str_value1;
           
        }
        public Form2()
        {
            InitializeComponent();
        }
        void backupdata()
        {
            string conn = "server=localhost;user=root;password=vijay;database=medicalstore";
            string file = "G:\\Visual Studio\\MySQL Backup\\hospital.sql";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = con;
                        con.Open();
                        mb.ExportToFile(file);
                        con.Close();
                    }
                }
            }
            //MessageBox.Show("Backup completed...!");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            backupdata();

            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            newaccess na = new newaccess();
            na.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x1A2028);
         
            panel3.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel5.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel8.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel10.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel12.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            
            panel16.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel18.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel20.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel3.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel5.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel8.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel10.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel12_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel12.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void panel16_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel16.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel18_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel18.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void panel20_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x0066CC);
            panel20.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }



       

        private void Form2_Load(object sender, EventArgs e)
        {
            if (label4.Text == "Administrator")
            {
                linkLabel1.Visible = true;
                linkLabel2.Visible = true;
            }


            String susername = label4.Text;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from hospital.login where username ='" + susername + "';", conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {

                    byte[] imgg = (byte[])(myReader["Image"]);
                    if (imgg == null)
                        pictureBox2.Image = null;
                        
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);

                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
                  
          

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            panel24.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel24.Visible = true;
        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {
            //panel24.Visible = false;
        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {
            //panel24.Visible = false;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            panel24.Visible = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            Color temp = Color.FromArgb(0x1A2028);
          
            panel3.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel5.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel8.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel10.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel12.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            
            panel16.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel18.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
            panel20.BackColor = Color.FromArgb(temp.R, temp.G, temp.B);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeaccount ra = new removeaccount();
            ra.ShowDialog();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2OutP op = new Form2OutP(label4.Text);
            op.ShowDialog();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            ipbillprint ipbp = new ipbillprint(label4.Text);
            ipbp.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form5Bloodinfo f5 = new Form5Bloodinfo();
            f5.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            doctorinfo di = new doctorinfo();
            di.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            staffnfo si = new staffnfo();
            si.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            pathology f3 = new pathology();
            f3.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            appointment f4 = new appointment();
            f4.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form6 f5 = new Form6();
            f5.ShowDialog();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
