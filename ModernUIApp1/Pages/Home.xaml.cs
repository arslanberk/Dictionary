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
    public partial class Home : UserControl
    {
       
        public Home()
        {
            InitializeComponent();
            
            error.Visibility = Visibility.Hidden;
            su.Visibility = Visibility.Hidden;
            string path=string.Format("{0}\\Images\\logo.png", AppDomain.CurrentDomain.BaseDirectory);
            image.Source=new BitmapImage(new Uri(path));
           
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Master m = new Master();
                users user = new users();
                user.initialize();

                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";

                XmlSerializer deserializer = new XmlSerializer(typeof(users));
                using (TextReader textReader = new StreamReader(dir+"users.xml"))
                {
                    user = (users)deserializer.Deserialize(textReader);
                }


                if (pass.Password.ToString() != "" && username.Text != "")
                {
                    if (user.checkU(username.Text, m.encrypt(pass.Password.ToString())))
                    {
                        // MessageBox.Show("Login succesful");
                        if (username.Text == user.userName[0] && pass.Password.ToString() == m.decrypt(user.password[0]))
                        {
                            su.Content = "Login successful ";
                            su.Visibility = Visibility.Visible;
                            error.Visibility = Visibility.Hidden;

                            AdminWindow admin = new AdminWindow();
                            admin.Show();
                            Application.Current.Windows[0].Close();
                        }
                        else
                        {
                            su.Content = "Login successful ";
                            error.Visibility = Visibility.Hidden;
                            su.Visibility = Visibility.Visible;
                            UserWindow q = new UserWindow(username.Text.ToString());
                            q.Show();
                            Application.Current.Windows[0].Close();
                        }

                    }
                    else
                    {
                        error.Content = "Check your Username and Password";
                        error.Visibility = Visibility.Visible;
                    }

                }
                else
                {
                    error.Content = "Input empty information is prohibited!";
                    error.Visibility = Visibility.Visible;
                    su.Visibility = Visibility.Hidden;

                }
                username.Text = "";
                pass.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
          
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            forget f = new forget();
            f.Show();
        }

    }
}
