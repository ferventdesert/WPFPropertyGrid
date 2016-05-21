namespace System.Windows.Controls.WpfPropertyGrid.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StringEditorAttribute : Attribute
    {
        public StringEditorAttribute(string stringType)
        {
            StringType = stringType;
            Title = "文本编辑器";
            
        }

        public string StringType { get; set; }
        public string Title { get; set; }

        public string CompleteWordName { get; set; }
    }
   
}
