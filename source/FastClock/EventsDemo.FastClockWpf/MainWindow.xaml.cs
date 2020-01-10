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
            string[] time = TextBoxTime.Text.Split(':');
            DateTime dateTime = Convert.ToDateTime(DatePickerDate.SelectedDate).AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(time[1]));
            FastClock.FastClock.GetInstance().CurrentDateTime = dateTime;
            SetFastClockStartDateAndTime();
        }

        private void SetFastClockStartDateAndTime()
        {
            string[] dates = Convert.ToString(FastClock.FastClock.GetInstance().CurrentDateTime.Date).Split(' ');
            string time = $"{Convert.ToString(FastClock.FastClock.GetInstance().CurrentDateTime.Hour)}:{Convert.ToString(FastClock.FastClock.GetInstance().CurrentDateTime.Minute)}";
            TextBlockDate.Text = dates[0];
            TextBlockTime.Text = time;
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
