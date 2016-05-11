using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;
using System.Threading;


namespace Excuron
{
    public partial class formMain : Form
    {
        private ContextMenu trayMenu;// the menu that opening when right clicked on minimized system tray of app, actually its definition
        Thread t,databaseThread;
        static Form refToWallet;

        public static Form RefToWallet
        {
            get { return formMain.refToWallet; }
            set { formMain.refToWallet = value; }
        }
        static Button logoutClone;

        public static Button LogoutClone
        {
            get { return formMain.logoutClone; }
            set { formMain.logoutClone = value; }
        }
        public formMain()
        {

            this.MaximizeBox = false;
            InitializeComponent();
            t = new Thread(new ThreadStart(splashScreen));
            t.Start();
            if (XMLREAD.checkConnection() == false)
            {
                connectionException();
            }
            t.Abort();
            logoutClone = btnLogOut;
            if (!Properties.Settings.Default.logged)
            {
                btnLogOut.Enabled = false;
            }


            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = LabelsText;//setting label1's text via string for the case if that value changes in another class
            theDayToShowString = DateTime.Today.ToShortDateString();//as default choose today as to be shown
            dateTimePicker1.MaxDate = DateTime.Today;//set datetime picker's max date as today
            dateTimePicker1.MinDate = dateTimePicker1.MaxDate.AddDays(-85);// set datetime picker's range as last 85 days

            //XMLREAD.getOldValues("USD","TRY");
        }
        static String labelsText = "", toolStripStatusLabel1Text = "", theDayToShowString; //they are gonna be used while passing values
        static String[] currencyDataForComboBox, currencyDataForListBox, currencyPricesArray;//they are gonna be used while passing values
        static int selectedListBoxIndex = 0;//to distinguish which index has selected by user in controls
        static int selectedComboBoxIndex = 0;
        public static String[] CurrencyDataForComboBox
        {
            get { return formMain.currencyDataForComboBox; }
            set { formMain.currencyDataForComboBox = value; }
        }
        public static int SelectedListBoxIndex
        {
            get { return formMain.selectedListBoxIndex; }
            set { formMain.selectedListBoxIndex = value; }
        }

        public static int SelectedComboBoxIndex
        {
            get { return formMain.selectedComboBoxIndex; }
            set { formMain.selectedComboBoxIndex = value; }
        }
        //Next 3 functions for the passing values between classes

        public static string LabelsText
        {
            get
            {
                return labelsText;
            }

            set
            {
                labelsText = value;
            }
        }


        public static string ToolStripStatusLabel1Text
        {
            get
            {
                return toolStripStatusLabel1Text;
            }

            set
            {
                toolStripStatusLabel1Text = value;
            }
        }

        public static string TheDayToShowString
        {
            get
            {
                return theDayToShowString;
            }

            set
            {
                theDayToShowString = value;
            }
        }
        Thread tr;
        public void connectionException()
        {

            t.Abort();
            if (tr != null)
            {
                tr.Abort();
            }
            DialogResult dr = MessageBox.Show("Please check your internet connection!", "Connection Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            if (dr == DialogResult.Retry)
            {
                tr = new Thread(new ThreadStart(splashScreen));
                tr.Start();
                XMLREAD.readtheXml();

                if (XMLREAD.checkConnection() == false)
                {
                    connectionException();
                }
                tr.Abort();
            }
            else
            {
                this.Dispose();
                this.Close();

            }
        }
        public void splashScreen()
        {
            Application.Run(new openingLoader());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearThingsUp();//to clear things up
            XMLREAD.readtheXml();//read the xml
            CurrencyDataForComboBox = XMLREAD.CurrencyDataForComboBox;// get array from XMLREAD
            currencyDataForListBox = XMLREAD.CurrencyDataForListBox;// get array from XMLREAD
            currencyPricesArray = XMLREAD.CurrencyPricesArray;// get array from XMLREAD
            CurrencyDataForComboBox = CurrencyDataForComboBox.Skip(1).ToArray();//We don't use Euro on this screen
            currencyDataForListBox = currencyDataForListBox.Skip(1).ToArray();//We don't use Euro on this screen
            currencyPricesArray = currencyPricesArray.Skip(1).ToArray();//We don't use Euro on this screen
            lbCurrencies.DataSource = currencyDataForListBox;  //assaigning collection of data (Array) to the listBox
            if (lbCurrencies.Items.Count > 0)
            {
                lbCurrencies.SelectedIndex = 0;//Show first index as default
                txtShow.Text = "EURO/" + currencyDataForListBox[SelectedListBoxIndex];//return a text to label such like EURO/"USD" or sth
                txtForexName.Text = currencyPricesArray[SelectedListBoxIndex];//return the price of selected currency
                cbDoAgain.Enabled = true;//enable checkbox
            }
            toolStripStatusLabel1.Text = ToolStripStatusLabel1Text;// get label text from XMLREAD
        }

        private void lbCurrencies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectedListBoxIndex = lbCurrencies.SelectedIndex;//when we double-clicked on an item in listBox, we getting its index value in here
            txtShow.Text = "EURO/" + currencyDataForListBox[SelectedListBoxIndex];//return a text to label such like EURO/"USD" or sth
            txtForexName.Text = currencyPricesArray[SelectedListBoxIndex];//return the price of selected currency
            cbDoAgain.Enabled = true;//enable checkbox
        }
        static CheckBox cbClone;

        public static CheckBox CbClone
        {
            get { return formMain.cbClone; }
            set { formMain.cbClone = value; }
        }

        static Boolean cbIsChecked = false;
        public static Boolean isChecked()
        {
            return cbIsChecked;
        }
        private void cbDoAgain_CheckStateChanged(object sender, EventArgs e)
        {
            CbClone = cbDoAgain;
            if (cbDoAgain.Checked)
            {
                cbIsChecked = true;
                txtCompareName.Visible = true;
                txtCompareCurrency.Visible = true;
                cmbSecondCurrency.Visible = true;
                cmbSecondCurrency.DataSource = CurrencyDataForComboBox;//fill up the comboBox with same list of currencies
            }
            else if (!cbDoAgain.Checked)
            { // vice versa, revert effects
                cbIsChecked = false;
                txtCompareName.Visible = false;
                txtCompareCurrency.Visible = false;
                cmbSecondCurrency.Visible = false;
            }
        }
        private void cmbSecondCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {

            selectedComboBoxIndex = cmbSecondCurrency.SelectedIndex;//get selected index of comboBox
            txtCompareName.Text = currencyDataForListBox[SelectedListBoxIndex] + "/" + CurrencyDataForComboBox[selectedComboBoxIndex];// lets say first textBox is like "EURO/USD" then we pick assumably "TRY" in comboBox lets say, then this code does that "USD/TRY". *magic*
            Decimal first = Math.Round((Decimal.Parse(currencyPricesArray[SelectedListBoxIndex], CultureInfo.InvariantCulture)), 5);//briefly lets us to get appropriate numbers corresponding to selected currencies
            Decimal second = Math.Round((Decimal.Parse(currencyPricesArray[selectedComboBoxIndex], CultureInfo.InvariantCulture)), 5);// same as above
            Decimal rate = Math.Round((second * (1 / first)), 5);// this is the part that cross-conversion happens, like "USD/TRY"

            btnOpenChart.Visible = true;
            txtCompareCurrency.Text = Convert.ToString(rate);//display result in textBox

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {//if form is minimized
                notifyIcon.Visible = true;//let its notifyIcon visible in system tray
                notifyIcon.ShowBalloonTip(500);// show message that programme still works behind the scene
                this.ShowInTaskbar = false;//make it look like closed on taskbar
                trayContext();//right click menu of system tray icon
            }

        }
        private void NotifyState()
        {// things that happening when we opening back the form from system tray
            this.WindowState = FormWindowState.Normal;//show back as it was once
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }
        private void trayContext()
        {//tray right click menu, can be added more actions
            trayMenu = new ContextMenu();//constructor
            trayMenu.MenuItems.Add(0, new MenuItem("Show", new System.EventHandler(Show_Click)));//adding "Show" control
            trayMenu.MenuItems.Add(1, new MenuItem("Exit", new System.EventHandler(Exit_Click)));//adding "Exit" control
            notifyIcon.ContextMenu = trayMenu;//assaigning that to notifyIcons contextMenu
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NotifyState();//open back from system tray, with double click
        }
        private void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();//close from system tray
        }
        private void Show_Click(Object sender, System.EventArgs e)
        {
            NotifyState();//open bakc from system tray
        }

        private void btnOpenChart_Click(object sender, EventArgs e)
        {
            if (lbCurrencies.SelectedItem.Equals("BGN")&&!cbDoAgain.Checked)
            {
                MessageBox.Show("According to Bulgarian Central Bank, Lev rate is fixed to 1.95583 EURO.\nTherefore there is not any visualized instance of rate change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (lbCurrencies.SelectedItem==cmbSecondCurrency.SelectedItem)
            {
                MessageBox.Show("Drawing a chart requires two different currencies.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                formChart f2 = new formChart();// new constructor to communicate with chart form
                f2.RefToFirstForm = this;//f2.RefToFirstForm=FormMain; // holds the situation of FormMain
                f2.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();// hide FormMain
                f2.Show();//Show FormChart
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            theDayToShowString = dateTimePicker1.Value.ToShortDateString();//get chosen date from datetimepicker
            ClearThingsUp();//to reset
            button1_Click(sender, e);
            if (lbCurrencies.Items.Count != 0)
            {
                btnRss.Enabled = true;
                btnLogin.Enabled = true;
            }
            if (lbCurrencies.Items.Count == 0)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
                dateTimePicker1_ValueChanged(sender, e);
            }

        }

        private void ClearThingsUp() //the one function to clear 'em all!
        {
            txtCompareCurrency.Text = ""; //to reset
            txtCompareName.Text = "";//to reset
            txtForexName.Text = "";//to reset
            txtShow.Text = "";//to reset
            cbDoAgain.Checked = false;//to reset
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnRss_Click(object sender, EventArgs e)
        {
            RSSScreen f3 = new RSSScreen(notifyIcon);
            f3.RefToFirstForm = this;
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Visible = true;
        }
        public void splashScreenDatabase()
        {
            Application.Run(new Loading("Connecting..."));
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.logged)
            {
               databaseThread = new Thread(new ThreadStart(splashScreenDatabase));
                databaseThread.Start();
                if (DatabaseConnection.hasDatabaseConnection())
                {
                WalletScreen w5 = new WalletScreen();
                w5.StartPosition = FormStartPosition.CenterScreen;
                w5.Visible = true;
                }
              
                databaseThread.Abort();
            }
            else
            {

                LoginScreen f4 = new LoginScreen();
                f4.StartPosition = FormStartPosition.CenterScreen;
                f4.Visible = true;

            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currency data will be updated every work day between 15:00-16:00 CET.\n", "General Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.logged )
            {
                if (RefToWallet!=null)
                {
                    RefToWallet.Close();

                }
                Properties.Settings.Default.UserID = -1;
                Properties.Settings.Default.logged = false;
                Properties.Settings.Default.numberOfWallets = 1;
                Properties.Settings.Default.CurrentWalletID = -1;                
                Properties.Settings.Default.Save();
                MessageBox.Show("You have successfuly logged out.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnLogOut.Enabled = false;
            }
            else
            {
                MessageBox.Show("You are not logged in so that you can not log out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
