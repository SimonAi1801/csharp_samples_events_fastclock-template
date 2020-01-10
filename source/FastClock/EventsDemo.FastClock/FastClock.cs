using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {
        private static FastClock instance = null;
        private readonly DispatcherTimer _timer;
        private bool _isRunning;


        public event EventHandler<DateTime> OneMinuteIsOver;


        public DateTime CurrentDateTime { get; set; }

        public int Factor { get; set; }

        public bool IsRunning 
        {
            get => _isRunning;

            set
            {
                if (!_isRunning && value)
                {
                    _timer.Start();
                }
                else if(_isRunning && value == false)
                {
                    _timer.Stop();
                }
                _isRunning = value;
            }
        }

        private FastClock()
        {
            //CurrentDateTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
        }

        public static FastClock GetInstance()
        {
            if (instance == null)
            {
                instance = new FastClock();
            }
            return instance;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (Factor == 0)
            {
                Factor = 1;
            }
            _timer.Interval = TimeSpan.FromMilliseconds(1000 / Factor);
            CurrentDateTime = CurrentDateTime.AddMinutes(1);
            OnOneMinuteIsOver(CurrentDateTime);
        }

        protected virtual void OnOneMinuteIsOver(DateTime time)
        {
            OneMinuteIsOver?.Invoke(this, time);
        }
    }
}
