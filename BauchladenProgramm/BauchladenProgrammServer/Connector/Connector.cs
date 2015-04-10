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


        public Connector(TcpClient client)
        {
            if (client == null)
                throw new Exception("Serververbidung hat keinen gültigen Client");
    
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
            //closing the Stream from Server and break off the Client-connection
                try
                {
                    this.receiveThread.Abort();
                    client.GetStream().Close(); // close the stream
                    client.Close();  // closes the server-connection

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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

        public void send(String msg)
        {
            try
            {
                if (msg!=null)
                {
                    this.sender.sendMessage(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
