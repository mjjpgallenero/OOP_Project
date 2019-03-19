using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OOP_Project
{
    public class NullToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsInverse = (parameter as string) == "inverse";

            if (IsInverse)
            {
                if (value == null)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }

            }
            else
            {
                if (value == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}