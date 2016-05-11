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
    public partial class LoginScreen : Form
    {   
        public LoginScreen()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
            
        }
        private void validateInputs()
        {
            lblErrorMessage.Text = "";
            lblErrorPassword.Text = "";
            if(validateMail() && DatabaseConnection.emailExists(txtMail.Text)){
                if(DatabaseConnection.logIN(txtMail.Text,txtPassword.Text)){
                    lblErrorMessage.Text = "";
                    lblErrorPassword.Text = "";
                    Properties.Settings.Default.logged = true;
                    Properties.Settings.Default.Save();
                    formMain.LogoutClone.Enabled = true;
                    this.Close();
                    WalletScreen w5 = new WalletScreen();
                    w5.StartPosition = FormStartPosition.CenterScreen;
                    w5.Visible = true;
                }
                else{
                    lblErrorPassword.Text="Please check your password";
                }
            }
            else{
                lblErrorMessage.Text="Mail address is not valid or not found";
            }
        }
        private Boolean validateMail() {
            String mail = txtMail.Text;
            Regex expression = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            Match isRight = expression.Match(mail);
            if(isRight.Success){
                return true;
            }
            else
                return false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpScreen f5 = new SignUpScreen();
            this.Close();
            f5.StartPosition = FormStartPosition.CenterScreen;
            f5.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(splashScreen));
            t.Start();
            validateInputs();
            t.Abort();
        }
        public void splashScreen() {
            Application.Run(new Loading("Logging in.."));
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
