using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Dictionary
{
    public class result
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string[] questions;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string[] trues;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string[] answers;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int success;

        public result()
        {
            success = 0;
            questions = new string[0];
            trues = new string[0];
            answers = new string[0];
        }

        private void resize()
        {
            Array.Resize<string>(ref questions, (questions.Length + 1));
            Array.Resize<string>(ref trues, (trues.Length + 1));
            Array.Resize<string>(ref answers, (answers.Length + 1));
        }
        public void insert(string q, string t, string a)
        {
            check(t, a);
            resize();
            questions[(questions.Length - 1)] = q;
            trues[(trues.Length - 1)] = t;
            answers[(answers.Length - 1)] = a;

        }
        private void check(string t, string a)
        {
            if (t == a)
            {
                success += 10;
            }
            else { }
        }
        public void writer()
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            result re = new result();
            re.questions = questions;
            re.answers = answers;
            re.trues = trues;
            re.success = success;

            string path = string.Format("{0}Results\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string date = DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss");
            XmlSerializer serializer = new XmlSerializer(typeof(result));
            using (TextWriter textWriter = new StreamWriter(path + date + ".xml"))
            {
                serializer.Serialize(textWriter, re);
            }

        }

        public void reader(out string p)
        {

            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            string path = string.Format("{0}Results\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] files = Directory.GetFiles(path);
            p=Path.GetFileNameWithoutExtension(files[files.Length - 1]);
           

            result r = new result();
            XmlSerializer deserializer = new XmlSerializer(typeof(result));
            using (TextReader textReader = new StreamReader(files[files.Length - 1]))
            {
                r = (result)deserializer.Deserialize(textReader);
            }

            questions = r.questions;
            answers = r.answers;
            trues = r.trues;
            success = r.success;
        }
    }
}
