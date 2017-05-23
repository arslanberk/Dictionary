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
    public partial class MakeReport : UserControl
    {
        public MakeReport()
        {
            InitializeComponent();

            // create and assign the appearance view model
            this.DataContext = new SettingsAppearanceViewModel();
        }
        private void report_html()
        {
            report r = new report();
            r.html_report();
            r.html2_report();
            r.html3_report();
            r.html4_report();
        }
        private void make(object sender, RoutedEventArgs e)
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            if (html.IsChecked == true)
            {
                report_html();
                warn.Content = ".html report has been created.";
                string path = string.Format("{0}Reports\\html\\index.html",dir);

                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(path);
                proc.Start();
            }
            else if (doc.IsChecked == true)
            {
                report t = new report();
                t.doc();
                warn.Content = ".doc report has been created.";
                string path = string.Format("{0}Reports\\doc\\report.doc", dir);

                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(path);
                proc.Start();

            }
            else if (docx.IsChecked == true)
            {
                report t = new report();
                t.docx();
                warn.Content = ".docx report has been created.";
                string path = string.Format("{0}Reports\\docx\\report.docx", dir);

                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(path);
                proc.Start();

            }
           

        }

    }
}
