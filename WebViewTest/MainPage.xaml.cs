using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.Web.Http;
using PixivCS;
using Windows.Data.Json;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace WebViewTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public async Task TestMethod()
        {
            WebViewLogin wvl = new WebViewLogin(900, 600);
            wvl.targetUri = "https://www.pixiv.net/";
            wvl.loginUri = "https://accounts.pixiv.net/login";
            wvl.ClearCookies();//若不提前清除，可能会保留有之前的cookie而直接登录成功
            wvl.Method += SetCookieText;//将WebViewLogin类的委托对象绑定实际的传值方法
            await wvl.ShowWebView();
        }

        /// <summary>
        /// 供WebViewLogin类调用的传值方法
        /// </summary>
        /// <param name="str">WebView抓取到的cookie</param>
        private void SetCookieText(string str)
        {
            cookieShow.Text = str;
        }
        private async void start_Click(object sender, RoutedEventArgs e)
        {
            await TestMethod();
        }
    }
}
