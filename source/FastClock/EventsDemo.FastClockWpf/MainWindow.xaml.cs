using System;
using System.Windows;


namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Parse($"{DatePickerDate.SelectedDate} {TextBoxTime.Text}");
            FastClock.FastClock.GetInstance().CurrentDateTime = date;
        }

        private void SetFastClockStartDateAndTime()
        {

        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockTime.Text = fastClockTime.ToShortTimeString();
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            FastClock.FastClock.GetInstance().Factor = Convert.ToInt32(TextBoxFactor.Text);
            FastClock.FastClock.GetInstance().IsRunning = CheckBoxClockRuns.IsChecked == true;
            FastClock.FastClock.GetInstance().OneMinuteIsOver += FastClockOneMinuteIsOver;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();
        }

    }
}
