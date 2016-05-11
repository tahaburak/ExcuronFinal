using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excuron
{
    class Wallet
    {
        private int userID = Properties.Settings.Default.UserID, walletID;
        private static int tempIndex=-1;//to get wallets index number by it's id
        private string walletName, wanted;
        private string[] currencies;
        private Double[] amounts,exchangeValues;
    

        public static int getWalletIndexWithID(User user,int walletID)
        {
            for (int i = 0; i < user.WalletList.Count; i++)
            {
                if (user.WalletList.ElementAt(i).walletID==walletID)
                {
                    tempIndex = i;
                }
            }
            return tempIndex;
        }
        public double[] Amounts
        {
            get
            {
                return amounts;
            }

            set
            {
                amounts = value;
            }
        }

        public string[] Currencies
        {
            get
            {
                return currencies;
            }

            set
            {
                currencies = value;
            }
        }

        public string WalletName
        {
            get
            {
                return walletName;
            }

            set
            {
                walletName = value;
            }
        }

        public int WalletID
        {
            get
            {
                return walletID;
            }

            set
            {
                walletID = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public double[] ExchangeValues
        {
            get
            {
                return exchangeValues;
            }

            set
            {
                exchangeValues = value;
            }
        }

        public Wallet(int walletID, string walletName, string wanted)
        {
            this.walletName = walletName;
            this.walletID = walletID;
            this.wanted = wanted;

            Amounts = new Double[3];
            Currencies = new string[3];
            for (int i = 0; i < (wanted.Length) / 3; i++)
            {
                Currencies[i] = wanted.Substring(3 * i, 3);
            }
            this.amounts = DatabaseConnection.getAmounts(walletID, Currencies);


        }
        
        public override String ToString()
        {
            return WalletName;
        }
    }
}
