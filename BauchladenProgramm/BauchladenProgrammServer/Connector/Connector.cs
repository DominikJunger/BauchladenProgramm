using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Connector
{

    //class to apply sender and receiver
    public class Connector
    {
        private Sender sender;
        private Receiver receiver;
        private TcpClient client;
        private Thread receiveThread;
        private Parser parser;


        public Connector(TcpClient client, Server backend)
        {
            if (client == null)
                throw new Exception("Serververbidung hat keinen gültigen Client");
            this.client = client;

            receiver = new Receiver(this.client);
            sender = new Sender(this.client);

            if (backend == null)
                throw new Exception("Kein Parsen von Daten möglich");
            this.parser = new Parser(receiver.getBufferRef(), backend);

            this.receiveThread = new Thread(new ThreadStart(receive));
            this.receiveThread.Name = "Receive";
            this.receiveThread.Start();
        }

        public Buffer getBufferRef()
        {
            return this.receiver.getBufferRef();
        }

        public bool isConnected()
        {
            return this.client.Connected;
        }

        public void sendMessageToClient(String s)
        {
            //here send a message to the Client with the Sender-class (sender.sendMessage(String))
            Contract.Requires(s!=null);
            if (s != null)
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

        private void receive()
        {
            try
            {
                this.receiver.receive();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
