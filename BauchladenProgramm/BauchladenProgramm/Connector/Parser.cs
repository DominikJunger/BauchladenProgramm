using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgramm.Connector
{
    public class Parser
    {
        private Buffer buffer;
        private Manager backend;
        private Thread parsThread;

        public Parser(Buffer buffer, Manager backend)
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

        public static String[] parsMatchPlayer(String input)
        {
            return Regex.Split(input, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER);
        }

        public static String[] parsMatchDragon(String input)
        {
            return Regex.Split(input, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DRAGON);
        }

        public static String[] parsMatchMapCell(String input)
        {
            return Regex.Split(input, Syntax.CUTCELL);
        }

        public static String[] parsMatchMapCells(String input)
        {
            return Regex.Split(input, Syntax.CUTCELLS);
        }

//---------------------------------------------------------
        
        private void determineParsMethod(String dataFromBuffer)
        {
            Contract.Requires(dataFromBuffer != null);
            if (dataFromBuffer != null)
            {
                try
                {
                    //Check if this is an update
                    if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        dataFromBuffer= Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.UPDATE + "\r\n", "");
                        //update(dataFromBuffer);
                    }
                    //Check if this is a delete
                    else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DELETE)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.DELETE + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.DELETE + "\r\n", "");
                        //delete(dataFromBuffer);
                    }

                    //recieves entities
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ENTITIES).Success &&
                        !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ENTITIES + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.ENTITIES + "\r\n", "");
                        //this.EntityList(dataFromBuffer);
                    }

                    //receives players
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYERS).Success &&
                        !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYERS + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.PLAYERS + "\r\n", "");
                        //this.createPlayers(dataFromBuffer);
                    }

                    //recieves a player
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER).Success &&
                        !(Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.UPDATE)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.PLAYER + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.PLAYER + "\r\n", "");
                        //this.createPlayer(dataFromBuffer);
                    }

                    //recieves a map
                    else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MAP)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MAP + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.MAP + "\r\n", "");
                        //this.createMap(dataFromBuffer);
                    }

                    //check if this is a message
                    else if ((Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MESSAGE)).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.MESSAGE + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.MESSAGE + "\r\n", "");
                        //this.createMessage(dataFromBuffer);
                    }

                    //Time - Info
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.TIME).Success)
                    {
                        //this.createTimeInfo(dataFromBuffer);
                    }

                    //Online - Info
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.ONLINE).Success)
                    {
                        //this.createOnlineInfo(dataFromBuffer);
                    }
                    //YourID - Info
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.YOURID).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.YOURID + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.YOURID + "\r\n", "");
                        //this.createYourID(dataFromBuffer);
                    }
                    //recieves Challenge
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CHALLENGE).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.CHALLENGE + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.CHALLENGE + "\r\n", "");
                        //this.createChallenge(dataFromBuffer);
                    }
                    //recieves Opponent
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.OPPONENT).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.OPPONENT + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.OPPONENT + "\r\n", "");
                        //this.createOpponent(dataFromBuffer);
                    }

                    //Check if this is a answer from server
                    else if (Regex.Match(dataFromBuffer, Syntax.ANSWER + Syntax.COLON_CHAR).Success)
                    {
                        //createAnswer(dataFromBuffer);
                    }
                    //Check if this is a game info
                    else if (Regex.Match(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.RESULT).Success)
                    {
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.RESULT + "\r\n", "");
                        dataFromBuffer = Regex.Replace(dataFromBuffer, Syntax.END + Syntax.COLON_CHAR + Syntax.RESULT + "\r\n", "");
                        //createResult(dataFromBuffer);
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
