using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TitleScanner;

namespace NewsHeadlineWordCounter
{    
    public partial class MainWindow : Window
    {
        public List<string> _messages;
        public HeadlinesWordCounter _headlinesWordCounter;
        public MainWindow()
        {
            InitializeComponent();
            _headlinesWordCounter = new HeadlinesWordCounter();
        }

        private void ShowTopCommonWordsBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateFeed.Text = "";
            
            int.TryParse(TopNumber.Text, out int topNumber);
            _messages = _headlinesWordCounter.GetTopCommonWords(topNumber);
            
            for (int i = 0; i < _messages.Count; i++)
            {
                UpdateFeed.Text += $"{i + 1}) {_messages[i]} {Environment.NewLine}";
            }
            
        }

        private void ScanNewsHealdinesBtn_Click(object sender, RoutedEventArgs e)
        {
            _headlinesWordCounter.UpdateTitles();
            UpdateFeed.Text = _headlinesWordCounter.GetUpdateMessage();
        }
    }
}
