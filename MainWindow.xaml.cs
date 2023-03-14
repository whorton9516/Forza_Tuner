using Forza_Tuner.UDPConnection;
using System;
using System.Windows;
using System.Threading;
using System.Timers;
using System.ComponentModel;

namespace Forza_Tuner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ForzaListener Listener = new ForzaListener();
        TelemetryData Data = new TelemetryData();

        DateTime SessionStartTime;

        System.Timers.Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            Thread ListenerThread = new Thread(Listener.Listen);
            ListenerThread.IsBackground = true;
            ListenerThread.Start();
            SessionStartTime = DateTime.Now;

            this.DataContext = Data;

            timer = new System.Timers.Timer();
            timer.Interval = 16;
            timer.Elapsed += Timer_Tick;
            timer.Enabled = true;

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Get Data
            Data = Listener.GetSnapshot();
            TimeSpan elapsedTime = DateTime.Now - SessionStartTime;

            // Update Values
            //UpdateSessionTimer();

            Dispatcher.BeginInvoke(() =>
            {
                SessionTimerLabel.Content = $"Session: {elapsedTime.ToString(@"hh\:mm\:ss")}";
                SpeedLabel.Content = $"Speed: {Data.SpeedMPH}";
                RPMLabel.Content = $"RPM: {Math.Round(Data.CurrentEngineRpm)}";
                GearLabel.Content = $"Gear: {Data.Gear}";
                Speedometer.UpdateAngle(Data.SpeedMPH);
            });
        }
    }
}
