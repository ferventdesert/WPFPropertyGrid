using System.ComponentModel;

namespace System.Windows.Controls.WpfPropertyGrid.Attributes
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayNameAttribute(string key) : base(key)
        {
        }

        public override string DisplayName
        {
            get
            {
                object str = null;
                str = Application.Current.TryFindResource(DisplayNameValue);
                if (str == null)
                    return DisplayNameValue;
                return str.ToString();
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        public LocalizedDescriptionAttribute(string key) : base(key)
        {
        }

        public override string Description
        {
            get
            {
                object str = null;
                str = Application.Current.TryFindResource(DescriptionValue);
                if (str == null)
                    return DescriptionValue;
                return str.ToString();
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        public LocalizedCategoryAttribute(string key) : base(key)
        {
        }

        protected override string GetLocalizedString(string value)
        {
            object str = null;
            str = Application.Current.TryFindResource(value);
            if (str == null)
                return value;
            return str.ToString();
        }
    }
}