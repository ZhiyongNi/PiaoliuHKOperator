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
using static PiaoliuHKOperator.Global;

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
            TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == 0 ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
            TransitBillSerialID_TextBox.Text = TransitBillDetails_Instance.TransitBillSerialID == null ? "" : TransitBillDetails_Instance.TransitBillSerialID;
            TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == 0 ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();

            foreach (string RelatedPackageSerialID in TransitBillDetails_Instance.TransitBillRelatedPackageSerialID)
            {
                CheckBox TransitBillRelatedPackageSerialID_CheckBox = new CheckBox();
                TransitBillRelatedPackageSerialID_CheckBox.Content = RelatedPackageSerialID;
                TransitBillRelatedPackageSerialID_CheckBox.IsChecked = true;
                TransitBillRelatedPackageSerialID_ComboBox.Items.Add(TransitBillRelatedPackageSerialID_CheckBox);
            }
            TransitBillRelatedPackageSerialID_ComboBox.SelectedIndex = 0;

            TransitBillRelatedPackageQuantity_TextBox.Text = TransitBillDetails_Instance.TransitBillRelatedPackageQuantity == 0 ? "" : TransitBillDetails_Instance.TransitBillRelatedPackageQuantity.ToString();
            TransitBillPrice_TextBox.Text = TransitBillDetails_Instance.TransitBillPrice == 0 ? "" : TransitBillDetails_Instance.TransitBillPrice.ToString();
            TransitBillMethod_TextBox.Text = TransitBillDetails_Instance.TransitBillMethod == 0 ? "" : TransitBillDetails_Instance.TransitBillMethod.ToString();
            TransitBillAddress_TextBox.Text = TransitBillDetails_Instance.TransitBillAddress == null ? "" : TransitBillDetails_Instance.TransitBillAddress;
            TransitBillSettlement_TextBox.Text = TransitBillDetails_Instance.TransitBillSettlement == 0 ? "" : TransitBillDetails_Instance.TransitBillSettlement.ToString();
            TransitBillInitializationTimeStamp_TextBox.Text = new DateTime(1970, 1, 1).AddSeconds(TransitBillDetails_Instance.TransitBillInitializationTimeStamp).ToLocalTime().ToString();
            TransitBillSignTimeStamp_TextBox.Text = new DateTime(1970, 1, 1).AddSeconds(TransitBillDetails_Instance.TransitBillSignTimeStamp).ToLocalTime().ToString();

            TransitBillStatus_ComboBox.Items.Clear();
            foreach (TransitBillStatus_Struct TransitBillStatus_Struct_Item in Global.TransitBillStatus_Dictionary.Values)
            {
                ComboBoxItem TransitBillStatus_ComboBoxItem = new ComboBoxItem();
                TransitBillStatus_ComboBoxItem.Tag = TransitBillStatus_Struct_Item.Tag;
                TransitBillStatus_ComboBoxItem.Content = TransitBillStatus_Struct_Item.Chinese;

                TransitBillStatus_ComboBox.Items.Add(TransitBillStatus_ComboBoxItem);
                if (TransitBillStatus_ComboBoxItem.Tag.Equals(TransitBillDetails_Instance.TransitBillStatus))
                {
                    TransitBillStatus_ComboBox.SelectedItem = TransitBillStatus_ComboBoxItem;
                }
            }

            switch (f_Action)
            {
                case AddNew_Action:
                    TransitBillID_CheckBox.IsEnabled = false;
                    TransitBillID_CheckBox.IsChecked = false;
                    TransitBillID_TextBox.IsEnabled = false;
                    TransitBillID_TextBox.Text = String.Empty;
                    TransitBillSerialID_CheckBox.IsEnabled = false;
                    TransitBillSerialID_CheckBox.IsChecked = false;
                    TransitBillSerialID_TextBox.IsEnabled = false;
                    TransitBillSerialID_TextBox.Text = String.Empty;
                    TransitBillStatus_CheckBox.IsEnabled = false;
                    TransitBillStatus_CheckBox.IsChecked = false;
                    TransitBillStatus_ComboBox.IsEnabled = false;
                    TransitBillStatus_ComboBox.SelectedItem = null;
                    /*TransitBillOwnerMobile_CheckBox.IsChecked = true;
                    TransitBillExpressCompany_CheckBox.IsChecked = true;
                    TransitBillInTimeStamp_CheckBox.IsEnabled = false;
                    TransitBillInTimeStamp_CheckBox.IsChecked = false;
                    TransitBillInTimeStamp_TextBox.IsEnabled = false;
                    TransitBillInTimeStamp_TextBox.Text = String.Empty;
                    TransitBillOutTimeStamp_CheckBox.IsEnabled = false;
                    TransitBillOutTimeStamp_CheckBox.IsChecked = false;
                    TransitBillOutTimeStamp_TextBox.IsEnabled = false;
                    TransitBillOutTimeStamp_TextBox.Text = String.Empty;
                    TransitBillWorkerID_CheckBox.IsEnabled = false;
                    TransitBillWorkerID_CheckBox.IsChecked = false;
                    TransitBillWorkerID_TextBox.IsEnabled = false;
                    TransitBillWorkerID_TextBox.Text = String.Empty;*/
                    break;
                case Update_Action:
                    TransitBillID_CheckBox.IsEnabled = false;
                    TransitBillID_CheckBox.IsChecked = false;
                    TransitBillID_TextBox.IsEnabled = false;
                    TransitBillStatus_CheckBox.IsEnabled = true;
                    TransitBillStatus_CheckBox.IsChecked = true;
                    TransitBillStatus_ComboBox.IsEnabled = true;
                    break;
            }
        }


        private void getTransitBillinPage()
        {
            if (TransitBillID_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillID = Convert.ToInt16(TransitBillID_TextBox.Text); }
            if (TransitBillSerialID_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillSerialID = TransitBillSerialID_TextBox.Text; }
            if (TransitBillOwnerID_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillOwnerID = Convert.ToInt16(TransitBillOwnerID_TextBox.Text); }
            //if (TransitBillRelatedPackageSerialID_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillRelatedPackageSerialID = Convert.ToInt16(((ComboBoxItem)TransitBillExpressCompany_ComboBox.SelectedItem).Tag); }
            if (TransitBillRelatedPackageQuantity_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillRelatedPackageQuantity = Convert.ToInt16(TransitBillRelatedPackageQuantity_TextBox.Text); }
            if (TransitBillPrice_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillPrice = Convert.ToSingle(TransitBillPrice_TextBox.Text); }
            //if (TransitBillMethod_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillMethod = Convert.ToInt16(TransitBillMethod_TextBox.Text); }
            if (TransitBillAddress_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillAddress = TransitBillAddress_TextBox.Text; }
            if (TransitBillSettlement_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillSettlement = Convert.ToInt16(TransitBillSettlement_TextBox.Text); }
            if (TransitBillInitializationTimeStamp_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillInitializationTimeStamp = (Convert.ToDateTime(TransitBillInitializationTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds; }
            if (TransitBillSignTimeStamp_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillSignTimeStamp = (Convert.ToDateTime(TransitBillSignTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds; }
            if (TransitBillStatus_CheckBox.IsChecked == true) { this.TransitBillDetails_Instance.TransitBillStatus = Convert.ToInt16(((ComboBoxItem)TransitBillStatus_ComboBox.SelectedItem).Tag); }
        }

        private List<string> getTransitBillArgumentArrayinPage()
        {
            List<string> ArgumentArray = new List<string>();
            if (TransitBillID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("TransitBillID = \'" + TransitBillID_TextBox.Text + "\'");
            }
            return ArgumentArray;
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
                        TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == 0 ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
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

                case " TransitBillOwnerID_CheckBox":
                    if (Source_Checkbox.IsChecked == true)
                    {
                        TransitBillOwnerID_TextBox.IsEnabled = true;
                    }
                    else
                    {
                        TransitBillOwnerID_TextBox.IsEnabled = false;
                        TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == 0 ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();
                    }
                    break;

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


    }
}
