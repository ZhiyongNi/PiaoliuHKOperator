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
    public sealed partial class TransitBillDetailsPage : Page
    {
        private const int AddNew_Action = 1;
        private const int Update_Action = 2;

        public TransitBill TransitBillDetails_Instance;
        public TransitBillDetailsPage()
        {
            this.InitializeComponent();
            TransitBillDetails_Instance = new TransitBill();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TransitBillDetails_Instance = (TransitBill)e.Parameter;
            if (TransitBillDetails_Instance.TransitBillID == 0)
            {
                ViewTransitBillinPage(AddNew_Action);
            }
            else
            {
                ViewTransitBillinPage(Update_Action);
            }
        }
        private void ViewTransitBillinPage(int f_Action)
        {
            TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == null ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
            TransitBillSerialID_TextBox.Text = TransitBillDetails_Instance.TransitBillSerialID == null ? "" : TransitBillDetails_Instance.TransitBillSerialID;
            TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == null ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();

            for (int i = 0; i < TransitBillDetails_Instance.TransitBillRelatedPackageSerialID.Count; i++)
            {
                CheckBox TransitBillRelatedPackageSerialID_CheckBox = new CheckBox();
                TransitBillRelatedPackageSerialID_CheckBox.Content = TransitBillDetails_Instance.TransitBillRelatedPackageSerialID[i];
                TransitBillRelatedPackageSerialID_CheckBox.IsChecked = true;
                TransitBillRelatedPackageSerialID_ComboBox.Items.Add(TransitBillRelatedPackageSerialID_CheckBox);
            }
            TransitBillRelatedPackageSerialID_ComboBox.SelectedIndex = 0;

            TransitBillRelatedPackageQuantity_TextBox.Text = TransitBillDetails_Instance.TransitBillRelatedPackageQuantity == null ? "" : TransitBillDetails_Instance.TransitBillRelatedPackageQuantity.ToString();
            TransitBillPrice_TextBox.Text = TransitBillDetails_Instance.TransitBillPrice == null ? "" : TransitBillDetails_Instance.TransitBillPrice.ToString();
            TransitBillMethod_TextBox.Text = TransitBillDetails_Instance.TransitBillMethod == null ? "" : TransitBillDetails_Instance.TransitBillMethod.ToString();
            TransitBillAddress_TextBox.Text = TransitBillDetails_Instance.TransitBillAddress == null ? "" : TransitBillDetails_Instance.TransitBillAddress;
            TransitBillSettlement_TextBox.Text = TransitBillDetails_Instance.TransitBillSettlement == null ? "" : TransitBillDetails_Instance.TransitBillSettlement.ToString();
            TransitBillInitializationTimeStamp_TextBox.Text = TransitBillDetails_Instance.TransitBillInitializationTimeStamp == null ? "" : TransitBillDetails_Instance.TransitBillInitializationTimeStamp.ToString();
            TransitBillSignTimeStamp_TextBox.Text = TransitBillDetails_Instance.TransitBillSignTimeStamp == null ? "" : TransitBillDetails_Instance.TransitBillSignTimeStamp.ToString();
            TransitBillStatus_TextBox.Text = TransitBillDetails_Instance.TransitBillStatus == null ? "" : TransitBillDetails_Instance.TransitBillStatus.ToString();
            switch (f_Action)
            {
                case AddNew_Action:
                    /*PackageID_CheckBox.IsEnabled = false;
                    PackageID_CheckBox.IsChecked = false;
                    PackageID_TextBox.IsEnabled = false;
                    PackageID_TextBox.Text = String.Empty;
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
                case Update_Action:
                    TransitBillID_CheckBox.IsEnabled = false;
                    TransitBillID_CheckBox.IsChecked = false;
                    TransitBillID_TextBox.IsEnabled = false;
                    TransitBillStatus_CheckBox.IsEnabled = true;
                    TransitBillStatus_CheckBox.IsChecked = true;
                    //TransitBillStatus_ComboBox.IsEnabled = true;
                    break;
            }
        }


        private void getTransitBillinPage()
        {
            //if (PackageID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageID = Convert.ToInt16(PackageID_TextBox.Text); }
        }

        private List<string> getTransitBillArgumentArrayinPage()
        {
            List<string> ArgumentArray = new List<string>();
            if (PackageID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageID = \'" + PackageID_TextBox.Text + "\'");
            }
            return ArgumentArray;
        }


        private void RelatedPackageList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageListPage), this.TransitBillDetails_Instance);
        }

        private void CustomerOwnerList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerListPage), this.TransitBillDetails_Instance);
        }

        private void ALL_CheckBox_Checking(object sender, RoutedEventArgs e)
        {
            CheckBox Source_Checkbox = (CheckBox)e.OriginalSource;
            switch (Source_Checkbox.Name)
            {
                case "TransitBillID_CheckBox":
                    if (Source_Checkbox.IsChecked == true)
                    {
                        TransitBillID_TextBox.IsEnabled = true;
                    }
                    else
                    {
                        TransitBillID_TextBox.IsEnabled = false;
                        TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == null ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
                    }
                    break;
                case "TransitBillSerialID_CheckBox":
                    if (Source_Checkbox.IsChecked == true)
                    {
                        TransitBillSerialID_TextBox.IsEnabled = true;
                    }
                    else
                    {
                        TransitBillSerialID_TextBox.IsEnabled = false;
                        TransitBillSerialID_TextBox.Text = TransitBillDetails_Instance.TransitBillSerialID == null ? "" : TransitBillDetails_Instance.TransitBillSerialID;
                    }
                    break;


                    private void TransitBillOwnerID_CheckBox_Checked(object sender, RoutedEventArgs e)
                    {
                        TransitBillOwnerID_TextBox.IsEnabled = true;
                    }

                    private void TransitBillOwnerID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
                    {
                        TransitBillOwnerID_TextBox.IsEnabled = false;
                        TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == null ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();
                    }

            }
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TransitBillDetails_Instance.TransitBillID != 0)
            {
                this.TransitBillDetails_Instance.updateTransitBillArgumentInfo(getTransitBillArgumentArrayinPage());
            }
            else
            {
                getTransitBillinPage();
                this.TransitBillDetails_Instance.addTransitBillNewRecoder();
            }
        }
    }
}
