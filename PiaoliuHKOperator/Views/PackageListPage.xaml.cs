using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PiaoliuHKOperator.Models.engine;
using PiaoliuHKOperator.Models.core;
using System.Collections.Generic;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PackageListPage : Page
    {
        PackageList PackageList_Instance;
        public PackageListPage()
        {
            this.InitializeComponent();
            PackageList_Instance = new PackageList();
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
                        PackageOwnerID_TextBox.Text = CustomerOwner.CustomerID.ToString();
                        break;
                }
            }

        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> FilterArray = getFilterArrayinPage();
            PackageList_Instance.findALLPackagebyFilter(FilterArray);

            PackageList_ListView.ItemsSource = PackageList_Instance.PackageItemList;
            PackageList_ListView.HeaderTemplate.
        }

        private void SubmitDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            Package PackageDetails_Instance = new Package();
            PackageDetails_Instance = this.PackageList_Instance.PackageItemList[PackageList_ListView.SelectedIndex];
            //PackageSelecting_ListView.SelectedIndex();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageDetailsPage), PackageDetails_Instance);
        }

        private List<string> getFilterArrayinPage()
        {
            List<string> FilterArray = new List<string>();
            if (PackageSerialID_TextBox.Text != "")
            {
                FilterArray.Add("PackageSerialID = \'" + PackageSerialID_TextBox.Text + "\'");
            }
            if (PackageOwnerID_TextBox.Text != "")
            {
                FilterArray.Add("PackageOwnerID = \'" + PackageOwnerID_TextBox.Text + "\'");
            }
            if (PackageExpressTrackNumber_TextBox.Text != "")
            {
                FilterArray.Add("PackageExpressTrackNumber = \'" + PackageExpressTrackNumber_TextBox.Text + "\'");
            }
            return FilterArray;
        }
    }
}
