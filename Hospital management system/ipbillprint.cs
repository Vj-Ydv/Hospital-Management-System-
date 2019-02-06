using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
namespace Hospital_management_system
{
    public partial class ipbillprint : Form
    {
        public ipbillprint(string username)
        {
            InitializeComponent();
            user_lbl.Text = username;
        }

        void auto_increment()
        {
            String s1 = "SELECT MAX(BillNo) FROM hospital.billrecord";
            int a;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            conDataBase.Open();

            MySqlCommand cmd = new MySqlCommand(s1, conDataBase);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label35.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    label35.Text = a.ToString();
                }
            }
        }

        void load_patientdetail()
        {
            String spatientid = textBox12.Text;
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            string Query = "select o.PatientId,o.Name,o.DOB,o.Age,o.Gender,o.Married,o.Address,o.ContactNo,o.EmailId,o.Bloodgroup,o.ImageUrl,p.Cases,p.AppRoomNo,p.AppWith,P.TimeOfEntry,P.DateOfEntry,p.RecordedBy,p.Type,p.Sn,o.Image from hospital.opinfo o inner join hospital.patientinfo p on o.PatientId=p.PatientId where o.PatientID='" + textBox12.Text + "' order by(p.DateOfEntry) desc ; ";

            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                if (myReader.Read())
                {
                    String nameVal = myReader.GetString("Name");
                    Pname.Text = nameVal;
                    String genderVal = myReader.GetString("Gender");
                    Gender.Text = genderVal;
                    String dateVal = myReader.GetString("DateOfEntry");
                    Admitted_date.Text = dateVal;
                    String email = myReader.GetString("EmailId");
                    Emailid.Text = email;
                }
                else
                    MessageBox.Show("No records found in the database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        DataTable dbdataset;

        double sum = 0;
        double tax;
        double netamount;
        void calculate_expenses_ofpatient()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                    while (dataGridView1.Rows.Count == 0)
                        continue;
                }

                String spatientid = textBox12.Text;
                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                string Query = "select Particulars, sum(Charges) as Amount from hospital.tempcharge where PatientID='" + textBox12.Text + "' group by(Particulars)  order by(Particulars) desc ; ";

                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

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

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                   
                         double amount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        sum = sum + amount;
                    
                }
                tax = 0.13 * sum;
                netamount = tax + sum;
                /*
                dbdataset.Rows.Add();
                dbdataset.Rows.Add("Taxable Amount", sum.ToString());
                double tax = 0.13 * sum;
                dbdataset.Rows.Add("Tax(13%)", tax.ToString());
                double netamount = tax + sum;
                dbdataset.Rows.Add("Net Amount",netamount.ToString()); */
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        void delete_tempcharge()
        {

            string constring = "datasource=localhost;port=3306;username=root;password=vijay   ";
            string Query = "delete from hospital.tempcharge where PatientID='" + this.textBox12.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
               // MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void ipbillprint_Load(object sender, EventArgs e)
        {
            auto_increment();
            
            DateTime datetime = DateTime.Today;
            this.label11.Text = datetime.ToString("yyyy-MM-dd");

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            // dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

        }

        void add_record()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=vijay";
            MySqlConnection conDataBase = new MySqlConnection(constring);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlCommand cmdDataBase = new MySqlCommand("insert into hospital.billrecord (BillNo,PatientID,Particulars,Charge,RecordedOn,RecordedBy) values('" + this.label35.Text + "','" + this.textBox12.Text + "','" + this.dataGridView1.Rows[i].Cells[0].Value + "','" + this.dataGridView1.Rows[i].Cells[1].Value + "','" + this.label11.Text + "','" + this.user_lbl.Text + "')", conDataBase);
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

           // MessageBox.Show("Successfully Added.");
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = (int)netamount;
                string inwords = NumberToWords(a);

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "LIFEcare Hospital Pvt Ltd" + "\n" + "Kathmandu, Nepal" + "\n" + "PATIENT INVOICE" + "\n";//Header
                printer.SubTitle = "Invoice No.:  " + label35.Text + "\n" + string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy")) + "\n" + "Patient ID: " + textBox12.Text + "\n\n" + "Patient Name: " + Pname.Text + "                                                                                                   " + "Gender: " + Gender.Text + "\n\n" + "Date of Admission: " + Admitted_date.Text + "                                                             " + "Date of Discharge: " + label11.Text + "\n\n\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = false;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Taxable Amount:  Rs " + sum.ToString() + "\n" + "Tax Amount:  Rs " + tax.ToString() + "\n" + "\n" + "Net Total:  Rs " + netamount.ToString() + "\n" + "In Words: " + inwords + " Only." + "\n\n" + "Invoice Prepared by:  " + user_lbl.Text + "\n\n\n\n\n\n\n\n\n";//Footer

                printer.FooterSpacing = 15;
                //Print landscape mode
                printer.printDocument.DefaultPageSettings.Landscape = true;
                printer.PrintDataGridView(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                load_patientdetail();
                calculate_expenses_ofpatient();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_record();
            delete_tempcharge();
            MessageBox.Show("Successfully Added.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ipbillsearch bs = new ipbillsearch();
            bs.ShowDialog();
        }
    }
}
