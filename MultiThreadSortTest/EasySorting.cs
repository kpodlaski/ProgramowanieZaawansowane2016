using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadSortTest
{
    class EasySorting
    {
        protected int[] data;
        protected int maxLevels;
        protected int dataSize;

        public EasySorting(int[] data, int maxLevels, int dataSize) 
        {
            this.data = data;
            this.maxLevels = maxLevels;
            this.dataSize = dataSize;
        }


        virtual public void StartSort(int order)
        {
            MergeSort(1, 0, dataSize, order);
        }

        protected void MergeSort(int level, int offset, int size, int order)
        {
            if (level < maxLevels)
            {
                int nsize = size / 2;
                //size%2 for uneven cases, the first part take one additional element
                MergeSort(level + 1, offset, nsize + (size%2), order);
                MergeSort(level + 1, offset + nsize + (size % 2), nsize , order);
                Merge(level, offset, size, order);
            }
            else Sort(level - 1, offset, size, order);

        }

        protected void Sort(int level, int offset, int size, int order)
        {
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

        protected void Merge(int level, int offset, int size, int order)
        {
            int size2 = size / 2;
            int[] tdataA = new int[size2 + size%2];
            int[] tdataB = new int[size2];
            Array.Copy(data, offset, tdataA, 0, size2 + size%2);
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
