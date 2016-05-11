namespace Excuron
{
    partial class SignUpScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btnSignUp);
            this.panel1.Controls.Add(this.txtMail);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(41, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 265);
            this.panel1.TabIndex = 0;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmPassword.Location = new System.Drawing.Point(8, 180);
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(186, 27);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.Text = "Confirm password";
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Location = new System.Drawing.Point(8, 145);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(186, 27);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Enter password";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSignUp.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSignUp.Location = new System.Drawing.Point(56, 214);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(90, 39);
            this.btnSignUp.TabIndex = 4;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.Color.DimGray;
            this.txtMail.Location = new System.Drawing.Point(8, 110);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(186, 27);
            this.txtMail.TabIndex = 1;
            this.txtMail.Text = "Enter your mail address";
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Excuron.Properties.Resources.newuser;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(45, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblErrorMessage.Location = new System.Drawing.Point(36, 268);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 19);
            this.lblErrorMessage.TabIndex = 5;
            // 
            // SignUpScreen
            // 
            this.AcceptButton = this.btnSignUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(209)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(284, 295);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 333);
            this.MinimumSize = new System.Drawing.Size(300, 333);
            this.Name = "SignUpScreen";
            this.Text = "Sign Up";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}