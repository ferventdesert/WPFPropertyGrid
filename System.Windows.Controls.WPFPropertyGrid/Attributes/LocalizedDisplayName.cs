using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System.Windows.Controls.WpfPropertyGrid.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayNameAttribute(string key) : base(key)
        {
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        public LocalizedDescriptionAttribute(string key) : base(key)
        {
            
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
            return value;
        }
    }
}