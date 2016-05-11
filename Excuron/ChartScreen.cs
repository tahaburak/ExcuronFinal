using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;


namespace Excuron
{
    public partial class formChart : Form
    {

        public Form RefToFirstForm { get; set; }//new form instance to communicate with FormMain

        public formChart()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            if (formMain.isChecked())
            {
                XMLREAD.getOldValues(formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex], formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex]);
            }
            else {
                XMLREAD.getOneCurrencyData(formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex]);
            }
            /*if (XMLREAD.CrossConvertionOneMonth)
            {
                cbRevert.CheckState = CheckState.Checked;
            }*/
            drawChart();
        }

        private void btnSecFormOpenFirstForm_Click(object sender, EventArgs e)
        {
            //openChart.Visible = false;
            IsReverted = false;
            if (formMain.CbClone != null)
            {
                formMain.CbClone.Checked = false;
            }
            this.Dispose();
            this.Close();//close chart form
            RefToFirstForm.Show();// open back main form with old values

        }
        static Boolean isReverted = false;

        public static Boolean IsReverted
        {
            get { return formChart.isReverted; }
            set { formChart.isReverted = value; }
        }
        public void drawChart()
        {
            //checkBox1.Text = XMLREAD.CrossConvertionOneMonth.ToString();

            Decimal[] duplicateOldValueArray = XMLREAD.DecimalReturn;
            String[] datesOfOldCurrencies = XMLREAD.Dates.ToArray();
            Double minimumValueOfCurrentSet = 0;//to hold min value inside array, not necessary at all but better to have it as a variable instead of calling it each time we need it
            Double maximumValueOfCurrentSet = 0;
            crtCurrency.ChartAreas[0].AxisX.Interval = 1;

            for (int i = XMLREAD.DecimalReturn.Length - 1; i >= 0; i--)
            {
                crtCurrency.Series["Rate"].Points.AddXY(datesOfOldCurrencies[i], Math.Round(duplicateOldValueArray[i], 7));//adding values to chart, rounding y-axis values to 4 digit decimal
            }

            minimumValueOfCurrentSet = (Double)Math.Round(duplicateOldValueArray.Min(), 6);//lowest value appear in current array, rounded to 6 decimal points
            maximumValueOfCurrentSet = (Double)Math.Round(duplicateOldValueArray.Max(), 6);//highest value appear in current array, rounded to 6 decimal points

            this.crtCurrency.ChartAreas[0].AxisY.Minimum = minimumValueOfCurrentSet - ((maximumValueOfCurrentSet - minimumValueOfCurrentSet) / 2);//this part is the where we assign our minimum y-axis value
            crtCurrency.Series["Rate"].BorderWidth = 3;//to make chart drawings thicker

            /*Starting from this lane through the end label the code below is from stackoverflow*/
            Series s = crtCurrency.Series[0];//to not call each time we need series property, we created new fixed variable
            List<DataPoint> ptS = s.Points.OrderBy(x => x.YValues[0]).ToList();//probably getting y-axis values into a set to make labels from them
            for (int p = 0; p < ptS.Count; p++)
            {
                ptS[p].ToolTip = ptS[p].YValues[0].ToString("##0.0000000");//constructing a label for each breaking point of the chart
            }
            /*End*/
            if (IsReverted == false)
            {
                if (formMain.isChecked())
                {
                    crtCurrency.Legends["Legend1"].Title = formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex] + "/" + formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex];
                }
                else
                {
                    crtCurrency.Legends["Legend1"].Title = "EURO/" + formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex];
                }
            }
        }

        private void formChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsReverted = false;
    this.Dispose();
        
            RefToFirstForm.Show();// Just a small improvement. When user close the chart form, gets redirected back to main form just like the button on the formChart
        }

        private void crtCurrency_MouseMove(object sender, MouseEventArgs e)//mouseMove method for track values more visualized
        {
            /*Code below is from stackoverflow*/
            Point mousePoint = new Point(e.X, e.Y);//creating a new point object in order to get where is the mouse on the chart
            ChartArea crtArea = crtCurrency.ChartAreas[0];
            crtArea.CursorX.LineColor = SystemColors.ControlDark;
            crtArea.CursorY.LineColor = SystemColors.ControlDark;
            crtArea.CursorX.LineWidth = 2;
            crtArea.CursorY.LineWidth = 2;
            crtArea.CursorX.Interval = 0;//we set interval to zero for get rid of latency between values when mouse is dragged
            crtArea.CursorY.Interval = 0;

            crtArea.CursorX.SetCursorPixelPosition(mousePoint, true);//probably this is the part we draw the anchor on the chart
            crtArea.CursorY.SetCursorPixelPosition(mousePoint, true);
        }

        private void cbEnable3D_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnable3D.Checked)
            {
                crtCurrency.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
            else {
                crtCurrency.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            }
        }

        private void cbRevert_CheckedChanged(object sender, EventArgs e)
        {
            timer.Interval = 1500;
            timer.Tick += timer_Tick;
            timer.Start();
            cbRevert.Enabled = false;
            IsReverted = true;
            if (cbRevert.Checked)
            {
                crtCurrency.Series["Rate"].Points.Clear();
                crtCurrency.Legends["Legend1"].Title = formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex] + "/" + formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex];
                if (formMain.isChecked())
                {
                    XMLREAD.getOldValues(formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex], formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex]);
                    crtCurrency.Legends["Legend1"].Title = formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex] + "/" + formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex];
                    drawChart();
                }
                else
                {
                    XMLREAD.getOneCurrencyData(formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex]);

                    crtCurrency.Legends["Legend1"].Title = formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex] + "/EURO";
                    drawChart();
                }
            }
            else {
                crtCurrency.Series["Rate"].Points.Clear();
                IsReverted = false;
                if (formMain.isChecked())
                {
                    XMLREAD.getOldValues(formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex], formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex]);
                    crtCurrency.Legends["Legend1"].Title = formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex] + "/" + formMain.CurrencyDataForComboBox[formMain.SelectedComboBoxIndex];
                    drawChart();
                }
                else
                {
                    XMLREAD.getOneCurrencyData(formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex]);
                    crtCurrency.Legends["Legend1"].Title = "EURO/" + formMain.CurrencyDataForComboBox[formMain.SelectedListBoxIndex];
                    drawChart();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            cbRevert.Enabled = true;
            timer.Stop();
        }
    }
}
