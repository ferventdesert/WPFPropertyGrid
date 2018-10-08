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

        public List<string> Collection
        {
            get
            {
                if (GetItems != null)
                   return GetItems();
                return collection;
            }
        }

        private List<string> collection;
        public string ItemType { get; }

        public string SelectItem
        {
            get
            {
                if (!string.IsNullOrEmpty(_SelectItem))
                    return _SelectItem;
                return selectItem;

            }
            set
            {

                selectItem = value;
                _SelectItem = value;
            }
        }
        public string _SelectItem { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetDefault()
        {
        }

        public void SetSource(IEnumerable<string> _collection)
        {
            this.collection = _collection.ToList();
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
