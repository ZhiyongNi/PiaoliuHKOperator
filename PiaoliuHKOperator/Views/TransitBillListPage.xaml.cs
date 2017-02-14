using PiaoliuHKOperator.Models.core;
using PiaoliuHKOperator.Models.engine;
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
    public sealed partial class TransitBillListPage : Page
    {
        TransitBillList TransitBillList_Instance;
        public TransitBillListPage()
        {
            this.InitializeComponent();
            TransitBillList_Instance = new TransitBillList();
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
                        TransitBillOwnerID_TextBox.Text = CustomerOwner.CustomerID.ToString();
                        break;
                    case "PiaoliuHKOperator.Models.core.Package":
                        Package PackageRelated = (Package)TempObject;
                        TransitBillSerialID_TextBox.Text = PackageRelated.PackageRelatedTransitBillSerialID;
                        break;
                }
                Search_Button_Click(null, null);
            }
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = getFilterArrayinPage();
            TransitBillList_Instance.findAllTransitBillbyFilter(FilterArray);

            TransitBillList_ListView.ItemsSource = TransitBillList_Instance.TransitBillItemList;
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill TransitBillDetails_Instance = new TransitBill();
            TransitBillDetails_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillDetailsPage), TransitBillDetails_Instance);
        }
        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            if (TransitBillSerialID_TextBox.Text != "")
            {
                FilterArray.Add("TransitBillSerialID = \'" + TransitBillSerialID_TextBox.Text + "\'");
            }
            if (TransitBillOwnerID_TextBox.Text != "")
            {
                FilterArray.Add("TransitBillOwnerID = \'" + TransitBillOwnerID_TextBox.Text + "\'");
            }
            if (TransitBillStatus_TextBox.Text != "")
            {
                FilterArray.Add("TransitBillStatus = \'" + TransitBillStatus_TextBox.Text + "\'");
            }
            return FilterArray;
        }
    }
}
