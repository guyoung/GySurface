using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using GySurface.Framework.Addin;
using Mono.Addins;
using System.Reflection;
using System.IO;
using System.Windows.Threading;

namespace GySurface.Samples.Startup
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application, IExHost
    {
        public App()
        {
          
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

          
            Application app = Application.Current;

            AddinManager.AddinLoadError += OnLoadError;
            AddinManager.AddinLoaded += OnLoad;
            AddinManager.AddinUnloaded += OnUnload;



            AddinManager.Initialize(".", "./addin");
            AddinManager.Registry.Update(null);
            AddinManager.ExtensionChanged += OnExtensionChange;


            var objects = AddinManager.GetExtensionObjects<IExShell>("/Startup").AsEnumerable();
            if (!objects.Any())
            {
                throw new Exception();
            }

            var window = objects.First() as Window;
            if (window == null)
            {

            }

            app.MainWindow = window;

            app.MainWindow.Show();
        }


      

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }


        void OnLoadError(object s, AddinErrorEventArgs args)
        {
            Console.WriteLine("Add-in error: " + args.Message);
            Console.WriteLine(args.AddinId);
            Console.WriteLine(args.Exception);
        }

        void OnLoad(object s, AddinEventArgs args)
        {
            Console.WriteLine("Add-in loaded: " + args.AddinId);
        }

        void OnUnload(object s, AddinEventArgs args)
        {
            Console.WriteLine("Add-in unloaded: " + args.AddinId);
        }

        void OnExtensionChange(object s, ExtensionEventArgs args)
        {
            Console.WriteLine("Extension changed: " + args.Path);
        }

        void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var comException = e.Exception as System.Runtime.InteropServices.COMException;

            if (comException != null && comException.ErrorCode == -2147221040)
                e.Handled = true;
        }

    }
}
