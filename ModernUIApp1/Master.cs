using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Master
    {
        public string[,] master;
        public string[] x;
        public string[] y;
        public Master()
        {

            master = new string[10,9] { { "A", "B", "C", "D", "E", "F", "G", "H","I" }, 
                                        { "J", "K", "L", "M", "N", "O", "P", "Q","R"},
                                        { "S", "T", "U", "V", "W", "X", "Y", "Z","a"},
                                        { "b", "c", "d", "e", "f","g", "h",  "i", "j"},
                                        { "k", "l", "m", "n","o" ,"p", "q", "r", "s"},
                                        { "t", "u", "v","w" ,"x", "y", "z", "0", "1"},
                                        { "2", "3","4","5", "6", "7", "8", "9", "-"},
                                        {  "/",":",";", "(", ")", "$", "&", "@", "\""},
                                        { ".",",", "?", "!", "'", "+", "_", "#","^"},
                                        { "%", "*", "\\", "|", "<", ">", " ","`","~"}};
            y = new string[10] {"1","2","3","4","5","a","b","c","d","e" };
            x = new string[9] { "6","7","8","f","g","h","@","&","#"};
        }

        public bool check(string txt)
        {
            bool c = false;
           int count=0;
            A:
           while (count < txt.Length)
           {

               for (int j = 0; j < 10; j++)
               {
                   for (int k = 0; k < 9; k++)
                   {
                       if (txt[count].ToString() == master[j, k])
                       {
                           c = true;
                           count++;
                           goto A;
                          
                       }
                       else if (txt[count].ToString() != master[j, k])
                       {
                           c = false;
                       }
                   }
               }
               if (c == false)
               {
                   break;
               }
           }
           return c;
        }
        public string encrypt(string txt)
        {
            string enc = "";
            bool c = false;
            int count = 0;
        A:
            while (count < txt.Length)
            {

                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (txt[count].ToString() == master[j, k])
                        {
                            enc += y[j];
                            enc += x[k];
                            count++;
                            goto A;
                        }
                        else if (txt[count].ToString() != master[j, k])
                        {
                            c = false;
                        }
                    }
                }
                if (c == false)
                {
                    break;
                }
            }
            return enc;
        }
        public string decrypt(string txt)
        {
            
            string dec = "";
            int w=0;
            bool q = true;
            int count = 0;
        A:
            while (count < txt.Length)
            {
                if (q)
                {
                    for (int j = 0; j < 10; j++)
                    {
                             if (txt[count].ToString() == y[j])
                            {

                                w = j;
                                q = false;
                                count++;
                                break;
                            }      
                     }

                }
                else if (!q)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (txt[count].ToString() == x[j])
                        {

                            dec += master[w, j];
                            q = true;
                            count ++;
                            goto A;
                        }
                    }
                }
            }
        return dec;
        }
    }
}
