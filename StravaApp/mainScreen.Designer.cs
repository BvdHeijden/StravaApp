namespace StravaApp
{
    partial class mainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainScreen));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.goalData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalData)).BeginInit();
            this.SuspendLayout();
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(12, 9);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(35, 13);
            this.statusText.TabIndex = 1;
            this.statusText.Text = "status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(15, 149);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 4;
            this.checkButton.Text = "check connection";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(420, 35);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.MediumBlue;
            series6.Font = new System.Drawing.Font("MS Office Symbol Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Label = "#VAL";
            series6.LabelToolTip = "#VAL";
            series6.Legend = "Legend1";
            series6.Name = "2015";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Red;
            series7.Font = new System.Drawing.Font("MS Office Symbol Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.Label = "#VAL";
            series7.LabelToolTip = "#VAL";
            series7.Legend = "Legend1";
            series7.Name = "2016";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Font = new System.Drawing.Font("MS Office Symbol Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series8.Label = "#VAL";
            series8.LabelToolTip = "#VAL";
            series8.Legend = "Legend1";
            series8.Name = "2017";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Color = System.Drawing.Color.Gray;
            series9.Font = new System.Drawing.Font("MS Office Symbol Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series9.Label = "#VAL";
            series9.LabelToolTip = "#VAL";
            series9.Legend = "Legend1";
            series9.Name = "2018 Goal";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Color = System.Drawing.Color.Gold;
            series10.Font = new System.Drawing.Font("MS Office Symbol Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series10.Label = "#VAL";
            series10.LabelForeColor = System.Drawing.Color.Gold;
            series10.LabelToolTip = "#VAL";
            series10.Legend = "Legend1";
            series10.Name = "2018";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(1042, 517);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // goalData
            // 
            this.goalData.AllowUserToAddRows = false;
            this.goalData.AllowUserToDeleteRows = false;
            this.goalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goalData.Location = new System.Drawing.Point(56, 219);
            this.goalData.Name = "goalData";
            this.goalData.Size = new System.Drawing.Size(268, 333);
            this.goalData.TabIndex = 7;
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 564);
            this.Controls.Add(this.goalData);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusText);
            this.Name = "mainScreen";
            this.Text = "Bart\'s Coole Strava App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView goalData;
    }
}

