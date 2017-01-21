using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PiaoliuHKOperator.Models.core;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PiaoliuHKOperator.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void AdminLogin_Button_Click(object sender, RoutedEventArgs e)
        {
            Admin Admin_Instance = new Admin();

            CryptographicHash MD5Tool = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5).CreateHash();
            MD5Tool.Append(CryptographicBuffer.ConvertStringToBinary(AdminPassword_Text.Password, BinaryStringEncoding.Utf8));
            string AdminPassword_MD5 = CryptographicBuffer.EncodeToHexString(MD5Tool.GetValueAndReset());

            Admin_Instance.AuthAdminbyNameandPassword(AdminName_Text.Text, AdminPassword_MD5);

            if (Admin_Instance.isAuthorized)
            {
                AdminName_Text.Text = Admin_Instance.AdminRealName + "你好，成功登陆。";
            }
            Global.myAdmin = Admin_Instance;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ControlMainPage));

        }
    }
}
