using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    class Connection {
        private Socket socket;
        private List<IDataReceiver> recepients = new List<IDataReceiver>();
        public Connection(Socket s) {
            socket = s;
            Thread t = new Thread(new ThreadStart(readFromSocket)) ;
            t.Start();
        }

        private void readFromSocket() {
            byte[] buffer = new byte[128];
            while (true) {
                int readed = socket.Receive(buffer);
                String text = Encoding.UTF8.GetString(buffer);
                //Console.WriteLine("Otrzymano:" + text);
                foreach(IDataReceiver r in recepients) {
                    r.dataReceived(text);
                    }
            }
        }

        public void Send(String message) {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void RegisterRecepient(IDataReceiver r) {
            recepients.Add(r);
        }


        }
    }
