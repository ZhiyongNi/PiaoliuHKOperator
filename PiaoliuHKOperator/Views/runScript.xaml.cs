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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class runScript : Page
    {
        ScriptCommand ScriptCommand_Instance = new ScriptCommand();
        public runScript()
        {
            this.InitializeComponent();
        }

        private void run_Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDRepeatChecks_CheckBox.IsChecked == true)
            {
                this.ScriptCommand_Instance.IDRepeatChecks();

                foreach (string ResultReturn in this.ScriptCommand_Instance.ResultReturnList)
                {
                    Return_TextBlock.Inlines.Add(new Run() { Text = ResultReturn });
                    Return_TextBlock.Inlines.Add(new LineBreak());
                }
                this.ScriptCommand_Instance.ResultReturnList.Clear();
            }

            if (INSYSPackageRelatedTransitBillCheck_CheckBox.IsChecked == true)
            {
                this.ScriptCommand_Instance.INSYSPackageRelatedTransitBillCheck();

                foreach (string ResultReturn in this.ScriptCommand_Instance.ResultReturnList)
                {
                    Return_TextBlock.Inlines.Add(new Run() { Text = ResultReturn });
                    Return_TextBlock.Inlines.Add(new LineBreak());
                }
                this.ScriptCommand_Instance.ResultReturnList.Clear();
            }

            if (PendingtoCheckoutTransitBill_CheckBox.IsChecked == true)
            {
                this.ScriptCommand_Instance.PendingtoCheckoutTransitBill();

                foreach (string ResultReturn in this.ScriptCommand_Instance.ResultReturnList)
                {
                    Return_TextBlock.Inlines.Add(new Run() { Text = ResultReturn });
                    Return_TextBlock.Inlines.Add(new LineBreak());
                }
                this.ScriptCommand_Instance.ResultReturnList.Clear();
            }

            if (SIGNEDPackageRelatedTransitBillCheck_CheckBox.IsChecked == true)
            {
                this.ScriptCommand_Instance.SIGNEDPackageRelatedTransitBillCheck();

                foreach (string ResultReturn in this.ScriptCommand_Instance.ResultReturnList)
                {
                    Return_TextBlock.Inlines.Add(new Run() { Text = ResultReturn });
                    Return_TextBlock.Inlines.Add(new LineBreak());
                }
                this.ScriptCommand_Instance.ResultReturnList.Clear();
            }
        }
    }
}
