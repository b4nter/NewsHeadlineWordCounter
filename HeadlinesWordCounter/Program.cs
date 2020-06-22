using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using TitleScanner;

namespace NewsHeadlineWordCounter
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var titles = "D:\\User\\Projects\\news-title-reader\\titles.txt";
            var urlList = "D:\\User\\Projects\\news-title-reader\\url-list.txt";
            //TODO:
            var foo = new HeadlinesWordCounter();

            //create class that handles requests from UI

            //Implement word file for storing word frequency in WordCounter
        }

    }
}
