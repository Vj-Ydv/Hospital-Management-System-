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
    public partial class removeaccount : Form
    {
        public removeaccount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constring="datasource=localhost;port=3306;username=root;password=vijay";
				 MySqlConnection conDataBase=new MySqlConnection(constring);
				MySqlCommand cmdDataBase=new MySqlCommand("delete from hospital.login where username='"+this.textBox1.Text+"'",conDataBase);
				 MySqlDataReader myReader;
				 try{
					 conDataBase.Open();
					 myReader=cmdDataBase.ExecuteReader();
					 while(myReader.Read()){
					 }
					 MessageBox.Show("Account Deleted.");
				 }catch(Exception ex){
					 MessageBox.Show(ex.Message);
				 }
        }
    }
}
