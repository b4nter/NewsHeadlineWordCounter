using NewsHeadlineWordCounter;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitleScanner
{
    public class HeadlinesWordCounter
    {
        private string _directoryPath;
        private List<string> _filePaths = new List<string>();
        public string _titlesFilePath;
        public string _urlFilePath;
        public string _invalidWordsFilePath;
        public NewsHeadlineScanner _headlinesScanner;
        public WordCounter _wordCounter;
        public HeadlinesWordCounter()
        {
            _directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\NewsHeadlineWordCounter";
            _titlesFilePath = _directoryPath + "\\titles.txt";
            _urlFilePath = _directoryPath + "\\url-list.txt";
            _invalidWordsFilePath = _directoryPath + "\\invalid-words.txt";
            InitiliazeFiles();
            _headlinesScanner = new NewsHeadlineScanner(_titlesFilePath, _urlFilePath);
            _wordCounter = new WordCounter(_titlesFilePath, _invalidWordsFilePath);
        }

        public List<string> GetTopCommonWords(int number)
        {
            return _wordCounter.GetTopCommonWords(number);
        }

        public void UpdateTitles()
        {
            _headlinesScanner.UpdateTitles();
        }
        public string GetUpdateMessage()
        {
            return _headlinesScanner._updateMessage;
        }

        private void InitiliazeFiles()
        {
            Directory.CreateDirectory(_directoryPath); 
            _filePaths.Add(_titlesFilePath);
            _filePaths.Add(_urlFilePath);
            _filePaths.Add(_invalidWordsFilePath);
            foreach (var filePath in _filePaths)
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
            }
        }


    }
}