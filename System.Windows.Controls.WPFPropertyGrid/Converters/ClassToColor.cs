using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace System.Windows.Controls.WpfPropertyGrid
{
    public sealed class ClassToColor : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            int group = Convert.ToInt32(value);



            group=group>0?group:0;
          //  return new SolidColorBrush(new Color() { A = 200, R = (byte)(Group * 5), B = (byte)(Group * 5), G = 100 });
            var color = colors[group % (colors.Length)];
            color.A = (byte)(color.A * 0.7);
              return new SolidColorBrush(color);

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }


        private static readonly Color[] colors = new Color[] { Colors.DeepSkyBlue, Colors.BurlyWood,Colors.Coral, Colors.LimeGreen, Colors.Chartreuse, Colors.Coral, Colors.CornflowerBlue, Colors.SeaGreen, Colors.DeepPink, Colors.DeepSkyBlue };

     


    }
}
