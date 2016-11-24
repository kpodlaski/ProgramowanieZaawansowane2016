using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadSortTest
{
    class EasySortingWithThreads : EasySorting
    {
        public EasySortingWithThreads(int[] data, int maxLevels, int dataSize) : base(data, maxLevels, dataSize)
        {
        }

        public override void StartSort(int order)
        {
            Barrier barrier = new Barrier(2, (b) => { //Console.WriteLine("End Task");
                        });
            MergeSort(1, 0, dataSize ,order, barrier);
            barrier.SignalAndWait();

        }

        protected new void MergeSort(int level, int offset, int size, int order, Barrier barrier)
        {
            Barrier newbarrier = new Barrier(2, (b) =>{
                Merge(level, offset, size, order);
                //Console.WriteLine("Threading");
                barrier.SignalAndWait();
            });
            if (level < maxLevels)
            {
                int nsize = size / 2;
                //size%2 for uneven cases, the first part take one additional element
                new Thread(new ThreadStart(() => { MergeSort(level + 1, offset, nsize + (size % 2), order, newbarrier); })).Start();
                new Thread(new ThreadStart(() => { MergeSort(level + 1, offset + nsize + (size % 2), nsize, order, newbarrier); })).Start();
            }
            else
            {
                //The Barier is set to 2 participants, but if there is no merging we have only 1 participant - sort operation
                newbarrier.RemoveParticipant();
                Sort(level - 1, offset, size, order);
                newbarrier.SignalAndWait();
            }

        }
    }
}
