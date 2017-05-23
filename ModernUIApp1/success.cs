using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace Dictionary
{
    public class success
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string[] time;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int[] succes;

        public success()
        {
            time = new string[0];
            succes = new int[0];
        }

        private void resize()
        {
            Array.Resize<string>(ref time, (time.Length + 1));
            Array.Resize<int>(ref succes, (succes.Length + 1));
        }
        public void insert(string t, int s)
        {
            resize();
            time[(time.Length - 1)] = t;
            succes[(succes.Length - 1)] = s;

        }

        public void writer()
        {
            try{

                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
            success s = new success();
            s.succes = succes;
            s.time = time;

            string path = string.Format("{0}Success\\",dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(success));
            using (TextWriter textWriter = new StreamWriter(path + "success.xml"))
            {
                serializer.Serialize(textWriter, s);
            }
             }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        public void reader()
        {
            try{
                String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dir += "\\ArslanSoftware\\";
            string path = string.Format("{0}Results\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] files = Directory.GetFiles(path, "*.xml");

            foreach (string f in files)
            {
                result r = new result();
                XmlSerializer deserializer = new XmlSerializer(typeof(result));
                using (TextReader textReader = new StreamReader(f))
                {
                    r = (result)deserializer.Deserialize(textReader);
                }

                string file = Path.GetFileNameWithoutExtension(f);
                insert(file, r.success);
            }

            writer();
             }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }

}

