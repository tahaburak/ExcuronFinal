using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excuron
{
    class User
    {
        private int DBUserID = Properties.Settings.Default.UserID, numberOfWallets = Properties.Settings.Default.numberOfWallets;
        private int[] walletIDList = new int[Properties.Settings.Default.numberOfWallets];

        private LinkedList<Wallet> walletList = new LinkedList<Wallet>();
        public User()
        {
            walletIDList = DatabaseConnection.walletIDList();
            for (int i = 0; i < numberOfWallets; i++)
            {
                String[] walletNamePlusWanted = new string[2];
                walletNamePlusWanted = DatabaseConnection.walletNamePlusWanted(walletIDList[i]);
                walletList.AddLast(new Wallet(walletIDList[i], walletNamePlusWanted[0], walletNamePlusWanted[1]));
            }
        }

        internal LinkedList<Wallet> WalletList
        {
            get
            {
                return walletList;
            }

            set
            {
                walletList = value;
            }
        }
    }
}
