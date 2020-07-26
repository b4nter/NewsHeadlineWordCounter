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
            //TODO:
            var foo = new HeadlinesWordCounter();
            var counter = new HeadlinesWordCounter();
            counter.UpdateTitles();
            //Implement word file for storing word frequency in WordCounter
        }
    }
}
