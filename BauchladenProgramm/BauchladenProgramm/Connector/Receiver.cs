using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace BauchladenProgramm.Connector
{
    public class Receiver
    {
        private TcpClient client;
        private List<byte> data;
        private String rcvString="";
        private Buffer buffer;
        private const int sizeBuffer=100;
        private const int sizeByteTMP = 1;


        public Receiver(TcpClient client)
        {
            this.client=client;
            buffer = new Buffer(sizeBuffer);
        }

        public Buffer getBufferRef()
        {
            return this.buffer;
        }

        public void stopBuffer()
        {
            this.buffer.stopBuffer();
        }
        public void receive()      //to receive data via network
        {
            try{
                while(client.Connected)
                {
                    if (client.GetStream().DataAvailable)
                    {
                        data = new List<byte>();
                        //read byte by byte until rcvString contains "/n"
                        do
                        {
                            byte[] dataByte = new byte[sizeByteTMP];
                            client.GetStream().ReadAsync(dataByte, 0, sizeByteTMP);
                            data.Add(dataByte[0]);
                            rcvString = Encoding.UTF32.GetString(data.ToArray(), 0, data.Count);
                        } while (!(Regex.Match(rcvString, "\n").Success));

                        if (rcvString.Length > 0)
                        {
                            this.sendToBuffer(rcvString);
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void sendToBuffer(string msg)
        {
            Contract.Requires(msg != null);
            try{
                if (msg != null)
                {
                    buffer.append(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
