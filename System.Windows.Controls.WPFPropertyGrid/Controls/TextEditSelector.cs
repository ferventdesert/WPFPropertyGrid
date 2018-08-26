using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System.Windows.Controls.WpfPropertyGrid.Controls
{

    public class TextEditSelector : INotifyPropertyChanged
    {
        public Func<List<string>> GetItems;
        public EventHandler SelectChanged;
        protected string selectItem;

        public TextEditSelector()
        {
        }

        public TextEditSelector(IEnumerable<string> collection)
        {

        }

        public List<string> Collection { get; private set; }
        public string ItemType { get; }
        public string SelectItem { get; set; }
        public string _SelectItem { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetDefault()
        {
        }

        public void SetSource(IEnumerable<string> collection)
        {
            Collection=new List<string>();
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, null);
            }
            
        }
    }
}
