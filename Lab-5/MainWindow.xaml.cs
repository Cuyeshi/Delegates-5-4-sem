using System;
using System.Windows;
using System.Windows.Threading;

namespace Lab_5
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int timeoutInSeconds;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += TimerTick; // Подписываемся на событие Tick таймера
            timer.IsEnabled = false; // По умолчанию таймер выключен
        }

        private void TimerTick(object sender, EventArgs e)
        {
            // Действия, которые нужно выполнить при каждом тике таймера
            MessageBox.Show("Таймер сработал!");
            timer.Stop(); // Останавливаем таймер после срабатывания
        }

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TimeoutTextBox.Text, out timeoutInSeconds) || timeoutInSeconds <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение таймаута в секундах.");
                return;
            }

            timer.Interval = TimeSpan.FromSeconds(timeoutInSeconds); // Устанавливаем интервал таймера
            timer.IsEnabled = true; // Включаем таймер
        }
    }
}
