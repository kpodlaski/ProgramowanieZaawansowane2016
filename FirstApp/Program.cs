using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        public int Value;
        private double dvalue;
        public int PValue { get; set; }
        public int PValue2 { get; }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Value = 12;
            p = new Program();
            p.Value = 7;
            //p = null;
            p.PValue = p.Value;
            //p.PValue2 = p.PValue;

            SecondClass sc = new SecondClass(4);

            //Console.WriteLine("Coś tam" + p.Value+ " "+p);
            Console.Write(sc.Power(5));
            p.dvalue = p.Value;
            p.Value = (int) p.dvalue;
            PClass pc = new PClass();
            Console.ReadKey();
            
        }

        public override string ToString()
        {
            return " obiekt typu "+base.ToString();
        }
    }

    partial class PClass
    {
        public int f;
    }
}
