namespace Excuron
{
    partial class RSSScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSSScreen));
            this.refreshButton = new System.Windows.Forms.Button();
            this.titlesComboBox = new System.Windows.Forms.ComboBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.lblPublishDate = new System.Windows.Forms.Label();
            this.rbCNBC = new System.Windows.Forms.RadioButton();
            this.rbCNN = new System.Windows.Forms.RadioButton();
            this.rbEFinance = new System.Windows.Forms.RadioButton();
            this.rbForbes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNasdaq = new System.Windows.Forms.RadioButton();
            this.rbRouters = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.Menu;
            this.refreshButton.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.refreshButton.Location = new System.Drawing.Point(454, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(72, 38);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // titlesComboBox
            // 
            this.titlesComboBox.BackColor = System.Drawing.SystemColors.Menu;
            this.titlesComboBox.FormattingEnabled = true;
            this.titlesComboBox.Location = new System.Drawing.Point(12, 85);
            this.titlesComboBox.Name = "titlesComboBox";
            this.titlesComboBox.Size = new System.Drawing.Size(517, 21);
            this.titlesComboBox.TabIndex = 2;
            this.titlesComboBox.SelectedIndexChanged += new System.EventHandler(this.titlesComboBox_SelectedIndexChanged);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.linkLabel.Location = new System.Drawing.Point(12, 252);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(107, 13);
            this.linkLabel.TabIndex = 3;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Open in web browser";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.descriptionTextBox.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 112);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(517, 137);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.Location = new System.Drawing.Point(12, 239);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(0, 13);
            this.lblPublishDate.TabIndex = 5;
            // 
            // rbCNBC
            // 
            this.rbCNBC.AutoSize = true;
            this.rbCNBC.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCNBC.Location = new System.Drawing.Point(43, 18);
            this.rbCNBC.Name = "rbCNBC";
            this.rbCNBC.Size = new System.Drawing.Size(57, 19);
            this.rbCNBC.TabIndex = 7;
            this.rbCNBC.TabStop = true;
            this.rbCNBC.Text = "CNBC";
            this.rbCNBC.UseVisualStyleBackColor = true;
            // 
            // rbCNN
            // 
            this.rbCNN.AutoSize = true;
            this.rbCNN.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCNN.Location = new System.Drawing.Point(103, 18);
            this.rbCNN.Name = "rbCNN";
            this.rbCNN.Size = new System.Drawing.Size(51, 19);
            this.rbCNN.TabIndex = 8;
            this.rbCNN.TabStop = true;
            this.rbCNN.Text = "CNN";
            this.rbCNN.UseVisualStyleBackColor = true;
            // 
            // rbEFinance
            // 
            this.rbEFinance.AutoSize = true;
            this.rbEFinance.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEFinance.Location = new System.Drawing.Point(157, 18);
            this.rbEFinance.Name = "rbEFinance";
            this.rbEFinance.Size = new System.Drawing.Size(76, 19);
            this.rbEFinance.TabIndex = 9;
            this.rbEFinance.TabStop = true;
            this.rbEFinance.Text = "E-Finance";
            this.rbEFinance.UseVisualStyleBackColor = true;
            // 
            // rbForbes
            // 
            this.rbForbes.AutoSize = true;
            this.rbForbes.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbForbes.Location = new System.Drawing.Point(236, 19);
            this.rbForbes.Name = "rbForbes";
            this.rbForbes.Size = new System.Drawing.Size(59, 19);
            this.rbForbes.TabIndex = 10;
            this.rbForbes.TabStop = true;
            this.rbForbes.Text = "Forbes";
            this.rbForbes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNasdaq);
            this.groupBox1.Controls.Add(this.rbRouters);
            this.groupBox1.Controls.Add(this.rbForbes);
            this.groupBox1.Controls.Add(this.rbEFinance);
            this.groupBox1.Controls.Add(this.rbCNN);
            this.groupBox1.Controls.Add(this.rbCNBC);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 41);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSS Sources";
            // 
            // rbNasdaq
            // 
            this.rbNasdaq.AutoSize = true;
            this.rbNasdaq.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNasdaq.Location = new System.Drawing.Point(367, 18);
            this.rbNasdaq.Name = "rbNasdaq";
            this.rbNasdaq.Size = new System.Drawing.Size(66, 19);
            this.rbNasdaq.TabIndex = 12;
            this.rbNasdaq.TabStop = true;
            this.rbNasdaq.Text = "Nasdaq";
            this.rbNasdaq.UseVisualStyleBackColor = true;
            // 
            // rbRouters
            // 
            this.rbRouters.AutoSize = true;
            this.rbRouters.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRouters.Location = new System.Drawing.Point(299, 18);
            this.rbRouters.Name = "rbRouters";
            this.rbRouters.Size = new System.Drawing.Size(63, 19);
            this.rbRouters.TabIndex = 11;
            this.rbRouters.TabStop = true;
            this.rbRouters.Text = "Routers";
            this.rbRouters.UseVisualStyleBackColor = true;
            // 
            // RSSScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(209)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(538, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPublishDate);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.titlesComboBox);
            this.Controls.Add(this.refreshButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RSSScreen";
            this.Text = "RSS Feed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ComboBox titlesComboBox;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label lblPublishDate;
        private System.Windows.Forms.RadioButton rbCNBC;
        private System.Windows.Forms.RadioButton rbCNN;
        private System.Windows.Forms.RadioButton rbEFinance;
        private System.Windows.Forms.RadioButton rbForbes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNasdaq;
        private System.Windows.Forms.RadioButton rbRouters;
    }
}