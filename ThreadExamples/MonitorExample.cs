using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class MonitorExample
    {
        public void JobToDo(object a)
        {
            object[] args = (object[])a;
            object monitor = args[0];
            object id = args[1];
            bool finished = false;
            while (!finished)            {
                if (!Monitor.TryEnter(monitor))
                {
                    Console.WriteLine("WAITING " + id);
                    Monitor.Wait(monitor);
                    Monitor.Exit(monitor);
                }
                else
                {
                    Console.WriteLine("DO SOMETHING ... ");
                    Thread.Sleep(500);
                    Console.WriteLine("ENDED " + id);
                    finished = true;
                    Monitor.Exit(monitor);
                }
            }            
        }
        public static void Main(String[] a)        {
            Thread[] thread = new Thread[5];
            MonitorExample job = new MonitorExample();
            for(int i=0; i<thread.Length; i++)            {
                thread[i] = new Thread(job.JobToDo);
                thread[i].Start(new object[] { job, "id:" + i });
            }
            Console.WriteLine("FINISHED");
            Console.ReadKey();
        }
    }
}
