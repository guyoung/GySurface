using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GySurface.Samples.Shell.Commands
{
    public class ExitCommand
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
            Application.Current.Shutdown();
        }
    }
}
