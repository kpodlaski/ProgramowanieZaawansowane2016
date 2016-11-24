using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadSortTest
{
    class FirstApproach
    {
        static int[] data;
        static int[] dataC;
        static int maxLevels;
        static int dataSize;

        public static void BasicStaticOneThreadSort()
        {
            dataSize = 1000;
            maxLevels = 5;

            Random r = new Random();
            data = new int[dataSize];
            dataC = new int[dataSize];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;// r.Next();
            }
            Array.Copy(data, dataC, data.Length);
            int order = -1; //+1=>asceding, -1=>desceding;
            OneThreadMergeSort(order);

        }

        static void OneThreadMergeSort(int order)
        {
            int level = 1; int offset = 0;
            MergeSort(level, offset, dataSize,order);
            if (order > 0) Array.Sort(dataC);
            else Array.Sort(dataC, delegate (int a, int b)
            {
                return b - a; //Normal compare is a-b
            });
            bool goodResults = true;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != dataC[i])
                {
                    Console.WriteLine(i+"::"+data[i] + " : " + dataC[i]);
                    goodResults = false;
                    break;
                }

            }
            if (goodResults) Console.WriteLine("Sorting gives proper results");
            Console.ReadKey();
        }

        static void MergeSort(int level, int offset, int size, int order)
        {
            if (level < maxLevels)
            {
                /*Console.WriteLine("Splits on level " + level);
                Console.WriteLine("size " + size+":::"+dataSize / Math.Pow(2,level) + "offset "+offset);
                Console.WriteLine("A " + offset);
                Console.WriteLine("B " + (offset + size/2));
                */
                int nsize = size / 2;
                //size%2 for uneven cases, the first part take one additional element
                MergeSort(level + 1, offset, nsize + (size%2),order);
                MergeSort(level + 1, offset + nsize + (size % 2), nsize,order);
                Merge(level, offset, order, size);
            }
            else Sort(level - 1, offset, size,order);

        }

        private static void Sort(int level, int offset, int size, int order)
        {
            Console.WriteLine("Sort offset :" + offset + " size: " + size);

            int t;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (order * data[i + offset] < order * data[j + offset])
                    {
                        t = data[i + offset];
                        data[i + offset] = data[j + offset];
                        data[j + offset] = t;
                    }
                }
            }
        }

        private static void Merge(int level, int offset, int order, int size)
        {
            int size2 = size / 2;
            int[] tdataA = new int[size2 + size%2];
            int[] tdataB = new int[size2];
            Array.Copy(data, offset, tdataA, 0, size2 + size % 2);
            Array.Copy(data, offset + size2 + size % 2, tdataB, 0, size2);
            int offset1 = 0, offset2 = 0;
            while (offset1 + offset2 < size)
            {
                if (offset1 >= tdataA.Length || offset2 >= tdataB.Length)
                {
                    if (offset1 < tdataA.Length)
                    {
                        data[offset + offset1 + offset2] = tdataA[offset1];
                        offset1++;
                    }
                    else
                    {
                        data[offset + offset1 + offset2] = tdataB[offset2];
                        offset2++;
                    }
                    continue;
                }
                if (order * tdataA[offset1] < order * tdataB[offset2])
                {
                    data[offset + offset1 + offset2] = tdataA[offset1];
                    offset1++;
                }
                else
                {
                    data[offset + offset1 + offset2] = tdataB[offset2];
                    offset2++;
                }
            }
        }
    }
}
