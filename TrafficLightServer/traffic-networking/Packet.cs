using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_networking
{
    public class Packet
    {
        public int ID { get; private set; }

        private byte[] buffer;
        private MemoryStream stream;

        private BinaryReader br;
        private BinaryWriter bw;

        private bool reading;

        /// <summary>
        /// Used for reading a buffer
        /// </summary>
        /// <param name="buffer"></param>
        public Packet(byte[] buffer) //Read
        {
            this.reading = true;

            this.buffer = new byte[buffer.Length];
            buffer.CopyTo(this.buffer, 0);

            this.stream = new MemoryStream(this.buffer);
            this.br = new BinaryReader(this.stream);
            this.ID = this.br.ReadInt32();
        }

        /// <summary>
        /// Used for writing a packet
        /// </summary>
        /// <param name="id"></param>
        public Packet(int id) //Write
        {
            this.reading = false;
            this.stream = new MemoryStream();
            this.bw = new BinaryWriter(this.stream);
            this.ID = id;
        }

        /// <summary>
        /// Outputs a byte array formatted for a packet
        /// </summary>
        /// <returns></returns>
        public byte[] FormatBytes()
        {
            byte[] bytes = this.GetBytes();
            this.bw.Write(bytes.Length + 4);
            this.bw.Write(this.ID);
            this.bw.Write(bytes);

            return this.stream.ToArray();
        }

        /// <summary>
        /// Read an integer from the buffer
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            if (this.reading)
                return this.br.ReadInt32();
            else
                throwException();

            return 0;
        }

        /// <summary>
        /// Reads a string from the buffer
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            if (this.reading)
                return this.br.ReadString();
            else
                throwException();

            return null;
        }

        /// <summary>
        /// Returns the current stream
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return this.stream.ToArray();
        }

        /// <summary>
        /// Writes an int to the buffer
        /// </summary>
        /// <param name="num"></param>
        public void WriteInt(int num)
        {
            if (!this.reading)
                this.bw.Write(num);
            else
                throwException();
        }

        /// <summary>
        /// Writes a string to the buffer
        /// </summary>
        /// <param name="str"></param>
        public void WriteString(string str)
        {
            if (!this.reading)
                this.bw.Write(str);
            else
                throwException();
        }

        /// <summary>
        /// Throws an exception for incorrect usage
        /// </summary>
        private void throwException()
        {
            if (!reading)
                throw new Exception("Shouldn't be reading...");
            else
                throw new Exception("Shouldn't be writing...");
        }
    }
}
