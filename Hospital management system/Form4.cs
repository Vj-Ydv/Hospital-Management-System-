using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_management_system
{
    public partial class appointment : Form
    {
        public appointment()
        {
            InitializeComponent();
            load_table();
            fillcombobox();
        }
        DataTable dbdataset;

        void fillcombobox()
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
                    cases.Items.Add(sname);


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = appointmentFrom.Value;
            string sdate = d.ToString("HH:mm");
            textBox3.Text = sdate;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From hospital.appointment where '" + this.textBox3.Text + "' between appointmentFrom And appointmentUpto And doctor ='" + this.doctor.Text + "' And appointmentdate='" + this.appointmentdate.Text + "' ", conDataBase);

            try
            {
                conDataBase.Open();
                MySqlDataReader myReader = cmdDataBase.ExecuteReader();



                Boolean s = myReader.HasRows;
                if (s)
                    doctor.ForeColor = Color.Red;
                else
                    doctor.ForeColor = Color.Black;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = " datasource=localhost;port=3306;username=root;password=vijay";
                string Query = "update hospital.appointment set sn='" + this.sn.Text + "',name='" + this.name.Text + "',mobileno='" + this.mobileno.Text + "',doctor='" + this.doctor.Text + "',cases='" + this.cases + "',date='" + this.date.Text + "',appointmentdate='" + this.appointmentdate.Text + "'where sn='" + this.sn.Text + "' ;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Updated");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = " datasource=localhost;port=3306;username=root;password=vijay";
                string Query = "delete from hospital.appointment where sn= '" + this.sn.Text + "';";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                
                if (comboBox3.Text == "name")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("name LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
                else if (comboBox3.Text == "mobileno")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("mobileno LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
                else if (comboBox3.Text == "doctor")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("doctor LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
                else if (comboBox3.Text == "department")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("department LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
                else if (comboBox3.Text == "date")
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("date LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
                else
                {
                    DataView dv = new DataView(dbdataset);
                    dv.RowFilter = String.Format("appointmentdate LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = dv;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void load_table()
        {
            try
            {
                string constring = " datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand("Select * from hospital.appointment;", conDatabase);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dbdataset;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dbdataset);

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "select * from hospital.doctorinfo where Field='" + cases.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                doctor.Items.Clear();


                while (myReader.Read())
                {

                    //string sAppRoom = myReader.GetString("Room").ToString();
                    string sAppWith = myReader.GetString("Name");
                    string sAppRoom = myReader.GetString("Room");



                    doctor.Items.Add(sAppWith);
                    AppointmentRoom.Text = sAppRoom;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime d = appointmentFrom.Value;
            string sdate = d.ToString("HH:mm");
            textBox3.Text = sdate;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From hospital.appointment where '" + this.textBox3.Text + "' between appointmentFrom And appointmentUpto And doctor ='" + this.doctor.Text + "' And appointmentdate='" + this.appointmentdate.Text + "' ", conDataBase);

            try
            {
                conDataBase.Open();
                MySqlDataReader myReader = cmdDataBase.ExecuteReader();



                Boolean s = myReader.HasRows;
                if (s)
                    doctor.ForeColor = Color.Red;
                else
                    doctor.ForeColor = Color.Black;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "insert into hospital.appointment (sn, name, mobileno, doctor,date,appointmentdate) values('" + this.sn.Text + "','" + this.name.Text + "','" + this.mobileno.Text + "','" + this.doctor.Text + "','" + this.date.Text + "','" + this.appointmentdate.Text + "');";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("saved");
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void doctor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void mobileno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int c = dataGridView1.Rows.Count-1;
                label35.Text = c.ToString();
            }
        }

        private void cases_TextChanged(object sender, EventArgs e)
        {

        }

        private void appointmentFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime d = appointmentFrom.Value;
            string sdate = d.ToString("HH:mm");
            textBox3.Text = sdate;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * From hospital.appointment where '" + this.textBox3.Text + "' between appointmentFrom And appointmentUpto And doctor ='" + this.doctor.Text + "' And appointmentdate='" + this.appointmentdate.Text + "' ", conDataBase);

            try
            {
                conDataBase.Open();
                MySqlDataReader myReader = cmdDataBase.ExecuteReader();




                Boolean s = myReader.HasRows;
                if (s)
                    doctor.ForeColor = Color.Red;
                else
                    doctor.ForeColor = Color.Black;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void appointmentUpto_ValueChanged(object sender, EventArgs e)
        {

            DateTime d = appointmentUpto.Value;
            string sdate = d.ToString("HH:mm");
            textBox4.Text = sdate;
        }
    }
}
