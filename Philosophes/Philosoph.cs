using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Philosophes
{
    class Philosoph
    {
        private static Random rand = new Random();
        public String Name { get;  set;}
        public static int sleepParameter =1000;
        private ChopStick left, right;
        public void Eat()
        {
            Console.WriteLine(Name + " starts Eatind");
            bool lChS = false;
            bool rChS = false;
            while (!rChS || !lChS )
            {
                lock (right)
                {
                    if (!right.canBeUsed())
                    {
                        right.pickUp();
                        rChS = true;
                    }
                    else
                    {
                        Monitor.Wait(right);
                    }

                }
                if (!rChS) continue;
                lock (left)                {
                    if (!left.canBeUsed())
                    {
                        left.pickUp();
                        lChS = true;
                    }
                    else
                    {
                        Monitor.Wait(left);
                    }
                }
                if (!lChS)                {
                    right.putDown();
                    rChS = false;
                } 
                
                
            }
            Thread.Sleep(rand.Next() % sleepParameter);
            left.putDown();
            lock (left)
                Monitor.PulseAll(left);
            right.putDown();
            lock (right)
                Monitor.PulseAll(right);
            Console.WriteLine(Name + " finished Eating");
        }

        public void Think()
        {
            Console.WriteLine(Name + " Thinks");
            Thread.Sleep(rand.Next() % sleepParameter);
            Console.WriteLine(Name + " Finished Thinking");
        }

        public void Live()
        {
            while (true)
            {
                Think();
                Eat();
            }
        }

        public Philosoph(String name, ChopStick right, ChopStick left)
        {
            Name = name;
            this.right = right;
            this.left = left;
            Thread t = new Thread(new ThreadStart(this.Live));
            t.Start();
        }
    }
}
