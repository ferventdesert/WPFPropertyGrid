using System.Windows.Controls.WpfPropertyGrid.Design;
using System.Windows.Media;

namespace System.Windows.Controls.WpfPropertyGrid
{
    /// <summary>
    ///     属性工厂
    /// </summary>
    public class PropertyGridFactory
    {
        private static ResourceDictionary dictionary;

        /// <summary>
        ///     获取一个实例
        /// </summary>
        /// <returns></returns>
        public static WPFPropertyGrid GetInstance()
        {
            if (dictionary == null)
            {
                var path = "System.Windows.Controls.WpfPropertyGrid;component";
                dictionary = new ResourceDictionary();
                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Design/AlphabeticalLayout.xaml", UriKind.RelativeOrAbsolute)
                });
                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Design/CategorizedLayout.xaml", UriKind.RelativeOrAbsolute)
                });

                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Design/TabbedLayout.xaml", UriKind.RelativeOrAbsolute)
                });

                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Themes/DoubleEditor.xaml", UriKind.RelativeOrAbsolute)
                });

                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Themes/EditorResources.xaml", UriKind.RelativeOrAbsolute)
                });

                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Themes/PropertyGrid.xaml", UriKind.RelativeOrAbsolute)
                });

                dictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(path + "/Themes/SearchTextBox.xaml", UriKind.RelativeOrAbsolute)
                });

                Application.Current.Resources.MergedDictionaries.Add(dictionary);
            }
            var property = new WPFPropertyGrid();


            return property;
        }

        public static Window GetWindow()
        {
            var window = new Window
            {
                Title = "设置属性值",
                Background = Application.Current.TryFindResource("NormalBrush") as Brush,
                Width = 400
            };
            return window;
        }

        public static WPFPropertyGrid GetInstance(object selectObject)
        {
            var property = GetInstance();

            property.SetObjectView(selectObject);
            return property;
        }

        public static Window GetPropertyWindow(object item)
        {
            var prop = GetInstance(item);

            var window = new Window
            {
                Title = "设置属性值",
                Content = prop,
                Background = Application.Current.TryFindResource("NormalBrush") as Brush,
                Width = 400
            };

            return window;
        }
    }

    public class WPFPropertyGrid : UserControl
    {
        private readonly PropertyGrid propertyGrid;

        public WPFPropertyGrid()
        {
            Brush itemBrush;

            propertyGrid = new PropertyGrid
            {
                PropertyFilterVisibility = Visibility.Collapsed,
                ShowReadOnlyProperties = true,
                Layout = new CategorizedLayout()
            };


            itemBrush = Application.Current.TryFindResource("TextBrush") as Brush;
            if (itemBrush != null)
            {
                propertyGrid.ItemsForeground = itemBrush;
            }


            Content = propertyGrid;
        }

        public bool ShowReadOnlyProperties
        {
            get { return propertyGrid.ShowReadOnlyProperties; }
            set { propertyGrid.ShowReadOnlyProperties = value; }
        }

        public Visibility PropertyFilterVisibility
        {
            get { return propertyGrid.PropertyFilterVisibility; }
            set { propertyGrid.PropertyFilterVisibility = value; }
        }

        public void SetObjectView(object obj)
        {
            propertyGrid.SelectedObject = obj;
        }
    }
}