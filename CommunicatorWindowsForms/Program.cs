using SimpleCommunicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunicatorWindowsForms {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread t = new Thread(new ThreadStart(watekSerwera));
            t.Start();
            Thread.Sleep(200);
            t = new Thread(new ThreadStart(watekKlienta));
            t.Start();

            }
        static void watekSerwera() {
            Server server = Server.createServer(5000);
            Application.Run(new ComWindow(server));
            }

        static void watekKlienta() {
            Client client = Client.createClient("localhost", 5000);
            Application.Run(new ComWindow(client));
            while (true) {
                String text = Console.ReadLine();
                client.Send(text);
                }
            }


        }
    }
