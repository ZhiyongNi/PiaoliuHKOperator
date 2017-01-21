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
using PiaoliuHKOperator.Models.core;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RegisterPackagePage : Page
    {
        private Package Package_Instance;
        public RegisterPackagePage()
        {
            this.InitializeComponent();
        }




        private void PackageExpressTrackNumber_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Package Package_Instance = new Package();
            Package_Instance.findPackagebyExpressTrackNumber(int.Parse(PackageExpressTrackNumber_TextBox.Text));
            if (Package_Instance.PackageOwnerID != 0)
            {
                PackageOwnerID_TextBox.Text = Package_Instance.PackageOwnerID.ToString();


            }

        }
    }
}