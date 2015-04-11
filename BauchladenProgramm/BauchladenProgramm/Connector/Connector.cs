using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BauchladenProgramm.Connector
{

    //class to apply sender and receiver
    public class Connector
    {
        private Sender sender;
        private Receiver receiver;
        private bool connected = false;
        private TcpClient client;
        private IPEndPoint ipep;
        private Thread receiveThread;


        public Connector(String ip, Int32 port)
        {
            //the server needs an ip-adress and a port for the unique identification
            Contract.Requires(ip != null);
            Contract.Requires(port != 0);
            if (ip != null && port > 0)
            {
                ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            client = new TcpClient();
            receiver = new Receiver(this.client);
            sender = new Sender(this.client);

            this.receiveThread = new Thread(new ThreadStart(receive));
            this.receiveThread.Name = "Receive";
        }

        public Buffer getBufferRef()
        {
            return this.receiver.getBufferRef();
        }

        public void closeConnection()
        {
            Contract.Requires(connected);
            //closing the Stream from client and break off the server-connection
            if(this.connected){
                try
                {
                    this.receiveThread.Abort();
                    client.GetStream().Close(); // close the stream
                    client.Close();  // closes the server-connection
                    connected = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        public void sendMessageToServer(String s)
        {
            //here send a message to the Server with the Sender-class (sender.sendMessage(String))
            Contract.Requires(s!=null);
            Contract.Requires(connected);
            if (s != null && this.connected)
            {
                try
                {
                    sender.sendMessage(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public bool isConnected()
        {
            return connected;
        }
        public void connectToServer()
        {
            if (!this.connected)
            {
                try
                {
                    client.Connect(this.ipep);
                    this.connected = true;
                    this.receiveThread.Start();
                }
                catch (SocketException e)
                {
                    this.connected = false;
                    Console.WriteLine("Unable to connect to server.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void receive()
        {
            try
            {
                if (this.isConnected())
                {
                    this.receiver.receive();
                }
                else
                {
                    throw new Exception("Can not receive without connection!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(sender != null);
            Contract.Invariant(receiver != null);
        }
    }

}
