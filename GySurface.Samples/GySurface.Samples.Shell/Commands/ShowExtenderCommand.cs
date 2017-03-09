using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using GySurface.Framework.Addin;
using MahApps.Metro.Controls;

namespace GySurface.Samples.Shell.Commands
{
    public class ShowExtenderCommand
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
            var extender = ExBuilder.CreateExtender((String)parameter);

            if (extender != null)
            {
                extender.Width = 600;
                extender.Height = 400;
                extender.Top = Window.GetWindow(source).Top + 100;
                extender.Left = Window.GetWindow(source).Left + 100;

                extender.Show();
            }
            
        }
    }
}
