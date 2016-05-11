namespace Excuron
{
    partial class formChart
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChart));
            this.crtCurrency = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSecFormOpenFirstForm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEnable3D = new System.Windows.Forms.CheckBox();
            this.cbRevert = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.crtCurrency)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crtCurrency
            // 
            this.crtCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(209)))), ((int)(((byte)(132)))));
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.crtCurrency.ChartAreas.Add(chartArea1);
            this.crtCurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crtCurrency.ImeMode = System.Windows.Forms.ImeMode.On;
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.TitleFont = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.crtCurrency.Legends.Add(legend1);
            this.crtCurrency.Location = new System.Drawing.Point(6, 19);
            this.crtCurrency.Name = "crtCurrency";
            this.crtCurrency.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.SystemColors.ControlDarkDark;
            series1.Legend = "Legend1";
            series1.Name = "Rate";
            series1.YValuesPerPoint = 4;
            this.crtCurrency.Series.Add(series1);
            this.crtCurrency.Size = new System.Drawing.Size(668, 218);
            this.crtCurrency.TabIndex = 0;
            this.crtCurrency.Tag = "";
            this.crtCurrency.Text = "chart1";
            this.crtCurrency.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtCurrency_MouseMove);
            // 
            // btnSecFormOpenFirstForm
            // 
            this.btnSecFormOpenFirstForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSecFormOpenFirstForm.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecFormOpenFirstForm.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSecFormOpenFirstForm.Location = new System.Drawing.Point(280, 267);
            this.btnSecFormOpenFirstForm.Name = "btnSecFormOpenFirstForm";
            this.btnSecFormOpenFirstForm.Size = new System.Drawing.Size(142, 35);
            this.btnSecFormOpenFirstForm.TabIndex = 1;
            this.btnSecFormOpenFirstForm.Text = "Switch back main screen";
            this.btnSecFormOpenFirstForm.UseVisualStyleBackColor = true;
            this.btnSecFormOpenFirstForm.Click += new System.EventHandler(this.btnSecFormOpenFirstForm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crtCurrency);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 248);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // cbEnable3D
            // 
            this.cbEnable3D.AutoSize = true;
            this.cbEnable3D.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEnable3D.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbEnable3D.Location = new System.Drawing.Point(600, 267);
            this.cbEnable3D.Name = "cbEnable3D";
            this.cbEnable3D.Size = new System.Drawing.Size(86, 18);
            this.cbEnable3D.TabIndex = 5;
            this.cbEnable3D.Text = "Turn into 3D";
            this.cbEnable3D.UseVisualStyleBackColor = true;
            this.cbEnable3D.CheckedChanged += new System.EventHandler(this.cbEnable3D_CheckedChanged);
            // 
            // cbRevert
            // 
            this.cbRevert.AutoSize = true;
            this.cbRevert.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRevert.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbRevert.Location = new System.Drawing.Point(600, 291);
            this.cbRevert.Name = "cbRevert";
            this.cbRevert.Size = new System.Drawing.Size(83, 18);
            this.cbRevert.TabIndex = 6;
            this.cbRevert.Text = "Revert ratio";
            this.cbRevert.UseVisualStyleBackColor = true;
            this.cbRevert.CheckedChanged += new System.EventHandler(this.cbRevert_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // formChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(209)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(704, 312);
            this.Controls.Add(this.cbRevert);
            this.Controls.Add(this.cbEnable3D);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSecFormOpenFirstForm);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 350);
            this.MinimumSize = new System.Drawing.Size(720, 350);
            this.Name = "formChart";
            this.Text = "Chart View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formChart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.crtCurrency)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtCurrency;
        private System.Windows.Forms.Button btnSecFormOpenFirstForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbEnable3D;
        private System.Windows.Forms.CheckBox cbRevert;
        private System.Windows.Forms.Timer timer;
    }
}