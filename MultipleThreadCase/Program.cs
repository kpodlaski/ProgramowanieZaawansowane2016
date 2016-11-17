using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleThreadCase
{
    class Program
    {
        static volatile int[] data = new int[1000];
        static Barrier barrier;
        static ManualResetEvent[] doneEvents;
        static void Main(string[] args)
        {
            Random r = new Random();
            for(int i=0; i < data.Length; i++)
            {
                data[i] = r.Next();
            }

            int howManyTimes = 64;
            //=================JEDEN WATEK===================
            long start = DateTime.Now.Ticks;
            for (int i=0; i<howManyTimes; i++) {
                SumOfData();
            }
            long end = DateTime.Now.Ticks;
            Console.WriteLine("Start:" + start + " End:" + end);
            Console.WriteLine("Jednowatkowo: " +  (end - start));
            //=================PRZYGOTOWANIE===================
            barrier = new Barrier(howManyTimes,
                  (b) =>
                  {
                      end = DateTime.Now.Ticks;
                      Console.WriteLine("Start:"+start +" End:"+ end);

                      Console.WriteLine("Wielowatkowo: "+ (end - start));
                  });

            Thread[] threads = new Thread[howManyTimes];
            doneEvents = new ManualResetEvent[howManyTimes];
            for (int i = 0; i < howManyTimes; i++)
            {
                threads[i] = new Thread(new ThreadStart(TSumOfData));
                doneEvents[i] = new ManualResetEvent(false);
            }
            //=================POOL===================
            start = DateTime.Now.Ticks;
            for (int i = 0; i < howManyTimes; i++)
            {
                ThreadPool.QueueUserWorkItem(PSumOfData, doneEvents[i]);
            }
            //Stop unitl Pool finished
            WaitHandle.WaitAll(doneEvents);
            end = DateTime.Now.Ticks;
            Console.WriteLine("Start:" + start + " End:" + end);

            Console.WriteLine("Poolowatkowo: " + (end - start));
            int wTh, cPT;
            ThreadPool.GetMaxThreads(out wTh, out cPT);
            Console.WriteLine("Wielkość Pooli: " +wTh +" :: "+cPT  );
            //=================WĄTKI===================
            start = DateTime.Now.Ticks;
            for (int i = 0; i < howManyTimes; i++)
            {
                threads[i].Start();
            }

            
            Console.ReadKey();
        }

        static long SumOfData()
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum+=data[i];
            }
            //barrier.SignalAndWait();
            return sum;
        }

        static void  TSumOfData()
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            barrier.SignalAndWait();
            //return sum;
        }

        static void PSumOfData(Object _event)
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            ((ManualResetEvent)_event).Set();
            //return sum;
        }
    }
}
