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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            load_table();
        }
        DataTable dbdataset;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            roominfo f6 = new roominfo();
            f6.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = String.Format("roomno LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
