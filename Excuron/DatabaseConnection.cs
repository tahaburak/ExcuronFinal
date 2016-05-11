using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Excuron
{
    class DatabaseConnection
    {
    /*
    Contact for connection strings.
    */
        private static string server = "***";
        private static string database = "ExcuronDB";
        private static string uid = "***";
        private static string password = "***";
        private static string connectionString = "SERVER=" + server + ";PORT=3306;" + "USERNAME=" + uid + ";" + "PASSWORD=" + password + ";" + "DATABASE=" + database + ";";
        private static MySqlConnection connection = new MySqlConnection(connectionString);
        public static Boolean hasDatabaseConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }



        public static Boolean logIN(String userMail, String userPassword)/*Log in method*/
        {
            /*  establish connection, define the command, execute, read data, if data email exists, dispose connection */
            connection.Open();
            string cmdText = "Select DBUserID from RegistrationTable where DBEmail='" + userMail + "' and DBPassword='" + userPassword + "';";
            string cmdLastLogin = "UPDATE  RegistrationTable set LastLogDate=now() WHERE  DBEmail='" + userMail + "';";

            MySqlCommand cmd = new MySqlCommand(cmdText, connection), cmdLastLog = new MySqlCommand(cmdLastLogin, connection);

            MySqlDataReader data = cmd.ExecuteReader();
            if (!data.Read())// if there is no such data that means email and password are wrong
            {

                connection.Close();
                return false;
            }
            Properties.Settings.Default.logged = true;
            Properties.Settings.Default.UserID = data.GetInt32(0);
            Properties.Settings.Default.Save();
            data.Close();
            cmdLastLog.ExecuteNonQuery();


            string cmdNumberOfWallets = "Select count(WalletID) from WalletTable where DBUserID =" + Properties.Settings.Default.UserID + ";";

            MySqlCommand cmdNumberOfWallet = new MySqlCommand(cmdNumberOfWallets, connection);


            Properties.Settings.Default.numberOfWallets = int.Parse(cmdNumberOfWallet.ExecuteScalar() + "");
            Properties.Settings.Default.Save();
            connection.Close();
            return true;
        }
        public static string signUp(String userMail, String userPassword) /*Sign up method*/
        {
            int userID = -1, walletID = -1;/*default values*/
                                           /*Check for connection error*/
            try
            {
                connection.Open();
            }
            catch (Exception)
            {

                return "Connection failed";
            }
            connection.Close();

            /*To see if email already exists*/
            if (emailExists(userMail))
            {
                return "Given mail address already exists";
            }


            /*to get ids for new user*/
            userID = getLatest()[0];
            walletID = getLatest()[1];
            if (userID == -1 || walletID == -1)
            {
                return "Empty table";
            }


            return insertNewUser(userID, userMail, userPassword, walletID);
        }

        private static string insertNewUser(int userID, string userMail, string userPassword, int walletID)/*Insert new user*/
        {
            try/* to returning error in exception*/
            {
                /* execution of mysql command is as follows : establish connection, define the command with proper values, execute, dispose connection */

                connection.Open();
                MySqlCommand firstCmd = new MySqlCommand("", connection), secondCmd = new MySqlCommand("", connection);
                firstCmd.CommandText = "INSERT INTO RegistrationTable(DBuserID,DBEmail,DBPassword,RegDate,LastLogDate,WalletID) VALUES(?userid,?usermail,?userpass,now(),now(),?walletid);";
                firstCmd.Parameters.Add("?userid", MySqlDbType.Int32).Value = userID;
                firstCmd.Parameters.Add("?userpass", MySqlDbType.VarChar).Value = userPassword;
                firstCmd.Parameters.Add("?usermail", MySqlDbType.VarChar).Value = userMail;
                firstCmd.Parameters.Add("?walletid", MySqlDbType.Int32).Value = walletID;
                secondCmd.CommandText = "Insert into WalletTable(WalletID,DBUserID,WalletName) VALUES(?walletid,?userid,'Main Wallet'); ";
                secondCmd.Parameters.Add("?userid", MySqlDbType.Int32).Value = userID;
                secondCmd.Parameters.Add("?walletid", MySqlDbType.Int32).Value = walletID;


                firstCmd.ExecuteNonQuery();
                secondCmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                return "ERROR";
            }
            Properties.Settings.Default.UserID = userID;
            Properties.Settings.Default.logged = true;
            Properties.Settings.Default.numberOfWallets = 1;
            Properties.Settings.Default.Save();

            return "UserID:" + userID;/*Since we created the user lets get user's id for further usage*/

        }

        public static bool emailExists(String userMail)
        {/*  establish connection, define the command, execute, read data, if data email exists, dispose connection */

            try
            {
                connection.Open();
            }
            catch (Exception)
            {

                return false;
            }

            string cmdText = "Select DBUserID from RegistrationTable where DBEmail='" + userMail + "';";

            MySqlCommand cmd = new MySqlCommand(cmdText, connection);

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public static int[] getLatest()
        { /*  establish connection, define the command, execute, read data, dispose connection, return proper data */
            int[] array = new int[2];//temp array to get and set values


            connection.Open();
            string cmdText = "Select r.DBUserID,w.WalletID from RegistrationTable r,WalletTable w order by r.DBUserID desc ,w.WalletID desc limit 1;";

            MySqlCommand cmd = new MySqlCommand(cmdText, connection);

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read()) //to get latest userid,walletid from table 
            {
                array[0] = data.GetInt32("DBUserID") + 1;//UserID
                array[1] = data.GetInt32("WalletID") + 1;//WalletID

            }
            connection.Close();

            return array;
        }

        public static Double[] getAmounts(int walletID, String[] currencies)
        {
            Double[] amounts = new Double[3];
            int lenghtOfArray = 0;
            string cmdText = "Select ";
            for (int i = 0; i < currencies.Length; i++)
            {
                if (currencies[i] != null)
                {
                    cmdText += currencies[i] + ",";
                    lenghtOfArray++;
                }
            }
            cmdText = cmdText.Substring(0, cmdText.Length - 1) + " from WalletTable where WalletID='" + walletID + "';";

            connection.Open();

            MySqlCommand cmd = new MySqlCommand(cmdText, connection);

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                for (int i = 0; i < lenghtOfArray; i++)
                {
                    amounts[i] = data.GetDouble(i);
                }
            }
            connection.Close();
            return amounts;

        }



        public static int[] walletIDList()
        {
            int[] array = new int[Properties.Settings.Default.numberOfWallets];

            int DBUserID = Properties.Settings.Default.UserID;
            string cmdText = "Select WalletID from WalletTable where DBUserID=" + DBUserID + ";";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            MySqlDataReader data = cmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                array[i] = data.GetInt32(0);
                i++;
            }



            connection.Close();
            return array;
        }
        public static String[] walletNamePlusWanted(int walletID)
        {
            String[] array = new string[2];
            connection.Open();
            int DBUserID = Properties.Settings.Default.UserID;
            string cmdText = "Select WalletName,Wanted from WalletTable where WalletID=" + walletID + ";";

            MySqlCommand cmd = new MySqlCommand(cmdText, connection);

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                array[0] = data.GetString("WalletName");
                array[1] = data.GetString("Wanted");

            }
            connection.Close();
            return array;
        }

        public static Boolean addWallet(User user, String wanted, String walletName)
        {
            int walletID = -1;
            try
            {
                walletID = getLatest()[1];
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Insert into WalletTable(WalletID,DBUserID,WalletName,Wanted) VALUES(?walletid,?userid,?walletName,?wanted); ";

                cmd.Parameters.Add("?userid", MySqlDbType.Int32).Value = Properties.Settings.Default.UserID;
                cmd.Parameters.Add("?walletid", MySqlDbType.Int32).Value = walletID;
                cmd.Parameters.Add("?walletName", MySqlDbType.VarChar).Value = walletName;
                cmd.Parameters.Add("?wanted", MySqlDbType.VarChar).Value = wanted;
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                connection.Close();
                return false;
            }
            connection.Close();
            Properties.Settings.Default.numberOfWallets++;
            Properties.Settings.Default.Save();
            user.WalletList.AddLast(new Wallet(walletID, walletName, wanted));
            return true;
        }
        public static Boolean deleteWallet(User user, int indexNumber)
        {

            try
            {
                int walletID = user.WalletList.ElementAt(indexNumber).WalletID;
                string cmdText = "Delete from WalletTable where WalletID =" + walletID;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                connection.Close();
                return false;
            }
            connection.Close();
            Properties.Settings.Default.numberOfWallets--;
            Properties.Settings.Default.Save();
            user.WalletList.Remove(user.WalletList.ElementAt(indexNumber));
            return true;
        }

        public static Boolean walletRename(int walletID, String reName)
        {
            try
            {

                string cmdText = "UPDATE WalletTable set WalletName='" + reName 
                    + "'  where WalletID='" + walletID + "';";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
        public static Boolean updateCurrencySettings(String[] currencies)
        {
            try
            {
                int walletID = Properties.Settings.Default.CurrentWalletID;
                string cmdText = "UPDATE WalletTable set Wanted='" 
                    + currencies[0] + currencies[1] + currencies[2] 
                    + "'  where WalletID='" + walletID + "';";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }

        public static Boolean WalletUpdate(User user, Double[] updateAmounts)/*This method will be used for only the submission on 21.04.16*/
        {
            try
            {
                int walletID = Properties.Settings.Default.CurrentWalletID;
                String[] currencies = user.WalletList.ElementAt(Wallet.getWalletIndexWithID(user, walletID)).Currencies;
                connection.Open();
                int DBUserID = Properties.Settings.Default.UserID;
                string cmdText = "UPDATE WalletTable set " 
                    + currencies[0] + "=" + updateAmounts[0].ToString().Replace(',', '.') + "," 
                    + currencies[1] + "=" + updateAmounts[1].ToString().Replace(',', '.') + "," 
                    + currencies[2] + " =" + updateAmounts[2].ToString().Replace(',', '.') 
                    + "  where WalletID='" + walletID + "';";
                MySqlCommand cmd = new MySqlCommand(cmdText, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }

    }

}
