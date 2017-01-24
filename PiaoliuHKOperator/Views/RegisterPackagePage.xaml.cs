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
using PiaoliuHKOperator.Models.core;
using PiaoliuHKOperator.Models.engine;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PackageDetailsPage : Page
    {

        public PackageDetailsPage()
        {
            this.InitializeComponent();
        }






        private void PackageExpressTrackNumber_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PackageList PackageList_Instance = new PackageList();
            PackageList_Instance.findAllPackagebyFilter("PackageExpressTrackNumber = " + PackageExpressTrackNumber_TextBox.Text);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            Package a = new Package();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageDetailsPage));
            
        }
    }
}