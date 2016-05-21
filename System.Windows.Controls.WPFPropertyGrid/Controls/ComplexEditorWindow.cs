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
    ///     <MyNamespace:ComplexEditorWindow />
    /// </summary>
    [TemplatePart(Name = PART_CANCEL_Button, Type = typeof (Button))]
    [TemplatePart(Name = PART_OK_Button, Type = typeof (Button))]
    [TemplatePart(Name = PART_ContentPresenter, Type = typeof (ContentPresenter))]
    public class ComplexEditorWindow : Window
    {
        private const string PART_OK_Button = "PART_OK_Button";
        private const string PART_CANCEL_Button = "PART_CANCEL_Button";
        private const string PART_ContentPresenter = "PART_ContentPresenter";
        private Button cancelButton;
        private ContentPresenter contentPresenter;
        private Button okButton;

        private WPFPropertyGrid propertyGrid;

        static ComplexEditorWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ComplexEditorWindow),
                new FrameworkPropertyMetadata(typeof (ComplexEditorWindow)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            okButton = GetTemplateChild(PART_OK_Button) as Button;
            cancelButton = GetTemplateChild(PART_CANCEL_Button) as Button;
            contentPresenter = GetTemplateChild(PART_ContentPresenter) as ContentPresenter;
            okButton.Click += okButton_Click;
            propertyGrid = PropertyGridFactory.GetInstance(DataContext);

            contentPresenter.Content = propertyGrid;

            // cancelButton.Click += cancelButton_Click;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}