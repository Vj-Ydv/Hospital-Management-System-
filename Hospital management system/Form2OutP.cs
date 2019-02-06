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
    public partial class Form2OutP : Form
    {
        public Form2OutP(string username)
        {
            InitializeComponent();
            timer1.Start();
            FillCombo();
            label23.Text = username;
        }
        
        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "select distinct Field from hospital.doctorinfo; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("Field");
                    Case_txt.Items.Add(sname);


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        void auto_increment()
        {
            String s1 = "SELECT MAX(PatientID) FROM hospital.opinfo";
            int a;
            String constringv1 = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBasev1 = new MySqlConnection(constringv1);
            conDataBasev1.Open();

            MySqlCommand cmdv1 = new MySqlCommand(s1, conDataBasev1);
            MySqlDataReader dr = cmdv1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    ID_txt.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    ID_txt.Text = a.ToString();
                }
            }
        }



       

        private void Form2OutP_Load(object sender, EventArgs e)
        {

            auto_increment();
            DateTime datetime = DateTime.Today;
            this.DOE_txt.Text = datetime.ToString("yyyy-MM-dd");
            //webcam = new WebCam();
            //webcam.InitializeWebCam(ref pictureBox2);
            comboBox4.Text = "New Patient";
            comboBox6.Text = "OutPatient";

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox9.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox9.SelectedIndex = 0;

        }


        void add_opinfo_tablerecord()
        {

            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_imagepath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                string Query = "insert into hospital.opinfo (PatientID,Name,DOB,Age,Gender,Married,Address,ContactNo,EmailId,BloodGroup,ImageUrl,Image)  values('" + ID_txt.Text + "','" + Name_txt.Text + "','" + DOB_txt.Text + "','" + Age_txt.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + textBox2.Text + "','" + Contact_txt.Text + "','" + textBox7.Text + "','" + comboBox5.Text + "','"+imageurl.Text+"',@IMG) ; ";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {


                    conDataBase.Open();

                    cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                    myReader = cmdDataBase.ExecuteReader();
                    //MessageBox.Show("Record successfully Saved");
                    while (myReader.Read())
                    {

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            

        }

        void add_patientinfo_table()
        {


            string constring = "datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "insert into hospital.patientinfo (PatientID,Cases,AppRoomNo,AppWith,TimeOfEntry,DateOfEntry,RecordedBy,Type)  values('" + ID_txt.Text + "','" + Case_txt.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + TOE_txt.Text + "','" + DOE_txt.Text + "','" + label23.Text + "','" + comboBox6.Text + "') ; ";
           // string Query = "insert into hospital.patientinfo (PatientID,Cases)  values('" + ID_txt.Text + "','" + Case_txt.Text + "') ; ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();


                myReader = cmdDataBase.ExecuteReader();
                // MessageBox.Show("Record successfully Saved");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        void adddata_tobloodbank()
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_imagepath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string constring = "datasource=localhost;port=3306;username=root;password=vijay ";
            string Query = "insert into hospital.bloodbank (name,DOB,gender,address,contactno,bloodgroup,emailid,regdate,Image)  values('" + Name_txt.Text + "','" + DOB_txt.Text + "','" +comboBox7.Text + "','" + textBox2.Text + "','" + Contact_txt.Text + "','" + comboBox5.Text + "','" + textBox7.Text + "','" + DOE_txt.Text + "',@IMG) ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();
                //MessageBox.Show("Record successfully Saved");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "New Patient")
            {
                add_opinfo_tablerecord();
                add_patientinfo_table();
                adddata_tobloodbank();
                MessageBox.Show("Record successfully Saved");
            }

            else if(comboBox4.Text=="Old Patient")
            {
                add_patientinfo_table();
                MessageBox.Show("Record successfully Saved");
            }


           // button6.PerformClick();
          //  int a = Convert.ToInt32(ID_txt.Text);
          //  a++;
           // ID_txt.Text = a.ToString();
        }

        void update_patienttype()
        {

            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "update hospital.patientinfo set Type='"+comboBox6.Text+"' where Sn='" + this.label17.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

               
                myReader = cmdDataBase.ExecuteReader();
                
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.imageurl.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            update_patienttype();
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "update hospital.opinfo set Name='" + this.Name_txt.Text + "',DOB='" + this.DOB_txt.Text + "',Age='" + this.Age_txt.Text + "',Gender='" + this.comboBox7.Text + "',Married='" + this.comboBox8.Text + "', ContactNo='" + this.Contact_txt.Text + "',EmailId='" + this.textBox7.Text + "',BloodGroup='"+comboBox5.Text+"',Image=@IMG, ImageUrl='"+imageurl.Text+"' where PatientID='" + this.ID_txt.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Record successfully Updated");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "delete from hospital.opinfo where ID='" + this.ID_txt.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                textBox_imagepath.Text = PicPath;
                pictureBox1.ImageLocation = PicPath;

                string newfilename = PicPath.Replace("\\", "\\\\");
                imageurl.Text = newfilename;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.Time_lbl.Text = dateTime.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3OutP f3 = new Form3OutP();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "OutPatient")
            {
                opbilling ob = new opbilling(AppCh_txt.Text, comboBox3.Text, ID_txt.Text, label23.Text);
                ob.ShowDialog();
                button6.PerformClick();
                int a = Convert.ToInt32(ID_txt.Text);
                a++;
                ID_txt.Text = a.ToString();
            }

            else if(comboBox6.Text=="InPatient")
            {
                ipbillinginfo ipbi = new ipbillinginfo(ID_txt.Text,label23.Text);
                ipbi.ShowDialog();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            String comboval2 = comboBox2.Text;
            this.comboBox2.Text = comboval2;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String comboval3 = comboBox3.Text;
            this.comboBox3.Text = comboval3;
        }

        private void AppDr_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            this.DOB_txt.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            DateTime endDate = DateTime.Today.Date;
            DateTime StartDate = dateTimePicker1.Value;
            var totalDays = (endDate - StartDate).TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            // var totalMonths = Math.Truncate(totalDays / 30);
            // var remainingDays = Math.Truncate((totalDays % 365) % 30);
            Age_txt.Text = totalYears.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AppRn_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_imagepath_TextChanged(object sender, EventArgs e)
        {

        }

        private void Case_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "select * from hospital.doctorinfo where Field='" + Case_txt.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                comboBox3.Items.Clear();


                while (myReader.Read())
                {
                    
                    string sAppRoom = myReader.GetString("Room").ToString();
                    string sAppWith = myReader.GetString("Name");


                    comboBox2.Text = sAppRoom;
                    comboBox3.Items.Add(sAppWith);


                    


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Time_lbl_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            auto_increment();
            Name_txt.Text = "";
            DOB_txt.Text = "";
            Age_txt.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            Contact_txt.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            Case_txt.Text = "";
            DOE_txt.Text = "";
            TOE_txt.Text = "";
            AppCh_txt.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            //comboBox4.Text = "";
          //  comboBox6.Text = "";
            textBox_imagepath.Text = "G:\\visual c#\\Photos\\photo2.jpg";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\photo2.jpg");
        }

        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private void cam_newframe(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Start Webcam")
            {
                cam = new VideoCaptureDevice(webcam[comboBox9.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_newframe);
                cam.Start();
                button7.Text = "Stop";
            }
            else if(button7.Text=="Stop")
            {
                if (cam.IsRunning)
                {
                    cam.Stop();
                }

                String filepath = "F:\\HMS_image" + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                pictureBox1.Image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                textBox_imagepath.Text = filepath;

                string newfilename = filepath.Replace("\\", "\\\\");
                imageurl.Text = newfilename;
                button7.Text = "Start Webcam";
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

       /* private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
           

            String filepath = "F:\\HMS_image" + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            pictureBox1.Image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            textBox_imagepath.Text = filepath;
        }*/

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             
             if (comboBox1.Text == "Patient ID")
             {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                    string Query = "select o.PatientId,o.Name,o.DOB,o.Age,o.Gender,o.Married,o.Address,o.ContactNo,o.EmailId,o.Bloodgroup,o.ImageUrl,p.Cases,p.AppRoomNo,p.AppWith,P.TimeOfEntry,P.DateOfEntry,p.RecordedBy,p.Type,p.Sn,o.Image from hospital.opinfo o inner join hospital.patientinfo p on o.PatientId=p.PatientId where o.PatientID='" + textBox1.Text + "' ; ";
                   // string Query = "select* from hospital.opinfo where PatientID='"+textBox1.Text+"';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {


                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {
                            string sID = myReader.GetInt32("PatientID").ToString();
                            string sname = myReader.GetString("Name");
                            string sDOB = myReader.GetString("DOB");
                            string sAge = myReader.GetInt32("Age").ToString();
                            string sGender = myReader.GetString("Gender");
                            string sMarried = myReader.GetString("Married");
                            string sAddress = myReader.GetString("Address");
                            string sContact_number = myReader.GetString("ContactNo");
                            string sEmailid = myReader.GetString("EmailId");
                            string sBloodgroup = myReader.GetString("BloodGroup");
                            string stype = myReader.GetString("Type");
                            string ssn = myReader.GetString("Sn");
                            /*
                             string sDOE = myReader.GetString("DateOfEntry");
                             string sTOE = myReader.GetString("TimeOfEntry");
                             string sCase = myReader.GetString("Cases");
                             string sAppRoom = myReader.GetString("AppRoom");
                             string sAppWith = myReader.GetString("AppWith");
                             */


                            ID_txt.Text = sID;
                            Name_txt.Text = sname;
                            DOB_txt.Text = sDOB;
                            Age_txt.Text = sAge;
                            comboBox7.Text = sGender;
                            comboBox8.Text = sMarried;
                            textBox2.Text = sAddress;
                            Contact_txt.Text = sContact_number;
                            textBox7.Text = sEmailid;
                            comboBox5.Text = sBloodgroup;
                            comboBox6.Text = stype;
                            label17.Text = ssn;
                            //  DOE_txt.Text = sDOE;
                            // TOE_txt.Text = sTOE;
                            //  Case_txt.Text = sCase;
                            //    comboBox2.Text = sAppRoom;
                            // comboBox3.Text = sAppWith;


                            


                            byte[] imgg = (byte[])(myReader["Image"]);
                        if (imgg == null)
                            pictureBox1.Image = null;
                        else
                        {
                            MemoryStream mstream = new MemoryStream(imgg);
                            pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        }


                            string imageurl = myReader.GetString("ImageUrl");
                            string iu = imageurl.Replace("\\", "\\\\");
                            this.imageurl.Text = iu;

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
             }


           
               else if (comboBox1.Text == "Contact_number")
               {
                string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
                    string Query = "select o.PatientId,o.Name,o.DOB,o.Age,o.Gender,o.Married,o.Address,o.ContactNo,o.EmailId,o.Bloodgroup,o.ImageUrl,p.Cases,p.AppRoomNo,p.AppWith,P.TimeOfEntry,P.DateOfEntry,p.RecordedBy,p.Type,p.Sn,o.Image from hospital.opinfo o inner join hospital.patientinfo p on o.PatientId=p.PatientId where o.ContactNo='" + textBox1.Text + "'  ; ";
                    //string Query = "select* from hospital.opinfo where PatientID='" + textBox1.Text + "'";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;

                try
                {


                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {
                            string sID = myReader.GetInt32("PatientID").ToString();
                            string sname = myReader.GetString("Name");
                            string sDOB = myReader.GetString("DOB");
                            string sAge = myReader.GetInt32("Age").ToString();
                            string sGender = myReader.GetString("Gender");
                            string sMarried = myReader.GetString("Married");
                            string sAddress = myReader.GetString("Address");
                            string sContact_number = myReader.GetString("ContactNo");
                            string sEmailid = myReader.GetString("EmailId");
                            string sBloodgroup = myReader.GetString("BloodGroup");
                            string stype = myReader.GetString("Type");
                            string ssn = myReader.GetString("Sn");
                            /*  string sDOE = myReader.GetString("DateOfEntry");
                              string sTOE = myReader.GetString("TimeOfEntry");
                              string sCase = myReader.GetString("Cases");
                              string sAppRoom = myReader.GetString("AppRoom");
                              string sAppWith = myReader.GetString("AppWith");
                              */


                            ID_txt.Text = sID;
                            Name_txt.Text = sname;
                            DOB_txt.Text = sDOB;
                            Age_txt.Text = sAge;
                            comboBox7.Text = sGender;
                            comboBox8.Text = sMarried;
                            textBox2.Text = sAddress;
                            Contact_txt.Text = sContact_number;
                            textBox7.Text = sEmailid;
                            comboBox5.Text = sBloodgroup;
                            comboBox6.Text = stype;
                            label17.Text = ssn;
                            //  DOE_txt.Text = sDOE;
                            // TOE_txt.Text = sTOE;
                            // Case_txt.Text = sCase;
                            //  comboBox2.Text = sAppRoom;
                            //   comboBox3.Text = sAppWith;





                            byte[] imgg = (byte[])(myReader["Image"]);
                        if (imgg == null)
                            pictureBox1.Image = null;
                        else
                        {
                            MemoryStream mstream = new MemoryStream(imgg);
                            pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        }
                            string imageurl = myReader.GetString("ImageUrl");
                            string iu = imageurl.Replace("\\", "\\\\");
                            this.imageurl.Text = iu;

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
               }


            

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(comboBox6.Text=="OutPatient")
            {
                label12.Visible = true;
                AppCh_txt.Visible =true;
            }
            else 
            {
                label12.Visible = false;
                AppCh_txt.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            

        }

        private void ID_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TOE_txt_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = TOE_txt.Value;
            string sdate = d.ToString("HH:mm");
            TimeToText.Text = sdate;


            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From hospital.appointment where '" + this.TimeToText.Text + "' between appointmentFrom And appointmentUpto And doctor ='" + this.comboBox3.Text + "' And appointmentdate='" + this.DOE_txt.Text + "' ", conDataBase);

            try
            {
                conDataBase.Open();
                MySqlDataReader myReader = cmdDataBase.ExecuteReader();



                Boolean s = myReader.HasRows;
                if (s)
                    comboBox3.ForeColor = Color.Red;
                else
                    comboBox3.ForeColor = Color.Black;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DateTime d = TOE_txt.Value;
            string sdate = d.ToString("HH:mm");
            TimeToText.Text = sdate;


            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From hospital.appointment where '" + this.TimeToText.Text + "' between appointmentFrom And appointmentUpto And doctor ='" + this.comboBox3.Text + "' And appointmentdate='" + this.DOE_txt.Text + "' ", conDataBase);

            try
            {
                conDataBase.Open();
                MySqlDataReader myReader = cmdDataBase.ExecuteReader();



                Boolean s = myReader.HasRows;
                if (s)
                    comboBox3.ForeColor = Color.Red;
                else
                    comboBox3.ForeColor = Color.Black;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
     }

        private void DOE_txt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
