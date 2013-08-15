using System;
using System.Globalization;
using System.Windows.Data;

namespace Localization4WPF
{
    public class LocalizationConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if( value == null )
            {
                return string.Empty;
            }

            string key = parameter != null ? string.Concat( parameter, value ) : value.ToString();
            string localizedString = LocalizationService.Instance.Get( key );
            return localizedString ?? "";
        }

        // ------------------------------------------------------------------

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Implementation of IValueConverter
    }
}
