using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace BauchladenProgramm.Connector
{
    public class Parser
    {
        private Buffer buffer;
        private Connector backend;
        private Thread parsThread;

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
            Contract.Requires(dataFromBuffer != null);
            if (dataFromBuffer != null)
            {
                Console.WriteLine(dataFromBuffer);
                try
                {
                    if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST).Success)
                    {
                        dataFromBuffer=Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST+"\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUCT_LIST + "\n", "");
                        
                        MatchCollection pr = Parser.parsMatchCollection(dataFromBuffer);

                        while(pr.Count > 0)
                        {
                            int i = 0;
                            if (Regex.Match(pr[i].Value, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PRODUKT).Success)
                            {
                                while (!(Regex.Match(pr[i].Value, Syntax.END + Syntax.COLON_CHAR + Syntax.PRODUKT).Success))
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                throw new Exception("Fehler beim Parsen");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fehler: Befehl vom Server nicht Parsbar");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(buffer != null);
            Contract.Invariant(backend != null);
        }
    }
}
