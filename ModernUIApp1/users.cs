using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Dictionary
{
    public class users
    {
        
        public int index;

        public int []ID;

        public string[] firstName;

        public string[] lastName;

        public string[] userName;

        public string[] password;

       
       public users() 
        {
           
        }
       public void initialize()
       {
           String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           path += "\\ArslanSoftware\\";
           if (!Directory.Exists(path))
           {
               Directory.CreateDirectory(path);
           
           }
           Master m = new Master();
           if (File.Exists(path+"users.xml"))
           {
               users user = new users();
               XmlSerializer deserializer = new XmlSerializer(typeof(users));
               using (TextReader textReader = new StreamReader(path+"users.xml"))
               {
                   user = (users)deserializer.Deserialize(textReader);
               }
               index = user.index;
               ID = user.ID;
               firstName = user.firstName;
               lastName = user.lastName;
               password = user.password;
               userName = user.userName;
           }
           else
           {
               index = 1;
               ID = new int[index];
               firstName = new string[index ];
               lastName = new string[index];
               password = new string[index ];
               userName = new string[index];
               ID[index - 1] = index - 1;
               firstName[index - 1] = "berk";
               lastName[index - 1] = "arslan";
               userName[index - 1] = "admin";
               password[index - 1 ] = m.encrypt("admin");
               users u = new users();
               u.index = index;
               u.ID = ID;
               u.firstName = firstName;
               u.lastName = lastName;
               u.userName = userName;
               u.password = password;
              
               XmlSerializer serializer = new XmlSerializer(typeof(users));
               using (TextWriter textWriter = new StreamWriter(path+"users.xml"))
               {

                   serializer.Serialize(textWriter, u);
               }  

           }
       }

       public bool check(string us)
       {
           bool checkU = false;
           for (int i = 0; i < userName.Length; i++)
           {
               if (userName[i] == us)
               {
                   checkU = true;
                   break;
               }
               else { checkU = false; }
           
           }
           return checkU;
       }
       public string passwordForget(string us)
       {
           Master m = new Master();
          
           string checkU = "";
           for (int i = 0; i < userName.Length; i++)
           {
               if (userName[i] == us)
               {
                   checkU = m.decrypt(password[i]);
                   break;
               }
               else { checkU = ""; }

           }
           return checkU;
       }
       public bool checkU(string us, string ps)
       {
           bool c = false;
           for (int i = 0; i < ID.Length; i++)
           {
               if (userName[i] == us && password[i]==ps)
               {
                   c = true;
                   break;
               }
               else { c = false; }

           }
           return c;
       }
        public void writeUsers(string f, string s, string un, string pass)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\ArslanSoftware\\";   
            Master m = new Master();
            index++;
            Array.Resize<int>(ref ID, (index ));
            Array.Resize<string>(ref firstName, (index ));
            Array.Resize<string>(ref lastName, (index ));
            Array.Resize<string>(ref userName, (index ));
            Array.Resize<string>(ref password, (index ));


            ID[index-1 ] = index-1 ;
            userName[index-1] = un;
            password[index - 1] = m.encrypt(pass);
            firstName[index - 1] = f;
            lastName[index - 1] = s;
            

            users user = new users();
            user.index = index;
            user.ID= ID ;
            user.userName= userName ;
            user.password= password ;
             user.firstName=firstName ;
             user.lastName=lastName ;
            XmlSerializer serializer = new XmlSerializer(typeof(users));
            using (TextWriter textWriter = new StreamWriter(path+"users.xml"))
            {

                serializer.Serialize(textWriter, user);
            }  
           
        }

    };
}
