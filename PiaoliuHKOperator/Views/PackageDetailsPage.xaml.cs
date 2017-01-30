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
        public Package PackageDetails_Instance;
        public PackageDetailsPage()
        {
            this.InitializeComponent();
            PackageDetails_Instance = new Package();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.PackageDetails_Instance = (Package)e.Parameter;
            PackageID_TextBox.Text = PackageDetails_Instance.PackageID == null ? "" : PackageDetails_Instance.PackageID.ToString();
            PackageSerialID_TextBox.Text = PackageDetails_Instance.PackageSerialID == null ? "" : PackageDetails_Instance.PackageSerialID;
            PackageOwnerID_TextBox.Text = PackageDetails_Instance.PackageOwnerID == null ? "" : PackageDetails_Instance.PackageOwnerID.ToString();
            PackageOwnerMobile_TextBox.Text = PackageDetails_Instance.PackageOwnerMobile == null ? "" : PackageDetails_Instance.PackageOwnerMobile;
            PackageExpressCompany_TextBox.Text = PackageDetails_Instance.PackageExpressCompany == null ? "" : PackageDetails_Instance.PackageExpressCompany;
            PackageExpressTrackNumber_TextBox.Text = PackageDetails_Instance.PackageExpressTrackNumber == null ? "" : PackageDetails_Instance.PackageExpressTrackNumber;
            PackageSnapshot_TextBox.Text = PackageDetails_Instance.PackageSnapshot == null ? "" : PackageDetails_Instance.PackageSnapshot;
            PackageWeight_TextBox.Text = PackageDetails_Instance.PackageWeight == null ? "" : PackageDetails_Instance.PackageWeight.ToString();
            PackageFee_TextBox.Text = PackageDetails_Instance.PackageFee == null ? "" : PackageDetails_Instance.PackageFee.ToString();
            PackageInTimeStamp_TextBox.Text = PackageDetails_Instance.PackageInTimeStamp == null ? "" : PackageDetails_Instance.PackageInTimeStamp.ToString();
            PackageOutTimeStamp_TextBox.Text = PackageDetails_Instance.PackageOutTimeStamp == null ? "" : PackageDetails_Instance.PackageOutTimeStamp.ToString();
            PackageStatus_TextBox.Text = PackageDetails_Instance.PackageStatus == null ? "" : PackageDetails_Instance.PackageStatus.ToString();
            PackageRemarks_TextBox.Text = PackageDetails_Instance.PackageRemarks == null ? "" : PackageDetails_Instance.PackageRemarks;
            PackageWorkerID_TextBox.Text = PackageDetails_Instance.PackageWorkerID == null ? "" : PackageDetails_Instance.PackageWorkerID.ToString();
            PackageRelatedTransitBillSerialID_TextBox.Text = PackageDetails_Instance.PackageRelatedTransitBillSerialID == null ? "" : PackageDetails_Instance.PackageRelatedTransitBillSerialID;

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerOwnerList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillListPage), this.PackageDetails_Instance);
        }

        private void RelatedTransitBillList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillListPage), this.PackageDetails_Instance);
        }
    }
}
