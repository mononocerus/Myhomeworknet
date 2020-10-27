using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections;


namespace homework5
{
    public partial class Form1 : Form
    {
        private SimpleCrawler crawler = new SimpleCrawler();



        public Form1()
        {
            InitializeComponent();

            crawler.Stopped += CrawlerStopped;
            crawler.HtmlDownloaded += HtmlDownloaded;
        }
        private void HtmlDownloaded(SimpleCrawler crawler, int index, string url, string info)
        {
            string msg = $"{index}\t{url}\t{info}\r\n";
            Action action = () => { outputbox.AppendText(msg); };

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void CrawlerStopped(SimpleCrawler crawler)
        {
            string msg = $"爬虫已终止...\r\n";
            Action action = () => { outputbox.AppendText(msg); };

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            crawler.url =url_textbox.Text;
            crawler.MaxNum = Convert.ToInt32(sum_textbox.Text);

            Thread thread = new Thread(new ThreadStart(crawler.Start));
            thread.Start();

        }

        private void stop_Click(object sender, EventArgs e)
        {
            crawler.processing = false;
        }
    }
}
