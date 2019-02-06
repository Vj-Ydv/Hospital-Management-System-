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
    public partial class roominfo : Form
    {
        public roominfo()
        {
            InitializeComponent();
            load_table();
        }
        DataTable dbdataset;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void load_table()
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand("Select * from hospital.roominfo;", conDatabase);
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
        private void button1_Click(object sender, EventArgs e)
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "insert into hospital.roominfo (roomno, roomname , no_of_beds,charge,roomtype,remarks) values('" + this.roomno.Text + "','" + this.roomname.Text + "','" + this.no_of_beds.Text + "','" + this.charge.Text + "','" + this.roomtype.Text + "','" + this.remarks.Text + "');";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = String.Format("roomno LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void properties_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                roomno.Text = row.Cells["roomno"].Value.ToString();
                roomname.Text = row.Cells["roomname"].Value.ToString();
                roomtype.Text = row.Cells["roomtype"].Value.ToString();
                no_of_beds.Text = row.Cells["no_of_beds"].Value.ToString();
                charge.Text = row.Cells["charge"].Value.ToString();
                //sex.Text=row.Cells["sex"].Value.ToString();
                remarks.Text = row.Cells["remarks"].Value.ToString();
                //appointmentdate.Text = row.Cells["appointmentdate"].Value.ToString();
                //date.Text = row.Cells["date"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f7 = new Form6();
            f7.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomname.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomtype.Text = comboBox2.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "delete from hospital.roominfo where roomno='" + this.roomno.Text + "';";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("deleted");
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
            string constring = " datasource=localhost;port=3306;username=root;password=vijay";
            string Query = "update hospital.roominfo set roomno='" + this.roomno.Text + "', roomname='" + this.roomname.Text + "' , no_of_beds='" + this.no_of_beds.Text + "',charge='" + this.charge.Text + "', roomtype='" + this.roomtype.Text + "', remarks='" + this.remarks.Text + "' where roomno='" + this.roomno.Text + "';";
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

        private void roomtype_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
