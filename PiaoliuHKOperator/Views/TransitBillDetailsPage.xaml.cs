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
        TransitBill TransitBillDetails_Instance;
        public TransitBillDetailsPage()
        {
            this.InitializeComponent();
            TransitBillDetails_Instance = new TransitBill();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TransitBillDetails_Instance = (TransitBill)e.Parameter;
           // CustomerID_TextBox.Text = CustomerDetails_Instance.CustomerID == null ? "" : CustomerDetails_Instance.CustomerID.ToString();


        }
        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
