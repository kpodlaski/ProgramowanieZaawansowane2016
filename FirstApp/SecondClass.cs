using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class SecondClass
    {
        int Value { get; set; }
        public SecondClass(int Value)
        {
            this.Value = Value;
        }

        public int Power(int n)
        {
            int result = 1;
            for (int i = 0; i<n; i++)
                result = result * Value;
            
            return result;
        }

        void four1(double[] data, ulong nn)
        {
            ulong n, mmax, m, j, istep, i;
            double wtemp, wr, wpr, wpi, wi, theta;
            double tempr, tempi;

            // reverse-binary reindexing
            n = nn << 1;
            j = 1;
            for (i = 1; i < n; i += 2)
            {
                if (j > i)
                {
                    swap(data,j - 1, i - 1);
                    swap(data,j,i);
                }
                m = nn;
                while (m >= 2 && j > m)
                {
                    j -= m;
                    m >>= 1;
                }
                j += m;
            };

            // here begins the Danielson-Lanczos section
            mmax = 2;
            while (n > mmax)
            {
                istep = mmax << 1;
                theta = -(2 * Math.PI / mmax);
                wtemp = Math.Sin(0.5 * theta);
                wpr = -2.0 * wtemp * wtemp;
                wpi = Math.Sin(theta);
                wr = 1.0;
                wi = 0.0;
                for (m = 1; m < mmax; m += 2)
                {
                    for (i = m; i <= n; i += istep)
                    {
                        j = i + mmax;
                        tempr = wr * data[j - 1] - wi * data[j];
                        tempi = wr * data[j] + wi * data[j - 1];

                        data[j - 1] = data[i - 1] - tempr;
                        data[j] = data[i] - tempi;
                        data[i - 1] += tempr;
                        data[i] += tempi;
                    }
                    wtemp = wr;
                    wr += wr * wpr - wi * wpi;
                    wi += wi * wpr + wtemp * wpi;
                }
                mmax = istep;
            }
        }

        void swap (double[] data, ulong index1, ulong index2)
        {
            double temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }
    }

    partial class PClass
    {
        public int x;
    }
}
