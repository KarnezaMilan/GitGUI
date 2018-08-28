using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converter
{
    public class StatusToCharacterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*
            LibGit2Sharp.FileStatus status = (LibGit2Sharp.FileStatus)value;

            if (status.HasFlag(LibGit2Sharp.FileStatus.DeletedFromIndex) || status.HasFlag(LibGit2Sharp.FileStatus.DeletedFromWorkdir))
                return "D";
            if (status.HasFlag(LibGit2Sharp.FileStatus.NewInIndex) || status.HasFlag(LibGit2Sharp.FileStatus.NewInWorkdir))
                return "N";
            if (status.HasFlag(LibGit2Sharp.FileStatus.ModifiedInIndex) || status.HasFlag(LibGit2Sharp.FileStatus.ModifiedInWorkdir))
                return "M";
                */

            string status = value.ToString();
            if (status == "DeletedFromIndex" || status == "DeletedFromWorkdir")
                return "D";
            if (status=="NewInIndex" || status=="NewInWorkdir")
                return "N";
            if (status == "ModifiedInIndex" || status == "ModifiedInWorkdir")
                return "M";

            return "?";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
