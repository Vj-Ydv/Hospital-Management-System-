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
using AForge.Video;
using AForge.Video.DirectShow;
using AForge;

namespace Hospital_management_system
{
    public partial class Form5Bloodinfo : Form
    {
        public Form5Bloodinfo()
        {
            InitializeComponent();
        }

      

        private void Form5Bloodinfo_Load(object sender, EventArgs e)
        {
            
            DateTime datetime = DateTime.Today;
            this.textBox8.Text = datetime.ToString("yyyy-MM-dd");
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox9.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox9.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox7.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "insert into hospital.bloodbank (age,gender,name,address,contactno,bloodgroup,emailid,regdate,Image)  values('" + this.textBox10.Text + "','" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox8.Text + "',@IMG) ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Form5Bloodinfo_FormClosing(object sender, FormClosingEventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                textBox7.Text = PicPath;
                pictureBox1.ImageLocation = PicPath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox7.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "update hospital.bloodbank set gender ='" + this.textBox1.Text + "',name='" + this.textBox2.Text + "',address='" + this.textBox3.Text + "', contactno='" + this.textBox4.Text + "', bloodgroup='" + this.textBox5.Text + "',emailid='" + this.textBox6.Text + "',regdate='" + this.textBox8.Text + "',age='" + this.textBox10.Text + "',Image=@IMG where contactno='" + this.textBox4.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Updated");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            Form6BloodSearch f6 = new Form6BloodSearch();
            f6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "delete from hospital.bloodbank where contactno='" + this.textBox4.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Record Deleted");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "G:\\visual c#\\Photos\\photo2.jpg";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\photo2.jpg");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Contact no.")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                string Query = "select * from hospital.bloodbank where contactno='" + textBox9.Text + "' ; ";
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
                        string sname = myReader.GetString("Name");

                        string saddress = myReader.GetString("address");
                        string scontactno = myReader.GetString("contactno");

                        string sBlood = myReader.GetString("bloodgroup");
                        string semailid = myReader.GetString("emailid");
                        string sregdate = myReader.GetString("regdate");
                        string sage = myReader.GetString("age");
                        textBox1.Text = sgender;
                        textBox2.Text = sname;
                        textBox3.Text = saddress;
                        textBox4.Text = scontactno;
                        textBox5.Text = sBlood;
                        textBox6.Text = semailid;
                        textBox8.Text = sregdate;
                        textBox10.Text = sage;


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

            if (comboBox1.Text == "Name")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                string Query = "select * from hospital.bloodbank where Name='" + textBox9.Text + "' ; ";
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
                        string sname = myReader.GetString("Name");

                        string saddress = myReader.GetString("address");
                        string scontactno = myReader.GetString("contactno");

                        string sBlood = myReader.GetString("bloodgroup");
                        string semailid = myReader.GetString("emailid");
                        string sregdate = myReader.GetString("regdate");
                        string sage = myReader.GetString("age");
                        textBox1.Text = sgender;
                        textBox2.Text = sname;
                        textBox3.Text = saddress;
                        textBox4.Text = scontactno;
                        textBox5.Text = sBlood;
                        textBox6.Text = semailid;
                        textBox8.Text = sregdate;
                        textBox10.Text = sage;


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

            if (comboBox1.Text == "address")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                string Query = "select * from hospital.bloodbank where address='" + textBox9.Text + "' ; ";
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
                        string sname = myReader.GetString("Name");

                        string saddress = myReader.GetString("address");
                        string scontactno = myReader.GetString("contactno");

                        string sBlood = myReader.GetString("bloodgroup");
                        string semailid = myReader.GetString("emailid");
                        string sregdate = myReader.GetString("regdate");
                        string sage = myReader.GetString("age");
                        textBox1.Text = sgender;
                        textBox2.Text = sname;
                        textBox3.Text = saddress;
                        textBox4.Text = scontactno;
                        textBox5.Text = sBlood;
                        textBox6.Text = semailid;
                        textBox8.Text = sregdate;
                        textBox10.Text = sage;
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

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button8.PerformClick();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String comboval2 = comboBox2.Text;
            this.textBox5.Text = comboval2;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String comboval3 = comboBox3.Text;
            this.textBox1.Text = comboval3;
        }

        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private void cam_newframe(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = bit;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            cam = new VideoCaptureDevice(webcam[comboBox9.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_newframe);
            cam.Start();

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }

            panel1.Visible = false;
            pictureBox1.Image = pictureBox2.Image;
            String filepath = "F:\\HMS_image" + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            pictureBox1.Image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            textBox7.Text = filepath;

        }
    }
}