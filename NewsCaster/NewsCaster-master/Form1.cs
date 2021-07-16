using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Net;
using System.IO;
using Newtonsoft;
using System.Web;
using Newtonsoft.Json;
using Bunifu;


namespace NewsCaster
{
    public partial class Form1 : Form
    {
        int increment = 1;

        //As such I am not using all these properties into my code.
        //But Things mention in proprty are availabe and you can use them in parsing data.
        private string SourceStatus { get; set; }
        public string status { get; set; }
        public string totalResults { get; set; }
        public string articles { get; set; }
        public string source { get; set; }
        public string id { get; set; }
        public string  name { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }


        public Form1()
        {
            SourceStatus = "Default";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetNews();
        }

        public void GetNews(int NewsNumber=1)
        {
                lblNetStatus.Text = "Connected to internet";
                string query = "United State";
                try
                {
                    WebRequest request = WebRequest.Create("http://newsapi.org/v2/top-headlines?q=" + query + "&apiKey=");
                    request.Credentials = CredentialCache.DefaultCredentials;
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    var obj = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer);
                    
                    urlToImage = obj["articles"][NewsNumber]["urlToImage"].ToString();
                    picBox.ImageLocation = urlToImage;
                    lblAuthor.Text = obj["articles"][NewsNumber]["author"].ToString();
                    richTxt.Text = obj["articles"][NewsNumber]["content"].ToString();
                    lblUrlmore.Text = obj["articles"][NewsNumber]["url"].ToString();
                    url = obj["articles"][NewsNumber]["url"].ToString();
                    lblNewsSource.Text = obj["articles"][NewsNumber]["publishedAt"].ToString();
                    description = obj["articles"][NewsNumber]["description"].ToString();

                    
                        string lengthoflbl = obj["articles"][NewsNumber]["title"].ToString();
                        if (lengthoflbl.Length > 75)
                        {
                            string one = lengthoflbl.Substring(0, 75);
                            string two = lengthoflbl.Substring(75);
                            lblTitle.Text = one + ".." + "\n" + two;

                        }
                        else
                        {
                            lblTitle.Text = obj["articles"][NewsNumber]["title"].ToString();
                        }
                    
                    
                    response.Close();
                }
                catch (Exception catched)
                {
                    MessageBox.Show("The data you are searching for is not available\nOR Internnet connection problem","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    lblNetStatus.Text = "Not Connected to internet or slow connection";
                }  
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ++increment;
            if (increment <= 19)
            {
                
                GetNews(increment);
  
            }
            else
            {
                MessageBox.Show("No More news for now");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (increment > 1)
            {
                increment--;
                GetNews(increment);
            }
            else if (increment < 1)
            {
                MessageBox.Show("This is the 1st news you are reading");
            }
        }
        private void lblUrlmore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetNews();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            NewsAnchor.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Text2Speech.Speak(description);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            NewsAnchor.Visible = false;
        }
    }
}

