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

namespace Dictionary.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class uTest : UserControl
    {

        public int ques;
        public int[] answer;
        public int count;
        test t;
        result r;

        public uTest()
        {
            InitializeComponent();
            string path = string.Format("{0}\\Images\\logo.png", AppDomain.CurrentDomain.BaseDirectory);
            image.Source = new BitmapImage(new Uri(path));
            image.Visibility = Visibility.Hidden;
            error.Content = "Select answer !";
            error.Visibility = Visibility.Hidden;
            count = 0;
            t = new test();
            r = new result();
            question.Visibility = Visibility.Hidden;
            a1.Visibility = Visibility.Hidden;
            a2.Visibility = Visibility.Hidden;
            a3.Visibility = Visibility.Hidden;
            a4.Visibility = Visibility.Hidden;
            a5.Visibility = Visibility.Hidden;
            cont.Visibility = Visibility.Hidden;
            result.Visibility = Visibility.Hidden;
        }

        public void tester()
        {
            t.tester();
            ques = t.ques;
            answer = t.answer;
            words w = new words();
            w.initialize();
            question.Content = (count + 1) + ".What is the translation of \"" + w.word[ques] + "\" ?";
            a1.Content = w.translation[answer[0]];
            a2.Content = w.translation[answer[1]];
            a3.Content = w.translation[answer[2]];
            a4.Content = w.translation[answer[3]];
            a5.Content = w.translation[answer[4]];


        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            image.Visibility = Visibility.Visible;
            count = 0;
            t = new test();
            r = new result();
            label.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            tester();
            a1.IsEnabled = true;
            a2.IsEnabled = true;
            a3.IsEnabled = true;
            a4.IsEnabled = true;
            a5.IsEnabled = true;
            a1.IsChecked = false;
            a2.IsChecked = false;
            a3.IsChecked = false;
            a4.IsChecked = false;
            a5.IsChecked = false;
            question.Visibility = Visibility.Visible;
            a1.Visibility = Visibility.Visible;
            a2.Visibility = Visibility.Visible;
            a3.Visibility = Visibility.Visible;
            a4.Visibility = Visibility.Visible;
            a5.Visibility = Visibility.Visible;
            cont.Visibility = Visibility.Visible;
            result.Visibility = Visibility.Visible;
        }
        private void radio(object sender, RoutedEventArgs e)
        {
            a1.IsEnabled = false;
            a2.IsEnabled = false;
            a3.IsEnabled = false;
            a4.IsEnabled = false;
            a5.IsEnabled = false;
            words w = new words();
            w.initialize();
            string a = w.translation[ques];

            if (a1.IsChecked == true && a1.Content.ToString() == a)
            {
                r.insert(w.word[ques], a, a1.Content.ToString());
                result.Content = "True :)";
            }
            else if (a2.IsChecked == true && a2.Content.ToString() == a)
            {
                r.insert(w.word[ques], a, a2.Content.ToString());
                result.Content = "True :)";
            }
            else if (a3.IsChecked == true && a3.Content.ToString() == a)
            {
                r.insert(w.word[ques], a, a3.Content.ToString());
                result.Content = "True :)";
            }
            else if (a4.IsChecked == true && a4.Content.ToString() == a)
            {
                r.insert(w.word[ques], a, a4.Content.ToString());
                result.Content = "True :)";
            }
            else if (a5.IsChecked == true && a5.Content.ToString() == a)
            {
                r.insert(w.word[ques], a, a5.Content.ToString());
                result.Content = "True :)";
            }
            else if (a1.IsChecked == true && a1.Content.ToString() != a)
            {
                result.Content = "False :(";
                r.insert(w.word[ques], a, a1.Content.ToString());
            }
            else if (a2.IsChecked == true && a2.Content.ToString() != a)
            {
                result.Content = "False :(";
                r.insert(w.word[ques], a, a2.Content.ToString());
            }
            else if (a3.IsChecked == true && a3.Content.ToString() != a)
            {
                result.Content = "False :(";
                r.insert(w.word[ques], a, a3.Content.ToString());
            }
            else if (a4.IsChecked == true && a4.Content.ToString() != a)
            {
                result.Content = "False :(";
                r.insert(w.word[ques], a, a4.Content.ToString());
            }
            else if (a5.IsChecked == true && a5.Content.ToString() != a)
            {
                result.Content = "False :(";
                r.insert(w.word[ques], a, a5.Content.ToString());
            }
            else { }

        }
        private void continue_click(object sender, RoutedEventArgs e)
        {
            if (a5.IsChecked == true || a4.IsChecked == true || a3.IsChecked == true || a2.IsChecked == true || a1.IsChecked == true)
            {

                error.Visibility = Visibility.Hidden;
                if (count < 9)
                {
                    count++;
                    result.Content = "Result";
                    a1.IsChecked = false;
                    a2.IsChecked = false;
                    a3.IsChecked = false;
                    a4.IsChecked = false;
                    a5.IsChecked = false;
                    a1.IsEnabled = true;
                    a2.IsEnabled = true;
                    a3.IsEnabled = true;
                    a4.IsEnabled = true;
                    a5.IsEnabled = true;
                    tester();
                }
                else
                {
                    label.Visibility = Visibility.Visible;
                    Start.Visibility = Visibility.Visible;
                    r.writer();
                 
                    image.Visibility = Visibility.Hidden;
                    question.Visibility = Visibility.Hidden;
                    a1.Visibility = Visibility.Hidden;
                    a2.Visibility = Visibility.Hidden;
                    a3.Visibility = Visibility.Hidden;
                    a4.Visibility = Visibility.Hidden;
                    a5.Visibility = Visibility.Hidden;
                    cont.Visibility = Visibility.Hidden;
                    result.Visibility = Visibility.Hidden;
                    result.Content = "Result";
                    aftertest t = new aftertest();
                    t.Show();
                }
            }
            else { error.Visibility = Visibility.Visible; }
        }
    }
}
