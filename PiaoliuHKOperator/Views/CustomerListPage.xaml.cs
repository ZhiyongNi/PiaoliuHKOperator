﻿using PiaoliuHKOperator.Models.engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CustomerListPage : Page
    {
        public CustomerListPage()
        {
            this.InitializeComponent();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerList CustomerList_Instance = new CustomerList();
            CustomerList_Instance.findAllCustomerbyFilter("CustomerID > 100");




            for (int i = 0; i < CustomerList_Instance.CustomerItemList.Count; i++)
            {

                ListViewItem CustomerListViewItem = new ListViewItem();
                CustomerList_ListView.Items.Add(CustomerListViewItem);

            }

        }


    }
}
