﻿using PiaoliuHKOperator.Models.core;
using PiaoliuHKOperator.Models.engine;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Provider;
using System.Text;
using PiaoliuHKOperator.Models.engine.DataCSV;
using static PiaoliuHKOperator.Global;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using System.Collections.ObjectModel;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class TransitBillCheckoutPage : Page
    {
        List<TransitBillCheckoutCSVItem> TransitBillCheckoutCSVItem_List;
        TransitBillList TransitBillList_Instance;
        PackageList PackageList_Instance;
        TransitBill TransitBill_Instance;
        Package Package_Instance;
        ObservableCollection<TransitBill> TransitBillRemoveItem_Collection;
        ObservableCollection<Package> PackageRemoveItem_Collection;

        public TransitBillCheckoutPage()
        {
            this.InitializeComponent();
            TransitBillList_Instance = new TransitBillList();
            PackageList_Instance = new PackageList();

            TransitBill_Instance = new TransitBill();
            Package_Instance = new Package();

            TransitBillRemoveItem_Collection = new ObservableCollection<TransitBill>();
            PackageRemoveItem_Collection = new ObservableCollection<Package>();

            TransitBillCheckoutCSVItem_List = new List<TransitBillCheckoutCSVItem>();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Global.TransitBillStatus_Struct TransitBillStatusItem in Global.TransitBillStatus_Dictionary.Values)
            {
                ComboBoxItem TransitBillStatus_ComboBoxItem = new ComboBoxItem();
                TransitBillStatus_ComboBoxItem.Tag = TransitBillStatusItem.Tag;
                TransitBillStatus_ComboBoxItem.Content = TransitBillStatusItem.Chinese;

                TransitBillStatus_ComboBox.Items.Add(TransitBillStatus_ComboBoxItem);
            }

            foreach (Global.CustomerSelfDefaultAddress_Struct CustomerSelfDefaultAddress_Struct_Item in Global.CustomerSelfDefaultAddress_Dictionary.Values)
            {
                ComboBoxItem CustomerSelfDefaultAddress_ComboBoxItem = new ComboBoxItem();
                CustomerSelfDefaultAddress_ComboBoxItem.Tag = CustomerSelfDefaultAddress_Struct_Item.Tag;
                CustomerSelfDefaultAddress_ComboBoxItem.Content = CustomerSelfDefaultAddress_Struct_Item.Chinese;

                TransitBillAddress_ComboBox.Items.Add(CustomerSelfDefaultAddress_ComboBoxItem);
            }
        }
        private void SearchTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = new List<string>();
            ComboBoxItem ComboBoxItem_Selected = (ComboBoxItem)TransitBillAddress_ComboBox.SelectedItem;
            if ((string)ComboBoxItem_Selected.Content != "All")
            {
                FilterArray.Add("TransitBillAddress = \'" + ComboBoxItem_Selected.Tag + "\'");
            }
            ComboBoxItem_Selected = (ComboBoxItem)TransitBillStatus_ComboBox.SelectedItem;
            if ((string)ComboBoxItem_Selected.Content != "All")
            {
                FilterArray.Add("TransitBillStatus = \'" + ComboBoxItem_Selected.Tag + "\'");
            }
            TransitBillList_Instance.findINSYSTransitBillbyFilter(FilterArray);

            TransitBillSelecting_ListView.ItemsSource = TransitBillList_Instance.TransitBillItemList;
            TransitBillRemoved_ListView.ItemsSource = TransitBillRemoveItem_Collection;
        }
        private void ExtendTransitBill_Button_Click(object sender, RoutedEventArgs e)//unFinished
        {
            TransitBill_Instance = (TransitBill)TransitBillSelecting_ListView.SelectedItem;

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findINSYSPackagebyFilter(FilterArray);

            TransitBill_TextBlock.Text = TransitBill_Instance.TransitBillSerialID;
            PackageSelecting_ListView.ItemsSource = PackageList_Instance.PackageItemList;
            PackageRemoved_ListView.ItemsSource = PackageRemoveItem_Collection;

            FilterArray = new List<string>();
            FilterArray.Add("TransitBillOwnerID = \'" + TransitBill_Instance.TransitBillOwnerID + "\'");
            FilterArray.Add("TransitBillStatus = \'" + (TransitBill_Instance.TransitBillStatus + 1) + "\'");
            TransitBillList TransitBillFollow_List = new TransitBillList();
            TransitBillFollow_List.findINSYSTransitBillbyFilter(FilterArray);
            foreach (TransitBill TransitBillItem in TransitBillFollow_List.TransitBillItemList)
            {
                ComboBoxItem TransitBillItem_ComboBoxItem = new ComboBoxItem();
                TransitBillItem_ComboBoxItem.Tag = TransitBillItem.TransitBillID;
                TransitBillItem_ComboBoxItem.Content = TransitBillItem.TransitBillSerialID;
                TransitBillTarget_ComboBox.Items.Add(TransitBillItem_ComboBoxItem);
            }
            TransitBillTargetQuantity_TextBlock.Text = "Row: " + (TransitBillFollow_List.TransitBillItemList.Count + 1).ToString();
        }
        private void PackupTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            Container Container_Instance = new Container();
            foreach (TransitBill TransitBill_Cell in this.TransitBillList_Instance.TransitBillItemList)
            {
                Container_Instance.ContainerRelatedTransitBillSerialID.Add(TransitBill_Cell.TransitBillSerialID);
            }
            Container_Instance.addContainerNewRecoder();
        }

        private async void CSVDownload_Button_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem ComboBoxItem_Selected = (ComboBoxItem)TransitBillAddress_ComboBox.SelectedItem;

            foreach (TransitBill TransitBill_Cell in this.TransitBillList_Instance.TransitBillItemList)
            {
                TransitBillCheckoutCSVItem CheckoutCSVItem_Cell = new TransitBillCheckoutCSVItem(TransitBill_Cell);
                CheckoutCSVItem_Cell.CompleteSelfInfo();
                TransitBillCheckoutCSVItem_List.Add(CheckoutCSVItem_Cell);
            }
            string CSVContent = DataToCSV.parseListToCSV(this.TransitBillCheckoutCSVItem_List);

            FileSavePicker FileSavePicker_Instance = new FileSavePicker();
            FileSavePicker_Instance.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

            FileSavePicker_Instance.FileTypeChoices.Add("CSV（逗号分隔）", new List<string>() { ".csv" });
            FileSavePicker_Instance.SuggestedFileName = DateTime.Now.ToString("yyyyMMdd") + ".SZ." + (string)ComboBoxItem_Selected.Content + "_List";


            StorageFile TargetCSVFile = await FileSavePicker_Instance.PickSaveFileAsync();
            if (TargetCSVFile != null)
            {
                // 在用户完成更改并调用CompleteUpdatesAsync之前，阻止对文件的更新
                CachedFileManager.DeferUpdates(TargetCSVFile);

                await FileIO.WriteBytesAsync(TargetCSVFile, Encoding.UTF8.GetBytes(CSVContent));
                // 当完成更改时，其他应用程序才可以对该文件进行更改。
                FileUpdateStatus updateStatus = await CachedFileManager.CompleteUpdatesAsync(TargetCSVFile);
                if (updateStatus == FileUpdateStatus.Complete)
                {
                    textBlock.Text = TargetCSVFile.Name + " 已经保存好了。";
                }
                else
                {
                    textBlock.Text = TargetCSVFile.Name + " 保存失败了。";
                }
            }
            else
            {
                textBlock.Text = "保存操作被取消。";
            }
        }

        private void TransitBillRemove_Button_Click(object sender, RoutedEventArgs e)
        {
            Button Source_Button = (Button)e.OriginalSource;
            switch (Source_Button.Name)
            {
                case "TransitBillRemoveRight_Button":
                    ExtendTransitBill_Button.IsEnabled = false;
                    TransitBillRemoveItem_Collection.Add((TransitBill)TransitBillSelecting_ListView.SelectedItem);
                    TransitBillList_Instance.TransitBillItemList.Remove((TransitBill)TransitBillSelecting_ListView.SelectedItem);
                    break;
                case "TransitBillRemoveLeft_Button":
                    ExtendTransitBill_Button.IsEnabled = false;
                    TransitBillRemoveItem_Collection.Add((TransitBill)TransitBillSelecting_ListView.SelectedItem);
                    TransitBillList_Instance.TransitBillItemList.Remove((TransitBill)TransitBillSelecting_ListView.SelectedItem);
                    break;
            }
        }

        private void PackageRemove_Button_Click(object sender, RoutedEventArgs e)
        {
            Button Source_Button = (Button)e.OriginalSource;
            switch (Source_Button.Name)
            {
                case "PackageRemoveRight_Button":
                    ExtendTransitBill_Button.IsEnabled = false;
                    PackageRemoveItem_Collection.Add((Package)PackageSelecting_ListView.SelectedItem);
                    PackageList_Instance.PackageItemList.Remove((Package)PackageSelecting_ListView.SelectedItem);
                    break;
                case "PackageRemoveLeft_Button":
                    ExtendTransitBill_Button.IsEnabled = false;
                    PackageList_Instance.PackageItemList.Add((Package)PackageRemoved_ListView.SelectedItem);
                    PackageRemoveItem_Collection.Remove((Package)PackageRemoved_ListView.SelectedItem);
                    break;
            }
        }

        private void TransitbillListChanging_Button_Click(object sender, RoutedEventArgs e)
        {
            Button Source_Button = (Button)e.OriginalSource;
            switch (Source_Button.Name)
            {
                case "TransitbillChangingSubmit_Button":
                    break;
                case "TransitBillChangingIgnore_Button":
                    break;
            }
        }

        private void PackageListChanging_Button_Click(object sender, RoutedEventArgs e)//unFinished
        {
            Button Source_Button = (Button)e.OriginalSource;
            switch (Source_Button.Name)
            {
                case "PackageListChangingSubmit_Button":

                    break;
                case "PackageListChangingIgnore_Button":
                    break;
            }
        }

    }
}
