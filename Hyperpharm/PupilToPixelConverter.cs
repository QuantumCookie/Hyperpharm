using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hyperpharm
{
    class PupilToPixelConverter : IValueConverter
    {
        public static float UNITS_PER_MM = 6;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float pupilDiameter = float.Parse(value.ToString());
            float pupilUnits = pupilDiameter * UNITS_PER_MM;

            return pupilUnits;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float pupilUnits = float.Parse(value.ToString());
            float pupilDiameter = pupilUnits / UNITS_PER_MM;

            return pupilDiameter;
        }
    }
}
