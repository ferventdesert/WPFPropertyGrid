namespace System.Windows.Controls.WpfPropertyGrid.Controls
{
    /// <summary>
    ///     按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///     步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    ///     将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    ///     元素中:
    ///     xmlns:MyNamespace="clr-namespace:System.Windows.Controls.WpfPropertyGrid"
    ///     步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    ///     将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    ///     元素中:
    ///     xmlns:MyNamespace="clr-namespace:System.Windows.Controls.WpfPropertyGrid;assembly=System.Windows.Controls.WpfPropertyGrid"
    ///     您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    ///     并重新生成以避免编译错误:
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///     步骤 2)
    ///     继续操作并在 XAML 文件中使用控件。
    ///     <MyNamespace:ComplexControlEditor />
    /// </summary>
    [TemplatePart(Name = EditButton, Type = typeof (Button))]
    public class ComplexControlEditor : Control
    {
        public const string EditButton = "EditButton";

        private Button editButton;

        static ComplexControlEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ComplexControlEditor),
                new FrameworkPropertyMetadata(typeof (ComplexControlEditor)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            editButton = GetTemplateChild(EditButton) as Button;
            editButton.Click += editButton_Click;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ComplexEditorWindow window=new ComplexEditorWindow();
            window.DataContext = this.DataContext;
            window.ShowDialog();
        }
    }
}