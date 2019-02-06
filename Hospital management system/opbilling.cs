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
    public partial class opbilling : Form
    {
        public opbilling(string str_value1, string str_value2, string str_value3,string username)
        {
            InitializeComponent();
            label22.Text = str_value1;
            label16.Text = str_value2;
            label3.Text = str_value3;
            label18.Text = username;    
        }
        void auto_increment()
        {
            String s1 = "SELECT MAX(BillNo) FROM hospital.billrecord";
            int a;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            conDataBase.Open();

            MySqlCommand cmd = new MySqlCommand(s1, conDataBase);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label35.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label35.Text = a.ToString();
                }
            }
        }
        
        private void opbilling_Load(object sender, EventArgs e)
        {
            try
            {
                auto_increment();
                DateTime datetime = DateTime.Today;
                this.label11.Text = datetime.ToString("yyyy-MM-dd");

                double a = Convert.ToInt32(label22.Text);
                double v = 0.05 * a;
                double t = a + v;
                label24.Text = v.ToString();
                label32.Text = t.ToString();

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = barcode.Draw(label3.Text, 50);


                String spatientid = label3.Text;
                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select o.Name,o.Age,o.Gender,p.AppWith from hospital.opinfo o inner join hospital.patientinfo p where o.PatientID=p.PatientID and o.PatientID ='" + spatientid + "';", conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    if (myReader.Read())
                    {
                        String nameVal = myReader.GetString("Name");
                        label5.Text = nameVal;
                        String ageVal = myReader.GetString("Age");
                        label7.Text = ageVal;
                        String genderVal = myReader.GetString("Gender");
                        label12.Text = genderVal;
                        String dateVal = myReader.GetString("AppWith");
                        label16.Text = dateVal;

                    }
                    else
                        MessageBox.Show("No record found in the database");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Visible = true;
           

            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("insert into hospital.billrecord (Billno,PatientID,Particulars,Charge,RecordedOn,RecordedBy) values('" + this.label35.Text + "','" + this.label3.Text + "','" + this.label17.Text + "','" + this.label32.Text + "','" + this.label11.Text + "','"+label18.Text+"')", conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Informations successfully Added.");
                while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          //  auto_increment();
        }

        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
           
        }

     

        private void opbilling_MouseClick(object sender, MouseEventArgs e)
        {
            
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
