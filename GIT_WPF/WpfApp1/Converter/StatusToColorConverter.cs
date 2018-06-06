using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1.Converter
{
    public class StatusToColorConverter : IValueConverter
    {
        SolidColorBrush DELETE = new SolidColorBrush(Color.FromRgb(255, 120, 0));
        SolidColorBrush NEW = new SolidColorBrush(Color.FromRgb(76, 153, 64));
        SolidColorBrush MODIFIED = new SolidColorBrush(Color.FromRgb(0, 102, 204));
        SolidColorBrush UNKNOWN = new SolidColorBrush(Color.FromRgb(160, 160, 160));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value.ToString();
            if (status == "DeletedFromIndex" || status == "DeletedFromWorkdir")
                return DELETE;
            if (status == "NewInIndex" || status == "NewInWorkdir")
                return NEW;
            if (status == "ModifiedInIndex" || status == "ModifiedInWorkdir")
                return MODIFIED;

            return UNKNOWN;



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
