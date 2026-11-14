using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace cw2_wpf
{
    /// <summary>
    /// Interaction logic for OtherWindow.xaml
    /// </summary>
    public partial class OtherWindow : Window
    {
        private readonly DispatcherTimer _timer = new()
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        private static System.Timers.Timer aTimer;
        public OtherWindow()
        {
            InitializeComponent();
            _timer.Tick += (_, _) => {
                lblShowTime.Content = DateTime.Now.ToLongTimeString();
            };

            _timer.Start();
            //aTimer = new System.Timers.Timer(1000);
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           // Update the label with the current time
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    var otherWindow = Application.Current.Windows.OfType<OtherWindow>()
            //       .FirstOrDefault();
            //    if (otherWindow != null)
            //    {
            //        otherWindow.lblShowTime.Content = DateTime.Now.ToLongTimeString();
            //    }
            //});
            // lbS
        }

        private void MyOtherWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lblShowTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void BtnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}
