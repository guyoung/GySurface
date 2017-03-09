using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Windows;
using GySurface.Framework.Addin;

namespace GySurface.Samples.Shell.Commands
{
    public class ChangeThemeCommand
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
                String theme = (String)parameter;
                Dictionary<string, string> newStyle = new Dictionary<string, string>(); ;

                if (!String.IsNullOrEmpty(theme))
                {
                    string[] a = theme.Split(new char[] { ',' });

                    if (a.Length >= 2)
                    {
                        newStyle["Accent"] = a[0];
                        newStyle["Theme"] = a[1];

                        ExContext.Instance.Configuration["Style"] = newStyle;
                    }
                }
           

        }
    }
}
