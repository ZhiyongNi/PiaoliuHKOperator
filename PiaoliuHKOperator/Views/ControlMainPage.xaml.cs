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
using PiaoliuHKOperator.Views;
using PiaoliuHKOperator.Models.core;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ControlMainPage : Page
    {
        public ControlMainPage()
        {
            this.InitializeComponent();
            if (Global.myAdmin.isAuthorized) { }
            this.AdminStatus_TextBlock.Text = Global.myAdmin.AdminRealName + "，欢迎你。";
        }

        private void CustomerList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerListPage));
        }

        private void PackageList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageListPage));
        }



        private void RegisterPackage_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(RegisterPackagePage));
        }



        private void TransitBillList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillListPage));
        }

       

        private void CheckoutTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillCheckoutPage));
        }

        private void TransitBillinOrderList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillinOrderPage));
        }

        private void RestoreTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void runScript_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(runScript));
        }

        private void ContainerWorkflow_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Repeat_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllShortcut_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
