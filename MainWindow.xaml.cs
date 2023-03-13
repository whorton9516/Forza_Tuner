using Forza_Tuner.UDPConnection;
using System;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace Forza_Tuner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ForzaListener Listener = new ForzaListener();
        TelemetryData Data = new TelemetryData();
        TimeSpan SessionTimer = new TimeSpan();
        uint SessionStartTime = 0;

        DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            Thread ListenerThread = new Thread(Listener.Listen);
            ListenerThread.IsBackground = true;
            ListenerThread.Start();

            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(22000);
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Get Data
            Data = Listener.GetSnapshot();

            // Update Values
            UpdateSessionTimer();

            SessionTimerLabel.Content = $"Session: {SessionTimer.ToString(@"hh\:mm\:ss")}";
            SpeedLabel.Content = $"Speed: {Data.SpeedMPH}";
            RPMLabel.Content = $"RPM: {Math.Round(Data.CurrentEngineRpm)}";
            GearLabel.Content = $"Gear: {Data.Gear}";
        }

        private void UpdateSessionTimer()
        {
            if(SessionStartTime == 0) { SessionStartTime = Data.TimestampMS; }
            SessionTimer = TimeSpan.FromSeconds(
                Math.Round((double)Data.TimestampMS - SessionStartTime/100)
                );
        }
    }
}
