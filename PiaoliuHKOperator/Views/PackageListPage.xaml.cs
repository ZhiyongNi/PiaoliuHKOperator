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
using PiaoliuHKOperator.Models.engine;
using PiaoliuHKOperator.Models.core;
using PiaoliuHKOperator.Views;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PackageListPage : Page
    {
        PackageList PackageList_Instance;
        public PackageListPage()
        {
            this.InitializeComponent();
            PackageList_Instance = new PackageList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            object TempObject = e.Parameter;
            if (TempObject != null)
            {
                switch (TempObject.GetType().FullName)
                {
                    case "PiaoliuHKOperator.Models.core.Customer":
                        Customer CustomerOwner = (Customer)TempObject;
                        PackageOwnerID_TextBox.Text = CustomerOwner.CustomerID.ToString();
                        break;
                }
            }
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            string FilterString = getFilterStringinPage();
            PackageList_Instance.findAllPackagebyFilter(FilterString);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageList_ListView.Items.Add(PackageListViewItem);
            }
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Package PackageDetails_Instance = new Package();
            PackageDetails_Instance = this.PackageList_Instance.PackageItemList[PackageList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageDetailsPage), PackageDetails_Instance);
        }

        private string getFilterStringinPage()
        {
            string FilterString = "";
            if (PackageSerialID_TextBox.Text != "SerialID" && PackageSerialID_TextBox.Text != "")
            {
                FilterString += "PackageSerialID = " + PackageSerialID_TextBox.Text;
            }
            if (PackageOwnerID_TextBox.Text != "OwnerID" && PackageOwnerID_TextBox.Text != "")
            {
                FilterString += "PackageOwnerID = " + PackageOwnerID_TextBox.Text;
            }
            if (PackageExpressTrackNumber_TextBox.Text != "ExpressNum" && PackageExpressTrackNumber_TextBox.Text != "")
            {
                FilterString += "PackageExpressTrackNumber = " + PackageExpressTrackNumber_TextBox.Text;
            }

            if (FilterString != "")
            {
                FilterString = "Where " + FilterString;
            }
            return FilterString;

        }
    }
}
