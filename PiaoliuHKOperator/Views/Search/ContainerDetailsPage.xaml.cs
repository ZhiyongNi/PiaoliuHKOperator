﻿using PiaoliuHKOperator.Models.core;
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
    public sealed partial class ContainerDetailsPage : Page
    {
        TransitBill TransitBillDetails_Instance;
        public ContainerDetailsPage()
        {
            this.InitializeComponent();
            TransitBillDetails_Instance = new TransitBill();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TransitBillDetails_Instance = (TransitBill)e.Parameter;
            TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == null ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
            TransitBillSerialID_TextBox.Text = TransitBillDetails_Instance.TransitBillSerialID == null ? "" : TransitBillDetails_Instance.TransitBillSerialID;
            TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == null ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();

            for (int i = 0; i < TransitBillDetails_Instance.TransitBillRelatedPackageSerialID.Count; i++)
            {
                CheckBox TransitBillRelatedPackageSerialID_CheckBox = new CheckBox();
                TransitBillRelatedPackageSerialID_CheckBox.Content = TransitBillDetails_Instance.TransitBillRelatedPackageSerialID[i];
                TransitBillRelatedPackageSerialID_CheckBox.IsChecked = true;
                TransitBillRelatedPackageSerialID_ComboBox.Items.Add(TransitBillRelatedPackageSerialID_CheckBox);
            }
            TransitBillRelatedPackageSerialID_ComboBox.SelectedIndex = 0;

            TransitBillRelatedPackageQuantity_TextBox.Text = TransitBillDetails_Instance.TransitBillRelatedPackageQuantity == null ? "" : TransitBillDetails_Instance.TransitBillRelatedPackageQuantity.ToString();
            TransitBillPrice_TextBox.Text = TransitBillDetails_Instance.TransitBillPrice == null ? "" : TransitBillDetails_Instance.TransitBillPrice.ToString();
            TransitBillMethod_TextBox.Text = TransitBillDetails_Instance.TransitBillMethod == null ? "" : TransitBillDetails_Instance.TransitBillMethod.ToString();
            TransitBillAddress_TextBox.Text = TransitBillDetails_Instance.TransitBillAddress == null ? "" : TransitBillDetails_Instance.TransitBillAddress;
            TransitBillSettlement_TextBox.Text = TransitBillDetails_Instance.TransitBillSettlement == null ? "" : TransitBillDetails_Instance.TransitBillSettlement.ToString();
            TransitBillInitializationTimeStamp_TextBox.Text = TransitBillDetails_Instance.TransitBillInitializationTimeStamp == null ? "" : TransitBillDetails_Instance.TransitBillInitializationTimeStamp.ToString();
            TransitBillSignTimeStamp_TextBox.Text = TransitBillDetails_Instance.TransitBillSignTimeStamp == null ? "" : TransitBillDetails_Instance.TransitBillSignTimeStamp.ToString();
            TransitBillStatus_TextBox.Text = TransitBillDetails_Instance.TransitBillStatus == null ? "" : TransitBillDetails_Instance.TransitBillStatus.ToString();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RelatedPackageList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PackageListPage), this.TransitBillDetails_Instance);
        }

        private void CustomerOwnerList_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CustomerListPage), this.TransitBillDetails_Instance);
        }

        private void TransitBillID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TransitBillID_TextBox.IsEnabled = true;
        }

        private void TransitBillID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TransitBillID_TextBox.IsEnabled = false;
            TransitBillID_TextBox.Text = TransitBillDetails_Instance.TransitBillID == null ? "" : TransitBillDetails_Instance.TransitBillID.ToString();
        }

        private void TransitBillSerialID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TransitBillSerialID_TextBox.IsEnabled = true;
        }

        private void TransitBillSerialID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TransitBillSerialID_TextBox.IsEnabled = false;
            TransitBillSerialID_TextBox.Text = TransitBillDetails_Instance.TransitBillSerialID == null ? "" : TransitBillDetails_Instance.TransitBillSerialID;
        }

        private void TransitBillOwnerID_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TransitBillOwnerID_TextBox.IsEnabled = true;
        }

        private void TransitBillOwnerID_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TransitBillOwnerID_TextBox.IsEnabled = false;
            TransitBillOwnerID_TextBox.Text = TransitBillDetails_Instance.TransitBillOwnerID == null ? "" : TransitBillDetails_Instance.TransitBillOwnerID.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
