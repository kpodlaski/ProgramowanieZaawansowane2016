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
        public int sleepParameter =500;
        private ChopStick left, right;
        public void Eat()
        {
            Console.WriteLine(Name + " starts Eatind");
            right.pickUp();
            left.pickUp();
            Thread.Sleep(rand.Next() % sleepParameter);
            left.putDown();
            right.putDown();
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
