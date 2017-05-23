using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Dictionary
{
    public class words
    {

        public int index;

        public int[] ID;

        public string[] word;

        public string[] translation;

        public string[] status;


        public words()
        {
        }
        public void initialize()
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";

            if (File.Exists(dir+"words.xml"))
            {
                words w = new words();
                XmlSerializer deserializer = new XmlSerializer(typeof(words));
                using (TextReader textReader = new StreamReader(dir+"words.xml"))
                {
                    w = (words)deserializer.Deserialize(textReader);
                }
                index = w.index;
                ID = w.ID;
                word = w.word;
                translation = w.translation;
                status = w.status;
            }
            else
            {
                index = 10;
                ID = new int[index];
                word = new string[index];
                translation = new string[index];
                status = new string[index];
                ID[0] = 0;
                word[0] = "dictionary";
                status[0] = "noun";
                translation[0] = "словарь";
                ID[1] = 1;
                word[1] = "know";
                status[1] = "verb";
                translation[1] = "знать";
                ID[2] = 2;
                word[2] = "hair";
                status[2] = "noun";
                translation[2] = "волос";
                ID[3] = 3;
                word[3] = "theme";
                status[3] = "noun";
                translation[3] = "тема";
                ID[4] = 4;
                word[4] = "team";
                status[4] = "noun";
                translation[4] = "команда";
                ID[5] = 5;
                word[5] = "beauty";
                status[5] = "noun";
                translation[5] = "красота";
                ID[6] = 6;
                word[6] = "father";
                status[6] = "noun";
                translation[6] = "отец";
                ID[7] = 7;
                word[7] = "file";
                status[7] = "noun";
                translation[7] = "файл";
                ID[8] = 8;
                word[8] = "paper";
                status[8] = "noun";
                translation[8] = "бумага";
                ID[9] = 9;
                word[9] = "news";
                status[9] = "noun";
                translation[9] = "новости";
                words w = new words();
                w.index = index;
                w.ID = ID;
                w.word = word;
                w.status = status;
                w.translation = translation;
                
                XmlSerializer serializer = new XmlSerializer(typeof(words));
                using (TextWriter textWriter = new StreamWriter(dir+"words.xml"))
                {

                    serializer.Serialize(textWriter, w);
                }

            }
        }

        public bool check(string us)
        {
            bool checkU = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == us)
                {
                    checkU = true;
                    break;
                }
                else { checkU = false; }

            }
            return checkU;
        }
       
        public void writeWords(string w, string s, string tran)
        {
            index++;
            Array.Resize<int>(ref ID, (index));
            Array.Resize<string>(ref word, (index));
            Array.Resize<string>(ref status, (index));
            Array.Resize<string>(ref translation, (index));


            ID[index - 1] = index - 1;
            word[index - 1] = w;
            status[index - 1] = s;
            translation[index - 1] = tran;

            words wordd = new words();
            wordd.index = index;
            wordd.ID = ID;
            wordd.word = word;
            wordd.status = status;
            wordd.translation = translation;
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            XmlSerializer serializer = new XmlSerializer(typeof(words));
            using (TextWriter textWriter = new StreamWriter(dir+"words.xml"))
            {

                serializer.Serialize(textWriter, wordd);
            }

        }

    };
}
