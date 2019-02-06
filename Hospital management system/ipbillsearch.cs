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
    public partial class ipbillsearch : Form
    {
        public ipbillsearch()
        {
            InitializeComponent();
            
        }
        DataTable dbdataset;
        void load_table()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select* from hospital.billrecord ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ipbillsearch_Load(object sender, EventArgs e)
        {
            load_table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_table();
            label35.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Bill No.")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("BillNo LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }


            else if (comboBox1.Text == "Patient ID")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("PatientID LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "Recorded On")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("RecordedOn LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "Recorded By")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("RecordedBy LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

           

        }

        void calculate_total()
        {
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double x = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                total = total + x;
            }

            label3.Text = total.ToString();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int c = dataGridView1.Rows.Count-1;
                label35.Text = c.ToString();

                calculate_total();
            }
        }
    }
}
