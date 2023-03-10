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

        DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            Thread ListenerThread = new Thread(Listener.Listen);
            ListenerThread.IsBackground = true;
            ListenerThread.Start();

            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(16000);
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Data = Listener.GetSnapshot();

            SpeedLabel.Content = $"Speed: {Math.Round(Data.Speed * 2.23694f)}";
            RPMLabel.Content = $"RPM: {Math.Round(Data.CurrentEngineRpm)}";
            GearLabel.Content = $"Gear: {Data.Gear}";
        }
    }
}
