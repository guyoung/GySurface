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
using GySurface.Framework.Xcad.Themes;
using GySurface.Samples.Skeleton.Contents;

namespace GySurface.Samples.Skeleton.Workareas
{
    /// <summary>
    /// HomeWorkarea.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWorkarea : UserControl
    {
        public HomeWorkarea()
        {
            InitializeComponent();

            dockingManager.Theme = new AeroTheme();

            this.Loaded += Workarea_Loaded;
        }

        private void Workarea_Loaded(object sender, RoutedEventArgs e)
        {

            this.Dispatcher.BeginInvoke((Action)delegate ()
            {


                AddWorkItem();

            }, DispatcherPriority.Background, null);

            this.Loaded -= Workarea_Loaded;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AddWorkItem();
        }

        private void AddWorkItem()
        {
            LayoutDocument document = new LayoutDocument();
            //document.Title = "";
            document.CanClose = true;
            document.ContentId = "document_" + Guid.NewGuid().ToString("N");

            BrowserContent browserContent = new BrowserContent(document);
            document.Content = browserContent;

            mainPane.InsertChildAt(mainPane.Children.Count, document);

            browserContent.Navigate(new Uri("about: blank"));

            document.IsActive = true;
        }

       

    }
}
