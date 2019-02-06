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
    public partial class pathology : Form
    {
        

        public pathology()
        {
            InitializeComponent();
           
            load_table();
        }

        

       
        DataTable dbdataset;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void patientno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox2.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                byte[] imageBt2 = null;
                FileStream fstream2 = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br2 = new BinaryReader(fstream2);
                imageBt2 = br2.ReadBytes((int)fstream2.Length);

                byte[] imageBt3 = null;
                FileStream fstream3 = new FileStream(this.textBox41.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br3 = new BinaryReader(fstream3);
                imageBt3 = br3.ReadBytes((int)fstream3.Length);

                byte[] imageBt4 = null;
                FileStream fstream4 = new FileStream(this.textBox51.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br4 = new BinaryReader(fstream4);
                imageBt4 = br4.ReadBytes((int)fstream4.Length);

                byte[] imageBt5 = null;
                FileStream fstream5 = new FileStream(this.textBox61.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br5 = new BinaryReader(fstream5);
                imageBt5 = br5.ReadBytes((int)fstream5.Length);

                byte[] imageBt6 = null;
                FileStream fstream6 = new FileStream(this.textBox71.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br6 = new BinaryReader(fstream6);
                imageBt6 = br6.ReadBytes((int)fstream6.Length);


                string constring = " datasource=localhost;port=3306;username=root;password=vijay";
                string Query = "insert into hospital.pathology (PatientID,reportabout,reportabout2,reportabout4,reportabout5,reportabout6,reportabout7,Report,date,image1,image2,image3,image4,image5,image6) values('" + this.patientno.Text + "','" + this.reportabout.Text + "','" + this.reportabout2.Text + "','" + this.reportabout4.Text + "','" + this.reportabout5.Text + "','" + this.reportabout6.Text + "','" + this.reportabout7.Text + "','" + this.reportdesc.Text + "','" + this.date.Text + "',@IMG ,@IMG2,@IMG3,@IMG4,@IMG5,@IMG6);";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                try
                {
                    conDatabase.Open();

                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG2", imageBt2));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG3", imageBt3));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG4", imageBt4));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG5", imageBt5));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG6", imageBt6));

                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Record Added.");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                load_table();
                patientno.Text = "";

                reportabout.Text = "";
                reportabout2.Text = "";
                reportabout4.Text = "";
                reportabout5.Text = "";
                reportabout6.Text = "";
                reportabout7.Text = "";

                reportdesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "delete from hospital.pathology where PatientID= '" + this.patientno.Text + "';";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            load_table();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout.Text = comboBox1.Text;
        }

        void load_table()
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand("Select p.PatientID,o.Name,o.Gender,o.Address,p.date,p.Report,p.Reportabout,p.image1,p.reportabout2,p.image2,p.reportabout4,p.image3,p.reportabout5,p.image4,p.reportabout6,p.image5,p.reportabout7,p.image6 from hospital.opinfo o inner join hospital.pathology p on o.PatientID=p.PatientID;", conDatabase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
                imageColumn1 = (DataGridViewImageColumn)dataGridView1.Columns[7];
                imageColumn1.ImageLayout = DataGridViewImageCellLayout.Stretch;

                DataGridViewImageColumn imageColumn2 = new DataGridViewImageColumn();
                imageColumn2 = (DataGridViewImageColumn)dataGridView1.Columns[9];
                imageColumn2.ImageLayout = DataGridViewImageCellLayout.Stretch;

                DataGridViewImageColumn imageColumn3 = new DataGridViewImageColumn();
                imageColumn3 = (DataGridViewImageColumn)dataGridView1.Columns[11];
                imageColumn3.ImageLayout = DataGridViewImageCellLayout.Stretch;

                DataGridViewImageColumn imageColumn4 = new DataGridViewImageColumn();
                imageColumn4 = (DataGridViewImageColumn)dataGridView1.Columns[13];
                imageColumn4.ImageLayout = DataGridViewImageCellLayout.Stretch;

                DataGridViewImageColumn imageColumn5 = new DataGridViewImageColumn();
                imageColumn5 = (DataGridViewImageColumn)dataGridView1.Columns[15];
                imageColumn5.ImageLayout = DataGridViewImageCellLayout.Stretch;

                DataGridViewImageColumn imageColumn6 = new DataGridViewImageColumn();
                imageColumn6 = (DataGridViewImageColumn)dataGridView1.Columns[17];
                imageColumn6.ImageLayout = DataGridViewImageCellLayout.Stretch;

                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            load_table();
            patientno.Text = "";

            reportabout.Text = "";
            reportabout2.Text = "";
            reportabout4.Text = "";
            reportabout5.Text = "";
            reportabout6.Text = "";
            reportabout7.Text = "";

            textBox2.Text = "G:\\visual c#\\Photos\\upload.jpg";
            textBox3.Text = "G:\\visual c#\\Photos\\upload.jpg";
            textBox41.Text = "G:\\visual c#\\Photos\\upload.jpg";
            textBox51.Text = "G:\\visual c#\\Photos\\upload.jpg";
            textBox61.Text = "G:\\visual c#\\Photos\\upload.jpg";
            textBox71.Text = "G:\\visual c#\\Photos\\upload.jpg";



            reportdesc.Text = "";
            label35.Text = "0";
            pictureBox1.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            pictureBox2.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            pictureBox3.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            pictureBox4.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            pictureBox5.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            pictureBox6.Image = Image.FromFile("G:\\visual c#\\Photos\\upload.jpg");
            //radioButton1 = null;
            //radioButton2 = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
             
                if (comboBox2.Text == "Name")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("Name LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }

                else if (comboBox2.Text == "Date")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("date LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }

                else if (comboBox2.Text == "PatientID")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("PatientID LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    patientno.Text = row.Cells["PatientID"].Value.ToString();

                    reportabout.Text = row.Cells["reportabout"].Value.ToString();
                    reportabout2.Text = row.Cells["reportabout2"].Value.ToString();
                    reportabout4.Text = row.Cells["reportabout4"].Value.ToString();
                    reportabout5.Text = row.Cells["reportabout5"].Value.ToString();
                    reportabout6.Text = row.Cells["reportabout6"].Value.ToString();
                    reportabout7.Text = row.Cells["reportabout7"].Value.ToString();
                    reportdesc.Text = row.Cells["Report"].Value.ToString();
                    date.Text = row.Cells["date"].Value.ToString();


                    //pictureBox1.Text = row.Cells["image1"].Value.ToString();
                    byte[] bytes = (byte[])row.Cells["image1"].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBox1.Image = Image.FromStream(ms);

                    byte[] bytes2 = (byte[])row.Cells["image2"].Value;
                    MemoryStream ms2 = new MemoryStream(bytes2);
                    pictureBox2.Image = Image.FromStream(ms2);

                    byte[] bytes3 = (byte[])row.Cells["image3"].Value;
                    MemoryStream ms3 = new MemoryStream(bytes3);
                    pictureBox3.Image = Image.FromStream(ms3);

                    byte[] bytes4 = (byte[])row.Cells["image4"].Value;
                    MemoryStream ms4 = new MemoryStream(bytes4);
                    pictureBox4.Image = Image.FromStream(ms4);

                    byte[] bytes5 = (byte[])row.Cells["image5"].Value;
                    MemoryStream ms5 = new MemoryStream(bytes5);
                    pictureBox5.Image = Image.FromStream(ms5);

                    byte[] bytes6 = (byte[])row.Cells["image6"].Value;
                    MemoryStream ms6 = new MemoryStream(bytes6);
                    pictureBox6.Image = Image.FromStream(ms6);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void reportabout_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox2.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                byte[] imageBt2 = null;
                FileStream fstream2 = new FileStream(this.textBox3.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br2 = new BinaryReader(fstream2);
                imageBt2 = br2.ReadBytes((int)fstream2.Length);

                byte[] imageBt3 = null;
                FileStream fstream3 = new FileStream(this.textBox41.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br3 = new BinaryReader(fstream3);
                imageBt3 = br3.ReadBytes((int)fstream3.Length);

                byte[] imageBt4 = null;
                FileStream fstream4 = new FileStream(this.textBox51.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br4 = new BinaryReader(fstream4);
                imageBt4 = br4.ReadBytes((int)fstream4.Length);

                byte[] imageBt5 = null;
                FileStream fstream5 = new FileStream(this.textBox61.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br5 = new BinaryReader(fstream5);
                imageBt5 = br5.ReadBytes((int)fstream5.Length);

                byte[] imageBt6 = null;
                FileStream fstream6 = new FileStream(this.textBox71.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br6 = new BinaryReader(fstream6);
                imageBt6 = br6.ReadBytes((int)fstream6.Length);


                string constring = " datasource=localhost;port=3306;username=root;password=vijay";
                string Query = "update hospital.pathology set patientno = '" + this.patientno.Text + "', reportabout = '" + this.reportabout.Text + "', reportabout2 = '" + this.reportabout2.Text + "',reportabout4 = '" + this.reportabout4.Text + "',reportabout5 = '" + this.reportabout5.Text + "',reportabout6 = '" + this.reportabout6.Text + "',reportabout7 = '" + this.reportabout7.Text + "',reportdesc = '" + this.reportdesc.Text + "',date ='" + this.date.Text + "' ,image1 = @IMG ,image2 =  @IMG2,image3 = @IMG3,image4 = @IMG4,image5 = @IMG5,image6 =@IMG6 WHERE patientno = '" + this.patientno.Text + "'; ";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                try
                {
                    conDatabase.Open();

                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG2", imageBt2));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG3", imageBt3));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG4", imageBt4));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG5", imageBt5));
                    cmdDatabase.Parameters.Add(new MySqlParameter("@IMG6", imageBt6));

                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("updated");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                load_table();
                patientno.Text = "";

                reportabout.Text = "";
                reportabout2.Text = "";
                reportabout4.Text = "";
                reportabout5.Text = "";
                reportabout6.Text = "";
                reportabout7.Text = "";

                reportdesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stream mystream;
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((mystream = openfiledialog1.OpenFile()) != null)
                {
                    string strfilename = openfiledialog1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    reportdesc.Text = filetext;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int c = dataGridView1.Rows.Count - 1;
                label35.Text = c.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg1 = new OpenFileDialog();
            dlg1.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                String picPath = dlg1.FileName.ToString();
                textBox2.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg2 = new OpenFileDialog();
            dlg2.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg2.ShowDialog() == DialogResult.OK)
            {
                String picPath1 = dlg2.FileName.ToString();
                textBox3.Text = picPath1;
                pictureBox2.ImageLocation = picPath1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout2.Text = comboBox3.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox1.Image);
            afp.Show();
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout4.Text = comboBox4.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg3 = new OpenFileDialog();
            dlg3.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg3.ShowDialog() == DialogResult.OK)
            {
                String picPath3 = dlg3.FileName.ToString();
                textBox41.Text = picPath3;
                pictureBox3.ImageLocation = picPath3;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout5.Text = comboBox5.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout6.Text = comboBox6.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportabout7.Text = comboBox7.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg4 = new OpenFileDialog();
            dlg4.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg4.ShowDialog() == DialogResult.OK)
            {
                String picPath4 = dlg4.FileName.ToString();
                textBox51.Text = picPath4;
                pictureBox4.ImageLocation = picPath4;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg5 = new OpenFileDialog();
            dlg5.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg5.ShowDialog() == DialogResult.OK)
            {
                String picPath5 = dlg5.FileName.ToString();
                textBox61.Text = picPath5;
                pictureBox5.ImageLocation = picPath5;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg6 = new OpenFileDialog();
            dlg6.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg6.ShowDialog() == DialogResult.OK)
            {
                String picPath6 = dlg6.FileName.ToString();
                textBox71.Text = picPath6;
                pictureBox6.ImageLocation = picPath6;
            }
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox2.Image);
            afp.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox3.Image);
            afp.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox4.Image);
            afp.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox5.Image);
            afp.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            AccrossFormPicture afp = new AccrossFormPicture(pictureBox6.Image);
            afp.Show();
        }
    }
}


