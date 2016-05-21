using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.WpfPropertyGrid;

namespace System.Windows.Controls.WpfPropertyGrid
{
    using System.Globalization;
    using System.Windows.Data;

    public  class DataToTypeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type t;
            var p = value as PropertyItemValue;
            if (value == null)
                return null;
            if (p != null)
                t= p.Value.GetType();
            else
            {
                t = value.GetType();

            }
             
            if (t.IsGenericType)
                return t.GetGenericArguments()[0].Name;
            return t.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
