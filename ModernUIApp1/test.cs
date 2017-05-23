using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class test
    {
        public int count;
        public int[] qn;

        public int ques;
        public int[] answer;
        public test()
        {
            count = 0;
            qn = new int[10];
            answer = new int[5];
            for (int i = 0; i < qn.Length; i++)
            {
                qn[i] = -1;
            }
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = -1;
            }
        }
        public bool qns(int index)
        {
            bool c = true;
            for (int i = 0; i < qn.Length; i++)
            {
                if (index == qn[i])
                {
                    c = false;
                    break;
                }
                else { c = true; }
            }

            return c;
        }
        public bool ans(int index)
        {
            bool c = true;
            for (int i = 0; i < answer.Length; i++)
            {
                if (index == answer[i])
                {
                    c = false;
                    break;
                }
                else { c = true; }
            }

            return c;
        }
        public void ask()
        {
            words w = new words();
            w.initialize();
        q:
            Random rand = new Random();
            int index = rand.Next(0, w.index);
            if (qns(index))
            {
                ques = index;
            }
            else { goto q; }

            int indexa = rand.Next(0, 5);
            answer[indexa] = index;
            int c = 0;
            do
            {
                if (c != indexa)
                {
                e:
                   
                    int y = rand.Next(0, w.index);
                    if (y != index)
                    {
                        if (ans(y))
                        {

                        answer[c] = y;
                        c++;
                        }
                        else { goto e; }
                    }
                    else{goto e;}
                }
                else { c++; }
            } while (c < 5);


        }
        public void tester()
        {
           
                ask();
                qn[count] = ques;
                count++;
           
        
        }
    }
}
