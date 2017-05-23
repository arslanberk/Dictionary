using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Dictionary
{
    public class username
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string user_name;

        public username()
        {
            user_name = "";
        }

      
        public void setname(string q)
        {
          user_name=q;

        }

        public void writer()
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            username uu = new username();
             uu.user_name=user_name;

            string path = string.Format("{0}Reports\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(username));
            using (TextWriter textWriter = new StreamWriter(path+"username.xml"))
            {
                serializer.Serialize(textWriter, uu);
            }

        }

        public void reader(out string p)
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            string path = string.Format("{0}Reports\\", dir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

          
             username u = new username();

           
            XmlSerializer deserializer = new XmlSerializer(typeof(username));
            using (TextReader textReader = new StreamReader(path+"username.xml"))
            {
                u = (username)deserializer.Deserialize(textReader);
            }

           user_name=u.user_name;
            p=user_name;
        }
    }
    }

