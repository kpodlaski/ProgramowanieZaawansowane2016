using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExamples
{
    class TeamWorkBarrier
    {
        static volatile int result = 0;
        static Random r = new Random();
        public void MyTurn(object start)
        {
            Barrier _s = (Barrier)start;
            for (long i = 0; i < 10000; i++)
            {

                result++;//= r.Next();
            }
            Console.WriteLine("Actual result:" + result);
            _s.SignalAndWait();
            Console.WriteLine("END THREAD");
        }

        public void BarrierReleased(Barrier b)
        {
            Console.WriteLine("Barrier Released" +b);
        }

        static void Main(String[] a){
            Thread[] threads = new Thread[5];
            TeamWorkBarrier tw = new TeamWorkBarrier();
            Barrier barrier = new Barrier(5, (b) =>
                    {
                            Console.WriteLine("Barrier Released" + b);
                    }
            );
            //barrier = new Barrier(5, tw.BarrierReleased);
            barrier.AddParticipant();          
            for (int i = 0; i < threads.Length; i++){

                threads[i] = new Thread(tw.MyTurn);
            }
            for (int i = 0; i < threads.Length; i++){
                threads[i].Start(barrier);
            }
            barrier.SignalAndWait();
            Console.WriteLine("END");

            List<int> lista = new List<int>();
            for (int i = 0; i < 100; i++) lista.Add(r.Next());
            int wynik=0;
            lista.ForEach((x) => { wynik += x; });
            Console.WriteLine(wynik);
            Console.ReadKey();
        }
    }
}
