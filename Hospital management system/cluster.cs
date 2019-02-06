using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Accord;
using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Math.Distances;
using Accord.Statistics;
using Accord.Statistics.Analysis;
using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Kernels;
using Accord.Statistics.Filters;
using ZedGraph;

using TClustering = Accord.MachineLearning.IMulticlassClassifier<double[], int>;
using TLearning = Accord.MachineLearning.IUnsupervisedLearning<
    Accord.MachineLearning.IMulticlassClassifier<double[], int>, double[], int>;
using MySql.Data.MySqlClient;

namespace Hospital_management_system
{
    public partial class cluster : Form
    {
        TLearning learning;
        TClustering clustering;

        string[] columnNames; // stores the column names for the loaded da

        public cluster()
        {
            InitializeComponent();
            dgvLearningSource.AutoGenerateColumns = true;
        }

        DataTable tableSource;
        void load_table()
        {
            try
            {
                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select quantity,rate,productname from medicalstore.pharmacy;", conDataBase);
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    tableSource = new DataTable();
                    dgvLearningSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLearningSource.RowTemplate.Height = 100;
                    dgvLearningSource.AllowUserToAddRows = false;

                    sda.Fill(tableSource);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = tableSource;
                    dgvLearningSource.DataSource = bSource;


                    sda.Update(tableSource);

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //this.dgvLearningSource.Columns[0].ValueType = typeof(double);
                // this.dgvLearningSource.Columns[1].ValueType = typeof(double);

                //Normalization normalization = new Normalization(tableSource);
                // double mean = normalization["quantity"].Mean;              // 25.55
                // double sdev = normalization["quantity"].StandardDeviation; // 23.29
                // double rmean = normalization["rate"].Mean;              // 25.55
                //double rsdev = normalization["rate"].StandardDeviation; // 23.29

                //DataTable result = normalization.Apply(tableSource);
                //DataGridBox.Show(result);

                double[,] sourceMatrix = tableSource.ToMatrix(out columnNames);

                // Detect the kind of problem loaded.
                if (sourceMatrix.GetLength(1) == 2)
                {
                    MessageBox.Show("Missing class column.");
                }
                else
                {
                    this.dgvLearningSource.DataSource = tableSource;


                    scatterplotView1.DataSource = sourceMatrix;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void CreateScatterplot(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "Normal (Gaussian) Distributions";
        }
        private void cluster_Load(object sender, EventArgs e)
        {
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLearningSource.DataSource == null)
                {
                    MessageBox.Show("Please load some data first.");
                    return;
                }

                // Finishes and save any pending changes to the given data
                dgvLearningSource.EndEdit();



                // Creates a matrix from the entire source data table
                double[,] table = (dgvLearningSource.DataSource as DataTable).ToMatrix(out columnNames);

                // Get only the input vector values (first two columns)
                double[][] inputs = table.GetColumns(0, 1).ToJagged();


                try
                {
                    // Create and run the specified algorithm
                    this.learning = createClustering(inputs);

                    this.clustering = this.learning.Learn(inputs);

                    lbStatus.Text = "Training complete!";
                }
                catch (ConvergenceException)
                {
                    lbStatus.Text = "Convergence could not be attained. " +
                        "The learned clustering might still be usable.";
                }

                createSurface(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createSurface(double[,] table)
        {
            // Get the ranges for each variable (X and Y)
            DoubleRange[] ranges = table.GetRange(0);

            // Generate a Cartesian coordinate system
            double[][] map = Matrix.Mesh(ranges[0], 200, ranges[1], 200);

            // Classify each point in the Cartesian coordinate system
            double[] result = clustering.Decide(map).ToDouble();
            double[,] surface = map.ToMatrix().InsertColumn(result);
           
            scatterplotView3.DataSource = surface;
        }

        private TLearning createClustering(double[][] data)
        {

            if (cbBalanced.Checked)
            {
                return new BalancedKMeans((int)numKMeans.Value)
                {
                    MaxIterations = 1000,
                };
            }

            return new KMeans((int)numKMeans.Value);


            throw new InvalidOperationException("Invalid options");
        }

        public void GetStandardDeviation_of_column1()
        {
            double sumx = 0.0;
            double sumx_sq = 0.0;
            double meanx;
            for (int i = 0; i < dgvLearningSource.Rows.Count; i++)
            {
                double rowx = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[0].Value);

                sumx = sumx + rowx;
            }
            double num = Convert.ToDouble(dgvLearningSource.Rows.Count);
            meanx = sumx / num;
            
            for (int i = 0; i < dgvLearningSource.Rows.Count ; i++)
            {
                double xvalue = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[0].Value);
                sumx_sq = sumx_sq + (xvalue - meanx) * (xvalue - meanx);

            }
            sumx_sq = sumx_sq / num;
            double sdx;
            sdx = Math.Sqrt(sumx_sq);


            for (int i = 0; i < dgvLearningSource.Rows.Count - 1; i++)
            {
                double rowx = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[0].Value);
                double temp= (rowx - meanx) / sdx;
                dgvLearningSource.Rows[i].Cells[0].Value = temp;

                

            }


            

        }

        public void GetStandardDeviation_of_column2()
        {
            double sumy = 0.0;
            double sumy_sq = 0.0;
            double meany;
            for (int i = 0; i < dgvLearningSource.Rows.Count; i++)
            {
                double rowy = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[1].Value);

                sumy = sumy + rowy;
            }
            double num = Convert.ToDouble(dgvLearningSource.Rows.Count);
            meany = sumy / num;
           
            for (int i = 0; i < dgvLearningSource.Rows.Count; i++)
            {
                double xvalue = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[1].Value);
                sumy_sq = sumy_sq + (xvalue - meany) * (xvalue - meany);

            }
            sumy_sq = sumy_sq / num;
            double sdy;
            sdy = Math.Sqrt(sumy_sq);
            for (int i = 0; i < dgvLearningSource.Rows.Count - 1; i++)
            {
                double rowy = Convert.ToDouble(dgvLearningSource.Rows[i].Cells[1].Value);
                double temp = (rowy - meany) / sdy;
                dgvLearningSource.Rows[i].Cells[1].Value = temp;
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSource bSource = new BindingSource();

                try
                {
                    String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                    MySqlConnection conDataBase = new MySqlConnection(constring);
                    // MySqlCommand cmdDataBase = new MySqlCommand("select Male,Female,Year from test.tab;", conDataBase);
                    MySqlCommand cmdDataBase = new MySqlCommand("select sum(case when t.Gender='Male' then 1 else 0 end) as Male,sum(case when t.Gender='Female' then 1 else 0 end) as Female,year(t.DateOfEntry) as Year from (select o.PatientID, o.Age, o.Gender,p.Cases,P.DateOfEntry from hospital.opinfo o inner join hospital.patientinfo p on o.PatientID = p.PatientID ) as t group by Year ORDER BY Year; ", conDataBase);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    try
                    {

                        sda.SelectCommand = cmdDataBase;
                        tableSource = new DataTable();
                        // dgvLearningSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvLearningSource.RowTemplate.Height = 100;
                        //dgvLearningSource.AllowUserToAddRows = false;

                        sda.Fill(tableSource);



                        bSource.DataSource = tableSource;
                        dgvLearningSource.DataSource = bSource;


                        sda.Update(tableSource);

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //foreach (DataGridViewColumn column in this.dgvLearningSource.Columns)
                    // {
                    //column.ValueType = typeof(double);
                    // }

                    this.dgvLearningSource.Columns[0].ValueType = typeof(double);
                    this.dgvLearningSource.Columns[1].ValueType = typeof(double);


                    GetStandardDeviation_of_column1();
                    GetStandardDeviation_of_column2();







                    bSource.ResetBindings(true);
                    tableSource.AcceptChanges();
                    tableSource.EndLoadData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                double[,] sourceMatrix = tableSource.ToMatrix(out columnNames);



                // Detect the kind of problem loaded.
                if (sourceMatrix.GetLength(1) == 2)
                {


                    MessageBox.Show("Missing class column.");

                }

                else
                {

                    this.dgvLearningSource.DataSource = tableSource;
                    scatterplotView1.DataSource = sourceMatrix;


                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   




        private void button4_Click(object sender, EventArgs e)
        {
            /*
            // Create the aforementioned sample table
            DataTable table = new DataTable("Sample data");
            table.Columns.Add("Age", typeof(double));
            table.Columns.Add("Label", typeof(double));

            //            age   label
            table.Rows.Add(10, "70");
            table.Rows.Add(07, "50");
            table.Rows.Add(04, "20");
            table.Rows.Add(21, "30");
            table.Rows.Add(27, "10");
            table.Rows.Add(12, "30");
            table.Rows.Add(79, "40");
            table.Rows.Add(40, "50");
            table.Rows.Add(30, "30");

            // The filter will ignore non-real (continuous) data
            Normalization normalization = new Normalization(table);

            double mean = normalization["Age"].Mean;              // 25.55
            double sdev = normalization["Age"].StandardDeviation; // 23.29
            double lmean = normalization["label"].Mean;              // 25.55
            double lsdev = normalization["label"].StandardDeviation; // 23.29
           
            // Now we can process another table at once:
            DataTable result = normalization.Apply(table);

            // The result will be a table with the same columns, but
            // in which any column named "Age" will have been normalized
            // using the previously detected mean and standard deviation:

            DataGridBox.Show(result);


            double[,] sourceMatrix = result.ToMatrix(out columnNames);

            // Detect the kind of problem loaded.

            if (sourceMatrix.GetLength(1) == 2)
            {
                MessageBox.Show("Missing class column.");
            }
            else
            {

                 this.dgvLearningSource.DataSource = result;
                 scatterplotView1.DataSource = sourceMatrix;

            }*/





        }

        private void button5_Click(object sender, EventArgs e)
        {
            



        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}


