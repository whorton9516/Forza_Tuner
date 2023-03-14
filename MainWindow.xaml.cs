using Forza_Tuner.UDPConnection;
using System;
using System.Windows;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Forza_Tuner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ForzaListener Listener = new ForzaListener();
        TelemetryData Data = new TelemetryData();

        System.Timers.Timer timer;

        DateTime SessionStartTime;

        private bool isMoving = false;
        private bool OTSIsRunning = false;
        private bool OTSIsReady = false;
        private bool OTSCoolDown = false;
        private DateTime OTSStartTime;
        private TimeSpan OTSTime;
        private TimeSpan OTSCoolDownTimer;

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
            if (Data.Speed < 0.1) isMoving = false;
            else isMoving = true;

            Dispatcher.BeginInvoke(() =>
            {
                SessionTimerLabel.Content = $"Session: {elapsedTime.ToString(@"hh\:mm\:ss")}";
                SpeedLabel.Content = $"{Data.SpeedMPH}";
                RPMLabel.Content = $"RPM: {Math.Round(Data.CurrentEngineRpm)}";
                if (Data.Gear == 0) GearLabel.Content = "R";
                else GearLabel.Content = $"{Data.Gear}";
                
                Speedometer.UpdateAngle(Data.SpeedMPH);

                if (!OTSIsReady)
                {
                    if (!isMoving && (Data.Handbrake > 0 || Data.Brake > 0) && Data.Accelerator > 0)
                    {
                        OTSIsReady = true;
                    }
                }
                else
                {
                    if (!OTSIsRunning)
                    {
                        switch (isMoving && Data.Gear > 0)
                        {
                            case true:
                                OTSIsRunning = true;
                                OTSStartTime = DateTime.Now;
                                break;

                            case false:
                                OTSTimerLabel.Content = "Accelerate to start 0-60 timer";
                                break;
                        }
                    }
                    else
                    {
                        switch (Data.SpeedMPH < 60)
                        {
                            case true:
                                OTSTime = DateTime.Now - OTSStartTime;
                                break;

                            case false:
                                OTSIsRunning = false;
                                OTSIsReady = false;
                                break;
                        }
                        OTSTimerLabel.Content = $"0 to 60 time: {OTSTime.TotalSeconds.ToString("0.00")} seconds";
                    }
                }

            });
        }
    }
}
