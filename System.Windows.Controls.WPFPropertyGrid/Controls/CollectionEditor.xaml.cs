/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.WpfPropertyGrid.Attributes;
using System.Windows.Data;


namespace System.Windows.Controls.WpfPropertyGrid
{
    /// <summary>
    /// Interaction logic for CollectionEditor.xaml
    /// </summary>
    public partial class CollectionEditor : UserControl
    {



        public IList BindingSource
        {
            get { return (IList)GetValue(BindingSourceProperty); }
            set { SetValue(BindingSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BindingSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingSourceProperty =
            DependencyProperty.Register("BindingSource", typeof(object), typeof(CollectionEditor), new PropertyMetadata(null));



        public CollectionEditor()
        {
            InitializeComponent();
        }


       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CollectionControlDialog editor = new CollectionControlDialog();
            Binding binding = new Binding("BindingSource");

            binding.Source = this;
            binding.Mode = BindingSource.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            BindingOperations.SetBinding(editor, CollectionControlDialog.ItemsSourceProperty, binding);

            List<object> NewItemTypes = null;

            var type = BindingSource.GetType();
            if (type.IsGenericType)
            {
                var type2 = type.GetGenericArguments()[0];

                if (type2.IsInterface)
                {
                 
                        NewItemTypes = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(type2))).Select(d=>(object)d)
           .ToList();
                 
                  
                 

                }
                else if (type2.IsClass)
                {
                    NewItemTypes = AppDomain.CurrentDomain.GetAssemblies()
             .SelectMany(a => a.GetTypes().Where(t => AttributeHelper.IsBaseType(t, type2))).Select(d=>(object)d)
             .ToList();
                    if(type2.IsAbstract==false)
                     NewItemTypes.Add(type2);
                }




            }
            editor.NewItemTypes = NewItemTypes;


            editor.ShowDialog();
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确认清空当前集合的元素吗？", "提示信息",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                BindingSource.Clear();
            }
        
        }
    }
}
