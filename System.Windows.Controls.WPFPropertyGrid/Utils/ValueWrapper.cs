using System.ComponentModel;
using System.Windows.Controls.WpfPropertyGrid.Annotations;
using System.Windows.Controls.WpfPropertyGrid.Attributes;

namespace System.Windows.Controls.WpfPropertyGrid.Utils
{
    public class ValueWrapper : INotifyPropertyChanged
    {
        private object item;

        public ValueWrapper(object item)
        {
            Item = item;
        }

        public event EventHandler ValueChanged;

        private void OnValueChanged(EventArgs e)
        {
            EventHandler handler = this.ValueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [LocalizedDisplayName("值")]
        public object Item
        {
            get
            {
                return this.item;
            }
            set
            {
                if( this.item != value)
                {
                    item = value;
                   
                    OnValueChanged(new  EventArgs());
                    this.OnPropertyChanged("Item");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
