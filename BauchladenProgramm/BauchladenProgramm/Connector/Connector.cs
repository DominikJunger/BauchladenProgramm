﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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
        private Parser parser;
        private Mainwindow mainwindow;


        public Connector(String ip, Int32 port, Mainwindow mainwindow)
        {
            //the server needs an ip-adress and a port for the unique identification
            try
            {
                if (ip != null && port > 0)
                {
                    ipep = new IPEndPoint(IPAddress.Parse(ip), port);
                }
                client = new TcpClient();
                receiver = new Receiver(this.client);
                sender = new Sender(this.client);

                this.parser = new Parser(receiver.getBufferRef(), mainwindow);

                this.receiveThread = new Thread(new ThreadStart(receive));
                this.receiveThread.Name = "Receive";
                this.mainwindow = mainwindow;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Buffer getBufferRef()
        {
            return this.receiver.getBufferRef();
        }

        public void closeConnection()
        {
            //closing the Stream from client and break off the server-connection
            if(this.connected){
                try
                {
                    this.receiveThread.Abort();
                    client.GetStream().Close(); // close the stream
                    client.Close();  // closes the server-connection
                    connected = false;

                    this.parser.stopParser();
                    this.receiver.stopBuffer();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        private void sendMessageToServer(String s)
        {
            //here send a message to the Server with the Sender-class (sender.sendMessage(String))
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
                    throw e;
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

// Methoden zum Senden-------------------------
        // Methoden zum abfragen von Werten auf dem Server
        public void getProductList()
        {
            this.sendMessageToServer(Syntax.GET + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST);
        }

        public void getKontostand(string userId)
        {
            this.sendMessageToServer(Syntax.GET + Syntax.COLON_CHAR + Syntax.SEARCH + Syntax.COLON_CHAR + userId);
        }

        public void getTeilnehmerList()
        {
            this.sendMessageToServer(Syntax.GET + Syntax.COLON_CHAR + Syntax.MEMBERLIST);
        }

        // Methoden zum setzen von Werten auf dem Server
        public void setBuy(string userId,string productID, string anzahl)
        {
            this.sendMessageToServer(Syntax.SET + Syntax.COLON_CHAR + Syntax.BUY + Syntax.COLON_CHAR + userId + Syntax.ENUM_CHAR + productID + Syntax.ENUM_CHAR + anzahl);
        }

        public void setEinzahlung(string userId, decimal betrag)
        {
            this.sendMessageToServer(Syntax.SET + Syntax.COLON_CHAR + Syntax.EINZAHLUNG + Syntax.COLON_CHAR + userId + Syntax.ENUM_CHAR + String.Format("{0:F2}",betrag));
        }

        public void setBuyEnd(string userId)
        {
            this.sendMessageToServer(Syntax.SET + Syntax.COLON_CHAR + Syntax.BUY + Syntax.COLON_CHAR + Syntax.OKAY + userId);
        }
    }

}
