using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadSortTest
{
    class EasySortingUsingThreadPool : EasySortingWithThreads
    {
        public EasySortingUsingThreadPool(int[] data, int maxLevels, int dataSize) : base(data, maxLevels, dataSize)
        {
            ThreadPool.SetMinThreads(maxLevels * 4, maxLevels * 4);
            ThreadPool.SetMinThreads(1<<(maxLevels-2), 1<<(maxLevels-2));
        }

        public override void StartSort(int order)
        {
            Barrier barrier = new Barrier(2, (b) => {
                //Console.WriteLine("End Task");
            });
            MergeSort(1, 0, dataSize, order, barrier);
            barrier.SignalAndWait();
        }

        private new void MergeSort(int level, int offset, int size, int order, Barrier barrier)
        {
            Barrier newbarrier = new Barrier(2, (b) => {
                Merge(level, offset, size, order);
                //Console.WriteLine("Pooling");
                barrier.SignalAndWait();
            });
            if (level < maxLevels)
            {
                int nsize = size / 2;
                //size%2 for uneven cases, the first part take one additional element
                ThreadPool.QueueUserWorkItem( (o) => {
                    //Console.WriteLine("Start:" + (level+1) +" : "+offset);
                    MergeSort(level + 1, offset, nsize + (size % 2), order, newbarrier);
                });
                ThreadPool.QueueUserWorkItem( (o) => {
                    //Console.WriteLine("Start:" + (level + 1) + " : " + offset + nsize + size%2);
                    MergeSort(level + 1, offset + nsize + (size % 2), nsize, order, newbarrier);
                });
            }
            else
            {
                newbarrier.RemoveParticipant();
                Sort(level - 1, offset, size, order);
                newbarrier.SignalAndWait();
            }

        }
    }
}
