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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void restoredata()
        {
            string conn = "server=localhost;user=root;password=vijay;database=medicalstore";
            string file = "G:\\Visual Studio\\MySQL Backup\\hospital.sql";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = con;
                        con.Open();
                        mb.ImportFromFile(file);
                        con.Close();
                    }
                }
            }
        }


        void show_notifyicon()
        {
            notifyIcon1.Icon = Properties.Resources.info1;
            notifyIcon1.BalloonTipTitle = "System Restoration process";
            notifyIcon1.BalloonTipText = "Please wait while system is restoring the backup files.";
            notifyIcon1.ShowBalloonTip(1000);

        }

        private void next_Click(object sender, EventArgs e)
        {

            if (checkBox1.CheckState == CheckState.Checked)
            {
                show_notifyicon();
               
                restoredata();
            }

            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vizayyadav.blogspot.com/");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
