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
    public partial class uHome : UserControl
    {
        words word;
        public uHome()
        {
            InitializeComponent();
             word = new words();
             word.initialize();
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
                        doc.Blocks.Add(new Paragraph(new Run(word.word[i] +"  "+ "(" + word.status[i] + ")")));
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

   

    }
}
