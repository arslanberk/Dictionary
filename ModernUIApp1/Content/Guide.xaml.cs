using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary.Content
{
    /// <summary>
    /// Interaction logic for SettingsAppearance.xaml
    /// </summary>
    public partial class Guide : UserControl
    {
        public Guide()
        {
            InitializeComponent();

            // create and assign the appearance view model
            this.DataContext = new SettingsAppearanceViewModel();
        }
       
        private void make(object sender, RoutedEventArgs e)
        {
            try
            {
                userGuide u = new userGuide();
                u.html3_report();
                warn.Content = "User Guide has been created.";
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
                string path = string.Format("{0}Guide\\guide.html", dir);

                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(path);
                proc.Start();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

    }
}
