using BauchladenProgramm.Connector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BauchladenProgrammServer.Backend_Klassen;

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
        private static int msgCount=0;
        private Mainwindow gui;


        public Connector(TcpClient client, Server backend, Mainwindow gui)
        {
            if (client == null)
                throw new Exception("Serververbidung hat keinen gültigen Client");
            this.client = client;

            receiver = new Receiver(this.client);
            sender = new Sender(this.client);
            this.gui=gui;

            if (backend == null)
                throw new Exception("Kein Parsen von Daten möglich");
            this.parser = new Parser(receiver.getBufferRef(),this, gui);

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
                    this.gui.logNachricht(s);
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

        // Methode zum Senden von TeilnehmerListe

        public void sendTeilnehmerList(List<Teilnehmer> teilnehmer)
        {
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + msgCount.ToString());
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MEMBERLIST);

            for (int i = 0; i < teilnehmer.Count; i++)
            {
                this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MEMBER + Syntax.COLON_CHAR + (i+1));
                this.sendMessageToClient(Syntax.FIRST_NAME + Syntax.COLON_CHAR + teilnehmer[i].VorName);
                this.sendMessageToClient(Syntax.LAST_NAME + Syntax.COLON_CHAR + teilnehmer[i].NachName);
                this.sendMessageToClient(Syntax.ID + Syntax.COLON_CHAR + teilnehmer[i].Id);
                this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.MEMBER + Syntax.COLON_CHAR + (i+1));
            }

            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.MEMBERLIST);
            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + msgCount.ToString());

            msgCount++;
        }

        public void sendTeilnehmerKontostand(Teilnehmer t)
        {
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + msgCount);
            this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.BANK_BALANCE);
            this.sendMessageToClient(Syntax.MEMBER + Syntax.COLON_CHAR + t.Id); 
            this.sendMessageToClient(t.Kontostand.ToString());
            this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + msgCount);
            msgCount++;
        }
        
        // Methoden zum Senden von ProduktListe
        public void sendProductList(List<Produkt> produkte)
        {
           this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + msgCount.ToString());
           this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST);

           for (int i = 0; i < produkte.Count; i++)
           {
               this.sendMessageToClient(Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUKT + Syntax.COLON_CHAR + (i+1));
               this.sendMessageToClient(Syntax.PRODUKT_NAME + Syntax.COLON_CHAR + produkte[i].Name);
               this.sendMessageToClient(Syntax.PRODUKT_PRICE + Syntax.COLON_CHAR + produkte[i].Preis);
               this.sendMessageToClient(Syntax.PRODUKT_ID + Syntax.COLON_CHAR + produkte[i].Id);
               this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT + Syntax.COLON_CHAR + (i+1));
           }

           this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST);
           this.sendMessageToClient(Syntax.END + Syntax.COLON_CHAR + msgCount.ToString());

           msgCount++;
           
        }
    }

}
