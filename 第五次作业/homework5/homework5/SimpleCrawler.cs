using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace homework5
{
    class SimpleCrawler

    {
        public string url { get; set; }    //起始网址
        public bool processing { get; set; }//是否正在运行

        public int MaxNum { get; set; }     // 最大下载数量


        private Hashtable urls = new Hashtable();
        private ConcurrentQueue<string> waitingUrls = new ConcurrentQueue<string>();
        public event Action<SimpleCrawler, int, string, string> HtmlDownloaded;
        public event Action<SimpleCrawler> Stopped;
        public SimpleCrawler()
        {
            processing = true;

        } 

        public void Start()
        {
            urls = urls = Hashtable.Synchronized(new Hashtable());
            waitingUrls = new ConcurrentQueue<string>();

            waitingUrls.Enqueue(url);

            List<Task> tasks = new List<Task>();
            int completedNum = 0;
            HtmlDownloaded += (crawler, indexer, urls, info) => { completedNum++; };

            while (tasks.Count < MaxNum)
            {
                if (!processing)
                {
                    break;
                }
                int index = tasks.Count + 1;
                Task task = Task.Run(() => Process(url, index));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            Stopped(this);
        }
        private void Process(string url, int index)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                urls[url] = true;

                if (html == null) return;

                Parse(url, html);                               // 解析新的url
                HtmlDownloaded(this, index, url, "Success");
            }
            catch (Exception e)
            {
                HtmlDownloaded(this, index, url, "Error: " + e.Message);
            }
        }
          

        private void Parse(string oldUrl, string html)
        {

            //匹配不含相对路径,且包含html的网址
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'](http|https)[^""'#>]+..html.*?[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                var url = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (url.Length == 0)
                    continue;
                //仅包含起始网站上的网页
                if (url.Contains("https://www.cnblogs.com"))
                {
                    if (urls[url] == null)
                        urls[url] = false;
                }
            }

            //匹配相对路径,且包含html的网址

            strRef = @"(href|HREF)[ ]*=[ ]*[""'][^(http|https)][^""'#>]+..html.*?[""']";
            matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                var url = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (url.Length == 0) continue;
                Uri baseUri = new Uri(oldUrl);
                Uri absoluteUri = new Uri(baseUri, url);
                Console.WriteLine("相对:" + url);
                Console.WriteLine("绝对:" + absoluteUri.ToString());
                if (urls[absoluteUri.ToString()] == null)
                    urls[absoluteUri.ToString()] = false;
            }
        }
    }
}
