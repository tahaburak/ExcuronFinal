using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excuron
{
    public partial class WalletScreen : Form
    {

        User user = new User();
        Double[] amount = new Double[3];//to keep values
        Double[] updateAmounts = new Double[3];//to update values
        String[] allNames = XMLREAD.CurrencyDataForComboBox;
        String[] allNamesFor = XMLREAD.CurrencyDataForListBox;
        public WalletScreen()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            formMain.RefToWallet = this;
            for (int i = 0; i < user.WalletList.Count; i++)
            {
                cbWallets.Items.Add(user.WalletList.ElementAt(i).ToString());
            }
            btnSaveWallet.Enabled = false;
            if (cbWallets.Items.Count < 2)
            {
                btnDeleteWallet.Enabled = false;
            }
            Properties.Settings.Default.CurrentWalletID = user.WalletList.ElementAt(0).WalletID;
            Properties.Settings.Default.Save();
            cbWallets.SelectedIndex = 0;
            tabPage3.Text = user.WalletList.ElementAt(0).WalletName;
            lblMoney1.Text = user.WalletList.ElementAt(0).Currencies[0];
            lblMoney2.Text = user.WalletList.ElementAt(0).Currencies[1];
            lblMoney3.Text = user.WalletList.ElementAt(0).Currencies[2];
            txtRename.Text = user.WalletList.ElementAt(0).WalletName;
            btnRename.Enabled = false;
            txtMoneyDisplay1.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[0]);
            txtMoneyDisplay2.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[1]);
            txtMoneyDisplay3.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[2]);
            txtMoneyResult1.Text = txtMoneyDisplay1.Text;
            txtMoneyResult2.Text = txtMoneyDisplay2.Text;
            txtMoneyResult3.Text = txtMoneyDisplay3.Text;
            numericUpDown1.Maximum = 1500000;
            numericUpDown2.Maximum = 1500000;
            numericUpDown3.Maximum = 1500000;
            numericUpDown1.Minimum = -1500000;
            numericUpDown2.Minimum = -1500000;
            numericUpDown3.Minimum = -1500000;
            cbCurrencySettings1.DataSource = allNames.Clone();
            cbCurrencySettings2.DataSource = allNames.Clone();
            cbCurrencySettings3.DataSource = allNames.Clone();
            cbCurrencySettings1.Text = user.WalletList.ElementAt(0).Currencies[0];
            cbCurrencySettings2.Text = user.WalletList.ElementAt(0).Currencies[1];
            cbCurrencySettings3.Text = user.WalletList.ElementAt(0).Currencies[2];


        }
        String[] prices = XMLREAD.CurrencyPricesArray;
        private void WalletScreen_Load(object sender, EventArgs e)
        {

        }

        private void cmbCompleteCurrencies_Enter(object sender, EventArgs e)
        {
            if (cmbCompleteCurrencies.Text == "To")
            {
                String[] exchangeCurrencies = getCurrentWallet().Currencies;

                cmbCompleteCurrencies.DataSource = exchangeCurrencies.Clone();
            }
        }
        int fromIndex = 0;
        int toIndex = 0;

        private void cmbCurrenciesFROM_Enter(object sender, EventArgs e)
        {
            if (cmbCurrenciesFROM.Text == "From")
            {
                cmbCurrenciesFROM.DataSource = allNamesFor;
            }
        }

        private void cmbCurrenciesTO_Enter(object sender, EventArgs e)
        {
            if (cmbCurrenciesTO.Text == "To")
            {
                cmbCurrenciesTO.DataSource = allNames;
            }
        }

        private void cmbCurrenciesFROM_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromIndex = cmbCurrenciesFROM.SelectedIndex;
        }

        private void cmbCurrenciesTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            toIndex = cmbCurrenciesTO.SelectedIndex;
        }

        private void txtExchangeAmount_Enter(object sender, EventArgs e)
        {
            txtExchangeAmount.Text = "";

        }

        private void txtExchangeAmount_Leave(object sender, EventArgs e)
        {
            if (txtExchangeAmount.Text == null || txtExchangeAmount.Text.Trim() == "")
            {
                txtExchangeAmount.Text = "Enter amount";
            }
        }

        private void txtAmountFROM_Enter(object sender, EventArgs e)
        {
            txtAmountFROM.Text = "";
        }

        private void txtAmountFROM_Leave(object sender, EventArgs e)
        {
            if (txtAmountFROM.Text == null || txtAmountFROM.Text.Trim() == "")
            {
                txtAmountFROM.Text = "Enter amount";
            }
        }

        private void txtExchangeAmount_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"^-*[0-9,\.]+$");
            if (!regex.IsMatch(txtExchangeAmount.Text) && txtExchangeAmount.Text.Trim() != "")
            {
                MessageBox.Show("Please be sure that your input is numeric.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtExchangeAmount.Text = "";
            }
            else if (txtExchangeAmount.Text.Trim() == "")
            {
                txtExchangeAmount.Text = "";
            }
        }

        private void txtAmountFROM_KeyUp(object sender, KeyEventArgs e)
        {
            var regex = new Regex(@"^-*[0-9,\.]+$");
            if (!regex.IsMatch(txtAmountFROM.Text) && txtAmountFROM.Text.Trim() != "")
            {
                MessageBox.Show("Please be sure that your input is numeric.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmountFROM.Text = txtAmountFROM.Text.Substring(0, txtAmountFROM.Text.Length - 1); ;
            }
            else if (txtAmountFROM.Text.Trim() == "")
            {
                txtAmountFROM.Text = "";
            }
        }

        private Wallet getCurrentWallet()
        {
            int walletID = Properties.Settings.Default.CurrentWalletID;
            Wallet currentWallet = user.WalletList.ElementAt(Wallet.getWalletIndexWithID(user, walletID));
            return currentWallet;
        }
        private void btnExchange_Click(object sender, EventArgs e)
        {
            int walletID = Properties.Settings.Default.CurrentWalletID;
            Wallet currentWallet = getCurrentWallet();

            if (!(cmbWalletsCurrencies.Text == "From" || cmbCompleteCurrencies.Text == "To" || txtExchangeAmount.Text == "Enter amount" || (cmbWalletsCurrencies.Text == cmbCompleteCurrencies.Text)))
            {
                if (Convert.ToDouble(txtExchangeAmount.Text.Replace('.', ',')) <= currentWallet.Amounts[cmbWalletsCurrencies.SelectedIndex])
                {
                    DialogResult dr = new DialogResult();
                    int suggestion = XMLREAD.giveSuggestion(cmbWalletsCurrencies.SelectedItem.ToString(), cmbCompleteCurrencies.SelectedItem.ToString());
                    if (suggestion == 0)
                    {
                        dr = MessageBox.Show("According to last 7 days data amoung your selections, rate of " + cmbWalletsCurrencies.SelectedItem.ToString() +
                            "/" + cmbCompleteCurrencies.SelectedItem.ToString() +
                            " is depreciated.\nIt does not seems as a good investment for the short term.\nWe can suggest you to do NOT perform this transaction." + "\nAverage of the week: " + XMLREAD.Aver + " Current value: " + XMLREAD.LastRate + "\nSelect 'Yes' to proceed 'No' to halt.",
                            "Suggestion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                    else if (suggestion == 1)
                    {
                        dr = MessageBox.Show("According to last 7 days data amoung your selections, rate of " + cmbWalletsCurrencies.SelectedItem.ToString() +
                            "/" + cmbCompleteCurrencies.SelectedItem.ToString() +
                            " is become more valuable.\nIt seems like a good investment for a short term.\nWe can suggest you to perform this transaction."+"\nAverage of the week: "+XMLREAD.Aver+" Current value: "+XMLREAD.LastRate+"\nSelect 'Ok' to proceed.",
                            "Suggestion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occured at reading the XML", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    DialogResult confirmation;
                    if ((dr == DialogResult.OK) || (dr == DialogResult.Yes))
                    {
                        String from = cmbWalletsCurrencies.SelectedItem.ToString();
                        String to = cmbCompleteCurrencies.SelectedItem.ToString();
                        String[] tempArrayFromTo = new String[] { from, to };
                        Decimal rate = XMLREAD.exchangeRate(tempArrayFromTo);
                        Decimal result = rate;
                        result *= Convert.ToDecimal(txtExchangeAmount.Text.Replace('.', ','));
                        confirmation = MessageBox.Show("You are going to exchange\n" + txtExchangeAmount.Text + " " + cmbWalletsCurrencies.SelectedItem.ToString()
                            + " to " + result + " " + cmbCompleteCurrencies.SelectedItem.ToString() +
                            ".\nIf you confirm that transaction select 'Yes'.", "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                        if (confirmation == DialogResult.Yes)
                        {
                            Thread t = new Thread(new ThreadStart(splashScreen));
                            t.Start();
                            NumericUpDown[] numericUpDownArray = numericUpdowns();//To get numeric up downs 

                            try
                            {

                                numericUpDownArray[cmbWalletsCurrencies.SelectedIndex].Value = -Convert.ToDecimal(txtExchangeAmount.Text.Replace('.', ','));
                                numericUpDownArray[cmbCompleteCurrencies.SelectedIndex].Value = result;
                                executeTransaction();
                                t.Abort();
                                txtExchangeAmount.Text = "Enter amount";
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                MessageBox.Show("Please consider smaller values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }

                }
                else if (Convert.ToDouble(txtExchangeAmount.Text.Replace('.', ',')) > currentWallet.Amounts[cmbWalletsCurrencies.SelectedIndex])
                {
                    MessageBox.Show("Please be sure that you have sufficient balance to perform this transaction.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExchangeAmount.Text = "Enter amount";
                }
            }
            else
            {
                MessageBox.Show("Please be sure that you have filled all required information.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbWalletsCurrencies.Text = "From";
                cmbCompleteCurrencies.Text = "To";
                txtExchangeAmount.Text = "Enter amount";
            }

        }
        public void splashScreen()
        {
            Application.Run(new Loading("Exchanging.."));
        }
        private void btnFastCalculator_Click(object sender, EventArgs e)
        {
            if (!(cmbCurrenciesFROM.Text == "From" || cmbCurrenciesTO.Text == "To" || txtAmountFROM.Text == "Enter amount"))
            {
                String stringFROM = prices[cmbCurrenciesFROM.SelectedIndex];
                String stringTO = prices[cmbCurrenciesTO.SelectedIndex];
                Decimal decimalFROM = Math.Round(Decimal.Parse(stringFROM, CultureInfo.InvariantCulture), 5);
                Decimal decimalTO = Math.Round(Decimal.Parse(stringTO, CultureInfo.InvariantCulture), 5);
                Decimal result = Math.Round(decimalTO * (1 / decimalFROM), 5);
                Decimal multiplier = Convert.ToDecimal(txtAmountFROM.Text);
                txtResult.Text = (multiplier * result) + "";
            }
            else
            {
                MessageBox.Show("Please be sure that you have filled all required information.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCurrenciesFROM.Text = "From";
                cmbCurrenciesTO.Text = "To";
                txtAmountFROM.Text = "Enter amount";

            }
        }



        private void cmbWalletsCurrencies_Enter(object sender, EventArgs e)
        {

            if (cmbWalletsCurrencies.Text == "From")
            {
                String[] exchangeCurrencies = getCurrentWallet().Currencies;

                cmbWalletsCurrencies.DataSource = exchangeCurrencies.Clone();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            btnSaveWallet.Enabled = true;

            txtMoneyResult1.Text = Convert.ToString(Convert.ToDouble(txtMoneyDisplay1.Text) + Convert.ToDouble(numericUpDown1.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            btnSaveWallet.Enabled = true;

            txtMoneyResult2.Text = Convert.ToString(Convert.ToDouble(txtMoneyDisplay2.Text) + Convert.ToDouble(numericUpDown2.Value));

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            btnSaveWallet.Enabled = true;

            txtMoneyResult3.Text = Convert.ToString(Convert.ToDouble(txtMoneyDisplay3.Text) + Convert.ToDouble(numericUpDown3.Value));

        }

        private void executeTransaction()
        {
            updateAmounts[0] = Convert.ToDouble(txtMoneyResult1.Text);
            updateAmounts[1] = Convert.ToDouble(txtMoneyResult2.Text);
            updateAmounts[2] = Convert.ToDouble(txtMoneyResult3.Text);

            if (DatabaseConnection.WalletUpdate(user, updateAmounts)
)
            {
                getCurrentWallet().Amounts = updateAmounts;

                txtMoneyDisplay1.Text = txtMoneyResult1.Text; txtMoneyDisplay2.Text = txtMoneyResult2.Text; txtMoneyDisplay3.Text = txtMoneyResult3.Text;

                numericUpDown1.Value = 0; numericUpDown2.Value = 0; numericUpDown3.Value = 0;
                btnSaveWallet.Enabled = false;

            }

        }

        private void btnSaveWallet_Click(object sender, EventArgs e)
        {

            updateAmounts[0] = Convert.ToDouble(txtMoneyResult1.Text);
            updateAmounts[1] = Convert.ToDouble(txtMoneyResult2.Text);
            updateAmounts[2] = Convert.ToDouble(txtMoneyResult3.Text);

            if (DatabaseConnection.WalletUpdate(user, updateAmounts)
)
            {
                getCurrentWallet().Amounts = updateAmounts;

                txtMoneyDisplay1.Text = txtMoneyResult1.Text; txtMoneyDisplay2.Text = txtMoneyResult2.Text; txtMoneyDisplay3.Text = txtMoneyResult3.Text;

                numericUpDown1.Value = 0; numericUpDown2.Value = 0; numericUpDown3.Value = 0;
                btnSaveWallet.Enabled = false;
                MessageBox.Show("Wallet Updated Successfully!", "Update Accomplished", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("An Error occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void btnLogOut_Click(object sender, EventArgs e)
        {
            formMain.LogoutClone.Enabled = false;
            Properties.Settings.Default.UserID = -1;
            Properties.Settings.Default.logged = false;
            Properties.Settings.Default.numberOfWallets = 1;
            Properties.Settings.Default.CurrentWalletID = -1;
            Properties.Settings.Default.Save();
            MessageBox.Show("You have successfuly logged out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnAddWallet_Click(object sender, EventArgs e)
        {
            if (cbWallets.Items.Count > 8)
            {
                MessageBox.Show("You have reached your wallet limit.");
            }
            else
            {


                String walletName = "";

                switch (Properties.Settings.Default.numberOfWallets)
                {
                    case 1:
                        walletName = "2nd Wallet";
                        break;
                    case 2:
                        walletName = "3rd Wallet";
                        break;
                    default:
                        walletName = Properties.Settings.Default.numberOfWallets + 1 + "th Wallet";
                        break;
                }

                if (DatabaseConnection.addWallet(user, "EURUSDTRY", walletName))
                {
                    cbWallets.Items.Add(user.WalletList.ElementAt(Properties.Settings.Default.numberOfWallets - 1).ToString());
                    btnDeleteWallet.Enabled = true;
                }

            }

        }

        private void btnDeleteWallet_Click(object sender, EventArgs e)
        {

            if (DatabaseConnection.deleteWallet(user, cbWallets.SelectedIndex))
            {
                cbWallets.Items.RemoveAt(cbWallets.SelectedIndex);
                Properties.Settings.Default.CurrentWalletID = user.WalletList.ElementAt(0).WalletID;
                Properties.Settings.Default.Save();
                tabPage3.Text = user.WalletList.ElementAt(0).WalletName;
                lblMoney1.Text = user.WalletList.ElementAt(0).Currencies[0];
                lblMoney2.Text = user.WalletList.ElementAt(0).Currencies[1];
                lblMoney3.Text = user.WalletList.ElementAt(0).Currencies[2];

                txtMoneyDisplay1.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[0]);
                txtMoneyDisplay2.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[1]);
                txtMoneyDisplay3.Text = Convert.ToString(user.WalletList.ElementAt(0).Amounts[2]);
                txtMoneyResult1.Text = txtMoneyDisplay1.Text;
                txtMoneyResult2.Text = txtMoneyDisplay2.Text;
                txtMoneyResult3.Text = txtMoneyDisplay3.Text;
                txtRename.Text = user.WalletList.ElementAt(0).WalletName;
                btnRename.Enabled = false;
            }
            if (cbWallets.Items.Count < 2)
            {
                btnDeleteWallet.Enabled = false;
            }
        }

        private void cbWallets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CurrentWalletID = user.WalletList.ElementAt(cbWallets.SelectedIndex).WalletID;
            Properties.Settings.Default.Save();
            tabPage3.Text = user.WalletList.ElementAt(cbWallets.SelectedIndex).WalletName;
            lblMoney1.Text = user.WalletList.ElementAt(cbWallets.SelectedIndex).Currencies[0];
            lblMoney2.Text = user.WalletList.ElementAt(cbWallets.SelectedIndex).Currencies[1];
            lblMoney3.Text = user.WalletList.ElementAt(cbWallets.SelectedIndex).Currencies[2];

            txtMoneyDisplay1.Text = Convert.ToString(user.WalletList.ElementAt(cbWallets.SelectedIndex).Amounts[0]);
            txtMoneyDisplay2.Text = Convert.ToString(user.WalletList.ElementAt(cbWallets.SelectedIndex).Amounts[1]);
            txtMoneyDisplay3.Text = Convert.ToString(user.WalletList.ElementAt(cbWallets.SelectedIndex).Amounts[2]);
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;

            txtMoneyResult1.Text = txtMoneyDisplay1.Text;
            txtMoneyResult2.Text = txtMoneyDisplay2.Text;
            txtMoneyResult3.Text = txtMoneyDisplay3.Text;
            txtRename.Text = user.WalletList.ElementAt(cbWallets.SelectedIndex).WalletName;
            btnRename.Enabled = false;
            String[] exchangeCurrencies = getCurrentWallet().Currencies;
            cmbWalletsCurrencies.DataSource = exchangeCurrencies.Clone();
            cmbWalletsCurrencies.Text = "From";
            cmbCompleteCurrencies.DataSource = exchangeCurrencies.Clone();
            cmbCompleteCurrencies.Text = "To";

        }

        private void txtRename_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRename.Text != user.WalletList.ElementAt(cbWallets.SelectedIndex).WalletName)
            {
                btnRename.Enabled = true;
            }

            if (txtRename.Text.Trim().Equals(""))
            {
                btnRename.Enabled = false;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            String reName = txtRename.Text;
            int walletID = Properties.Settings.Default.CurrentWalletID;

            if (reName.Length < 20)
            {
                if (DatabaseConnection.walletRename(walletID, reName))
                {
                    getCurrentWallet().WalletName = reName;
                    cbWallets.Items[cbWallets.SelectedIndex] = getCurrentWallet();
                    tabPage3.Text = getCurrentWallet().WalletName;
                    MessageBox.Show("Wallet successfully renamed!", "Rename", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please consider a shorter name.", "New Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCurrencySettingUpdate_Click(object sender, EventArgs e)
        {
            int walletID = Properties.Settings.Default.CurrentWalletID;
            String[] currencies = new string[3];
            currencies[0] = cbCurrencySettings1.Text;
            currencies[1] = cbCurrencySettings2.Text;
            currencies[2] = cbCurrencySettings3.Text;

            if (currencies.Count() != (currencies.Distinct().Count()))/*to check if there are duplicate values*/
            {

                MessageBox.Show("You need to choose 3 different currencies.", "Currency Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DatabaseConnection.updateCurrencySettings(currencies))
                {/*Following code block is getting wallet's data and replace it user's walletlist*/
                    String[] walletNamePlusWanted = new string[2];
                    walletNamePlusWanted = DatabaseConnection.walletNamePlusWanted(walletID);
                    Wallet tempWallet = new Wallet(walletID, walletNamePlusWanted[0], walletNamePlusWanted[1]);
                    user.WalletList.Find(getCurrentWallet()).Value = tempWallet;

                    /*Following code block is changing amounts,currency names at the other tab*/
                    lblMoney1.Text = getCurrentWallet().Currencies[0];
                    lblMoney2.Text = getCurrentWallet().Currencies[1];
                    lblMoney3.Text = getCurrentWallet().Currencies[2];

                    txtMoneyDisplay1.Text = Convert.ToString(getCurrentWallet().Amounts[0]);
                    txtMoneyDisplay2.Text = Convert.ToString(getCurrentWallet().Amounts[1]);
                    txtMoneyDisplay3.Text = Convert.ToString(getCurrentWallet().Amounts[2]);
                    txtMoneyResult1.Text = txtMoneyDisplay1.Text;
                    txtMoneyResult2.Text = txtMoneyDisplay2.Text;
                    txtMoneyResult3.Text = txtMoneyDisplay3.Text;
                    String[] exchangeCurrencies = getCurrentWallet().Currencies;
                    cmbCompleteCurrencies.DataSource = exchangeCurrencies.Clone();
                    cmbWalletsCurrencies.DataSource = exchangeCurrencies.Clone();


                    MessageBox.Show("Currency settings has successfully changed.", "Change Accomplished", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void cbCurrencySettings1_Enter(object sender, EventArgs e)
        {
            cbCurrencySettings1.DataSource = allNames.Clone();



        }

        private void cbCurrencySettings2_Enter(object sender, EventArgs e)
        {
            cbCurrencySettings2.DataSource = allNames.Clone();

        }

        private void cbCurrencySettings3_Enter(object sender, EventArgs e)
        {
            cbCurrencySettings3.DataSource = allNames.Clone();

        }
        private NumericUpDown[] numericUpdowns() /* to make accessing to numericupdowns will be easier*/
        {
            NumericUpDown[] cmbs = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3 };
            return cmbs;
        }
    }
}
