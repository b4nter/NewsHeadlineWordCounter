using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using TitleScanner;

namespace NewsHeadlineWordCounter
{    
    public partial class MainWindow : Window
    {
    //    private System.Windows.Forms.NotifyIcon m_notifyIcon;


        public List<string> _messages;
        public HeadlinesWordCounter _headlinesWordCounter;
        public MainWindow()
        {
           // this.Show();
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

        private void ScanNewsHeadlinesBtn_Click(object sender, RoutedEventArgs e)
        {
            _headlinesWordCounter.UpdateTitles();
            UpdateFeed.Text = _headlinesWordCounter.GetUpdateMessage();
        }

        private void AddUrlBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
          //  this.WindowState = WindowState.Minimized;
            this.Hide();
        }
    }
}
