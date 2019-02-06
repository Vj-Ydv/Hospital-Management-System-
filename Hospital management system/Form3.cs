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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              String constring="datasource=localhost;port=3306;username=root;password=vijay";
				 MySqlConnection conDataBase=new MySqlConnection(constring);
				MySqlCommand cmdDataBase=new MySqlCommand("select * from hospital.login where username='"+this.textBox1.Text+"' and password='"+this.textBox2.Text+"';",conDataBase);
				 MySqlDataReader myReader;
				 try{
					 conDataBase.Open();
					 myReader=cmdDataBase.ExecuteReader();
					 int count=0;
					 while(myReader.Read()){
						 count=count+1;
					 }
					 if(count==1){
						 MessageBox.Show("YOU ARE AN AUTHORIZED USER...ACCESS GRANTED.");
                          this.Hide();
                         Form2 f2 = new Form2(textBox1.Text);
                         f2.ShowDialog();
                         this.textBox1.Text = "";
                         this.textBox2.Text = "";
						 
						
					 }
					 else if(count>1){
						  MessageBox.Show("DUPLICATE USERNAME AND PASSWORD...ACCESS DENIED.");
					 }
					 else{
						  MessageBox.Show("YOU SEEM TO BE AN UNAUTHORIZED USER...ACCESS DENIED.");
					 }

				 }catch(Exception ex){
					 MessageBox.Show(ex.Message);
				 }
				 
				
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
