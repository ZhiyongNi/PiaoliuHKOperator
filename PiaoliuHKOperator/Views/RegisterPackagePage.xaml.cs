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
using PiaoliuHKOperator.Views;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RegisterPackagePage : Page
    {
        PackageList PackageList_Instance;

        public RegisterPackagePage()
        {
            this.InitializeComponent();
        }


        private void PackageExpressTrackNumber_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PackageList_Instance = new PackageList();
            PackageList_Instance.findINSYSPackagebyFilter(getFilterArrayinPage());

            if (PackageList_Instance.PackageItemList.Count != 0)
            {
                PackageSelecting_ListView.ItemsSource = PackageList_Instance.PackageItemList;

                Matched_CheckBox.IsChecked = true;
                PackageSelecting_ListView.SelectedIndex = 0;
            }
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Package PackageDetails_Instance = new Package();
            if (Matched_CheckBox.IsChecked == true)
            {
                PackageDetails_Instance = this.PackageList_Instance.PackageItemList[PackageSelecting_ListView.SelectedIndex];
            }
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageDetailsPage), PackageDetails_Instance);
        }
        private List<string> getFilterArrayinPage()
        {

            List<string> FilterArray = new List<string>();
            if (PackageExpressTrackNumber_TextBox.Text != "")
            {
                FilterArray.Add("PackageExpressTrackNumber = \'" + PackageExpressTrackNumber_TextBox.Text + "\'");
            }
            if (PackageExpressCompany_TextBox.Text != "")
            {
                FilterArray.Add("PackageExpressCompany = \'" + PackageExpressCompany_TextBox.Text + "\'");
            }
            if (PackageOwnerMobile_TextBox.Text != "")
            {
                FilterArray.Add("PackageOwnerMobile = \'" + PackageOwnerMobile_TextBox.Text + "\'");
            }
            if (PackageOwnerName_TextBox.Text != "")
            {
                FilterArray.Add("PackageOwnerName = \'" + PackageOwnerName_TextBox.Text + "\'");
            }
            return FilterArray;
        }

        private void Repeat_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllShortcut_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}