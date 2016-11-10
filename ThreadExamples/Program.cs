using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] thred = new Thread[50];
            JobToDo job = new JobToDo();
            /*for(int i=0; i < thred.Length; i++)
            {
                //thred[i] = new Thread(new ThreadStart(job.JoabA));
                thred[i] = new Thread(job.JoabB);
            }
            for (int i = 0; i < thred.Length; i++)
            {
                thred[i].Start(i);
            }
            */
            thred[0] = new Thread(job.JobC);
            thred[0].Start(1);
            thred[1] = new Thread(job.JobCTest);
            thred[1].Start(1);
            Console.WriteLine("WAITING ...");
            Console.ReadKey();
            Console.WriteLine(job.Counter);
            Console.ReadKey();
        }
    }

    class JobToDo
    {
        public int Counter = 0;
        private volatile bool  working = true;
        public void JoabA()
        {
            for (int i=0; i<15; i++)
            {
                Console.WriteLine(i+"::");
            }
        }

        public void JoabB(object _id)
        {
            int id = (int) _id;
            for (int i = 0; i < 15; i++)
            {
                //Console.WriteLine(id + "::" + i);
                Counter= Counter+1;
                Counter = Counter + 1;
            }
        }

        public void JobC(object _id)
        {
            while (working)
            {
                lock(this){
                    Counter++;
                    Counter++;
                }
            }
        }
        public void JobCTest(object _id)
        {
            int v;
            while (working)
            {
                
                v = Counter % 2; 
                if (v != 0)
                {
                    working = false;
                    Console.WriteLine(v + " "+ Counter);
                }
            }
        }
    }
}
