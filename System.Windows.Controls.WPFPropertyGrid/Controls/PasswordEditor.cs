using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Controls.WpfPropertyGrid.Controls
{
    using System.Windows;
    using System.Windows.Controls.WpfPropertyGrid;

    public class PasswordEditor : Editor
    {
       static ResourceDictionary dataViewResource = Application.LoadComponent(new Uri("/System.Windows.Controls.WpfPropertyGrid;component/Themes/EditorResources.xaml", UriKind.Relative)) as ResourceDictionary;
        public PasswordEditor( )
        {



            InlineTemplate = dataViewResource["PasswordEditor"];

        }


    }


    public class CodeEditor : Editor
    {
        static ResourceDictionary dataViewResource = Application.LoadComponent(new Uri("/System.Windows.Controls.WpfPropertyGrid;component/Themes/EditorResources.xaml", UriKind.Relative)) as ResourceDictionary;
        public CodeEditor()
        {



            InlineTemplate = dataViewResource["CodeEditor"];

        }
    }
    public class MarkdownEditor : Editor
    {
        static ResourceDictionary dataViewResource = Application.LoadComponent(new Uri("/System.Windows.Controls.WpfPropertyGrid;component/Themes/EditorResources.xaml", UriKind.Relative)) as ResourceDictionary;
        public MarkdownEditor()
        {



            InlineTemplate = dataViewResource["MarkdownEditor"];

        }
    }


}
