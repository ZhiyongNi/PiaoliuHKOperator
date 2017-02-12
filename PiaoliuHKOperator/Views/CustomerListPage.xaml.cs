using PiaoliuHKOperator.Models.core;
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
            List<string> FilterArray = getFilterArrayinPage();
            CustomerList_Instance.findAllCustomerbyFilter(FilterArray);
            CustomerList_ListView.ItemsSource = CustomerList_Instance.CustomerItemList;

        }


        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Customer CustomerDetails_Instance = new Customer();
            CustomerDetails_Instance = this.CustomerList_Instance.CustomerItemList[CustomerList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerDetailsPage), CustomerDetails_Instance);
        }
        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            if (CustomerID_TextBox.Text != "")
            {
                FilterArray.Add("CustomerID = \'" + CustomerID_TextBox.Text + "\'");
            }
            if (CustomerSelfMobile_TextBox.Text != "")
            {
                FilterArray.Add("CustomerSelfMobile = \'" + CustomerSelfMobile_TextBox.Text + "\'");
            }
            if (CustomerRealName_TextBox.Text != "")
            {
                FilterArray.Add("CustomerRealName = \'" + CustomerRealName_TextBox.Text + "\'");
            }
            if (CustomerEmail_TextBox.Text != "")
            {
                FilterArray.Add("CustomerEmail = \'" + CustomerEmail_TextBox.Text + "\'");
            }
            return FilterArray;
        }
    }
}
