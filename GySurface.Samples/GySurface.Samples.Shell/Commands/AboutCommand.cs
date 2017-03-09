using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;

namespace GySurface.Samples.Shell.Commands
{
    public class AboutCommand
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
            Window dialog = new Window();

            dialog.Width = 400;
            dialog.Height = 300;
            dialog.Title = "About GySurface Framework";
            dialog.Top = Window.GetWindow(source).Top + 100;
            dialog.Left = Window.GetWindow(source).Left + 100;
            dialog.ResizeMode = ResizeMode.NoResize;

            Grid grid = new Grid();
            var columnDefinition = new ColumnDefinition();
            columnDefinition.Width = GridLength.Auto;
            grid.ColumnDefinitions.Add(columnDefinition);
            columnDefinition = new ColumnDefinition();
            columnDefinition.Width = GridLength.Auto;
            grid.ColumnDefinitions.Add(columnDefinition);
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowDefinition);
            rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowDefinition);

            dialog.Content = grid;

            dialog.ShowDialog();
        }

        private static Button CreateLinkButton()
        {
            string xaml = 
                "<Button xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Margin=\"5\" Cursor=\"Hand\">"
                + "     <Button.Template >"
                + "         <ControlTemplate TargetType=\"Button\">"
                //+ "           <TextBlock TextDecorations=\"Underline\">"
                + "             <TextBlock>"
                + "                 <ContentPresenter />"
                + "             </TextBlock>"
                + "         </ControlTemplate>"
                + "     </Button.Template>"
                + "     <Button.Style >"
                + "         <Style TargetType=\"Button\">"
                + "             <Setter Property=\"Foreground\" Value =\"Blue\" />"
                + "             <Style.Triggers>"
                + "                 <Trigger Property=\"IsMouseOver\" Value=\"true\">"
                + "                     <Setter Property=\"Foreground\" Value=\"Red\" />"
                + "                 </Trigger>"
                + "             </Style.Triggers>"
                + "         </Style>"
                + "     </Button.Style>"
                + "</Button>";


            StringReader sr = new StringReader(xaml);
            XmlTextReader xtr = new XmlTextReader(sr);
            Button button = XamlReader.Load(xtr) as Button;

            return button;
        }
    }
}
