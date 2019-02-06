// Accord.NET Sample Applications
// http://accord-framework.net
//
// Copyright © 2009-2017, César Souza
// All rights reserved. 3-BSD License:
//
//   Redistribution and use in source and binary forms, with or without
//   modification, are permitted provided that the following conditions are met:
//
//      * Redistributions of source code must retain the above copyright
//        notice, this list of conditions and the following disclaimer.
//
//      * Redistributions in binary form must reproduce the above copyright
//        notice, this list of conditions and the following disclaimer in the
//        documentation and/or other materials provided with the distribution.
//
//      * Neither the name of the Accord.NET Framework authors nor the
//        names of its contributors may be used to endorse or promote products
//        derived from this software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
//  DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//  LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//  ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Accord.Controls;
using Accord.IO;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Models.Regression.Linear;
using Components;
using MySql.Data.MySqlClient;

namespace Hospital_management_system
{

    public partial class MainForm : Form
    {

        private PartialLeastSquaresAnalysis pls;
        private DescriptiveAnalysis sda;

        private MultivariateLinearRegression regression;

        string[] inputColumnNames;
        string[] outputColumnNames;
        double[][] inputs;
        double[][] outputs;



        public MainForm()
        {
            InitializeComponent();

            dgvAnalysisSource.AutoGenerateColumns = true;
           

            //openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Resources");
        }

        private void DataAnalyzer_Load(object sender, EventArgs e)
        {
            Array methods = Enum.GetValues(typeof(AnalysisMethod));
            Array algorithms = Enum.GetValues(typeof(PartialLeastSquaresAlgorithm));

            this.cbMethod.DataSource = methods;
            this.cbAlgorithm.DataSource = algorithms;
        }


        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnalysisSource.DataSource == null)
                {
                    MessageBox.Show("Please load some data first.");
                    return;
                }

                // Finishes and save any pending changes to the given data
                dgvAnalysisSource.EndEdit();
                DataTable table = dgvAnalysisSource.DataSource as DataTable;

                // Creates a matrix from the source data table
                double[][] sourceMatrix = table.ToJagged(out inputColumnNames);

                // Creates the Simple Descriptive Analysis of the given source
                sda = new DescriptiveAnalysis(inputColumnNames).Learn(sourceMatrix);

                // Populates statistics overview tab with analysis data
                dgvDistributionMeasures.DataSource = sda.Measures;


                // Extract variables
                List<string> inputNames = new List<string>();
                foreach (string name in clbInput.CheckedItems)
                    inputNames.Add(name);
                this.inputColumnNames = inputNames.ToArray();

                List<string> outputNames = new List<string>();
                foreach (string name in clbOutput.CheckedItems)
                    outputNames.Add(name);
                this.outputColumnNames = outputNames.ToArray();

                DataTable inputTable = table.DefaultView.ToTable(false, inputColumnNames);
                DataTable outputTable = table.DefaultView.ToTable(false, outputColumnNames);

                this.inputs = inputTable.ToJagged();
                this.outputs = outputTable.ToJagged();



                // Creates the Partial Least Squares of the given source
                pls = new PartialLeastSquaresAnalysis()
                {
                    Method = (AnalysisMethod)cbMethod.SelectedValue,
                    Algorithm = (PartialLeastSquaresAlgorithm)cbAlgorithm.SelectedValue
                };


                // Computes the Partial Least Squares
                MultivariateLinearRegression classifier = pls.Learn(inputs, outputs);

                dgvAnalysisLoadingsInput.DataSource = new ArrayDataView(pls.Predictors.FactorMatrix);
                 dgvAnalysisLoadingsOutput.DataSource = new ArrayDataView(pls.Dependents.FactorMatrix);

                this.regression = pls.CreateRegression();
                dgvRegressionCoefficients.DataSource = new ArrayDataView(regression.Weights, outputColumnNames);
                dgvRegressionIntercept.DataSource = new ArrayDataView(regression.Intercepts, outputColumnNames);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       







        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string extension = Path.GetExtension(filename);
                if (extension == ".xls" || extension == ".xlsx")
                {
                    ExcelReader db = new ExcelReader(filename, true, false);
                    TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

                    if (t.ShowDialog(this) == DialogResult.OK)
                    {
                        DataTable table = db.GetWorksheet(t.Selection);
                        this.dgvAnalysisSource.DataSource = table;

                        clbInput.Items.Clear();
                        clbOutput.Items.Clear();

                        foreach (DataColumn col in table.Columns)
                        {
                            clbInput.Items.Add(col.ColumnName);
                            clbOutput.Items.Add(col.ColumnName);
                        }
                    }
                }
            }

           






           


        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDistributionMeasures.CurrentRow != null)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvDistributionMeasures.CurrentRow;
                    DescriptiveMeasures measures = (DescriptiveMeasures)row.DataBoundItem;
                  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }



        DataTable tableSource;
        private void button1_Click(object sender, EventArgs e)
        {
           
            BindingSource bSource = new BindingSource();
            
            try
            {
                String constring = "datasource=localhost;port=3306;username=root;password=vijay";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand("select Male,Female,Year from hospital.tab;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                try
                {

                    sda.SelectCommand = cmdDataBase;
                    tableSource = new DataTable();
                    // dgvLearningSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvAnalysisSource.RowTemplate.Height = 100;
                    //dgvLearningSource.AllowUserToAddRows = false;

                    sda.Fill(tableSource);



                    bSource.DataSource = tableSource;
                    dgvAnalysisSource.DataSource = bSource;


                    sda.Update(tableSource);

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               

                this.dgvAnalysisSource.Columns[0].ValueType = typeof(double);
                this.dgvAnalysisSource.Columns[1].ValueType = typeof(double);

                
                this.dgvAnalysisSource.DataSource = tableSource;
                clbInput.Items.Clear();
                clbOutput.Items.Clear();

                foreach (DataColumn col in tableSource.Columns)
                {
                    clbInput.Items.Add(col.ColumnName);
                    clbOutput.Items.Add(col.ColumnName);
                }









                bSource.ResetBindings(true);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double fvalue = Convert.ToDouble(textBox1.Text);
                    double coeff = Convert.ToDouble(dgvRegressionCoefficients.Rows[0].Cells[0].Value);
                    double intercept = Convert.ToDouble(dgvRegressionIntercept.Rows[0].Cells[0].Value);
                    double result;
                    result = fvalue * coeff + intercept;
                    int final = (int)result;
                    label4.Text = final.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}