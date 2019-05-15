using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel.Converters
{
    class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            DateTimeOffset dt = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;
            var diff = rightNow - dt;
            if(diff.TotalDays > 1)
            {
                return $"{dt:d}";
            }
            else
            {
                if (diff.TotalSeconds < 60)
                    return $"{diff.TotalSeconds:0} seconds ago";
                if (diff.TotalMinutes < 60)
                    return $"{diff.TotalMinutes:0} minutes ago";
                          if(diff.TotalHours<24)
                    return $"{diff.TotalHours:0} hours ago";

                return "yesterday";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
