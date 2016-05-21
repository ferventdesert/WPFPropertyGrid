using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System.Windows.Controls.WpfPropertyGrid.Attributes
{
   public class MLDisplayNameAttribute:DisplayNameAttribute
    {
       public override string DisplayName {
           get { return null; }
       }
    }
}
