using System;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace MagicMirror
{
    /// <summary>
    /// Bool值和控件可见性转化类,
    /// <remarks>
    /// 不同于System.Windows.Controls.BooleanToVisibilityConverter可以双向转化
    /// </remarks>
    /// </summary>
    [ValueConversion(typeof(Boolean), typeof(Visibility))]
    internal class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            try
            {
                return System.Convert.ToBoolean(value) ? Visibility.Hidden : Visibility.Visible;
            }
            catch (Exception)
            {
                return Visibility.Visible;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
