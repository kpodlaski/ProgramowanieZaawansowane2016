using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class TeamWork
    {
        static volatile int result = 0;

        public void MyTurn(object start)
        {
            Thread _s = (Thread) start;
            if (_s != null) _s.Join();
            for(int i=0; i<1000; i++)
            {
                result++;
            }
            Console.WriteLine("Actual result:" + result);
        }

        static void Main(String[] a)
        {
            Thread[] threads = new Thread[5];
            TeamWork tw = new TeamWork();
            for (int i = 0; i < threads.Length; i++)
            {

                threads[i] = new Thread(tw.MyTurn);
            }
           
            for (int i = 0; i < threads.Length; i++)
            {
                if (i == 0) threads[i].Start(null);
                else threads[i].Start(threads[i - 1]);
            }

            threads[4].Join();
            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}
