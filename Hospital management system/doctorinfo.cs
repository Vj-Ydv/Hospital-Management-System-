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
    public partial class doctorinfo : Form
    {
        public doctorinfo()
        {
            InitializeComponent();
            load_table();
           
        }
              DataTable dbdataset;
              void load_table()
              {
                  String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                  MySqlConnection conDataBase = new MySqlConnection(constring);
                  MySqlCommand cmdDataBase = new MySqlCommand("select* from hospital.doctorinfo ;", conDataBase);
                  try
                  {
                      MySqlDataAdapter sda = new MySqlDataAdapter();
                      sda.SelectCommand = cmdDataBase;
                      dbdataset = new DataTable();
                      // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                      dataGridView1.RowTemplate.Height = 100;
                      dataGridView1.AllowUserToAddRows = false;

                      sda.Fill(dbdataset);
                      BindingSource bSource = new BindingSource();

                      bSource.DataSource = dbdataset;
                      dataGridView1.DataSource = bSource;
                       // dataGridView1.Columns["Image"].Visible = false;
                     DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                     imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[7];
                     imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                      sda.Update(dbdataset);
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }
        void auto_increment()
        {
            String s1 = "SELECT MAX(ID) FROM hospital.doctorinfo";
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
                    textBox1.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
            }
        }

        private void doctorinfo_Load(object sender, EventArgs e)
        {
            auto_increment();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String picPath = dlg.FileName.ToString();
                textBox9.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox9.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("insert into hospital.doctorinfo (Name,Qualification,Field,Address,Contactno,Room,Image) values('" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "',@IMG )", conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Record successfully added.");
                while (myReader.Read())
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
            int a = Convert.ToInt32(textBox1.Text);
            a++;
            textBox1.Text = a.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "G:\\visual c#\\Photos\\photo2.jpg";
            textBox10.Text = "";
           pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\photo2.jpg");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            auto_increment();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "G:\\visual c#\\Photos\\photo2.jpg";
            textBox10.Text = "";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\photo2.jpg");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "update hospital.doctorinfo set ID ='" + this.textBox1.Text + "',Name='" + this.textBox2.Text + "',Qualification='" + this.textBox3.Text + "',Field='" + this.textBox4.Text + "',Address='" + this.textBox5.Text + "',Contactno='" + this.textBox6.Text + "', Room='" + this.textBox7.Text + "', Image='" + this.textBox9.Text + "' where ID='" + this.textBox1.Text + "'; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
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
            
            load_table();
            button4.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.Text == "Doctor ID")
                {
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("delete from hospital.doctorinfo where ID='" + this.textBox8.Text + "'", conDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        while (myReader.Read())
                        {
                        }
                        MessageBox.Show(" Doctor's Informations successfully Deleted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                  
                }
                else if (comboBox1.Text == "Contact no.")
                {
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("delete from hospital.doctorinfo where contactno='" + this.textBox8.Text + "'", conDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        while (myReader.Read())
                        {
                        }
                        MessageBox.Show("Doctor's Informations successfully Deleted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                load_table();
                button4.PerformClick();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (comboBox2.Text == "Doctor ID")
                {
                    String sdoctorid = textBox10.Text;
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select * from hospital.doctorinfo where ID ='" + sdoctorid + "';", conDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        if (myReader.Read())
                        {
                            String patientidVal = myReader.GetString("ID");
                            textBox1.Text = patientidVal;
                            String nameVal = myReader.GetString("Name");
                            textBox2.Text = nameVal;
                            String dobVal = myReader.GetString("Qualification");
                            textBox3.Text = dobVal;
                            String ageVal = myReader.GetString("Field");
                            textBox4.Text = ageVal;
                            String genderVal = myReader.GetString("Address");
                            textBox5.Text = genderVal;
                            String addressVal = myReader.GetString("Contactno");
                            textBox6.Text = addressVal;
                            String contactnoVal = myReader.GetString("Room");
                            textBox7.Text = contactnoVal;
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
                else if (comboBox2.Text == "Contact no.")
                {
                    String scontactno = textBox10.Text;
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select * from hospital.doctorinfo where Contactno ='" + scontactno + "';", conDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        if (myReader.Read())
                        {
                            String patientidVal = myReader.GetString("ID");
                            textBox1.Text = patientidVal;
                            String nameVal = myReader.GetString("Name");
                            textBox2.Text = nameVal;
                            String dobVal = myReader.GetString("Qualification");
                            textBox3.Text = dobVal;
                            String ageVal = myReader.GetString("Field");
                            textBox4.Text = ageVal;
                            String genderVal = myReader.GetString("Address");
                            textBox5.Text = genderVal;
                            String addressVal = myReader.GetString("Contactno");
                            textBox6.Text = addressVal;
                            String contactnoVal = myReader.GetString("Room");
                            textBox7.Text = contactnoVal;
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
                else if (comboBox2.Text == "Doctor's Name")
                {
                    String sdoctorname = textBox10.Text;
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select * from hospital.doctorinfo where Name ='" + sdoctorname + "';", conDataBase);
                    MySqlDataReader myReader;
                    try
                    {
                        conDataBase.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        if (myReader.Read())
                        {
                            String patientidVal = myReader.GetString("ID");
                            textBox1.Text = patientidVal;
                            String nameVal = myReader.GetString("Name");
                            textBox2.Text = nameVal;
                            String dobVal = myReader.GetString("Qualification");
                            textBox3.Text = dobVal;
                            String ageVal = myReader.GetString("Field");
                            textBox4.Text = ageVal;
                            String genderVal = myReader.GetString("Address");
                            textBox5.Text = genderVal;
                            String addressVal = myReader.GetString("Contactno");
                            textBox6.Text = addressVal;
                            String contactnoVal = myReader.GetString("Room");
                            textBox7.Text = contactnoVal;
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
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            load_table();
           

             if (comboBox2.Text == "Doctor's Name")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Name LIKE '%{0}%'", textBox10.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox2.Text == "Contact no.")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Contactno LIKE '%{0}%'", textBox10.Text);
                dataGridView1.DataSource = DV;
            }

        }
    }
}
