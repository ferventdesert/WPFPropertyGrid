using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace System.Windows.Controls.WpfPropertyGrid.Controls
{
    public class ExtendSelector : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InformPropertyChanged(string propName)
        {
            OnPropertyChanged(propName);
        }
    }
   
    public class ExtendSelector<T> : ExtendSelector 
    {
        public ExtendSelector(IEnumerable<T> collection )
        {
            items = collection.ToList();
            SelectItem = Collection.FirstOrDefault();
        }

        public  string ItemType
        {
            get
            {
                return typeof(T).Name;
            }
        }


       
        public ExtendSelector()
        {
        }

     
        public  void SetSource(IEnumerable<T> collection)
        {
            bool hasv = Collection != null&&Collection.Any();
            if(collection==null)
                return;
            items = collection.ToList();
            if (hasv == false)
            {
                SelectItem = items.FirstOrDefault();
            }
        
            this.OnPropertyChanged("Collection");

        }

        public Func<List<T>> GetItems; 
        private List<T> items;  
        public List<T> Collection {
            get
            {
                if (GetItems == null)
                    return items;
                return GetItems();
            }
           
        }

        public EventHandler SelectChanged;
        private T selectItem;


        public void SetDefault()
        {
            if(Collection==null)
                return;
            
            this.SelectItem = Collection.FirstOrDefault();
        }
        public T SelectItem
        {
            get { return this.selectItem; }
            set
            {
                var isEaqual = Equals(this.selectItem, value);
                this.selectItem = value;
                OnPropertyChanged("SelectItem");
                if (isEaqual==false)
                {
                  
                    if (SelectChanged != null) SelectChanged(this,new EventArgs());
                } 


            }
        }

      
    }
}
