using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace NewsHeadlineWordCounter
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var titles = "D:\\User\\Projects\\news-title-reader\\titles.txt";
            var urlList = "D:\\User\\Projects\\news-title-reader\\url-list.txt";
            //TODO:
            //get rid of file paths
            // https://stackoverflow.com/questions/9065598/if-a-folder-does-not-exist-create-it
            //System.IO.Directory.Exists

            //create class that handles requests from UI
            //Implement word file for storing word frequency in WordCounter
        }

    }
}
