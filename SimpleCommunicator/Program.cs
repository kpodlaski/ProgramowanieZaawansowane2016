using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    class Program {
        static void Main(string[] args) {
            Thread t = new Thread(new ThreadStart(watekSerwera));
            t.Start();
            Thread.Sleep(200);
            t = new Thread(new ThreadStart(watekKlienta));
            t.Start();
            }

        static void watekSerwera() {
            Server server = Server.createServer(5000);
            }

        static void watekKlienta() {
            Client client = Client.createClient("localhost",5000);
            while (true) {
                String text = Console.ReadLine();
                client.Send(text);
                }
            }
        }
    }
