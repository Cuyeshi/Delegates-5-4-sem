using System;
using System.Windows;
using System.Windows.Threading;

namespace Lab_5
{
    public class CustomTimer
    {
        private DispatcherTimer timer;

        public event EventHandler TimerElapsed;

        public TimeSpan Interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        public bool IsEnabled
        {
            get { return timer.IsEnabled; }
            set { timer.IsEnabled = value; }
        }

        public CustomTimer(TimeSpan interval)
        {
            timer = new DispatcherTimer();
            timer.Interval = interval;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerElapsed?.Invoke(this, EventArgs.Empty);
        }
    }
}
