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
    public partial class ipbillinginfo : Form
    {
        public ipbillinginfo(string pid,string username)
        {
            InitializeComponent();
            textBox12.Text = pid;
            label1.Text = username;
        }

        private void ipbillinginfo_Load(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Today;
            this.label11.Text = datetime.ToString("yyyy-MM-dd");

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            // dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            this.dataGridView1.Rows.Add("Medicine");
            this.dataGridView1.Rows.Add("Doctor Fee");
            this.dataGridView1.Rows.Add("Room Charge");
            this.dataGridView1.Rows.Add("Facility Fee");
            this.dataGridView1.Rows.Add("Surgeon Fee");
            this.dataGridView1.Rows.Add("Anaesthetist Fee");
            this.dataGridView1.Rows.Add("Ward Procedures");
            this.dataGridView1.Rows.Add("Pathology Charge");
            this.dataGridView1.Rows.Add("Miscellaneous");


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ipbillsearch ipbs = new ipbillsearch();
            ipbs.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        void add_temprecord()
        {
            try
            {
                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmdDataBase = new MySqlCommand("insert into hospital.tempcharge (PatientID,Particulars,Charges,RecordedOn) values('" + this.textBox12.Text + "','" + this.dataGridView1.Rows[i].Cells[0].Value + "','" + this.dataGridView1.Rows[i].Cells[1].Value + "','" + this.label11.Text + "' );", conDataBase);
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
                    conDataBase.Close();
                }
                MessageBox.Show("Successfully Added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add_temprecord();
        }
    }
}
