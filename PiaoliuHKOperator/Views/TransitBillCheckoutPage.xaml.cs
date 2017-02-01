﻿using PiaoliuHKOperator.Models.core;
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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TransitBillCheckoutPage : Page
    {
        TransitBillList TransitBillList_Instance;
        TransitBill TransitBill_Instance;
        PackageList PackageList_Instance;
        Package Package_Instance;

        public TransitBillCheckoutPage()
        {
            this.InitializeComponent();
            TransitBillList_Instance = new TransitBillList();
            TransitBill_Instance = new TransitBill();
            PackageList_Instance = new PackageList();
            Package_Instance = new Package();
        }

        private void SearchTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = getFilterArrayinPage();
            TransitBillList_Instance.findINSYSTransitBillbyFilter(FilterArray);

            for (int i = 0; i < TransitBillList_Instance.TransitBillItemList.Count; i++)
            {
                ListViewItem TransitBillListViewItem = new ListViewItem();
                TransitBillListViewItem.Content = TransitBillList_Instance.TransitBillItemList[i].TransitBillSerialID;
                TransitBillSelecting_ListView.Items.Add(TransitBillListViewItem);
            }
        }
        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            /*if (TransitBillAddress_ComboBox.GetValue() != "")
            {
                FilterArray.Add("TransitBillSerialID = \'" + TransitBillSerialID_TextBox.Text + "\'");
            }*/
            return FilterArray;
        }


        private void IgnorePackage_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findAllPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
        }

        private void PackupTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findAllPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
        }

        private void CSVDownload_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findAllPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
        }
    }
}
