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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TransitBillCheckoutPage : Page
    {
        TransitBillList TransitBillList_Instance;
        PackageList PackageList_Instance;
        public TransitBillCheckoutPage()
        {
            this.InitializeComponent();
            TransitBillList_Instance = new TransitBillList();
            PackageList_Instance = new PackageList();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //string FilterString = getFilterStringinPage();
            string FilterString = "where TransitBillStatus = 1";
            //TransitBillList_Instance.findAllTransitBillbyFilter(FilterString);

            for (int i = 0; i < TransitBillList_Instance.TransitBillItemList.Count; i++)
            {
                ListViewItem TransitBillListViewItem = new ListViewItem();
                TransitBillListViewItem.Content = TransitBillList_Instance.TransitBillItemList[i].TransitBillSerialID;
                TransitBillSelecting_ListView.Items.Add(TransitBillListViewItem);
            }
        }
        private void ExtendTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            string FilterString = "where PackageRelatedTransitBillSerialID = " + TransitBill_Instance.TransitBillSerialID;
            //PackageList_Instance.findAllPackagebyFilter(FilterString);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }

        }

        private void Packup_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
