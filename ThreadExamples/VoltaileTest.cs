using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class VoltaileTest
    {
        static string _result;
        static  bool _done;

        static void SetVolatile()
        {
            // Set the string.
            _result = "Dot Net Perls";
            // The volatile field must be set at the end of this method.
            _done = true;
        }

        static void Main()
        {
            // Run the above method on a new thread.
            new Thread(new ThreadStart(SetVolatile)).Start();
            int i = 0;
            int y;
            Random r = new Random();
            while (i<100000)
            {
                i++;
                y = i * 100 + i + r.Next()%30;
            }

            // Read the volatile field.
            if (_done)
            {
                Console.WriteLine(_result);
            }
            Console.WriteLine("END" + i);
            Console.ReadKey();
        }
    }
}
