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
            string FilterString = getFilterStringinPage();
            CustomerList_Instance.findAllCustomerbyFilter(FilterString);

            for (int i = 0; i < CustomerList_Instance.CustomerItemList.Count; i++)
            {
                ListViewItem CustomerListViewItem = new ListViewItem();
                CustomerListViewItem.Content = CustomerList_Instance.CustomerItemList[i].CustomerRealName;
                CustomerList_ListView.Items.Add(CustomerListViewItem);

            }

        }


        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Customer CustomerDetails_Instance = new Customer();
            CustomerDetails_Instance = this.CustomerList_Instance.CustomerItemList[CustomerList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerDetailsPage), CustomerDetails_Instance);
        }
        private string getFilterStringinPage()
        {
            string FilterString = "";
            if (CustomerID_TextBox.Text != "CustomerID" && CustomerID_TextBox.Text != "")
            {
                FilterString += "CustomerID = " + CustomerID_TextBox.Text;
            }
            if (CustomerSelfMobile_TextBox.Text != "SelfMobile" && CustomerSelfMobile_TextBox.Text != "")
            {
                FilterString += "CustomerSelfMobile = " + CustomerSelfMobile_TextBox.Text;
            }
            if (CustomerRealName_TextBox.Text != "RealName" && CustomerRealName_TextBox.Text != "")
            {
                FilterString += "CustomerRealName = " + CustomerRealName_TextBox.Text;
            }
            if (CustomerEmail_TextBox.Text != "Email" && CustomerEmail_TextBox.Text != "")
            {
                FilterString += "CustomerEmail = " + CustomerEmail_TextBox.Text;
            }
            if (FilterString != "")
            {
                FilterString = "Where " + FilterString;
            }
            return FilterString;

        }

        private void CustomerID_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerID_TextBox.Text == "CustomerID")
            {
                CustomerID_TextBox.Text = "";
            }
        }

        private void CustomerSelfMobile_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerSelfMobile_TextBox.Text == "SelfMobile")
            {
                CustomerSelfMobile_TextBox.Text = "";
            }
        }

        private void CustomerRealName_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerRealName_TextBox.Text == "RealName")
            {
                CustomerRealName_TextBox.Text = "";
            }
        }

        private void CustomerEmail_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerEmail_TextBox.Text == "Email")
            {
                CustomerEmail_TextBox.Text = "";
            }
        }
    }
}
