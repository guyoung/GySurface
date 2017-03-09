using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace GySurface.Samples.Skeleton.Contents
{
    /// <summary>
    /// BrowserContent.xaml 的交互逻辑
    /// </summary>
    public partial class BrowserContent : UserControl
    {
        System.Windows.Forms.WebBrowser _webBrowser;

        private object _holder;
        private Uri _uri;
        public BrowserContent(object holder)
        {
            this._holder = holder;

            InitializeComponent();

            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                this._webBrowser = new System.Windows.Forms.WebBrowser();
                this._webBrowser.ScriptErrorsSuppressed = true;//禁用错误脚本提示
                this._webBrowser.IsWebBrowserContextMenuEnabled = false; //禁用右键菜单
                this._webBrowser.WebBrowserShortcutsEnabled = false; //禁用快捷键

           

                this._webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
                this._webBrowser.CanGoBackChanged += WebBrowser_CanGoBackChanged; ;
                this._webBrowser.CanGoForwardChanged += WebBrowser_CanGoForwardChanged;

                wfh.Child = this._webBrowser;
           

            }, DispatcherPriority.Background, null);
        }

        public void Navigate(Uri uri)
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                this._uri = uri;
                txtUrl.Text = uri.ToString();

                this._webBrowser.Navigate(uri);

            }, DispatcherPriority.Background, null);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(txtUrl.Text, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                MessageBox.Show("The Address URI must be absolute eg 'http://www.microsoft.com'");
                return;
            }

            this._uri = uri;
            this._webBrowser.Navigate(uri);
        }

        private void WebBrowser_DocumentCompleted(object sender,
          System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.HtmlDocument html = this._webBrowser.Document;
            LayoutContent content = this._holder as LayoutContent;

            if (content != null && html != null)
            {
                if (!String.IsNullOrEmpty(html.Title))
                {
                    content.Title = html.Title;
                }
                else
                {
                    content.Title = "untitled";
                }

            }
        }

        private void WebBrowser_CanGoBackChanged(object sender, EventArgs e)
        {

        }

        private void WebBrowser_CanGoForwardChanged(object sender, EventArgs e)
        {

        }
    }
}
