using PiaoliuHKOperator.Models.core;
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
    public sealed partial class CustomerDetailsPage : Page
    {
        Customer CustomerDetails_Instance;
        public CustomerDetailsPage()
        {
            this.InitializeComponent();
            CustomerDetails_Instance = new Customer();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CustomerDetails_Instance = (Customer)e.Parameter;
            CustomerID_TextBox.Text = CustomerDetails_Instance.CustomerID.ToString();
            CustomerName_TextBox.Text = CustomerDetails_Instance.CustomerName == "" ? "" : CustomerDetails_Instance.CustomerName;
            //CustomerPassword_PasswordBox.Password = CustomerDetails_Instance.CustomerPassword;
            CustomerRealName_TextBox.Text = CustomerDetails_Instance.CustomerRealName;
            CustomerGender_TextBox.Text = CustomerDetails_Instance.CustomerGender.ToString();
            CustomerSelfMobile_TextBox.Text = CustomerDetails_Instance.CustomerSelfMobile;
            /*CustomerSelfDefaultAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfDefaultAddress;
            CustomerSelfDirectAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfDirectAddress;
            CustomerSelfOtherAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfOtherAddress;
            CustomerCollage_TextBox.Text = CustomerDetails_Instance.CustomerCollage;
            CustomerEmail_TextBox.Text = CustomerDetails_Instance.CustomerEmail;*/
            CustomerQQ_TextBox.Text = CustomerDetails_Instance.CustomerQQ == null ? "" : CustomerDetails_Instance.CustomerQQ;
            CustomerWeixin_TextBox.Text = CustomerDetails_Instance.CustomerWeixin == null ? "" : CustomerDetails_Instance.CustomerWeixin;
            CustomerAlipay_TextBox.Text = CustomerDetails_Instance.CustomerAlipay == null ? "" : CustomerDetails_Instance.CustomerAlipay;
            CustomerAvatarMobile_TextBox.Text = CustomerDetails_Instance.CustomerAvatarMobile == null ? "" : CustomerDetails_Instance.CustomerAvatarMobile;
            CustomerAccountStatus_TextBox.Text = CustomerDetails_Instance.CustomerAccountStatus == null ? "" : CustomerDetails_Instance.CustomerAccountStatus.ToString();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RelatedPackageList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageListPage), CustomerDetails_Instance);
        }

        private void RelatedTransitBillList_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
