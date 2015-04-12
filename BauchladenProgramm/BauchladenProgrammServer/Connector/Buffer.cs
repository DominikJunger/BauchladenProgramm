using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Connector
{
    public class Buffer //is filled by the connector
    {
        private List<String> uBuffer; //unsortedBufffer
        private Object msgCountLock; //lock for msgCount
        private int msgCount; 
       

        public Buffer(int size) {
            Contract.Requires(size > 0);
            
            this.msgCountLock = new Object();
            this.msgCount = 0;
            if (size > 0)
            {
                uBuffer = new List<String>();
            }
            else 
            {
                throw new Exception("size<=0");   
            }
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
                        this.msgCount++;
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
                if (uBuffer.Count() > 0)
                {
                    lock (uBuffer)
                    {
                        message = uBuffer.First();
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
    }
}
