using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace NewsHeadlineWordCounter
{    
    public partial class MainWindow : Window
    {
        public List<string> _messages;
        public WordCounter _wordCounter;
        public NewsHeadlineScanner _headlinesScanner;
        
        public MainWindow()
        {
            InitializeComponent();            
            _wordCounter = new WordCounter("D:\\User\\Projects\\news-title-reader\\titles.txt");
            _headlinesScanner = new NewsHeadlineScanner("D:\\User\\Projects\\news-title-reader\\titles.txt",
                                                        "D:\\User\\Projects\\news-title-reader\\url-list.txt");
        }

        private void ShowTopCommonWordsBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateFeed.Text = "";
            // int.TryParse(TopNumberBox.Text, out int topNumber);
            int.TryParse(TopNumber.Text, out int topNumber);
            _messages = _wordCounter.GetTopCommonWords(topNumber);
            
            for (int i = 0; i < _messages.Count; i++)
            {
                UpdateFeed.Text += $"{i + 1}) {_messages[i]} {Environment.NewLine}";
            }
            
        }

        private void ScanNewsHealdinesBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateFeed.Text = "";
            _headlinesScanner.Update();
            UpdateFeed.Text = _headlinesScanner._updateMessage;
        }
    }
}
