using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BauchladenProgrammServer
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private List<Connector.Connector> clientList;

        public Server(IPEndPoint ipE)
        {
            this.clientList = new List<Connector.Connector>();
            this.tcpListener = new TcpListener(ipE);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
          this.tcpListener.Start();

          while (true)
          {
            //blocks until a client has connected to the server
            TcpClient client = this.tcpListener.AcceptTcpClient();

            //create a thread to handle communication 
            //with connected client
            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
            clientThread.Start(client);
            Console.WriteLine("Neuer Client vom Server aufgenommen");
          }
        }

        private void HandleClientComm(object client)
        {
            clientList.Add(new Connector.Connector((TcpClient)client,this));
        }
    }
}
