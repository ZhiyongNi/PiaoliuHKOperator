using PiaoliuHKOperator.Models.engine;
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
        CustomerList CustomerList_Instance;
        public CustomerListPage()
        {
            this.InitializeComponent();
            CustomerList_Instance = new CustomerList();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            string FilterString = getFilterStringinPage();
            CustomerList_Instance.findAllCustomerbyFilter(FilterString);

            for (int i = 0; i < CustomerList_Instance.CustomerItemList.Count; i++)
            {
                ListViewItem CustomerListViewItem = new ListViewItem();
                CustomerListViewItem.Content = CustomerList_Instance.CustomerItemList[i].CustomerRealName;
                CustomerList_ListView.Items.Add(CustomerListViewItem);

            }

        }
        private string getFilterStringinPage()
        {
            string FilterString = "";
            if (CustomerID_TextBox.Text != "")
            {
                FilterString = "CustomerID = " + CustomerID_TextBox.Text;
            }
            return FilterString;
        }

    }
}
