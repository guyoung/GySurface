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
using System.Windows.Shapes;

using GySurface.Framework.Addin;
using MahApps.Metro.Controls;
using System.Collections.Specialized;
using GySurface.Framework.Xcad.Themes;
using Xceed.Wpf.AvalonDock.Layout;
using MahApps.Metro;

namespace GySurface.Samples.Shell
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow, IExShell
    {
        public MainWindow()
        {

            Initialize();

            InitializeComponent();

            dockingManager.Theme = new MetroTheme();

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }

        private void Initialize()
        {

            Dictionary<string, string> theme = new Dictionary<string, string>();
            theme.Add("Accent", "");
            theme.Add("Theme", "");
            ExContext.Instance.Configuration.Add("Style", theme);

            ExContext.Instance.Configuration.CollectionChanged += Application_CollectionChanged;


            var services = ExBuilder.GetServices();

            foreach (var service in services)
            {
                try
                {
                    service.Start();
                }
                catch
                {

                }

            }

        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


            BuildMainMenu();

            BuildWorkarea();
        }


        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _Close();
        }

        private void Application_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            KeyValuePair<string, object> item = (KeyValuePair<string, object>)e.NewItems[0];

            if (item.Key.Equals("Style"))
            {
                ChangeStyle((Dictionary<string, string>)item.Value);
            }
        }


        public void BuildMainMenu()
        {
            var menus = ExBuilder.CreateMenu("/Shell/MainMenu");

            foreach (var menu in menus)
            {

                menu.Background = Brushes.Transparent;
                menu.Style = this.FindResource("MainMenuStyle") as Style;

                mainMenu.Items.Add(menu);
            }

            menus = ExBuilder.CreateMenu("/Shell/ThemeMenu");

            foreach (var menu in menus)
            {
                themeMenu.Items.Add(menu);
            }
        }

        public void BuildWorkarea()
        {
            var contents = ExBuilder.CreateContents("/Shell/Workareas");

            foreach (var content in contents)
            {
                var document = content as LayoutDocument;

                if (document != null)
                {
                    document.CanClose = false;

                    workareaPane.Children.Add(content);
                }


            }
        }

        private void _Close()
        {
            var services = ExBuilder.GetServices();
            foreach (var service in services)
            {
                service.Stop();
            }
        }

        private void ChangeStyle(Dictionary<string, string> newStyle)
        {
            var style = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                ThemeManager.GetAccent(newStyle["Accent"]),
                ThemeManager.GetAppTheme(newStyle["Theme"]));
        }
    }
}
