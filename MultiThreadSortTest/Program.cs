using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadSortTest
{
    class Program
    {
        delegate int NazwaDel(String a, int b);

        static int met1(String s, int i)
        {
            Console.WriteLine(s + i);
            return i;
        }

        static void met2(NazwaDel m, String s, int i)
        {
            m(s, i);
        }

        static void delegateUsageExample()
        {
            met2(met1, "Ala", 13);
        }

        static volatile int counter=1;
        public static void testPool()
        {
            

            for (int i = 1; i < 10000; i++)
            {
                ThreadPool.QueueUserWorkItem((d) =>
                {
                    Console.WriteLine("Start worker " + counter);
                    counter++;
                    int x;
                    while (true)
                    {
                        x = i;
                        Thread.Sleep(1000);
                    }
                });
                
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            int[] data;
            int[] dataC;
            int[] dataC2;
            int[] dataC3;
            int maxLevels  = 6;
            int dataSize = 100000;
            Random r = new Random();
            data = new int[dataSize];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = r.Next();
            }
            dataC = new int[dataSize];
            dataC2 = new int[dataSize];
            dataC3 = new int[dataSize];
            Array.Copy(data, dataC, data.Length);
            Array.Copy(data, dataC2, data.Length);
            Array.Copy(data, dataC3, data.Length);
            int order = -1; //+1=>asceding, -1=>desceding;
            long startTime = DateTime.Now.Ticks;
            EasySorting eSort = new EasySorting(data, maxLevels, dataSize);
            eSort.StartSort(order);
            long endTime = DateTime.Now.Ticks;
            if (order > 0) Array.Sort(dataC);
            else Array.Sort(dataC, delegate (int a, int b) {
                                    return b - a; //Normal compare is a-b
                                    });
            bool goodResults = true;
            for (int i = 0; i < dataC.Length; i++)
            {
                if (data[i] != dataC[i])
                {
                    Console.WriteLine(i + " :: " + data[i] + " : " + dataC[i]);
                    goodResults = false;
                    break;
                }
            }
            Console.WriteLine("=================ONE THREAD =================");
            if (goodResults) Console.WriteLine("Sorting gives proper results");
            TimeSpan ts = new TimeSpan(endTime - startTime);
            Console.WriteLine("Sorting time: "+ ts.Milliseconds+"ms");
            Console.WriteLine("=================MULTIPLE THREADS =================");
            startTime = DateTime.Now.Ticks;
            EasySorting teSort = new EasySortingWithThreads(dataC2, maxLevels, dataSize);
            teSort.StartSort(order);
            endTime = DateTime.Now.Ticks;
            goodResults = true;
            for (int i = 0; i < dataC.Length; i++)
            {
                if (dataC2[i] != dataC[i])
                {
                    Console.WriteLine(i+" :: "+dataC2[i] + " : " + dataC[i]);
                    goodResults = false;
                    break;
                }
            }
            if (goodResults) Console.WriteLine("Sorting gives proper results");
            ts = new TimeSpan(endTime - startTime);
            Console.WriteLine("Sorting time: " + ts.Milliseconds + "ms");
            //Console.ReadKey();
            //testPool();
            //return;

            Console.WriteLine("=================POOLED THREADS =================");
            startTime = DateTime.Now.Ticks;
            EasySorting tpeSort = new EasySortingUsingThreadPool(dataC3, maxLevels, dataSize);
            tpeSort.StartSort(order);
            endTime = DateTime.Now.Ticks;
            goodResults = true;
            for (int i = 0; i < dataC.Length; i++)
            {
                if (dataC3[i] != dataC[i])
                {
                    Console.WriteLine(i + " :: " + dataC3[i] + " : " + dataC[i]);
                    goodResults = false;
                    break;
                }
            }
            if (goodResults) Console.WriteLine("Sorting gives proper results");
            ts = new TimeSpan(endTime - startTime);
            Console.WriteLine("Sorting time: " + ts.Milliseconds + "ms");
            
            Console.ReadKey();
        }

        
    }
}
