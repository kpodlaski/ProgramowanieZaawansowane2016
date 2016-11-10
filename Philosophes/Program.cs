using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosophes
{
    class Program
    {
        static void Main(string[] args)
        {
            ChopStick[] chopsticks = new ChopStick[5];
            Philosoph[] philosophes = new Philosoph[5];
            for (int i=0; i< chopsticks.Length; i++)
            {
                chopsticks[i] = new ChopStick();
            }
            for (int i = 0; i < chopsticks.Length; i++)
            {
                philosophes[i] = new Philosoph("P"+i, chopsticks[i], chopsticks[(i+1)%5] );
            }
        }
    }
}
