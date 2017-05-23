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
using System.IO;

namespace Dictionary.Content
{
    /// <summary>
    /// Interaction logic for SettingsAppearance.xaml
    /// </summary>
    public partial class Clean : UserControl
    {
        public Clean()
        {
            InitializeComponent();

            // create and assign the appearance view model
            this.DataContext = new SettingsAppearanceViewModel();
        }
     
        private void clean(object sender, RoutedEventArgs e)
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            string path = string.Format("{0}Results\\", dir);
            try
            {
                Directory.Delete(path, true);
                warn.Foreground = new SolidColorBrush(Colors.Green);
                warn.Content = "Directory 'Results' has been deleted.";
            }
            catch (Exception ee)
            {
                warn.Foreground = new SolidColorBrush(Colors.Red);

                warn.Content = "Directory 'Results' does not exist.";

            }

        }

    }
}
