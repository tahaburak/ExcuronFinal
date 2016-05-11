using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Excuron
{
    public partial class RSSScreen : Form
    {   NotifyIcon notify;
        public RSSScreen(NotifyIcon n)
        {
            this.MaximizeBox = false;
            InitializeComponent();
            notify = n;
        }
        
        public Form RefToFirstForm { get; set; }//new form instance to communicate with FormMain
        String[,] rssData = null;//global array to hold rss data
        /*For settings part*/
        String cnbce = "http://www.cnbc.com/id/10000664/device/rss/rss.html";
        String routers = "http://feeds.reuters.com/news/wealth";
        String efinancialnews = "http://www.efinancialnews.com/tradingandtechnology/foreign-exchange/rss";
        String cnnmoney = "http://www.efinancialnews.com/tradingandtechnology/foreign-exchange/rss";
        String nasdaq = "http://articlefeeds.nasdaq.com/nasdaq/categories?category=Forex+and+Currencies";
        String forbes = "http://www.forbes.com/markets/feed/";
        private String sourceSelection() {
            if(rbCNBC.Checked){
                return cnbce;
            }
            else if(rbCNN.Checked){
                return cnnmoney;
            }
            else if(rbEFinance.Checked){
                return efinancialnews;
            }
            else if(rbForbes.Checked){
                return forbes;
            }
            else if(rbNasdaq.Checked){
                return nasdaq;
            }
            else if(rbRouters.Checked){
                return routers;
            }
            return cnbce;//for null case
        }
        private String[,] getRssData(String channel)
        {
            WebRequest myRequest = WebRequest.Create(channel);
            WebResponse myResponse = myRequest.GetResponse();
            
            Stream rssStream = myResponse.GetResponseStream();
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(rssStream);

            XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");//structure of rss page <rss> at top then inside <channel> then <item>

            String[,] tempRssData=new String[100,5];//getting up to 100 feed, at each feed holding 5 different string value

            for (int i = 0; i < rssItems.Count; i++)
            {
                XmlNode rssNode;
                rssNode = rssItems.Item(i).SelectSingleNode("title");//for retrieve title
                if (rssNode != null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";
                }
                rssNode = rssItems.Item(i).SelectSingleNode("description");//for retrieve description
                if (rssNode != null)
                {
                    String[] format = rssNode.InnerText.Split('<');//In a few rss pages there is html return as <something>, so we split string when we come across with '<'
                    format[0]=format[0].Replace("&#039;", "’");//special character codes
                    format[0] = format[0].Replace("&#39;", "’");
                    format[0] = format[0].Replace("&amp;", "&");
                    format[0] = format[0].Replace("&apos;", "’");
                    format[0] = format[0].Replace("ldquo;", "“");
                    format[0] = format[0].Replace("rdquo;", "”");
                    format[0] = format[0].Replace("nbsp;", " ");
                    format[0] = format[0].Replace("&rsquo;", "’");
                    format[0] = format[0].Replace("&hellip;", "…");
                    tempRssData[i, 1] = format[0];
                }
                else
                {
                    tempRssData[i, 1] = "";
                }
                rssNode = rssItems.Item(i).SelectSingleNode("item");//for retrieve item
                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }
                rssNode = rssItems.Item(i).SelectSingleNode("link");//for retrieve link
                if (rssNode != null)
                {
                    tempRssData[i, 3] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 3] = "";
                }
                rssNode = rssItems.Item(i).SelectSingleNode("pubDate");//for retrieve publish date
                if (rssNode != null)
                {
                    tempRssData[i, 4] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 4] = "";
                }
                
            }
            return tempRssData;
        }

        private void refreshButton_Click(object sender, EventArgs e)//calls getRssData with the link
        {
            titlesComboBox.Items.Clear();//clear previous session
            rssData = getRssData(sourceSelection());//call method and assign that to global rssData
            for (int i = 0; i < rssData.GetLength(0); i++)//String[,]--> 2-dim array, getting length of first dimension-> 0
            {
                if(rssData[i,0]!=null){//add all titles in rss feed to the combo box
                    titlesComboBox.Items.Add(rssData[i, 0]);
                }
                titlesComboBox.SelectedIndex = 0;//show the first one
            }
        }

        private void titlesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rssData[titlesComboBox.SelectedIndex,1]!=null){//change description after selecting a new title from combo box
                descriptionTextBox.Text=rssData[titlesComboBox.SelectedIndex,1];
            }
            if(rssData[titlesComboBox.SelectedIndex,2]!=null){//write link of feed as same as title
                linkLabel.Text = "Go to: " + rssData[titlesComboBox.SelectedIndex, 0];
            }
            if (rssData[titlesComboBox.SelectedIndex, 4] != null)//write publish date of feed
            {
                lblPublishDate.Text = rssData[titlesComboBox.SelectedIndex, 4];
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (titlesComboBox.Items.Count>0)
            {
                if (rssData[titlesComboBox.SelectedIndex, 3] != null)
                {//link of feed


                    //ProcessStartInfo psi = new ProcessStartInfo(rssData[titlesComboBox.SelectedIndex,2]);
                    //Process.Start(psi);
                    System.Diagnostics.Process.Start(rssData[titlesComboBox.SelectedIndex, 3]); 
                }
            }
            else
            {
                MessageBox.Show("Please select a source to retrieve RSS Feeds and then click to Refresh.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefToFirstForm.WindowState = FormWindowState.Normal;
            RefToFirstForm.ShowInTaskbar = true;
            notify.Visible = false;
         
        }
        
    }
}
