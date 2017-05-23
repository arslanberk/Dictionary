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
    public partial class passf : UserControl
    {

        public passf()
        {
            InitializeComponent();
            
            error.Visibility = Visibility.Hidden;
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

                if (username.Text != "admin" && username.Text != "Admin")
                {
                    error.Visibility = Visibility.Hidden;
                    if (user.check(username.Text))
                    {

                        pass.Content = "Password : "+user.passwordForget(username.Text);
                        pass.Visibility = Visibility.Visible;
                        error.Visibility = Visibility.Hidden;

                    }
                    else { error.Content = "Username does not exist!";
                    error.Visibility = Visibility.Visible;
                    pass.Visibility = Visibility.Hidden;

                    }
                }
                else {
                    error.Content = "Admin password cannot be recovered!";
                    error.Visibility = Visibility.Visible;
                    pass.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
          
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
