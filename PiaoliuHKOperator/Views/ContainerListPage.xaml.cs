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
    public sealed partial class ContainerListPage : Page
    {
        ContainerList ContainerList_Instance;
        public ContainerListPage()
        {
            this.InitializeComponent();
            ContainerList_Instance = new ContainerList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Global.ContainerStatus_Struct ContainerStatus_Struct_Item in Global.ContainerStatus_Dictionary.Values)
            {
                ComboBoxItem ContainerStatus_ComboBoxItem = new ComboBoxItem();
                ContainerStatus_ComboBoxItem.Tag = ContainerStatus_Struct_Item.Tag;
                ContainerStatus_ComboBoxItem.Content = ContainerStatus_Struct_Item.Chinese;

                ContainerStatus_ComboBox.Items.Add(ContainerStatus_ComboBoxItem);
            }

            object TempObject = e.Parameter;
            if (TempObject != null)
            {
                switch (TempObject.GetType().FullName)
                {
                    case "PiaoliuHKOperator.Models.core.TransitBill":
                        TransitBill TransitBillRelated = (TransitBill)TempObject;
                        ContainerRelatedTransitBillSerialID_TextBox.Text = TransitBillRelated.TransitBillSerialID;
                        break;
                    case "PiaoliuHKOperator.Models.core.Package":
                        Package PackageRelated = (Package)TempObject;
                        ContainerRelatedTransitBillSerialID_TextBox.Text = PackageRelated.PackageRelatedTransitBillSerialID;
                        break;
                }
                Search_Button_Click(null, null);
            }
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = getFilterArrayinPage();
            ContainerList_Instance.findAllContainerbyFilter(FilterArray);

            ContainerList_ListView.ItemsSource = ContainerList_Instance.ContainerItemList;
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Container ContainerDetails_Instance = new Container();
            ContainerDetails_Instance = this.ContainerList_Instance.ContainerItemList[ContainerList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ContainerDetailsPage), ContainerDetails_Instance);
        }
        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            if (ContainerSerialID_TextBox.Text != "")
            {
                FilterArray.Add("ContainerSerialID = \'" + ContainerSerialID_TextBox.Text + "\'");
            }
            if (ContainerRelatedTransitBillSerialID_TextBox.Text != "")
            {
                FilterArray.Add("ContainerOwnerID = \'" + ContainerRelatedTransitBillSerialID_TextBox.Text + "\'");
            }

            ComboBoxItem ComboBoxItem_Selected = (ComboBoxItem)ContainerStatus_ComboBox.SelectedItem;
            if (!ComboBoxItem_Selected.Tag.Equals("0"))
            {
                FilterArray.Add("ContainerStatus = \'" + ComboBoxItem_Selected.Tag + "\'");
            }
            return FilterArray;
        }
    }
}
