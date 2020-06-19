using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MostUsedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = DateTime.Now.Date.AddDays(-1);
            Console.WriteLine(f);

            var file = "D:\\User\\Projects\\news-title-reader\\titles.txt";

            var regex = new Regex(@"[^A-Za-z ]");

            var fileText = File.ReadAllText(file);
            fileText = regex.Replace(fileText, "");

            var titles = new Dictionary<string, int>();

            var words = fileText.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                {
                    if (!titles.ContainsKey(words[i]))
                    {
                        titles.Add(words[i], 1);
                    }
                    else
                    {
                        titles[words[i]]++;
                    }
                }
            }

            var orderedTitles = titles.OrderByDescending(x => x.Value);
            foreach (var item in orderedTitles)
            {
                Console.WriteLine(item);
            }
        }
    }
}
