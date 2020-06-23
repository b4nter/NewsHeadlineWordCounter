using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsHeadlineWordCounter
{
    public class NewsHeadlineScanner
    {
        private string _titlesFilePath;
        private string _urlFilePath;
        public string _urls;
        public string _titles;
        public int _newTitles;        
        public string _updateMessage { get; set; }

        public NewsHeadlineScanner(string titlesFilePath, string urlFilePath)
        {
            _titlesFilePath = titlesFilePath;
            _urlFilePath = urlFilePath;
            _titles = File.ReadAllText(titlesFilePath);
            _urls = File.ReadAllText(urlFilePath);
            _newTitles = 0;
        }

        public void AddUrl(string url)
        {
            if (!_urls.Contains(url))
            {
                File.AppendAllText(_urlFilePath, url + Environment.NewLine);
            }
        }

        public void UpdateTitles()
        {
            _updateMessage = "";
            var urlList = _urls.Split(Environment.NewLine.ToCharArray());
            foreach (var url in urlList)
            {                
                if (!string.IsNullOrEmpty(url))
                {
                    ReadRssFeed(url);
                }
            }
        }

        public void ReadRssFeed(string url)
        {
            _newTitles = 0;
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                foreach (SyndicationItem item in feed.Items)
                {
                    var title = $"{item.PublishDate.Date} - {item.Title.Text}{Environment.NewLine}";
                    if (item.PublishDate.Date >= DateTime.Now.Date.AddDays(-1))
                    {
                        if (!_titles.Contains(title))
                        {
                            File.AppendAllText(_titlesFilePath, title);
                            _newTitles++;
                        }
                    }
                }
                _titles = File.ReadAllText(_titlesFilePath);
                _updateMessage += $"{_newTitles} new titles added from {feed.Title.Text}{Environment.NewLine}";                
            }
        }
    }
}
