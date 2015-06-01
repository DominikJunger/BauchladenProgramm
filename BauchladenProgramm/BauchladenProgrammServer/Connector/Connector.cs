﻿using BauchladenProgramm.Connector;
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
            this.parser = new Parser(receiver.getBufferRef(), this);

            this.receiveThread = new Thread(new ThreadStart(receive));
            this.receiveThread.Name = "Receive";
            this.receiveThread.Start();
        }

        public bool isConnected()
        {
            return this.client.Connected;
        }

        private void sendMessageToClient(String s)
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

        // Methoden zum Senden
        public void sendProductList()
        {
            //Beispiel statisch aufgebaut zum Testen
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR +"1");
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST);

            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUKT +"1");
            this.sendMessageToClient(Syntax.PRODUKT_NAME+"Snicker Groß");
            this.sendMessageToClient(Syntax.PRODUKT_PRICE+"1,50");
            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT +"1");

            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUKT + "2");
            this.sendMessageToClient(Syntax.PRODUKT_NAME + "Mars");
            this.sendMessageToClient(Syntax.PRODUKT_PRICE + "0,30");
            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT + "2");

            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + "1");
            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST);
        }
    }

}
