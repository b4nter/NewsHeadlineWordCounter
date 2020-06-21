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
        private string _titles;
        private string _urlFile;
        public string _urls;
        public string _fileContent;
        public int _newTitles;
        
        public string _updateMessage { get; set; }//***

        public NewsHeadlineScanner(string titles, string urlFile)
        {
            _titles = titles;
            _urlFile = urlFile;
            _fileContent = File.ReadAllText(titles);
            _urls = File.ReadAllText(urlFile);
            _newTitles = 0;
        }

        public void AddUrl(string url)
        {
            if (!_urls.Contains(url))
            {
                File.AppendAllText(_urlFile, url + Environment.NewLine);
            }
        }

        public void Update()
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

                var newTitles = 0;
                foreach (SyndicationItem item in feed.Items)
                {
                    var title = $"{item.PublishDate.Date} - {item.Title.Text}{Environment.NewLine}";
                    if (item.PublishDate.Date >= DateTime.Now.Date.AddDays(-1))
                    {
                        if (!_fileContent.Contains(title))
                        {
                            File.AppendAllText(_titles, title);
                            _newTitles++;
                        }
                    }
                }
                _fileContent = File.ReadAllText(_titles);
                _updateMessage += $"{_newTitles} new titles added from {feed.Title.Text}{Environment.NewLine}";                
            }
        }
    }
}
