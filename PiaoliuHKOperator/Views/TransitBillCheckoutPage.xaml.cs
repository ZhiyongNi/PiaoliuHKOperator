using PiaoliuHKOperator.Models.core;
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
            TransitBillCheckoutCSVItem_List = new List<TransitBillCheckoutCSVItem>();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            for (int i = 0; i < Global.SelfPickupAddress_List.Count; i++)
            {
                ComboBoxItem TransitBill_ComboBoxItem = new ComboBoxItem();
                TransitBill_ComboBoxItem.Tag = Global.SelfPickupAddress_List[i].ID;
                TransitBill_ComboBoxItem.Content = Global.SelfPickupAddress_List[i].ChineseName;

                TransitBillAddress_ComboBox.Items.Add(TransitBill_ComboBoxItem);
            }
        }
        private void SearchTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = getFilterArrayinPage();
            TransitBillList_Instance.findINSYSTransitBillbyFilter(FilterArray);

            for (int i = 0; i < TransitBillList_Instance.TransitBillItemList.Count; i++)
            {
                ListViewItem TransitBillListViewItem = new ListViewItem();
                TransitBillListViewItem.Content = TransitBillList_Instance.TransitBillItemList[i].TransitBillSerialID;
                //TransitBillListViewItem.Tag = TransitBillList_Instance.TransitBillItemList[i].TransitBillSerialID;
                TransitBillSelecting_ListView.Items.Add(TransitBillListViewItem);
            }
        }
        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            ComboBoxItem ComboBoxItem_Selected = (ComboBoxItem)TransitBillAddress_ComboBox.SelectedItem;
            if ((string)ComboBoxItem_Selected.Content != "All")
            {
                FilterArray.Add("TransitBillAddress = \'" + ComboBoxItem_Selected.Tag + "\'");
                FilterArray.Add("TransitBillStatus = \'" + "8" + "\'");
            }
            return FilterArray;
        }


        private void IgnorePackage_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            /*List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findAllPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }*/
        }

        private void PackupTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findALLPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
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

        private void ExtendTransitBill_Button_Click(object sender, RoutedEventArgs e)
        {
            TransitBill_Instance = this.TransitBillList_Instance.TransitBillItemList[TransitBillSelecting_ListView.SelectedIndex];

            List<string> FilterArray = new List<string>();
            FilterArray.Add("PackageRelatedTransitBillSerialID = \'" + TransitBill_Instance.TransitBillSerialID + "\'");
            PackageList_Instance.findINSYSPackagebyFilter(FilterArray);

            for (int i = 0; i < PackageList_Instance.PackageItemList.Count; i++)
            {
                ListViewItem PackageListViewItem = new ListViewItem();
                PackageListViewItem.Content = PackageList_Instance.PackageItemList[i].PackageSerialID;
                PackageSelecting_ListView.Items.Add(PackageListViewItem);
            }
        }
    }
}
