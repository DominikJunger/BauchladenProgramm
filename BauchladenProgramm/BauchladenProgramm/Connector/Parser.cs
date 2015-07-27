using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgramm.Connector
{
    public class Parser
    {
        private Buffer buffer;
        private Mainwindow backend;
        private Thread parsThread;

        public Parser(Buffer buffer, Mainwindow backend)
        {

            if(buffer!=null)
            {
                this.buffer=buffer;
            }
            if(backend!=null)
            {
                this.backend=backend;
            }
            this.parsThread = new Thread(new ThreadStart(takeFromBuffer));
            this.parsThread.Start();
        }

        public void stopParser()
        {
            this.parsThread.Abort();
        }

        private void takeFromBuffer()
        {
            if (buffer!=null)
            {
                while(true)
                {
                    determineParsMethod(buffer.giveParser());  //takes the information from buffer with the giveparser() method
                }
            }
        }
//---------------------------------------------------------

        public static String parsToString(String input)
        {
            return Regex.Match(input, Syntax.STRING).Value.Replace("\r", "");
        }

        public static Int32 parsToInt32(String input)
        {
            return Convert.ToInt32(Regex.Match(input, Syntax.INTEGER).Value);
        }

        public static bool parsToBoolean(String input)
        {
            return Convert.ToBoolean(Regex.Match(input, Syntax.BOOLEAN).Value);
        }

        public static long parsToLong(String input)
        {
            return Convert.ToInt64(Regex.Match(input, Syntax.LONG).Value);
        }

        public static MatchCollection parsMatchCollection(String input)
        {
            return Regex.Matches(input, Syntax.CUT);
        }

//---------------------------------------------------------
        
        private void determineParsMethod(String dataFromBuffer)
        {
            if (dataFromBuffer != null)
            {               
                Console.WriteLine(dataFromBuffer);
                try
                {
                    // ProduktListe oder ProduktListeBüchertisch-------------------
                    if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST).Success)
                    {
                        this.backend.leere_dataGridViewProdukt();
                        
                        dataFromBuffer=Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST+"\n", "");

                        MatchCollection pr = parsMatchCollection(dataFromBuffer);

                        Int32 messageNumber = 1;
                        int i = 0;
                        while (!(Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST).Success))
                        {
                            if (Regex.Match(pr[i].Value, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUKT + Syntax.COLON_CHAR + messageNumber.ToString()).Success)
                            {
                                int id = 0;
                                string name = null;
                                double preis = 0;
                                bool bücherT=false;

                                while (!(Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT + Syntax.COLON_CHAR + messageNumber.ToString()).Success))
                                {
                                    if (Regex.Match(pr[i].Value, Syntax.PRODUKT_NAME).Success)
                                    {
                                        name = parsToString(pr[i].Value);
                                    }
                                    if (Regex.Match(pr[i].Value, Syntax.PRODUKT_PRICE).Success)
                                    {
                                        String tmp=Regex.Replace(pr[i].Value, Syntax.PRODUKT_PRICE+ Syntax.COLON_CHAR, "");
                                        preis = Double.Parse(tmp);
                                    }
                                    if (Regex.Match(pr[i].Value, Syntax.PRODUKT_ID).Success)
                                    {
                                        id = parsToInt32(pr[i].Value);
                                    }
                                    if (Regex.Match(pr[i].Value, Syntax.PRODUKT_Bücher).Success)
                                    {
                                        bücherT = parsToBoolean(pr[i].Value);
                                    }
                                    i++;
                                }
                                if (Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT + Syntax.COLON_CHAR + messageNumber.ToString()).Success)
                                {
                                    this.backend.addPr(new Produkt(id, name, preis), bücherT);
                                    if (i < (pr.Count-1))
                                    {
                                        i++;
                                        messageNumber++;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Fehler beim Parsen der Produkte");
                            }
                        }
                    }
                    // TeilnehmerListe
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MEMBERLIST).Success)
                    {
                        this.backend.leere_dataGridViewTeilnehmer();

                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MEMBERLIST + "\n", "");

                        MatchCollection pr = parsMatchCollection(dataFromBuffer);

                        Int32 messageNumber = 1;
                        int i = 0;
                        while (!(Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.MEMBERLIST).Success))
                        {
                            if (Regex.Match(pr[i].Value, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MEMBER + Syntax.COLON_CHAR + messageNumber.ToString()).Success)
                            {
                                int id=0;
                                string vorname=null;
                                string nachname=null;

                                while (!(Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.MEMBER + Syntax.COLON_CHAR + messageNumber.ToString()).Success))
                                {
                                    
                                    if (Regex.Match(pr[i].Value, Syntax.FIRST_NAME).Success)
                                    {
                                        vorname = parsToString(pr[i].Value);
                                    }
                                    if (Regex.Match(pr[i].Value, Syntax.LAST_NAME).Success)
                                    {
                                        nachname = parsToString(pr[i].Value);
                                    }
                                    if (Regex.Match(pr[i].Value, Syntax.ID).Success)
                                    {
                                        id = parsToInt32(pr[i].Value);
                                    }
                                    i++;
                                }
                                if (Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.MEMBER + Syntax.COLON_CHAR + messageNumber.ToString()).Success)
                                {
                                    this.backend.addTn(new Teilnehmer(id,vorname,nachname));
                                    if (i < (pr.Count-1))
                                    {
                                        i++;
                                        messageNumber++;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Fehler beim Parsen der Teilnehmer");
                            }
                        }
                    }
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.BANK_BALANCE).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.BANK_BALANCE + "\n", "");
                        if (Regex.Match(dataFromBuffer, Syntax.MEMBER + Syntax.COLON_CHAR).Success)
                        {
                            dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.MEMBER + Syntax.COLON_CHAR + "\n", "");
                            string[] tmp = dataFromBuffer.Split('\n');
                            int id = parsToInt32(tmp[0]);
                            double kontostand = Double.Parse(tmp[1]);
                            this.backend.kontostandAnzeigen(id,kontostand);
                        }
                    }
                    else
                    {
                        throw new Exception("Fehler: Befehl vom Server nicht Parsbar");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
