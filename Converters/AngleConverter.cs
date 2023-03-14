using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Forza_Tuner.Converters
{
    public class AngleConverter : IValueConverter
    {
        private const double MIN_SPEED = 0.0;
        private const double MAX_SPEED = 250.0;
        private const double MIN_ANGLE = -130.0;
        private const double MAX_ANGLE = 130.0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double speed)
            {
                // Scale the speed value to the range of [0, 1]
                double scaledSpeed = (speed - MIN_SPEED) / (MAX_SPEED - MIN_SPEED);

                // Map the scaled speed value to the range of [MIN_ANGLE, MAX_ANGLE]
                double angle = scaledSpeed * (MAX_ANGLE - MIN_ANGLE) + MIN_ANGLE;
                return angle;
            }

            // If the value is not a double or is null, return null
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter does not support converting back
            throw new NotSupportedException();
        }
    }
}
