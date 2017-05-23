using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Dictionary
{
    class reportPdf
    {
        public reportPdf()
        { }
        public void pdf()
        {
            try
            {
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
                string path = string.Format("{0}Reports\\pdf\\", dir);

                string path_img = string.Format("{0}Images\\graph.png", dir);


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream((path + "report.pdf"), FileMode.Create));
                    doc.Open();
               
                    lock (doc)
                    {
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("MINISTRY OF EDUCATION AND SCIENCE OF UKRAINE NATIONAL TECHNICAL"));
                        doc.Add(new Paragraph("       UNIVERSITY «KHARKIV POLITECNIC INSTITUTE» DEPARTMENT OF"));
                        doc.Add(new Paragraph("                            COMPUTER-AIDED MANAGMENT SYSTEMS"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("                                                     Course Work "));
                        doc.Add(new Paragraph("                         on course: << Object Oriented Programming>> "));
                        doc.Add(new Paragraph("                          entitled: << Wpf Applications \"Dictionary\">> "));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("                                                                                                          Performer:"));
                        doc.Add(new Paragraph("                                                                                                          Berk Arslan"));
                        doc.Add(new Paragraph("                                                                                                          If-32 J"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);

                        doc.Add(new Paragraph("                                                              Kharkiv 2014                                "));



                        //title1
                        doc.Add(new Paragraph("1.Graph Results"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("    Graph 1.1 shows results according to stored data \"Results\".   "));

                        //creating image

                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(path_img);


                        doc.Add(pic);

                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("                                                                     graph 1.1 - Results"));
                        doc.Add(Chunk.NEWLINE);

                        username u = new username();
                        string name;
                        u.reader(out name);
                        doc.Add(new Paragraph(String.Format("    According to these result you can see the progress day by day. This graph is directly created by dictionary program to provide feedbacks due to test has been done by {0}.", name)));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("2.Result Details"));
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("  Here there is shown detailed results due to questions and their answers. This comparison will help you to understand exactly which questions were wrong. "));
                        doc.Add(Chunk.NEWLINE);

                        string path_rslt = string.Format("{0}Results\\", dir);
                        string[] files = Directory.GetFiles(path_rslt);
                        result r;
                        for (int i = 0; i < files.Count(); i++)
                        {
                            lock (files)
                            {
                                r = new result();
                                XmlSerializer deserializer = new XmlSerializer(typeof(result));
                                using (TextReader textReader = new StreamReader(files[i]))
                                {
                                    r = (result)deserializer.Deserialize(textReader);
                                }
                                string p = Path.GetFileNameWithoutExtension(files[i]);
                                doc.Add(new Paragraph(String.Format("{0}, success:{1}%", p, r.success)));
                                lock(r)
                                {
                                for (int j = 0; j < 10; j++)
                                {

                                    doc.Add(new Paragraph(String.Format("{0}. word was \"{1}\" ,its translation was \"{2}\" , and you answered \"{3}\".", (j + 1), r.questions[j], r.trues[j], r.answers[j])));

                                    Thread.Sleep(1000);
                                }
                                }
                                doc.Add(Chunk.NEWLINE);
                            }
                           
                        }



                        doc.Add(Chunk.NEWLINE);
                        doc.Add(Chunk.NEWLINE);
                        doc.Add(new Paragraph("3.Conclusion"));

                        doc.Add(Chunk.NEWLINE);

                        string text = "    Dictionary program presented graphical presentation of results and detailed results which include questions and their answers with user answers.If success rate is less than 50% then it means result is bad, and average result is between 50-80 %, if success is greater than 80% then it means the result is very good.";
                        doc.Add(new Paragraph(text));
                    doc.Close();
                    }
                    
                    
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }



        }


    }
}
