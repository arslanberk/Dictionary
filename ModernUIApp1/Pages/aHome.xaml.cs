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
    public partial class aHome : UserControl
    {
        words word;
        public string[] stat;
        public aHome()
        {
            InitializeComponent();
            stat = new string[] {"noun","verb","adjective","adverb" };
             word = new words();
             word.initialize();
             aStatus.ItemsSource = stat;
             aStatus.SelectedIndex = 0;
            SearchWord.ItemsSource = word.word;
            SearchWord.SelectedIndex = 0;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sWord = "";

            sWord = SearchWord.Text;
            if (word.check(sWord))
            {
                for (int i = 0; i < word.index; i++)
                {
                    if (word.word[i] == sWord)
                    {
                        FlowDocument doc = new FlowDocument();

                        // Add paragraphs to the FlowDocument.
                        doc.Blocks.Add(new Paragraph(new Run(word.word[i] + "  " + "(" + word.status[i] + ")")));
                        doc.Blocks.Add(new Paragraph(new Run("- - - - - - - - - - - - - - - - - - - -")));
                        doc.Blocks.Add(new Paragraph(new Run(word.translation[i])));
                        Translation.Document = doc;

                    }

                }
            }
            else if (!word.check(sWord))
            {
                FlowDocument doc = new FlowDocument();
                // Add paragraphs to the FlowDocument.
                doc.Blocks.Add(new Paragraph(new Run("system cannot find . . .")));
                Translation.Document = doc;

            }

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string w = "";
            string s = "";
            string t = "";
            w = aWord.Text;
            s = aStatus.SelectedValue.ToString();
            t = aTranslation.Text;
            if (aWord.Text != "" && aStatus.SelectedValue.ToString() != "" && aTranslation.Text!="")
            {
                if (word.check(aWord.Text))
                {
                    MessageBox.Show("This word already exists !", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else 
                {
                    word.writeWords(w, s, t);
                }
                aWord.Text = "";
                aTranslation.Text = "";
            }

            word.initialize();
            SearchWord.ItemsSource = word.word;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserWindow us = new UserWindow("admin");
            us.Show();
            Application.Current.Windows[0].Close();         }

    }
}
