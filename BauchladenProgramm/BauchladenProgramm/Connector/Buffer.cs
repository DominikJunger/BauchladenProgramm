using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BauchladenProgramm.Connector
{
    public class Buffer //is filled by the connector
    {
        private Ringbuffer buffer;  //sortedBuffer
        private List<String> uBuffer; //unsortedBufffer
        private Thread bufferThread;
        private Object msgCountLock; //lock for msgCount
        private int msgCount; 
       

        public Buffer(int size) {
            Contract.Requires(size > 0);
            
            this.msgCountLock = new Object();
            this.msgCount = 0;
            if (size > 0)
            {
                buffer = new Ringbuffer(size);
                uBuffer = new List<String>();
            }
            else 
            {
                throw new Exception("size<=0");   
            }
            this.bufferThread = new Thread(new ThreadStart(complete));
            this.bufferThread.Name = "BufferThread";
            this.bufferThread.Start();
        }

        public void append(String s)
        {
            //add a new message to the unsortedBuffer
            Contract.Requires(s != null);
            try
            {
                if (s != null) {
                    lock(uBuffer)
                    {
                        uBuffer.Add(s);
                    }
                    //if s contains end:x(x=int) msgCount is incremented
                    if (Regex.Match(s,Syntax.END + Syntax.COLON_CHAR + Syntax.INTEGER).Success) 
                    {
                        lock(this.msgCountLock)
                        {
                            this.msgCount++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public String giveParser()
        {   
            String message=null;
            try
            {
                if (buffer.getBufferCount() > 0)
                {
                    lock (buffer)
                    {
                        if (buffer.getMsgAtReadPointer() != null)
                        {
                            message = buffer.getMessage();
                            //Console.WriteLine(message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //send message to parser
            return message; //if the buffer is full or a message is finished reading, content is give to the parser
        }

        public bool isBufferFull()
        {
            return buffer.isFull();  
        }
        public bool isBufferEmpty()
        {
            return this.buffer.isBufferEmpty();
        }

        public void complete() //runs in a thread
        {
            String message = "";
            String messageNumber;
            bool isFull=false; // is sortedBuffer full

            try
            {
                while (true)
                {
                    lock(msgCountLock)
                    {
                        // if msgCount>0, complete message is moves from unsortedBuffer to sortedBuffer
                        // else Thread sleep for 100ms
                        if (this.msgCount>0) 
                        {
                            lock (this.uBuffer)
                            {
                                messageNumber = Regex.Match(this.uBuffer[0], Syntax.INTEGER).ToString();

                                if (Regex.Match(this.uBuffer[0], Syntax.BEGIN + Syntax.COLON_CHAR + messageNumber).Success)
                                {
                                    while (!(Regex.Match(message, Syntax.END + Syntax.COLON_CHAR + messageNumber).Success))
                                    {
                                        if (uBuffer.Count > 0)
                                        {
                                            message += this.uBuffer[0]; //complete the message
                                            this.uBuffer.RemoveAt(0);
                                        }
                                    }
                                    //if the buffer is full, the thread sleeps for 100ms
                                    do
                                    {
                                        lock (this.buffer)
                                        {
                                            if (!buffer.isFull())
                                            {
                                                message = Regex.Replace(message, Syntax.BEGIN + Syntax.COLON_CHAR + Syntax.INTEGER + "\n", "");
                                                message = Regex.Replace(message, Syntax.END + Syntax.COLON_CHAR + Syntax.INTEGER + "\n", "");
                                                buffer.addMessage(message); //add the complete message to sortedBuffer
                                                isFull = false;
                                            }
                                            else
                                            {
                                                isFull = true;
                                            }
                                        }
                                    } while (isFull);
                                    message = "";
                                    this.msgCount--;
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
