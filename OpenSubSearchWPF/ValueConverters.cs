using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OpenSubSarchLib;

namespace OpenSubSearchWPF
{
    public class FilenameFromPath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int maxLength = 30;
            try
            {
                maxLength = parameter != null ? int.Parse(parameter.ToString()) : 30;
            } catch { }

            if (value == null)
                return "";

            String sval = value.ToString();
            if (sval.Length <= maxLength) return sval;

            return Path.GetFileName(sval);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }
    }

    // Parameter makes it inverse
    public class NullBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ^ parameter != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }
    }

}
