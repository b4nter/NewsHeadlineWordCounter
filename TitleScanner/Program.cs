using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace NewsTitleScanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var titles = "D:\\User\\Projects\\news-title-reader\\titles.txt";
            var urlList = "D:\\User\\Projects\\news-title-reader\\url-list.txt";
            var counter = new WordCounter(titles);
            // counter.PrintTopCommonWords(1000);
             Start(titles, urlList);
            //TODO:
            //get rid of file path
        }

        public static void Start(string titles, string urlList)
        {
            var counter = new WordCounter(titles);
            var scanner = new NewsHeadlineScanner(titles, urlList);
            Console.WriteLine("-------------News title scanner-------------");

            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Update News title list.");
                Console.WriteLine("2. Display most common words.");
                Console.WriteLine("3. Exit application.");
                Console.Write("Enter your choice: ");
                Int32.TryParse(Console.ReadLine(), out int choice);
                Console.WriteLine("--------------------------------------------");
                switch (choice)
                {
                    case 1:
                        scanner.Update();
                        break;
                    case 2:
                        Console.Write("Entery how many top words you want to see: "); 
                        Int32.TryParse(Console.ReadLine(), out int amount);
                        counter.PrintTopCommonWords(amount);
                        break;
                    case 3:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
