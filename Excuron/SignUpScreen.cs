using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excuron
{
    public partial class SignUpScreen : Form
    {
        public SignUpScreen()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        private void validateInputs() {
            if (validateMail())
            {
                lblErrorMessage.Text = "";
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    lblErrorMessage.Text = "";
                   string result = DatabaseConnection.signUp(txtMail.Text,txtPassword.Text);

                    if (Properties.Settings.Default.logged/* or we can just check the result string if it's contains ":" or not*/)
                    {
                        Properties.Settings.Default.NewUser = true;
                        formMain.LogoutClone.Enabled = true;
                        this.Close();
                        WalletScreen w5 = new WalletScreen();
                        w5.StartPosition = FormStartPosition.CenterScreen;
                        w5.Visible = true;
                    }
                    else
                    {
                        lblErrorMessage.Text = result;
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Given passwords are not match";
                }
            }
            else {
                lblErrorMessage.Text = "Please type a valid mail address";            
            }
        }
        public void splashScreen()
        {
            Application.Run(new Loading("Signing up.."));
        }
        private Boolean validateMail()
        {
            String mail = txtMail.Text;
            Regex expression = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            Match isRight = expression.Match(mail);
            if (isRight.Success)
            {
                return true;
            }
            else
                return false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(splashScreen));
            t.Start();
            validateInputs();
            t.Abort();
        }

        

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Confirm password")
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Confirm password";
                txtConfirmPassword.PasswordChar = '\0';
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter password";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Enter your mail address")
            {
                txtMail.Text = "";
                
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "Enter your mail address";
                
            }
        }
    }
}
