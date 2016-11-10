using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class ImplementingClass : SecondClass, IMyInterface, IMyInterface2
    {
        public ImplementingClass() : base(1)
        {
        }

        public double CountCost(double value)
        {
            return 0.1 * value;
        }

        public double CountTax(double value)
        {
            return 0.9 * value;
        }

        double IMyInterface.CountTax(double value)
        {
            return value;
        }

        double IMyInterface2.CountTax(double value)
        {
            return 0.3 * value;
        }

        static void Main(string[] args)
        {
            ImplementingClass ob = new ImplementingClass();
            Console.WriteLine(ob.CountTax(12));
            UseIMyInterface(ob);
            UseIMyInterface2(ob);
            Console.ReadKey();
            //Program.Main(new string[] { "Ala", "ma", "kota" });
        }
        static void UseIMyInterface(IMyInterface obj)
        {
            Console.WriteLine("Wynik Tax " + obj.CountTax(12));
        }
        static void UseIMyInterface2(IMyInterface2 obj)
        {
            Console.WriteLine("Wynik Tax2 " + obj.CountTax(12));
        }

        
    }
}
