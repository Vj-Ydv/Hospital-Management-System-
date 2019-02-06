namespace Hospital_management_system
{
    partial class cluster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cluster));
            this.dgvLearningSource = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scatterplotView1 = new Accord.Controls.ScatterplotView();
            this.scatterplotView3 = new Accord.Controls.ScatterplotView();
            this.cbBalanced = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numKMeans = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKMeans)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLearningSource
            // 
            this.dgvLearningSource.BackgroundColor = System.Drawing.Color.White;
            this.dgvLearningSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLearningSource.GridColor = System.Drawing.Color.DimGray;
            this.dgvLearningSource.Location = new System.Drawing.Point(12, 12);
            this.dgvLearningSource.Name = "dgvLearningSource";
            this.dgvLearningSource.Size = new System.Drawing.Size(233, 530);
            this.dgvLearningSource.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.scatterplotView1);
            this.groupBox4.Controls.Add(this.scatterplotView3);
            this.groupBox4.Location = new System.Drawing.Point(251, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1051, 536);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Visualization";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(791, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = ": After clustering";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = ": Before clustering";
            // 
            // scatterplotView1
            // 
            this.scatterplotView1.LinesVisible = false;
            this.scatterplotView1.Location = new System.Drawing.Point(6, 31);
            this.scatterplotView1.Name = "scatterplotView1";
            this.scatterplotView1.ScaleTight = false;
            this.scatterplotView1.Size = new System.Drawing.Size(503, 469);
            this.scatterplotView1.SymbolSize = 7F;
            this.scatterplotView1.TabIndex = 1;
            // 
            // scatterplotView3
            // 
            this.scatterplotView3.LinesVisible = false;
            this.scatterplotView3.Location = new System.Drawing.Point(525, 31);
            this.scatterplotView3.Name = "scatterplotView3";
            this.scatterplotView3.ScaleTight = false;
            this.scatterplotView3.Size = new System.Drawing.Size(504, 469);
            this.scatterplotView3.SymbolSize = 7F;
            this.scatterplotView3.TabIndex = 0;
            // 
            // cbBalanced
            // 
            this.cbBalanced.AutoSize = true;
            this.cbBalanced.Location = new System.Drawing.Point(285, 594);
            this.cbBalanced.Margin = new System.Windows.Forms.Padding(2);
            this.cbBalanced.Name = "cbBalanced";
            this.cbBalanced.Size = new System.Drawing.Size(71, 17);
            this.cbBalanced.TabIndex = 21;
            this.cbBalanced.Text = "Balanced";
            this.cbBalanced.UseVisualStyleBackColor = true;
            this.cbBalanced.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "K:";
            // 
            // numKMeans
            // 
            this.numKMeans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numKMeans.Location = new System.Drawing.Point(285, 557);
            this.numKMeans.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numKMeans.Name = "numKMeans";
            this.numKMeans.Size = new System.Drawing.Size(98, 20);
            this.numKMeans.TabIndex = 20;
            this.numKMeans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numKMeans.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(970, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 39);
            this.button1.TabIndex = 17;
            this.button1.Text = "Generate Clusters";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(738, 609);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(45, 16);
            this.lbStatus.TabIndex = 23;
            this.lbStatus.Text = "Status";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(477, 564);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 39);
            this.button3.TabIndex = 24;
            this.button3.Text = "Load Data";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(499, 609);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 25);
            this.button4.TabIndex = 25;
            this.button4.Text = "Normalize table";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cluster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1302, 661);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.cbBalanced);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numKMeans);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvLearningSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cluster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clustering";
            this.Load += new System.EventHandler(this.cluster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKMeans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLearningSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private Accord.Controls.ScatterplotView scatterplotView1;
        private Accord.Controls.ScatterplotView scatterplotView3;
        private System.Windows.Forms.CheckBox cbBalanced;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKMeans;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

