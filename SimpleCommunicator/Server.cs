using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommunicator {
    public class Server  : IDataReceiver, ICommunicator{
        Connection c = null;
        int port;
        Socket clientSocket;
        Socket serverSocket;

        public Server(int port) {
            this.port = port;
        }

        public static Server createServer(int port) {
            Server s = new Server(port);
            try {
                IPHostEntry ipHostInfo = Dns.Resolve("localhost");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

                Socket serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10);
                Socket clientSocket = serverSocket.Accept();
                s.c = new Connection(clientSocket);
                s.clientSocket = clientSocket;
                s.serverSocket = serverSocket;
                s.c.RegisterRecepient(s);
                }
            catch (Exception e) {
                Console.WriteLine(e);
                s = null;
            }
            return s;
        }

        public void dataReceived(string msg) {
                Console.WriteLine("Serwer otrzymał:" + msg);
                c.Send(msg);
            }

        public void RegisterRecepient(IDataReceiver r) {
            c.RegisterRecepient(r);
        }

        public void Send(String msg) {
            c.Send(msg);
        }

        //ADD CLOSE OPERATIONS
        }
    }
