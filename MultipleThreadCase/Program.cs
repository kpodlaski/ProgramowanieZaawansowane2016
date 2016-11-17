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
        static void Main(string[] args)
        {
            Random r = new Random();
            for(int i=0; i < data.Length; i++)
            {
                data[i] = r.Next();
            }

            int howManyTimes = 100;
            long start = DateTime.Now.Ticks;
            for (int i=0; i<howManyTimes; i++) {
                SumOfData();
            }
            long end = DateTime.Now.Ticks;
            Console.WriteLine("Start:" + start + " End:" + end);
            Console.WriteLine("Jednowatkowo: " +  (end - start));

            barrier = new Barrier(howManyTimes,
                  (b) =>
                  {
                      end = DateTime.Now.Ticks;
                      Console.WriteLine("Start:"+start +" End:"+ end);

                      Console.WriteLine("Wielowatkowo: "+ (end - start));
                  });

            Thread[] threads = new Thread[howManyTimes];
            for (int i = 0; i < howManyTimes; i++)
            {
                threads[i] = new Thread(new ThreadStart(TSumOfData));
            }
            start = DateTime.Now.Ticks;
            for (int i = 0; i < howManyTimes; i++)
            {
                threads[i].Start();
            }

            start = DateTime.Now.Ticks;
            for (int i = 0; i < howManyTimes; i++)
            {
                ThreadPool.QueueUserWorkItem(PSumOfData);
            }
            //Stop unitl Pool finished
            end = DateTime.Now.Ticks;
            Console.WriteLine("Start:" + start + " End:" + end);

            Console.WriteLine("Poolowatkowo: " + (end - start));
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

        static void PSumOfData(Object par)
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            //return sum;
        }
    }
}
