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
using PiaoliuHKOperator.Views;
using PiaoliuHKOperator.Models.core;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using PiaoliuHKOperator.Models.network;
using PiaoliuHKOperator.Models.engine;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using System.Collections.ObjectModel;
using Windows.UI.ViewManagement;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace PiaoliuHKOperator
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().TryResizeView(new Size { Width = 1280, Height = 720 });

        }




        private void WorkStart_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OperatorSocket.connectSocketServer();
            }
            catch (Exception) { }
            finally
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(LoginPage));
            }
        }
    }
}
