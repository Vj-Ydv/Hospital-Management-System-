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
using System.Windows.Forms.DataVisualization.Charting;

namespace Hospital_management_system
{
    public partial class Form3OutP : Form
    {
        public Form3OutP()
        {
            InitializeComponent();
            load_table();
        }

        DataTable dbdataset;
        void load_table()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select o.PatientID,o.Name,o.DOB,o.Age,o.Gender,o.Married,o.Address,o.ContactNo,o.EmailId,o.Bloodgroup,p.Cases,p.AppRoomNo,p.AppWith,P.TimeOfEntry,P.DateOfEntry,p.RecordedBy,p.Type,o.Image from hospital.opinfo o inner join hospital.patientinfo p on o.PatientId=p.PatientId;", conDataBase);
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
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[17];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3OutP_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cases")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Cases LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }


             if (comboBox1.Text == "Name")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Name LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "Contact_number")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("ContactNo LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "AppWith")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("AppWith LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "AppRoomNo")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("AppRoomNo LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "DateOfEntry")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("DateOfEntry LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_table();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int c = dataGridView1.Rows.Count;
                label35.Text = c.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        void load_chart1()
        {

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
           

           // this.chart1.Series["Quantity"]["PieLabelStyle"] = "Disabled";
            //this.chart1.Titles.Add("Product vs Quantity");
            //chart1.Series["Quantity"].SmartLabelStyle.Enabled = true;

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                this.chart1.Series["Number_of_cases"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value);
                //this.chart1.Series["Rate"].Points.AddXY(dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[3].Value);
                while (dataGridView1.Rows.Count == 0)
                    continue;

            }
           
           // this.chart1.DataManipulator.Sort(PointSortOrder.Ascending, chart1.Series["Number"]);
        }

        void load_chartforgender()
        {

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                //string val = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
               
                    this.chart2.Series["Male"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value);
                    this.chart2.Series["Female"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[2].Value);
                    
                
                
            }

           
        }

        void separate_gender()
        {
            for(int i=0;i<dataGridView1.Rows.Count-1;i++)
            {


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                if (comboBox2.Text == "Monthly" && comboBox3.Text == "Cases")
                {
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select monthname(t.DateOfEntry) as Month, count(t.Cases) as Number from (select o.PatientID, o.Age, o.Gender,p.Cases,P.DateOfEntry from hospital.opinfo o inner join hospital.patientinfo p on o.PatientID = p.PatientID where p.DateOfEntry between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') as t group by Month ORDER BY FIELD(month,'January','February','March','April','May','June','July','August','September','October','November','December'); ", conDataBase);
                    conDataBase.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;

                    sda.Update(dbdataset);

                    conDataBase.Close();

                    chart1.Visible = true;
                    chart2.Visible = false;
                   // chart1.Series["Number"].ChartType = SeriesChartType.Column;
                    //this.chart1.Series["Number"].LegendText = "Number";
                    load_chart1();

                }

                else if(comboBox2.Text=="Year" && comboBox3.Text == "Cases")
                {

                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select year(t.DateOfEntry) as Year, count(t.Cases) as Number from (select o.PatientID, o.Age, o.Gender,p.Cases,P.DateOfEntry from hospital.opinfo o inner join hospital.patientinfo p on o.PatientID = p.PatientID where p.DateOfEntry between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') as t group by Year ORDER BY Year; ", conDataBase);
                    conDataBase.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;

                    sda.Update(dbdataset);

                    conDataBase.Close();

                    chart1.Visible = true;
                    chart2.Visible = false;
                    //chart1.Series["Number"].ChartType = SeriesChartType.Column;
                    //this.chart1.Series["Number"].LegendText = "Number";
                    load_chart1();

                }
               else if (comboBox2.Text == "Monthly" && comboBox3.Text == "Gender")
                {
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select monthname(t.DateOfEntry) as Month, sum(case when t.Gender='Male' then 1 else 0 end) as Male,sum(case when t.Gender='Female' then 1 else 0 end) as Female from (select o.PatientID, o.Age, o.Gender,p.Cases,P.DateOfEntry from hospital.opinfo o inner join hospital.patientinfo p on o.PatientID = p.PatientID where p.DateOfEntry between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') as t group by Month ORDER BY FIELD(month,'January','February','March','April','May','June','July','August','September','October','November','December'); ", conDataBase);
                    conDataBase.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;

                    sda.Update(dbdataset);

                    conDataBase.Close();

                    chart1.Visible = false;
                    chart2.Visible = true;
                    
                    load_chartforgender();

                }

                else if (comboBox2.Text == "Year" && comboBox3.Text == "Gender")
                {

                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    MySqlCommand cmdDataBase = new MySqlCommand("select year(t.DateOfEntry) as Year, sum(case when t.Gender='Male' then 1 else 0 end) as Male,sum(case when t.Gender='Female' then 1 else 0 end) as Female from (select o.PatientID, o.Age, o.Gender,p.Cases,P.DateOfEntry from hospital.opinfo o inner join hospital.patientinfo p on o.PatientID = p.PatientID where p.DateOfEntry between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') as t group by Year ORDER BY Year; ", conDataBase);
                    conDataBase.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;

                    sda.Update(dbdataset);

                    conDataBase.Close();

                    chart1.Visible = false;
                    chart2.Visible = true;
                    
                    load_chartforgender();

                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }



        private void chart1_DoubleClick_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void chart2_DoubleClick(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            cluster cs = new cluster();
            cs.Show();
        }
    }
}

