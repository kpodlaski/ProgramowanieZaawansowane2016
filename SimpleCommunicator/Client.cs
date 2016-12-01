using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    class Client : IDataReceiver{
        Connection c;
        Socket socket;
        int port;

        public static Client createClient(String addres, int port) {
            Client client = new Client();
            client.port = port;
            try {
                IPHostEntry ipHostInfo = Dns.Resolve(addres);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                Socket socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(localEndPoint);
                client.c = new Connection(socket);
                client.socket = socket;
                client.c.RegisterRecepient(client);
                }
            catch(Exception e) {
                Console.WriteLine(e);
                client = null;
                }
            return client;
            }
        public void Send(String msg) {
            c.Send(msg);
        }

        public void dataReceived(string msg) {
            Console.WriteLine("Klient otrzymał:" + msg);
            }
        }
        
    }
