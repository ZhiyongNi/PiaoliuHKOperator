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
           /* object a = e.Parameter;
            if (a.GetType().Equals(new Customer()))
            {

                Customer s = (Customer)a;

            }
            */

        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {

            PackageList_Instance.findAllPackagebyFilter("PackageOwnerID = 191");

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

        private void PackageSerialID_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PackageSerialID_TextBox.Text == "SerialID")
            {
                PackageSerialID_TextBox.Text = "";
            }
        }

        private void PackageOwnerID_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PackageOwnerID_TextBox.Text == "OwnerID")
            {
                PackageOwnerID_TextBox.Text = "";
            }
        }

        private void PackageExpressTrackNumber_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PackageExpressTrackNumber_TextBox.Text == "ExpressNum")
            {
                PackageExpressTrackNumber_TextBox.Text = "";
            }
        }
    }
}
