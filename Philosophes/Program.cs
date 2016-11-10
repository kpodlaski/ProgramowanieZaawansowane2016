using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Philosophes
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            Philosoph.sleepParameter = 20;
            ChopStick[] chopsticks = new ChopStick[size];
            Philosoph[] philosophes = new Philosoph[size];
            for (int i=0; i< chopsticks.Length; i++)
            {
                chopsticks[i] = new ChopStick();
            }
            for (int i = 0; i < chopsticks.Length; i++)
            {
                philosophes[i] = new Philosoph("P"+i, chopsticks[i], chopsticks[(i+1)%size] );
                Thread.Sleep(500);
            }
        }
    }
}
