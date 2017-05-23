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
using System.Xml.Serialization;
using System.IO;

namespace Dictionary.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
            error.Visibility = Visibility.Hidden;
            su.Visibility = Visibility.Hidden;
            string path = string.Format("{0}\\Images\\logo.png", AppDomain.CurrentDomain.BaseDirectory);
            image.Source = new BitmapImage(new Uri(path));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            users user = new users();
            user.initialize();
            string fn = firstname.Text;
            string ln = lastname.Text;
            string ps = pass.Password.ToString();
            string un = username.Text;
            if (firstname.Text != "" && lastname.Text != "" && pass.Password.ToString() != "" && username.Text != "")
            {
                Master m = new Master();

                error.Visibility = Visibility.Hidden;
                if (m.check(firstname.Text) && m.check(lastname.Text) && m.check(pass.Password.ToString()) && m.check(username.Text)) { 
                if (user.check(un))
                {
                    error.Content = "This username has been taken already !";
                    error.Visibility = Visibility.Visible;
                }
                else {
                    su.Content = "Registeration successful ";
                    su.Visibility = Visibility.Visible;
                    error.Visibility = Visibility.Hidden;

                    user.writeUsers(fn, ln, un, ps);
                    UserWindow u = new UserWindow(un);
                    u.Show();
                    Application.Current.Windows[0].Close(); 
                }
                firstname.Text = "";
                lastname.Text = "";
                pass.Clear();
                username.Text = "";
            }
                else
                {
                    error.Content = "Only English characters!";
                    error.Visibility = Visibility.Visible;
                    su.Visibility = Visibility.Hidden;

                    firstname.Text = "";
                    lastname.Text = "";
                    pass.Clear();
                    username.Text = "";
                }
            }
            else
            {
                error.Content = "Input empty information is prohibited!";
                error.Visibility = Visibility.Visible;
                su.Visibility = Visibility.Hidden;

                firstname.Text = "";
                lastname.Text = "";
                pass.Clear();
                username.Text = "";
            }
            
        }

        
    }
}
