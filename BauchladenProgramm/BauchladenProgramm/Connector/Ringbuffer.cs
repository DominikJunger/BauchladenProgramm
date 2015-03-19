using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgramm.Connector
{
    class Ringbuffer
    {
        private String[] memory = null;
        private int readPointer=0;
        private int writePointer=0;


        public Ringbuffer(int size){
            if (size > 0)
            {  
                memory = new String[size];
            }
        }

        public void incReadPointer() {
            if (readPointer < this.memory.Length-1){
                this.readPointer++;
            }
            else {
                this.readPointer = 0;
            }
        }

        public void incWritePointer()
        {
            if (writePointer < this.memory.Length-1)
            {
                this.writePointer++;
            }
            else
            {
                this.writePointer = 0;
            }
        }

        public bool isFull() {
            bool full=false;
            int count = 0;
                for (int i = 0; i < memory.Length; i++)
                {
                    if (memory[i] != null)
                    {
                        count++;
                    }
                }
                if (count == memory.Length)
                {
                    full = true;
                }
                else
                {
                    full = false;
                }
            return full;
        }

        public void addMessage(String message){
            if (message != null)
            {
                if (this.memory[this.writePointer] == null)
                {
                    memory[this.writePointer] = message;
                    this.incWritePointer();
                }
            }
        }

        public String getMessage() {
            if (this.memory[this.readPointer] == null)
            {
                throw new Exception("Feld leer");
            }
            String s = this.memory[this.readPointer];
            this.memory[this.readPointer] = null;
            this.incReadPointer();
            return s;
        }

        public String getMsgAtReadPointer() {
            String s = this.memory[this.readPointer];
            return s;
        }

        public bool isBufferEmpty()
        {
            bool r;
            if (this.memory.Count() == 0)
            {
                r= true;
            }
            else
            {
                r = false; ;
            }
            return r;
        }
        public int getBufferCount()
        {
            return memory.Length;
        }

    }

    
}
