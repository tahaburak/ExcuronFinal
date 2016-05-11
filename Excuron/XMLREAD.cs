using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Excuron
{
    class XMLREAD
    {
        static String[] currencyDataForListBox = new String[32];//definition
        static String[] currencyDataForComboBox = new String[32];//definition
        static String[] currencyPricesArray = new String[32];//definition
        static String keepDateAsString = "";//in order to have string instance of currency dates
        static String theDayToShowString = formMain.TheDayToShowString;// the day that user want to choose as string
        static Decimal[] decimalReturn;//to keep compared currencies
        static LinkedList<String> dates = new LinkedList<String>();//dates of oldCurrencies

        public static LinkedList<String> Dates //setter-getter to keep dates we want to see in our chart
        {
            get { return XMLREAD.dates; }
            set { XMLREAD.dates = value; }
        }

        public static Decimal[] DecimalReturn //encapsulation for to retrieve compared data
        {
            get { return XMLREAD.decimalReturn; }
            set { XMLREAD.decimalReturn = value; }
        }
        //Next 4 functions for the passing values between classes
        public static string KeepDateAsString
        {
            get
            {
                return keepDateAsString;
            }

            set
            {
                keepDateAsString = value;
            }
        }

        public static string[] CurrencyDataForListBox
        {
            get
            {
                return currencyDataForListBox;
            }

            set
            {
                currencyDataForListBox = value;
            }
        }

        public static string[] CurrencyDataForComboBox
        {
            get
            {
                return currencyDataForComboBox;
            }

            set
            {
                currencyDataForComboBox = value;
            }
        }

        public static string[] CurrencyPricesArray
        {
            get
            {
                return currencyPricesArray;
            }

            set
            {
                currencyPricesArray = value;
            }
        }


        //The Main One for this class
        static XmlReader xml = null;

        public static XmlReader Xml
        {
            get { return XMLREAD.xml; }
            set { XMLREAD.xml = value; }
        }

        public static Boolean checkConnection()
        {
            try
            {
                XmlReader xx = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");//pointer to xml page
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void readtheXml()
        {
            LinkedList<string> currencyNamesListTEMP = new LinkedList<string>();//TEMP first address to put incoming currency names from xml page
            LinkedList<string> currencyPricesListTEMP = new LinkedList<string>();//TEMP first address to put incoming currency prices from xml page

            String[] currencyDataForListBoxTEMP = new String[32];//TEMP definition
            String[] currencyDataForComboBoxTEMP = new String[32];//TEMP definition
            String[] currencyPricesArrayTEMP = new String[32];//TEMP definition
            theDayToShowString = formMain.TheDayToShowString; //getting value from formmain
            Boolean flag = false;// to get only neccessary currencies
            DateTime date = new DateTime(); // to get date from XML

            try
            {
                Xml = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");//pointer to xml page
            }
            catch (Exception)
            {

            }

            if (xml != null)
            {

                while (Xml.Read())
                {
                    if ((Xml.NodeType == XmlNodeType.Element && (Xml.Name == "Cube")))//if node has element such as "<some_text>" && and if that "some_text" equals to "Cube"
                    {
                        if (Xml.AttributeCount == 1)
                        {//if element has one attribute "<some_text attr1="something">"
                            //xml.MoveToAttribute("time");//go to the specified attribute name, search for it
                            date = DateTime.Parse(Xml.GetAttribute("time"));//parse that value into dateTime then assaign to date
                            KeepDateAsString = date.ToString();//parse dateTime to String

                            if (KeepDateAsString.Equals(theDayToShowString + " 00:00:00") || (flag == true))
                            {
                                flag = !flag;
                            }
                        }
                        if (Xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                        {
                            if (flag)
                            {// if flag is true that means we found right date in xml page, so we can put incoming data to LinkedLists

                                currencyNamesListTEMP.AddLast(Xml.GetAttribute("currency"));//adding incoming data to list
                                currencyPricesListTEMP.AddLast(Xml.GetAttribute("rate"));//adding incoming data to list
                            }
                        }
                    }
                }
                if (currencyNamesListTEMP.Count > 0)
                {
                    currencyNamesListTEMP.AddFirst("EUR"); currencyPricesListTEMP.AddFirst("1");
                }
                currencyDataForComboBoxTEMP = currencyNamesListTEMP.ToArray();// casting LinkedList to Array
                currencyDataForListBoxTEMP = currencyNamesListTEMP.ToArray();//casting LinkedList to Array
                currencyPricesArrayTEMP = currencyPricesListTEMP.ToArray();//casting LinkedList to Array
                CurrencyDataForComboBox = currencyDataForComboBoxTEMP;//getting rid of from TEMPs
                CurrencyDataForListBox = currencyDataForListBoxTEMP;//getting rid of from TEMPs
                CurrencyPricesArray = currencyPricesArrayTEMP;//getting rid of from TEMPs
                formMain.ToolStripStatusLabel1Text = ("Showing Date: " + theDayToShowString + " Up-dated: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now));//showing the time when we connected to xml web page

            }
        }

        public static void getOneCurrencyData(String target)
        {
            XmlReader xml = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");
            dates.Clear();
            LinkedList<Decimal> ratesLinkedList = new LinkedList<Decimal>();//data structure to keep right currency rate

            int countX = 0;
            Boolean flag = true;
            String rate;//definition
            DateTime pickedDate = Convert.ToDateTime(theDayToShowString + " 00:00:00");
            if ((System.DateTime.Now.Date - pickedDate).TotalDays > 21)
            {
                while (xml.Read() && flag)
                {
                    String keepDate = "";
                    if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Cube"))
                    {
                        if (xml.AttributeCount == 1)//if element has one attribute "<some_text attr1="something">"
                        {
                            DateTime dt = new DateTime();
                            dt = DateTime.Parse(xml.GetAttribute("time"));//get date and parse it to dt variable
                            keepDate = dt.ToShortDateString();//change format of dt and keep as a string
                            //keepDate.Equals(theDayToShowString)
                            Dates.AddLast(keepDate);//add to list
                            if (keepDate.Equals(theDayToShowString))
                            {
                                flag = false;//cant get current days price, dunno why. will check later

                            }

                        }
                        else if (xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                        {

                            String pivot = String.Format(xml.GetAttribute("currency"));//pivot keeps change at each while iteration
                            if (pivot.Equals(target.ToUpper()))//this part or following if else will iterate
                            {
                                //countX++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                if (formChart.IsReverted)
                                {
                                    ratesLinkedList.AddLast(1 / decRate);
                                }
                                else
                                {
                                    ratesLinkedList.AddLast(decRate);
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                while (xml.Read() && (countX) < 16)
                {
                    String keepDate = "";
                    if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Cube"))
                    {
                        if (xml.AttributeCount == 1)//if element has one attribute "<some_text attr1="something">"
                        {
                            DateTime dt = new DateTime();
                            dt = DateTime.Parse(xml.GetAttribute("time"));//get date and parse it to dt variable
                            keepDate = dt.ToShortDateString();//change format of dt and keep as a string
                            //keepDate.Equals(theDayToShowString)
                            Dates.AddLast(keepDate);//add to list


                        }
                        else if (xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                        {

                            String pivot = String.Format(xml.GetAttribute("currency"));//pivot keeps change at each while iteration, 
                            //if its equals to the currency we want then 
                            if (pivot.Equals(target.ToUpper()))//this part or following if else will iterate
                            {
                                //countX++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                if (formChart.IsReverted)
                                {
                                    ratesLinkedList.AddLast(1 / decRate);
                                }
                                else
                                {
                                    ratesLinkedList.AddLast(decRate);
                                }

                                countX++;
                            }
                        }
                    }
                }
            }

            DecimalReturn = ratesLinkedList.ToArray();


        }
        public static Decimal exchangeRate(String[] arrayFromTo)
        {
            
            
            String from = arrayFromTo[0], to = arrayFromTo[1];

            XmlReader xml = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            LinkedList<string> currencyNamesList = new LinkedList<string>();//TEMP first address to put incoming currency names from xml page
            LinkedList<string> currencyPricesList = new LinkedList<string>();//TEMP first address to put incoming currency prices from xml page
           
            while (xml.Read())
            {
                if ((xml.NodeType == XmlNodeType.Element && (xml.Name == "Cube")))//if node has element such as "<some_text>" && and if that "some_text" equals to "Cube"
                {
                    if (xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                    {
                        String pivot = String.Format(xml.GetAttribute("currency"));
                        if((from.ToUpper().Equals(pivot)) || (to.ToUpper().Equals(pivot))){

                            currencyNamesList.AddLast(xml.GetAttribute("currency"));//adding incoming data to list
                            currencyPricesList.AddLast(xml.GetAttribute("rate"));//adding incoming data to list
                        }
                    }
                }
            }
            if (from.Equals("EUR"))
            {
                currencyNamesList.AddFirst("EUR");
                currencyPricesList.AddFirst("1");
            }
            else if (to.Equals("EUR"))
            {
                 currencyNamesList.AddLast("EUR");
                currencyPricesList.AddLast("1");
            }
            
            Decimal rate;
            if(currencyNamesList.ElementAt(0).Equals(from)){
                Decimal first = Math.Round((Decimal.Parse(currencyPricesList.ElementAt(1), CultureInfo.InvariantCulture)),7);
                Decimal second = Math.Round((Decimal.Parse(currencyPricesList.ElementAt(0), CultureInfo.InvariantCulture)), 7);
                rate = Math.Round((first * (1 / second)), 5);
                
            }
            else
            {
                Decimal first = Math.Round((Decimal.Parse(currencyPricesList.ElementAt(0), CultureInfo.InvariantCulture)), 7);
                Decimal second = Math.Round((Decimal.Parse(currencyPricesList.ElementAt(1), CultureInfo.InvariantCulture)), 7);
                rate = Math.Round((first * (1 / second)), 5);
            }

            return rate;
        }

        public static void getOldValues(String from, String to)// method to get old time currency datas and for compare those
        {
            XmlReader xml = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");
            String whichOneIsLast = "";//will clarify that later, move on
            dates.Clear();

            LinkedList<Decimal> finalRatesLinkedList = new LinkedList<Decimal>();//data structure to keep right currency rate
            LinkedList<Decimal> finalComparisionDone = new LinkedList<Decimal>();//data structure to keep final results, comparision done
            int countX = 0;
            int countY = 0;
            //&& (countX | countY)<8
            String rate;//definition
            Boolean flag = true;


            DateTime pickedDate = Convert.ToDateTime(theDayToShowString + " 00:00:00");
            if ((System.DateTime.Now.Date - pickedDate).TotalDays > 21)
            {
                //CrossConvertionOneMonth = true;
                while (xml.Read() && flag)
                {
                    String keepDate = "";
                    if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Cube"))
                    {
                        if (xml.AttributeCount == 1)//if element has one attribute "<some_text attr1="something">"
                        {
                            DateTime dt = new DateTime();
                            dt = DateTime.Parse(xml.GetAttribute("time"));//get date and parse it to dt variable
                            keepDate = dt.ToShortDateString();//change format of dt and keep as a string
                            //keepDate.Equals(theDayToShowString)
                            Dates.AddLast(keepDate);//add to list
                            if (keepDate.Equals(theDayToShowString))
                            {
                                flag = false;//cant get current days price, dunno why. will check later

                            }

                        }
                        else if (xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                        {
                            //xml.MoveToAttribute("currency");
                            String pivot = String.Format(xml.GetAttribute("currency"));//pivot keeps change at each while iteration, 
                            //if its equals to the currency we want then 
                            if (pivot.Equals(from.ToUpper()))//this part or following if else will iterate
                            {
                                //countX++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                finalRatesLinkedList.AddLast(decRate);//add rate to list
                                whichOneIsLast = "toIsLast";//---1*---since we dont know which if or if else block is triggered first we 
                                //need a reference to distinguish which order they have 
                            }
                            else if (pivot.Equals(to.ToUpper()))
                            {
                                //countY++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                finalRatesLinkedList.AddLast(decRate);//add rate to list
                                whichOneIsLast = "fromIsLast";//explanation done above, ref 1*
                            }
                        }
                    }
                }
            }
            else
            {
                //CrossConvertionOneMonth = false;
                while (xml.Read() && (countX | countY) < 16)
                {
                    String keepDate = "";
                    if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Cube"))
                    {
                        if (xml.AttributeCount == 1)//if element has one attribute "<some_text attr1="something">"
                        {
                            DateTime dt = new DateTime();
                            dt = DateTime.Parse(xml.GetAttribute("time"));//get date and parse it to dt variable
                            keepDate = dt.ToShortDateString();//change format of dt and keep as a string
                            //keepDate.Equals(theDayToShowString)
                            Dates.AddLast(keepDate);//add to list


                        }
                        else if (xml.AttributeCount == 2)//if element has two attribute "<some_text attr1="some" attr2="thing">"
                        {
                            //xml.MoveToAttribute("currency");
                            String pivot = String.Format(xml.GetAttribute("currency"));//pivot keeps change at each while iteration, 
                            //if its equals to the currency we want then 
                            if (pivot.Equals(from.ToUpper()))//this part or following if else will iterate
                            {
                                //countX++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                finalRatesLinkedList.AddLast(decRate);//add rate to list
                                whichOneIsLast = "fromIsLast";//---1*---since we dont know which if or if else block is triggered first we 
                                //need a reference to distinguish which order they have 
                                countX++;
                            }
                            else if (pivot.Equals(to.ToUpper()))
                            {
                                //countY++;
                                rate = xml.GetAttribute("rate");//get rate of desired currency
                                Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                                finalRatesLinkedList.AddLast(decRate);//add rate to list
                                whichOneIsLast = "toIsLast";//explanation done above, ref 1*
                                countY++;
                            }
                        }
                    }
                }
            }

            if (whichOneIsLast.Equals("fromIsLast"))//we will perform cross-conversion according to order
            {
                Decimal[] temp;
                temp = finalRatesLinkedList.ToArray();//get result of while block
                for (int i = 0; i < (temp.Length) - 1; i += 2)
                {
                    finalComparisionDone.AddLast((temp[i + 1] * (1 / (temp[i]))));//does conversion
                }
            }
            else if (whichOneIsLast.Equals("toIsLast"))//we will perform cross-conversion according to order
            {
                Decimal[] temp;
                temp = finalRatesLinkedList.ToArray();
                for (int i = 0; i < (temp.Length) - 1; i += 2)
                {
                    finalComparisionDone.AddLast((temp[i] * (1 / (temp[i + 1]))));
                }
            }


            DecimalReturn = finalComparisionDone.ToArray();//finally assaign list to an array

        }
        static Decimal lastRate;

        public static Decimal LastRate
        {
            get { return XMLREAD.lastRate; }
            set { XMLREAD.lastRate = value; }
        }
        static Decimal aver;

        public static Decimal Aver
        {
            get { return XMLREAD.aver; }
            set { XMLREAD.aver = value; }
        }

        public static int giveSuggestion(String from, String to)
        {
            LinkedList<Decimal> finalRatesLinkedListFROM = new LinkedList<Decimal>();//data structure to keep right currency rate
            LinkedList<Decimal> finalRatesLinkedListTO = new LinkedList<Decimal>();
            LinkedList<Decimal> averageRatesLinkedList = new LinkedList<Decimal>();
            
            int countX = 0;
            int countY = 0;

            String rate;//definition


            XmlReader xml = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");//pointer to xml page


            while (xml.Read() && (countX < 8 || countY < 8) && !(countX > 8 || countY > 8))
            {
                if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Cube"))
                {
                    if (xml.AttributeCount == 2)
                    {
                        String pivot = String.Format(xml.GetAttribute("currency"));//pivot keeps change at each while iteration, 
                        //if its equals to the currency we want then 
                       
                        if (pivot.Equals(from.ToUpper()))//this part or following if else will iterate
                        {

                            rate = xml.GetAttribute("rate");//get rate of desired currency
                            Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                            finalRatesLinkedListFROM.AddLast(decRate);//add rate to list

                            countX++;
                        }
                        else if (pivot.Equals(to.ToUpper()))
                        {

                            rate = xml.GetAttribute("rate");//get rate of desired currency
                            Decimal decRate = Math.Round((Decimal.Parse(rate, CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                            finalRatesLinkedListTO.AddLast(decRate);//add rate to list

                            countY++;
                        }
                       
                    }
                }
            }

            if ((countX == 0 || countY == 0))
            {
                if (from.ToUpper().Equals("EUR"))
                {
                    countX = 9;
                    for (int i = 0; i < countX; i++)
                    {
                         Decimal decRate = Math.Round((Decimal.Parse("1", CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                            finalRatesLinkedListFROM.AddLast(decRate);//add rate to list
                    }
                }
                else
                {
                    countY = 9;
                    for (int i = 0; i < countY; i++)
                    {
                        Decimal decRate = Math.Round((Decimal.Parse("1", CultureInfo.InvariantCulture)), 7);//parse incoming xml rate to decimal
                        finalRatesLinkedListTO.AddLast(decRate);//add rate to list
                    }
                }
                
            }
            int result = 2; // null condition
            if (!(countX == 0 || countY == 0))
            {

                for (int i = 0; i < countX; i++)
                {
                    averageRatesLinkedList.AddLast(Math.Round(finalRatesLinkedListTO.ElementAt(i) * (1 / finalRatesLinkedListFROM.ElementAt(i)), 7));
                }

                Decimal total = averageRatesLinkedList.Sum();
                Decimal average = Math.Round((total / countX),4);
                aver = average;
                lastRate = averageRatesLinkedList.First();
                if (average > averageRatesLinkedList.First())
                {
                    result = 0; // 0 means dont buy it, rate is decreasing
                }
                else
                {
                    result = 1;// 1 means go for it, buy --> average< last days price so rate is increasing
                }
            }
            
            return result;
        }
    }


}
