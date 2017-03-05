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
    public sealed partial class PackageDetailsPage : Page
    {
        private const int NewPackage_Action = 1;
        private const int UpdatePackage_Action = 2;

        public Package PackageDetails_Instance;
        public PackageDetailsPage()
        {
            this.InitializeComponent();
            PackageDetails_Instance = new Package();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.PackageDetails_Instance = (Package)e.Parameter;
            if (PackageDetails_Instance.PackageID == 0)
            {
                ViewPackageinPage(NewPackage_Action);
            }
            else
            {
                ViewPackageinPage(UpdatePackage_Action);
            }

        }

        private void ViewPackageinPage(int f_Action)
        {
            PackageID_TextBox.Text = PackageDetails_Instance.PackageID == 0 ? "" : PackageDetails_Instance.PackageID.ToString();
            PackageSerialID_TextBox.Text = PackageDetails_Instance.PackageSerialID == null ? "" : PackageDetails_Instance.PackageSerialID;
            PackageOwnerID_TextBox.Text = PackageDetails_Instance.PackageOwnerID == 0 ? "" : PackageDetails_Instance.PackageOwnerID.ToString();
            PackageOwnerMobile_TextBox.Text = PackageDetails_Instance.PackageOwnerMobile == null ? "" : PackageDetails_Instance.PackageOwnerMobile;
            foreach (Global.PackageExpressCompany_Struct PackageExpressCompany_Struct_Item in Global.PackageExpressCompany_Dictionary.Values)
            {
                ComboBoxItem PackageExpressCompany_ComboBoxItem = new ComboBoxItem();
                PackageExpressCompany_ComboBoxItem.Tag = PackageExpressCompany_Struct_Item.Tag;
                PackageExpressCompany_ComboBoxItem.Content = PackageExpressCompany_Struct_Item.Chinese;

                PackageExpressCompany_ComboBox.Items.Add(PackageExpressCompany_ComboBoxItem);
                if (PackageExpressCompany_ComboBoxItem.Tag.Equals(PackageDetails_Instance.PackageStatus))
                {
                    PackageExpressCompany_ComboBox.SelectedItem = PackageExpressCompany_ComboBoxItem;
                }
            }
            PackageExpressTrackNumber_TextBox.Text = PackageDetails_Instance.PackageExpressTrackNumber == null ? "" : PackageDetails_Instance.PackageExpressTrackNumber;
            PackageSnapshot_TextBox.Text = PackageDetails_Instance.PackageSnapshot == null ? "" : PackageDetails_Instance.PackageSnapshot;
            PackageWeight_TextBox.Text = PackageDetails_Instance.PackageWeight == 0 ? "" : PackageDetails_Instance.PackageWeight.ToString();
            PackageFee_TextBox.Text = PackageDetails_Instance.PackageFee == 0 ? "" : PackageDetails_Instance.PackageFee.ToString();
            PackageInTimeStamp_TextBox.Text = new DateTime(1970, 1, 1).AddSeconds(PackageDetails_Instance.PackageInTimeStamp).ToLocalTime().ToString();
            PackageOutTimeStamp_TextBox.Text = new DateTime(1970, 1, 1).AddSeconds(PackageDetails_Instance.PackageOutTimeStamp).ToLocalTime().ToString();
            foreach (Global.PackageStatus_Struct PackageStatus_Struct_Item in Global.PackageStatus_Dictionary.Values)
            {
                ComboBoxItem PackageStatus_ComboBoxItem = new ComboBoxItem();
                PackageStatus_ComboBoxItem.Tag = PackageStatus_Struct_Item.Tag;
                PackageStatus_ComboBoxItem.Content = PackageStatus_Struct_Item.Chinese;

                PackageStatus_ComboBox.Items.Add(PackageStatus_ComboBoxItem);
                if (PackageStatus_ComboBoxItem.Tag.Equals(PackageDetails_Instance.PackageStatus))
                {
                    PackageStatus_ComboBox.SelectedItem = PackageStatus_ComboBoxItem;
                }
            }
            PackageRemarks_TextBox.Text = PackageDetails_Instance.PackageRemarks == null ? "" : PackageDetails_Instance.PackageRemarks;
            PackageWorkerID_TextBox.Text = PackageDetails_Instance.PackageWorkerID == 0 ? "" : PackageDetails_Instance.PackageWorkerID.ToString();
            PackageRelatedTransitBillSerialID_TextBox.Text = PackageDetails_Instance.PackageRelatedTransitBillSerialID == null ? "" : PackageDetails_Instance.PackageRelatedTransitBillSerialID;

            switch (f_Action)
            {
                case NewPackage_Action:
                    PackageID_CheckBox.IsEnabled = false;
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
                    PackageWorkerID_TextBox.Text = String.Empty;
                    break;
                case UpdatePackage_Action:
                    PackageID_CheckBox.IsEnabled = false;
                    PackageID_CheckBox.IsChecked = false;
                    PackageID_TextBox.IsEnabled = false;
                    PackageStatus_CheckBox.IsEnabled = true;
                    PackageStatus_CheckBox.IsChecked = true;
                    PackageStatus_ComboBox.IsEnabled = true;
                    break;
            }
        }

        private void getPackageinPage()
        {
            if (PackageID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageID = Convert.ToInt16(PackageID_TextBox.Text); }
            if (PackageSerialID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageSerialID = PackageSerialID_TextBox.Text; }
            if (PackageOwnerID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageOwnerID = Convert.ToInt16(PackageOwnerID_TextBox.Text); }
            if (PackageOwnerMobile_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageOwnerMobile = PackageOwnerMobile_TextBox.Text; }
            if (PackageExpressCompany_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageExpressCompany = Convert.ToString(((ComboBoxItem)PackageExpressCompany_ComboBox.SelectedItem).Tag); }
            if (PackageExpressTrackNumber_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageExpressTrackNumber = PackageExpressTrackNumber_TextBox.Text; }
            if (PackageSnapshot_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageSnapshot = PackageSnapshot_TextBox.Text; }
            if (PackageWeight_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageWeight = Convert.ToSingle(PackageWeight_TextBox.Text); }
            if (PackageFee_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageFee = Convert.ToSingle(PackageFee_TextBox.Text); }
            if (PackageInTimeStamp_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageInTimeStamp = (Convert.ToDateTime(PackageInTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds; }
            if (PackageOutTimeStamp_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageOutTimeStamp = (Convert.ToDateTime(PackageOutTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds; }
            if (PackageStatus_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageStatus = Convert.ToInt16(((ComboBoxItem)PackageStatus_ComboBox.SelectedItem).Tag); }
            if (PackageRemarks_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageRemarks = PackageRemarks_TextBox.Text; }
            if (PackageWorkerID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageWorkerID = Convert.ToInt16(PackageWorkerID_TextBox.Text); }
            if (PackageRelatedTransitBillSerialID_CheckBox.IsChecked == true) { this.PackageDetails_Instance.PackageRelatedTransitBillSerialID = PackageRelatedTransitBillSerialID_TextBox.Text; }
        }

        private List<string> getPackageArgumentArrayinPage()
        {
            List<string> ArgumentArray = new List<string>();
            if (PackageID_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageID = \'" + PackageID_TextBox.Text + "\'");
            }
            if (PackageSerialID_CheckBox.IsChecked == true)
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
                ArgumentArray.Add("PackageInTimeStamp = \'" + (Convert.ToDateTime(PackageInTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds + "\'");
            }
            if (PackageOutTimeStamp_CheckBox.IsChecked == true)
            {
                ArgumentArray.Add("PackageOutTimeStamp = \'" + (Convert.ToDateTime(PackageOutTimeStamp_TextBox.Text).ToUniversalTime() - new DateTime(1970, 1, 1)).Seconds + "\'");
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
            }
            return ArgumentArray;
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PackageDetails_Instance.PackageID != 0)
            {
                this.PackageDetails_Instance.updatePackageArgumentInfo(getPackageArgumentArrayinPage());
            }
            else
            {
                getPackageinPage();
                this.PackageDetails_Instance.addPackageNewRecoder();
            }
        }

        private void CustomerOwnerList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerListPage), this.PackageDetails_Instance);
        }

        private void RelatedTransitBillList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillListPage), this.PackageDetails_Instance);
        }

        private void PackageID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PackageID_TextBox.IsEnabled = true;
        }

        private void PackageID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PackageID_TextBox.IsEnabled = false;
            PackageID_TextBox.Text = PackageDetails_Instance.PackageID == null ? "" : PackageDetails_Instance.PackageID.ToString();
        }

        private void PackageSerialID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PackageSerialID_TextBox.IsEnabled = true;
        }

        private void PackageSerialID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PackageSerialID_TextBox.IsEnabled = false;
            PackageSerialID_TextBox.Text = PackageDetails_Instance.PackageSerialID == null ? "" : PackageDetails_Instance.PackageSerialID;
        }

        private void PackageOwnerID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PackageOwnerID_TextBox.IsEnabled = true;
        }

        private void PackageOwnerID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PackageOwnerID_TextBox.IsEnabled = false;
            PackageOwnerID_TextBox.Text = PackageDetails_Instance.PackageOwnerID == null ? "" : PackageDetails_Instance.PackageOwnerID.ToString();
        }

        private void PackageOwnerMobile_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PackageOwnerMobile_TextBox.IsEnabled = true;
        }

        private void PackageOwnerMobile_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PackageOwnerMobile_TextBox.IsEnabled = false;
            PackageOwnerMobile_TextBox.Text = PackageDetails_Instance.PackageOwnerMobile == null ? "" : PackageDetails_Instance.PackageOwnerMobile;
        }


    }
}
