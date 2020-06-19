using System;
using System.Collections.Generic;

using System.Windows;


namespace NewsHeadlineWordCounter
{    
    public partial class MainWindow : Window
    {
        public List<string> _messages;
        public WordCounter _wordCounter;

        
        public MainWindow()
        {
            InitializeComponent();            
            _wordCounter = new WordCounter("D:\\User\\Projects\\news-title-reader\\titles.txt");
        }

        private void ShowTopCommonWordsBtn_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(TopNumberBox.Text, out int topNumber);
            _messages = _wordCounter.GetTopCommonWords(100);
            var text = "";
            foreach (var item in _messages)
            {
                text += item + "\n";
            }
            UpdateFeed.Text = text;
            //_messages = _wordCounter.GetTopCommonWords(10);
        }
    }
}
