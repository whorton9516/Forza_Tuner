using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forza_Tuner
{
    /// <summary>
    /// Interaction logic for RadialSpeedometerUserControl.xaml
    /// </summary>
    public partial class RadialSpeedometerUserControl : UserControl, INotifyPropertyChanged
    {
        private const double MIN_SPEED = 0.0;
        private const double MAX_SPEED = 250.0;
        private const double MIN_ANGLE = -130.0;
        private const double MAX_ANGLE = 130.0;

        private double _angle;

        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RadialSpeedometerUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void UpdateAngle(double currentSpeed)
        {
            double scaledSpeed = (currentSpeed - MIN_SPEED) / (MAX_SPEED - MIN_SPEED);
            Angle = scaledSpeed * (MAX_ANGLE - MIN_ANGLE) + MIN_ANGLE;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
