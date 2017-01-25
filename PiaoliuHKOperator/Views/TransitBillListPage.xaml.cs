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
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBillList_Instance.findAllTransitBillbyFilter("PackageOwnerID = 191");

            for (int i = 0; i < TransitBillList_Instance.TransitBillItemList.Count; i++)
            {
                ListViewItem TransitBillListViewItem = new ListViewItem();
                TransitBillListViewItem.Content = TransitBillList_Instance.TransitBillItemList[i].TransitBillSerialID;
                TransitBillList_ListView.Items.Add(TransitBillListViewItem);
            }
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill TransitBillDetails_Instance = new TransitBill();
            TransitBillDetails_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TransitBillDetailsPage), TransitBillDetails_Instance);
        }
    }
}
