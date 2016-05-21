/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Controls.WpfPropertyGrid.Attributes;
using System.Windows.Input;

namespace System.Windows.Controls.WpfPropertyGrid.Controls
{
    [TemplatePart(Name = PART_NewItemTypesComboBox, Type = typeof(ComboBox))]
    public class CollectionControl : Control
    {
        private const string PART_NewItemTypesComboBox = "PART_NewItemTypesComboBox";

        #region Private Members

        private ComboBox _newItemTypesComboBox;

        #endregion

        #region Properties

        #region IsReadOnly Property

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControl), new UIPropertyMetadata(false));
        public bool IsReadOnly
        {
            get
            {
                return (bool)this.GetValue(IsReadOnlyProperty);
            }
            set
            {
                this.SetValue(IsReadOnlyProperty, value);
            }
        }

        #endregion  //Items

        #region Items Property

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<object>), typeof(CollectionControl), new UIPropertyMetadata(null));
        public ObservableCollection<object> Items
        {
            get
            {
                return (ObservableCollection<object>)this.GetValue(ItemsProperty);
            }
            set
            {
                this.SetValue(ItemsProperty, value);
            }
        }

        #endregion  //Items

        #region ItemsSource Property

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IList), typeof(CollectionControl), new UIPropertyMetadata(null, OnItemsSourceChanged));
        public IList ItemsSource
        {
            get
            {
                return (IList)this.GetValue(ItemsSourceProperty);
            }
            set
            {
                this.SetValue(ItemsSourceProperty, value);
            }
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CollectionControl CollectionControl = (CollectionControl)d;
            if (CollectionControl != null)
                CollectionControl.OnItemSourceChanged((IList)e.OldValue, (IList)e.NewValue);
        }

        public void OnItemSourceChanged(IList oldValue, IList newValue)
        {
            if (newValue != null)
            {
                foreach (var item in newValue)
                    this.Items.Add(this.CreateClone(item));
            }
        }

        #endregion  //ItemsSource

        #region ItemsSourceType Property

        public static readonly DependencyProperty ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(object), typeof(CollectionControl), new UIPropertyMetadata(null));
        public object ItemsSourceType
        {
            get
            {
                return (object)this.GetValue(ItemsSourceTypeProperty);
            }
            set
            {
                this.SetValue(ItemsSourceTypeProperty, value);
            }
        }

        #endregion //ItemsSourceType

        #region NewItemType Property

        public static readonly DependencyProperty NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControl), new UIPropertyMetadata(null));
        public IList<object> NewItemTypes
        {
            get
            {
                return (IList<object>)this.GetValue(NewItemTypesProperty);
            }
            set
            {
                this.SetValue(NewItemTypesProperty, value);
            }
        }


       
        #endregion  //NewItemType

        #region SelectedItem Property

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(CollectionControl), new UIPropertyMetadata(null));
        public object SelectedItem
        {
            get
            {
                return (object)this.GetValue(SelectedItemProperty);
            }
            set
            {
                this.SetValue(SelectedItemProperty, value);
            }
        }

        #endregion  //SelectedItem

        #endregion //Properties

        #region Override Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._newItemTypesComboBox != null)
                this._newItemTypesComboBox.Loaded -= new RoutedEventHandler(this.NewItemTypesComboBox_Loaded);

            this._newItemTypesComboBox = this.GetTemplateChild(PART_NewItemTypesComboBox) as ComboBox;

            if (this._newItemTypesComboBox != null)
                this._newItemTypesComboBox.Loaded += new RoutedEventHandler(this.NewItemTypesComboBox_Loaded);
        }

        #endregion

        #region Constructors

        static CollectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CollectionControl), new FrameworkPropertyMetadata(typeof(CollectionControl)));
        }

        public CollectionControl()
        {
            this.Items = new ObservableCollection<object>();
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, this.AddNew, this.CanAddNew));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, this.Delete, this.CanDelete));
            this.CommandBindings.Add(new CommandBinding(ComponentCommands.MoveDown, this.MoveDown, this.CanMoveDown));
            this.CommandBindings.Add(new CommandBinding(ComponentCommands.MoveUp, this.MoveUp, this.CanMoveUp));
        }

        #endregion //Constructors

        #region Events

        #region ItemDeleting Event

        public delegate void ItemDeletingRoutedEventHandler(object sender, ItemDeletingEventArgs e);

        public static readonly RoutedEvent ItemDeletingEvent = EventManager.RegisterRoutedEvent("ItemDeleting", RoutingStrategy.Bubble, typeof(ItemDeletingRoutedEventHandler), typeof(CollectionControl));
        public event ItemDeletingRoutedEventHandler ItemDeleting
        {
            add
            {
                this.AddHandler(ItemDeletingEvent, value);
            }
            remove
            {
                this.RemoveHandler(ItemDeletingEvent, value);
            }
        }

        #endregion //ItemDeleting Event

        #region ItemDeleted Event

        public delegate void ItemDeletedRoutedEventHandler(object sender, ItemEventArgs e);

        public static readonly RoutedEvent ItemDeletedEvent = EventManager.RegisterRoutedEvent("ItemDeleted", RoutingStrategy.Bubble, typeof(ItemDeletedRoutedEventHandler), typeof(CollectionControl));
        public event ItemDeletedRoutedEventHandler ItemDeleted
        {
            add
            {
                this.AddHandler(ItemDeletedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ItemDeletedEvent, value);
            }
        }

        #endregion //ItemDeleted Event

        #region ItemAdding Event

        public delegate void ItemAddingRoutedEventHandler(object sender, ItemAddingEventArgs e);

        public static readonly RoutedEvent ItemAddingEvent = EventManager.RegisterRoutedEvent("ItemAdding", RoutingStrategy.Bubble, typeof(ItemAddingRoutedEventHandler), typeof(CollectionControl));
        public event ItemAddingRoutedEventHandler ItemAdding
        {
            add
            {
                this.AddHandler(ItemAddingEvent, value);
            }
            remove
            {
                this.RemoveHandler(ItemAddingEvent, value);
            }
        }

        #endregion //ItemAdding Event

        #region ItemAdded Event

        public delegate void ItemAddedRoutedEventHandler(object sender, ItemEventArgs e);

        public static readonly RoutedEvent ItemAddedEvent = EventManager.RegisterRoutedEvent("ItemAdded", RoutingStrategy.Bubble, typeof(ItemAddedRoutedEventHandler), typeof(CollectionControl));
        public event ItemAddedRoutedEventHandler ItemAdded
        {
            add
            {
                this.AddHandler(ItemAddedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ItemAddedEvent, value);
            }
        }

        #endregion //ItemAdded Event

        #endregion

        #region EventHandlers

        void NewItemTypesComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (this._newItemTypesComboBox != null)
                this._newItemTypesComboBox.SelectedIndex = 0;
        }

        #endregion

        #region Commands

        private void AddNew(object sender, ExecutedRoutedEventArgs e)
        {

            object newItem = null;
            if (realType == null)
            {
                if (Items.Count > 0) ItemsSourceType = Items[0].GetType();
            }
            if (Items.Count == 0)
            {
                if (ItemsSourceType == null)
                {
                    var type = ItemsSource.GetType();
                    if (type.IsGenericType)
                    {
                        ItemsSourceType = type.GetGenericArguments()[0];

                    }

                }


                try
                {
                    if (realType != null) newItem = Activator.CreateInstance(realType);

                    ItemsSource.Add(newItem);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                newItem = Items[0];


                if (realType == typeof(string))
                    newItem = "";
                else
                {
                    newItem = this.CreateNewItem(realType);
                   
                }
                ItemsSource.Add(newItem);
            }






            if (newItem == null)
            {
                return;
            }
            var eventArgs = new ItemAddingEventArgs(ItemAddingEvent, newItem);
            this.RaiseEvent(eventArgs);
            if (eventArgs.Cancel)
                return;
            newItem = eventArgs.Item;

            this.Items.Add(newItem);

            //this.RaiseEvent( new ItemEventArgs( ItemAddedEvent, newItem ) );

            this.SelectedItem = newItem;
        }

        private void CanAddNew(object sender, CanExecuteRoutedEventArgs e)
        {
            /*if(e.Parameter==null)
                e.CanExecute = false;
            Type t = e.Parameter.GetType();
            if (t != null && t.GetConstructor(Type.EmptyTypes) != null && !this.IsReadOnly)*/
            e.CanExecute = true;
        }

        private void Delete(object sender, ExecutedRoutedEventArgs e)
        {
            var eventArgs = new ItemDeletingEventArgs(ItemDeletingEvent, e.Parameter);
            this.RaiseEvent(eventArgs);
            if (eventArgs.Cancel)
                return;
            ItemsSource.Add(e.Parameter);
            this.Items.Remove(e.Parameter);

            //  this.RaiseEvent( new ItemEventArgs( ItemDeletedEvent, e.Parameter ) );
        }

        private void CanDelete(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = e.Parameter != null && !this.IsReadOnly;
        }

        private void MoveDown(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedItem = e.Parameter;
            var index = this.Items.IndexOf(selectedItem);
            this.Items.RemoveAt(index);
            this.Items.Insert(++index, selectedItem);
            this.SelectedItem = selectedItem;
        }

        private void CanMoveDown(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter != null && this.Items.IndexOf(e.Parameter) < (this.Items.Count - 1) && !this.IsReadOnly)
                e.CanExecute = true;
        }

        private void MoveUp(object sender, ExecutedRoutedEventArgs e)
        {
            var selectedItem = e.Parameter;
            var index = this.Items.IndexOf(selectedItem);
            this.Items.RemoveAt(index);
            this.Items.Insert(--index, selectedItem);
            this.SelectedItem = selectedItem;
        }

        private void CanMoveUp(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter != null && this.Items.IndexOf(e.Parameter) > 0 && !this.IsReadOnly)
                e.CanExecute = true;
        }

        #endregion //Commands

        #region Methods

        private static void CopyValues(object source, object destination)
        {
            Type currentType = source.GetType();

            while (currentType != null)
            {
                FieldInfo[] myObjectFields = currentType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (FieldInfo fi in myObjectFields)
                {
                    fi.SetValue(destination, fi.GetValue(source));
                }

                currentType = currentType.BaseType;
            }
        }

        private object CreateClone(object source)
        {
            object clone = null;
            if (source is string) return (string)source;


            Type type = source.GetType();

            clone = Activator.CreateInstance(type);
            CopyValues(source, clone);

            return clone;
        }


        private Type realType
        {
            get
            {
                if (ItemsSourceType == null)
                    return null;
               // if (ItemsSourceType is XFrmWorkAttribute)
                //    return ((XFrmWorkAttribute) ItemsSourceType).MyType;
                if (ItemsSourceType is Type)
                    return (ItemsSourceType as Type);
                return null;
            }
        }
        private IList CreateItemsSource()
        {
            IList list = null;

            if (this.realType != null)
            {
                ConstructorInfo constructor = this.realType.GetConstructor(Type.EmptyTypes);
                list = (IList)constructor.Invoke(null);
            }

            return list;
        }

        private object CreateNewItem(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public void PersistChanges()
        {
            IList list = this.ComputeItemsSource();
            if (list == null)
                return;

            //the easiest way to persist changes to the source is to just clear the source list and then add all items to it.
            list.Clear();

            foreach (var item in this.Items)
            {
                list.Add(item);
            }
        }

        private IList ComputeItemsSource()
        {
            if (this.ItemsSource == null)
                this.ItemsSource = this.CreateItemsSource();

            return this.ItemsSource;
        }

        #endregion //Methods
    }
}
