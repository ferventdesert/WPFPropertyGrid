namespace System.Windows.Controls.WpfPropertyGrid
{
    /// <summary>
    /// Contains a set of editor keys.
    /// </summary>
    public static class EditorKeys
    {
        private static readonly Type ThisType = typeof(EditorKeys);
        private static readonly ComponentResourceKey _NamedColorEditorKey = new ComponentResourceKey(ThisType, "NamedColorEditor");
        private static readonly ComponentResourceKey _PasswordEditorKey = new ComponentResourceKey(ThisType, "PasswordEditor");
        private static readonly ComponentResourceKey _DefaultEditorKey = new ComponentResourceKey(ThisType, "DefaultEditor");
        private static readonly ComponentResourceKey _BooleanEditorKey = new ComponentResourceKey(ThisType, "BooleanEditor");
        private static readonly ComponentResourceKey _DoubleEditorKey = new ComponentResourceKey(ThisType, "DoubleEditor");
        private static readonly ComponentResourceKey _EnumEditorKey = new ComponentResourceKey(ThisType, "EnumEditor");
        private static readonly ComponentResourceKey _SliderEditorKey = new ComponentResourceKey(ThisType, "SliderEditor");
        private static readonly ComponentResourceKey _FontFamilyEditorKey = new ComponentResourceKey(ThisType, "FontFamilyEditor");
        private static readonly ComponentResourceKey _BrushEditorKey = new ComponentResourceKey(ThisType, "BrushEditor");
        private static readonly ComponentResourceKey _DefaultCategoryEditorKey = new ComponentResourceKey(ThisType, "DefaultCategoryEditorKey");
        private static readonly ComponentResourceKey _ComplexPropertyEditorKey = new ComponentResourceKey(ThisType, "ComplexPropertyEditor");
        private static readonly ComponentResourceKey _PointPropertyEditorKey = new ComponentResourceKey(ThisType, "PointPropertyEditor");

        private static readonly ComponentResourceKey _PercentEditorKey = new ComponentResourceKey(ThisType, "PercentEditorTemplate");
        private static readonly ComponentResourceKey _XmlLanguageEditorKey = new ComponentResourceKey(ThisType, "XmlLanguageEditorTemplate");





        private static ComponentResourceKey _FilePathPickerEditorKey = new ComponentResourceKey(ThisType, "FilePathSelector");


        private static ComponentResourceKey _ExtendSelectorEditorKey = new ComponentResourceKey(ThisType, "ExtendSelector");

        private static ComponentResourceKey _CommandsBindingEditorKey = new ComponentResourceKey(ThisType, "CommandsBindingEditor");

    

        private static ComponentResourceKey _UserControlEditorKey = new ComponentResourceKey(ThisType, "UserControl");

        private static ComponentResourceKey _CollectionEditorKey = new ComponentResourceKey(ThisType, "IList");

        private static ComponentResourceKey _DateTimeEditorKey = new ComponentResourceKey(ThisType, "DateTimePropertyEditorKey");

        private static ComponentResourceKey _DictionaryEditorKey = new ComponentResourceKey(ThisType, "DictionaryEditorKey");
        private static ComponentResourceKey _CodeEditorEditorKey = new ComponentResourceKey(ThisType, "CodeEditorKey");
        public static ComponentResourceKey FilePathPickerEditorKey => _FilePathPickerEditorKey;

        public static ComponentResourceKey CodeEditorEditorKey => _CodeEditorEditorKey;

        public static ComponentResourceKey PercentEditorKey
        {
            get { return _PercentEditorKey; }
        }

        public static ComponentResourceKey XmlLanguageEditorKey
        {
            get { return _XmlLanguageEditorKey; }
        }

        /// <summary>
        /// Gets the NamedColor editor key.
        /// </summary>
        /// <value>The named color editor key.</value>
        public static ComponentResourceKey NamedColorEditorKey { get { return _NamedColorEditorKey; } }


        /// <summary>
        /// Gets the password editor key.
        /// </summary>
        /// <value>The password editor key.</value>
        public static ComponentResourceKey PointPropertyEditorKey { get { return _PointPropertyEditorKey; } }


        /// <summary>
        /// Gets the password editor key.
        /// </summary>
        /// <value>The password editor key.</value>
        public static ComponentResourceKey PasswordEditorKey { get { return _PasswordEditorKey; } }

        /// <summary>
        /// Gets the default editor key.
        /// </summary>
        /// <value>The default editor key.</value>
        public static ComponentResourceKey DefaultEditorKey { get { return _DefaultEditorKey; } }

        /// <summary>
        /// Gets the boolean editor key.
        /// </summary>
        /// <value>The boolean editor key.</value>
        public static ComponentResourceKey BooleanEditorKey => _BooleanEditorKey;

        /// <summary>
        /// Gets the double editor key.
        /// </summary>
        /// <value>The double editor key.</value>
        public static ComponentResourceKey DoubleEditorKey => _DoubleEditorKey;

        /// <summary>
        /// Gets the enum editor key.
        /// </summary>
        /// <value>The enum editor key.</value>
        public static ComponentResourceKey EnumEditorKey => _EnumEditorKey;

        /// <summary>
        /// Gets the slider editor key.
        /// </summary>
        /// <value>The slider editor key.</value>
        public static ComponentResourceKey SliderEditorKey => _SliderEditorKey;

        /// <summary>
        /// Gets the font family editor key.
        /// </summary>
        /// <value>The font family editor key.</value>
        public static ComponentResourceKey FontFamilyEditorKey => _FontFamilyEditorKey;

        /// <summary>
        /// Gets the brush editor key.
        /// </summary>
        /// <value>The brush editor key.</value>
        public static ComponentResourceKey BrushEditorKey => _BrushEditorKey;

        /// <summary>
        /// Gets the default category editor key.
        /// </summary>
        /// <value>The default category editor key.</value>
        public static ComponentResourceKey DefaultCategoryEditorKey => _DefaultCategoryEditorKey;

        /// <summary>
        /// Gets the default complex property editor key.
        /// </summary>
        public static ComponentResourceKey ComplexPropertyEditorKey => _ComplexPropertyEditorKey;

        public static ComponentResourceKey ExtendSelectorEditorKey => _ExtendSelectorEditorKey;

        public static ComponentResourceKey CommandsBindingEditorKey => _CommandsBindingEditorKey;


        public static ComponentResourceKey UserControlEditorKey => _UserControlEditorKey;

        public static ComponentResourceKey CollectionEditorKey => _CollectionEditorKey;

        public static ComponentResourceKey DateTimePropertyEditorKey => _DateTimeEditorKey;

        public static ComponentResourceKey DictionaryEditorKey => _DictionaryEditorKey;
    }
}
