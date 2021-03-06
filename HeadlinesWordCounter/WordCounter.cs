﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsHeadlineWordCounter
{
    public class WordCounter
    {
        private string _titles;
        private Dictionary<string, int> _wordFrequency;
        private string _invalidWordsFile;
        public string _words;
        public WordCounter(string titles, string invalidWords)
        {
            _titles = File.ReadAllText(titles);
            _invalidWordsFile = invalidWords;
            _words = "File.ReadAllText(wordsFrequencyFile)";
        }
        
        public List<string> GetTopCommonWords(int number)
        {
            UpdateWordFrequency();
            var orderedTitles = _wordFrequency.OrderByDescending(x => x.Value);
            var topCommonWords = new List<string>();
            for (int i = 0; i < number; i++)
            {
                var line = $"{orderedTitles.ElementAt(i).Key} - {orderedTitles.ElementAt(i).Value}";
                topCommonWords.Add(line);
            }
            return topCommonWords;
        }

        public void UpdateWordFrequency()
        {
            _wordFrequency = new Dictionary<string, int>();
            FormatFileContent();
            var words = _titles.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i].ToLower();
                if (words[i].Equals("UK") || words[i].Equals("US"))
                {
                    word = words[i];
                }
                if (!string.IsNullOrWhiteSpace(word) && !IsInvalidWord(word))
                {
                    if (!_wordFrequency.ContainsKey(word))
                    {
                        _wordFrequency.Add(word, 1);
                    }
                    else
                    {
                        _wordFrequency[word]++;
                    }
                }
            }
        }

        public void FormatFileContent()
        {
            var regex = new Regex(@"[^A-Za-z ]");
            _titles = regex.Replace(_titles, "");
        }

        public bool IsInvalidWord(string word)
        {
            var invalidWords = File.ReadAllText(_invalidWordsFile).Split(' ');
            return invalidWords.Contains(word);
        }
    }
}
