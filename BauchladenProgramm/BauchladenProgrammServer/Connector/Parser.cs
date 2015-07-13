using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using BauchladenProgrammServer.Backend_Klassen;
using BauchladenProgrammServer.Klassen;

namespace BauchladenProgrammServer.Connector
{
    public class Parser
    {
        private Buffer buffer;
        private Connector backend;
        private Thread parsThread;
        private SQL_Connector con = SQL_Connector.getInstance();

        public Parser(Buffer buffer, Connector backend)
        {
            Contract.Requires(buffer != null);
            Contract.Requires(backend != null);
            Contract.OldValue(this.buffer == null);
            Contract.OldValue(this.backend == null);

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
            Console.WriteLine(dataFromBuffer);
            Contract.Requires(dataFromBuffer != null);
            if (dataFromBuffer != null)
            {
                try
                {
                    if (Regex.Match(dataFromBuffer,Syntax.GET + Syntax.COLON_CHAR).Success)
                    {
                        dataFromBuffer=Regex.Replace(dataFromBuffer, Syntax.GET + Syntax.COLON_CHAR, "");
                        if (Regex.Match(dataFromBuffer, Syntax.PRODUCT_LIST).Success)
                        {
                            // hier kommt der methodenaufruf zum verschicken der produkte
                            //this.backend.sendProductList(con.selectProduktAll());
                            this.backend.sendProductList(null);
                        }

                        else if (Regex.Match(dataFromBuffer, Syntax.PRODUCT_LIST_BUECHERTISCH).Success)
                        {
                            // hier kommt der methodenaufruf zum verschicken der produkte vom Bueschertisch
                        }

                        else if (Regex.Match(dataFromBuffer, Syntax.MEMBERLIST).Success)
                        {
                            // hier kommt der methodenaufruf zum verschicken der TeilnehmerListe
                            this.backend.sendTeilnehmerList(null);
                        }

                        else if (Regex.Match(dataFromBuffer, Syntax.SEARCH + Syntax.COLON_CHAR).Success)
                        {
                            // hier kommt der sql befehlt zum suchen
                            int id = parsToInt32(dataFromBuffer);  
                            this.backend.sendTeilnehmerKontostand(id);
                        }
                        else
                        {
                            throw new Exception("Fehler: GET Befehl vom Client nicht Parsbar");
                        }
                    }
                    else if (Regex.Match(dataFromBuffer, Syntax.SET + Syntax.COLON_CHAR).Success)
                    {
                        Regex.Replace(dataFromBuffer, Syntax.SET + Syntax.COLON_CHAR, "");
                        if (Regex.Match(dataFromBuffer, Syntax.BUY + Syntax.COLON_CHAR).Success)
                        {
                            dataFromBuffer=Regex.Replace(dataFromBuffer, Syntax.BUY + Syntax.COLON_CHAR, "");
                            // hier kommt der sql befehlt zum setzen eines einkaufs
                        }
                        else
                        {
                            throw new Exception("Fehler: SET Befehl vom Client nicht Parsbar");
                        }
                    }
                    else
                    {
                        throw new Exception("Fehler: Befehl vom Client nicht Parsbar");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
