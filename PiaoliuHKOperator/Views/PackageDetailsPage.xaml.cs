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

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Package PackageDetails = (Package)e.Parameter;
            PackageID_TextBox.Text = PackageDetails.PackageID.ToString();
            PackageSerialID_TextBox.Text = PackageDetails.PackageSerialID;
            PackageOwnerID_TextBox.Text = PackageDetails.PackageOwnerID.ToString();
            /*PackageOwnerMobile_TextBox.Text = PackageDetails.PackageOwnerMobile;
            PackageExpressCompany_TextBox.Text = PackageDetails.PackageExpressCompany;
            PackageExpressTrackNumber_TextBox.Text = PackageDetails.PackageExpressTrackNumber;
            PackageSnapshot_TextBox.Text = PackageDetails.PackageSnapshot;
            PackageWeight_TextBox.Text = PackageDetails.PackageWeight.ToString();
            PackageFee_TextBox.Text = PackageDetails.PackageFee.ToString();
            PackageInTimeStamp_TextBox.Text = PackageDetails.PackageInTimeStamp.ToString();
            PackageOutTimeStamp_TextBox.Text = PackageDetails.PackageOutTimeStamp.ToString();
            PackageStatus_TextBox.Text = PackageDetails.PackageStatus.ToString();
            PackageRemarks_TextBox.Text = PackageDetails.PackageRemarks;
            PackageWorkerID_TextBox.Text = PackageDetails.PackageWorkerID.ToString();
            PackageRelatedTransitBillSerialID_TextBox.Text = PackageDetails.PackageRelatedTransitBillSerialID;
*/
        }
    }
}
