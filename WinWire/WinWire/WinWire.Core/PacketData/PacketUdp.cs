using System;
using System.IO;
using System.Net;


namespace WinWire.Core.PacketData
{
    public class PacketUdp
    {
        private ushort srcPort;
        private ushort destPort;
        private ushort length;
        private short checksum;
        private byte[] payload = new byte[65537];


        public PacketUdp(byte[] bBuffer, int lengthRecieved)
        {
            MemoryStream memoryStream = null;
            BinaryReader binaryReader = null;
            try
            {
                memoryStream = new MemoryStream(bBuffer, 0, lengthRecieved);
                binaryReader = new BinaryReader(memoryStream);
                srcPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                destPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                length = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                int headerLength = 8; 
                Array.Copy(bBuffer, headerLength, payload, 0, lengthRecieved - headerLength);
            }
            finally
            {
                binaryReader.Close();
                memoryStream.Close();
            }
        }

        #region Properties
        public string[] TreeViewData
        {
            get
            {
                string[] data = new string[2];
                data[0] = "Checksum: " + Checksum;
                data[1] = "Message lenght: " + MessageLength;
                return data;
            }
        }
        public string SourcePort { get { return srcPort.ToString(); } }
        public string DestinationPort { get { return destPort.ToString(); } }
        public string MessageLength { get { return length.ToString(); } }
        public string Checksum { get { return "0x" + checksum.ToString("x"); } }
        public byte[] Data { get { return payload; } }
        #endregion
    }
}
