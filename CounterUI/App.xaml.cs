using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.IO;
using System.Windows;
using Windowless_Sample;

namespace NewsHeadlineWordCounter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            
            
        }
        //private void Application_Exit(object sender, ExitEventArgs e)
        //{
        //    Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
        //    var file = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\NewsHeadlineWordCounter\\log.txt";
        //    File.WriteAllText(file, "exit");
        //    notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        //}

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }
    }
}
