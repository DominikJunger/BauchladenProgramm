using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace BauchladenProgramm.Connector
{
    class Sender        // the class to send data via network to the server
    {

        TcpClient client;
        byte[] data;


        public Sender(TcpClient client)
        {
            this.client = client;
        }

        public void sendMessage(String message)          //send a message to the Server 
        {
            try
            {
                if (message != null)
                {
                    // Translate the passed message and store it as a Byte array.
                    this.data = System.Text.Encoding.UTF32.GetBytes(message + "\n");
                    client.GetStream().Write(data, 0, data.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}