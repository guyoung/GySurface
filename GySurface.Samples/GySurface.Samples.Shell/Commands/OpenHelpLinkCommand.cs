using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GySurface.Samples.Shell.Commands
{
    public class OpenHelpLinkCommand
    {
        public static bool CanExecuteCommand(Control source, object parameter)
        {
            if (source != null)
            {
                return true;
            }

            return false;
        }

        public static void ExecutedCommand(Control source, object parameter)
        {

         
            string key = parameter as String;           

            if (Application.Current.Properties[key] != null && !String.IsNullOrEmpty((String)Application.Current.Properties[key]))
            {
                try
                {

                    Process.Start((String)Application.Current.Properties[key]);
                }
                catch
                {

                }
            }
        }
    }
}
