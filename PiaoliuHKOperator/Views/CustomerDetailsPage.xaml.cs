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
        private const int NewPackage_Action = 1;
        private const int UpdatePackage_Action = 2;

        Customer CustomerDetails_Instance;
        public CustomerDetailsPage()
        {
            this.InitializeComponent();
            CustomerDetails_Instance = new Customer();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.CustomerDetails_Instance = (Customer)e.Parameter;
            if (CustomerDetails_Instance.CustomerID == 0)
            {
                ViewCustomerinPage(NewPackage_Action);
            }
            else
            {
                ViewCustomerinPage(UpdatePackage_Action);
            }
        }

        private void ViewCustomerinPage(int f_Action)
        {
            CustomerID_TextBox.Text = CustomerDetails_Instance.CustomerID == 0 ? "" : CustomerDetails_Instance.CustomerID.ToString();
            CustomerName_TextBox.Text = CustomerDetails_Instance.CustomerName == null ? "" : CustomerDetails_Instance.CustomerName;
            CustomerPassword_PasswordBox.Password = CustomerDetails_Instance.CustomerPassword == null ? "" : CustomerDetails_Instance.CustomerPassword;
            CustomerRealName_TextBox.Text = CustomerDetails_Instance.CustomerRealName == null ? "" : CustomerDetails_Instance.CustomerRealName;
            CustomerGender_TextBox.Text = CustomerDetails_Instance.CustomerGender == null ? "" : CustomerDetails_Instance.CustomerGender.ToString();
            CustomerSelfMobile_TextBox.Text = CustomerDetails_Instance.CustomerSelfMobile == null ? "" : CustomerDetails_Instance.CustomerSelfMobile;
            CustomerSelfDefaultAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfDefaultAddress == null ? "" : CustomerDetails_Instance.CustomerSelfDefaultAddress;
            CustomerSelfDirectAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfDirectAddress == null ? "" : CustomerDetails_Instance.CustomerSelfDirectAddress;
            CustomerSelfOtherAddress_TextBox.Text = CustomerDetails_Instance.CustomerSelfOtherAddress == null ? "" : CustomerDetails_Instance.CustomerSelfOtherAddress;
            CustomerCollage_TextBox.Text = CustomerDetails_Instance.CustomerCollage == null ? "" : CustomerDetails_Instance.CustomerCollage;
            CustomerEmail_TextBox.Text = CustomerDetails_Instance.CustomerEmail == null ? "" : CustomerDetails_Instance.CustomerEmail;
            CustomerQQ_TextBox.Text = CustomerDetails_Instance.CustomerQQ == null ? "" : CustomerDetails_Instance.CustomerQQ;
            CustomerWeixin_TextBox.Text = CustomerDetails_Instance.CustomerWeixin == null ? "" : CustomerDetails_Instance.CustomerWeixin;
            CustomerAlipay_TextBox.Text = CustomerDetails_Instance.CustomerAlipay == null ? "" : CustomerDetails_Instance.CustomerAlipay;
            CustomerAvatarMobile_TextBox.Text = CustomerDetails_Instance.CustomerAvatarMobile == null ? "" : CustomerDetails_Instance.CustomerAvatarMobile;
            CustomerAvatarAddress_TextBox.Text = CustomerDetails_Instance.CustomerAvatarMobile == null ? "" : CustomerDetails_Instance.CustomerAvatarMobile;
            CustomerAccountStatus_TextBox.Text = CustomerDetails_Instance.CustomerAccountStatus == null ? "" : CustomerDetails_Instance.CustomerAccountStatus.ToString();
            switch (f_Action)
            {
                case NewPackage_Action:
                    /*CustomerID_CheckBox.IsEnabled = false;
                    CustomerID_CheckBox.IsChecked = false;
                    CustomerID_TextBox.IsEnabled = false;
                    CustomerID_TextBox.Text = String.Empty;
                    PackageSerialID_CheckBox.IsEnabled = false;
                    PackageSerialID_CheckBox.IsChecked = false;
                    PackageSerialID_TextBox.IsEnabled = false;
                    PackageSerialID_TextBox.Text = String.Empty;
                    PackageOwnerMobile_CheckBox.IsChecked = true;
                    PackageExpressCompany_CheckBox.IsChecked = true;
                    PackageInTimeStamp_CheckBox.IsEnabled = false;
                    PackageInTimeStamp_CheckBox.IsChecked = false;
                    PackageInTimeStamp_TextBox.IsEnabled = false;
                    PackageInTimeStamp_TextBox.Text = String.Empty;
                    PackageOutTimeStamp_CheckBox.IsEnabled = false;
                    PackageOutTimeStamp_CheckBox.IsChecked = false;
                    PackageOutTimeStamp_TextBox.IsEnabled = false;
                    PackageOutTimeStamp_TextBox.Text = String.Empty;
                    PackageStatus_CheckBox.IsEnabled = false;
                    PackageStatus_CheckBox.IsChecked = false;
                    PackageStatus_ComboBox.IsEnabled = false;
                    PackageStatus_ComboBox.SelectedItem = null;
                    PackageWorkerID_CheckBox.IsEnabled = false;
                    PackageWorkerID_CheckBox.IsChecked = false;
                    PackageWorkerID_TextBox.IsEnabled = false;
                    PackageWorkerID_TextBox.Text = String.Empty;*/
                    break;
                case UpdatePackage_Action:
                    CustomerID_CheckBox.IsEnabled = false;
                    CustomerID_CheckBox.IsChecked = false;
                    CustomerID_TextBox.IsEnabled = false;
                    CustomerSelfMobile_CheckBox.IsEnabled = false;
                    CustomerSelfMobile_CheckBox.IsChecked = false;
                    CustomerSelfMobile_TextBox.IsEnabled = false;
                    break;
            }
        }
        private void getPackageinPage() { }

        private List<string> getCustomerArgumentArrayinPage()
        {
            List<string> ArgumentArray = new List<string>();
            if (CustomerID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("CustomerID = \'" + CustomerID_TextBox.Text + "\'");
            }
            /*if (PackageSerialID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageSerialID = \'" + PackageSerialID_TextBox.Text + "\'");
            }
            if (PackageOwnerID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageOwnerID = \'" + PackageOwnerID_TextBox.Text + "\'");
            }
            if (PackageOwnerMobile_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageOwnerMobile = \'" + PackageOwnerMobile_TextBox.Text + "\'");
            }
            if (PackageExpressCompany_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageExpressCompany = \'" + Convert.ToString(((ComboBoxItem)PackageExpressCompany_ComboBox.SelectedItem).Tag) + "\'");
            }
            if (PackageExpressTrackNumber_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageExpressTrackNumber = \'" + PackageExpressTrackNumber_TextBox.Text + "\'");
            }
            if (PackageSnapshot_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageSnapshot = \'" + PackageSnapshot_TextBox.Text + "\'");
            }
            if (PackageWeight_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageWeight = \'" + PackageWeight_TextBox.Text + "\'");
            }
            if (PackageFee_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageFee = \'" + PackageFee_TextBox.Text + "\'");
            }
            if (PackageInTimeStamp_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageInTimeStamp = \'" + (Convert.ToDateTime(PackageInTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds + "\'");
            }
            if (PackageOutTimeStamp_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageOutTimeStamp = \'" + (Convert.ToDateTime(PackageOutTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds + "\'");
            }
            if (PackageStatus_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageStatus = \'" + Convert.ToString(((ComboBoxItem)PackageStatus_ComboBox.SelectedItem).Tag) + "\'");
            }
            if (PackageRemarks_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageRemarks = \'" + PackageRemarks_TextBox.Text + "\'");
            }
            if (PackageWorkerID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageWorkerID = \'" + PackageWorkerID_TextBox.Text + "\'");
            }
            if (PackageRelatedTransitBillSerialID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageRelatedTransitBillSerialID = \'" + PackageRelatedTransitBillSerialID_TextBox.Text);
            }*/
            return ArgumentArray;
        }


        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RelatedPackageList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageListPage), this.CustomerDetails_Instance);
        }

        private void RelatedTransitBillList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillListPage), this.CustomerDetails_Instance);
        }

        private void ALL_CheckBox_Checking(object sender, RoutedEventArgs e)
        {
            CheckBox Source_Checkbox = ((CheckBox)e.OriginalSource);
            switch (Source_Checkbox.Name)
            {
                case "CustomerID_CheckBox":
                    if (Source_Checkbox.IsChecked == true)
                    {
                        CustomerID_TextBox.IsEnabled = true;
                    }
                    else
                    {
                        CustomerID_TextBox.IsEnabled = false;
                        CustomerID_TextBox.Text = CustomerDetails_Instance.CustomerID == 0 ? "" : CustomerDetails_Instance.CustomerID.ToString();
                    }
                    break;
            }

        }
    }
}
