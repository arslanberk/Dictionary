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
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

namespace Dictionary.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class rslt : UserControl
    {

        public class DataObject
        {
            public int A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
        }
        public rslt()
        {
            InitializeComponent();
            string path = string.Format("{0}\\Images\\logo.png", AppDomain.CurrentDomain.BaseDirectory);
            image.Source = new BitmapImage(new Uri(path));
            result r = new result();
            string d;
            r.reader(out d);
            date.Content = d;
            string name;
           username u =new username();
            u.reader(out name);
            success.Content = r.success;
            if (r.success < 50)
            {
                comment.Content = "You must study hard, " + name;
                comment.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else if(r.success >=50 && r.success < 80)
            {
                comment.Content = "Not bad, almost done, " + name;
                comment.Foreground = new SolidColorBrush(Colors.Orange);
            }
            else if ( r.success > 80)
            {
                comment.Content = "Well done, " + name;
                comment.Foreground = new SolidColorBrush(Colors.Green);
            }
            var list = new ObservableCollection<DataObject>();
            list.Add(new DataObject() { A = 0, B = "Question", C = "True", D = "Answer" });
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DataObject() { A = (i + 1), B = r.questions[i], C = r.trues[i], D = r.answers[i] });
            }
            comment.Visibility = Visibility.Visible;
            this.data.ItemsSource = list;

        }

    }
}
