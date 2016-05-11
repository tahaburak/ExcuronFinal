namespace Excuron
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.lbCurrencies = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.txtForexName = new System.Windows.Forms.TextBox();
            this.cbDoAgain = new System.Windows.Forms.CheckBox();
            this.txtCompareName = new System.Windows.Forms.TextBox();
            this.txtCompareCurrency = new System.Windows.Forms.TextBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbSecondCurrency = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnOpenChart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnRss = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCurrencies
            // 
            this.lbCurrencies.BackColor = System.Drawing.SystemColors.Menu;
            this.lbCurrencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrencies.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbCurrencies.FormattingEnabled = true;
            this.lbCurrencies.Location = new System.Drawing.Point(12, 12);
            this.lbCurrencies.Name = "lbCurrencies";
            this.lbCurrencies.Size = new System.Drawing.Size(80, 238);
            this.lbCurrencies.TabIndex = 0;
            this.lbCurrencies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCurrencies_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 273);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.SystemColors.Window;
            this.txtShow.Enabled = false;
            this.txtShow.Location = new System.Drawing.Point(96, 41);
            this.txtShow.Name = "txtShow";
            this.txtShow.Size = new System.Drawing.Size(179, 20);
            this.txtShow.TabIndex = 3;
            this.txtShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtForexName
            // 
            this.txtForexName.BackColor = System.Drawing.SystemColors.Window;
            this.txtForexName.Enabled = false;
            this.txtForexName.Location = new System.Drawing.Point(96, 68);
            this.txtForexName.Name = "txtForexName";
            this.txtForexName.Size = new System.Drawing.Size(179, 20);
            this.txtForexName.TabIndex = 4;
            this.txtForexName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbDoAgain
            // 
            this.cbDoAgain.AutoSize = true;
            this.cbDoAgain.Enabled = false;
            this.cbDoAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoAgain.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cbDoAgain.Location = new System.Drawing.Point(102, 96);
            this.cbDoAgain.Name = "cbDoAgain";
            this.cbDoAgain.Size = new System.Drawing.Size(173, 17);
            this.cbDoAgain.TabIndex = 5;
            this.cbDoAgain.Text = "Compare with another currency";
            this.toolTip2.SetToolTip(this.cbDoAgain, "This will let you to compare the currency above with your second selection.");
            this.cbDoAgain.UseVisualStyleBackColor = true;
            this.cbDoAgain.CheckStateChanged += new System.EventHandler(this.cbDoAgain_CheckStateChanged);
            // 
            // txtCompareName
            // 
            this.txtCompareName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompareName.Enabled = false;
            this.txtCompareName.Location = new System.Drawing.Point(96, 150);
            this.txtCompareName.Name = "txtCompareName";
            this.txtCompareName.Size = new System.Drawing.Size(179, 20);
            this.txtCompareName.TabIndex = 6;
            this.txtCompareName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCompareName.Visible = false;
            // 
            // txtCompareCurrency
            // 
            this.txtCompareCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompareCurrency.Enabled = false;
            this.txtCompareCurrency.Location = new System.Drawing.Point(96, 176);
            this.txtCompareCurrency.Name = "txtCompareCurrency";
            this.txtCompareCurrency.Size = new System.Drawing.Size(179, 20);
            this.txtCompareCurrency.TabIndex = 7;
            this.txtCompareCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCompareCurrency.Visible = false;
            // 
            // cmbSecondCurrency
            // 
            this.cmbSecondCurrency.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbSecondCurrency.FormattingEnabled = true;
            this.cmbSecondCurrency.Location = new System.Drawing.Point(96, 123);
            this.cmbSecondCurrency.Name = "cmbSecondCurrency";
            this.cmbSecondCurrency.Size = new System.Drawing.Size(179, 21);
            this.cmbSecondCurrency.TabIndex = 8;
            this.cmbSecondCurrency.Visible = false;
            this.cmbSecondCurrency.SelectionChangeCommitted += new System.EventHandler(this.cmbSecondCurrency_SelectionChangeCommitted);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Still working here";
            this.notifyIcon.BalloonTipTitle = "Minimized..";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Currency";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btnOpenChart
            // 
            this.btnOpenChart.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOpenChart.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnOpenChart.Location = new System.Drawing.Point(98, 231);
            this.btnOpenChart.Name = "btnOpenChart";
            this.btnOpenChart.Size = new System.Drawing.Size(75, 23);
            this.btnOpenChart.TabIndex = 9;
            this.btnOpenChart.Text = "Open Chart";
            this.btnOpenChart.UseVisualStyleBackColor = false;
            this.btnOpenChart.Click += new System.EventHandler(this.btnOpenChart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(99, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(96, 12);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnRss
            // 
            this.btnRss.BackColor = System.Drawing.SystemColors.Menu;
            this.btnRss.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRss.Location = new System.Drawing.Point(98, 202);
            this.btnRss.Name = "btnRss";
            this.btnRss.Size = new System.Drawing.Size(75, 23);
            this.btnRss.TabIndex = 13;
            this.btnRss.Text = "Open Rss";
            this.btnRss.UseVisualStyleBackColor = false;
            this.btnRss.Click += new System.EventHandler(this.btnRss_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLogin.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLogin.Location = new System.Drawing.Point(200, 202);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = global::Excuron.Properties.Resources.questionmark1;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfo.Location = new System.Drawing.Point(12, 251);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(21, 21);
            this.btnInfo.TabIndex = 16;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLogOut.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnLogOut.Location = new System.Drawing.Point(200, 231);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(209)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(284, 295);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRss);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenChart);
            this.Controls.Add(this.cmbSecondCurrency);
            this.Controls.Add(this.txtCompareCurrency);
            this.Controls.Add(this.txtCompareName);
            this.Controls.Add(this.cbDoAgain);
            this.Controls.Add(this.txtForexName);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbCurrencies);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 333);
            this.MinimumSize = new System.Drawing.Size(300, 333);
            this.Name = "formMain";
            this.Text = "Excuron";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCurrencies;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.TextBox txtForexName;
        private System.Windows.Forms.CheckBox cbDoAgain;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.TextBox txtCompareName;
        private System.Windows.Forms.TextBox txtCompareCurrency;
        private System.Windows.Forms.ComboBox cmbSecondCurrency;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnOpenChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnRss;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnLogOut;
    }
}

