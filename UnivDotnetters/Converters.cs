using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace UnivDotnetters
{
    public sealed class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is bool && (bool)value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is Visibility && Equals(value, Visibility.Visible))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public sealed class FromStringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && value is String && !string.IsNullOrWhiteSpace((String)value))
            {
                Uri uri = new Uri((String)value);
                BitmapImage ret = new BitmapImage(uri);
                return ret;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
