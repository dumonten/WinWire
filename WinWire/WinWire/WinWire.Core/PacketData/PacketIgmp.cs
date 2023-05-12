using System.IO;
using System.Net;


namespace WinWire.Core.PacketData
{
    public class PacketIgmp
    {
        private byte type;
        private short maxResponseTime;
        private short checksum;
        private int groupAddress;


        public PacketIgmp(byte[] bBuffer, int lengthRecieved)
        {
            MemoryStream memoryStream = null;
            BinaryReader binaryReader = null;
            try
            {
                memoryStream = new MemoryStream(bBuffer, 0, lengthRecieved);
                binaryReader = new BinaryReader(memoryStream);

                type = binaryReader.ReadByte();
                maxResponseTime = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                groupAddress = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
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
                string[] data = new string[8];
                data[0] = "Type: " + Type;
                data[1] = "Max response time: " + MaxResponseTime;
                data[2] = "Checksum: " + Checksum;
                data[3] = "Group address: " + GroupAddress;
                return data;
            }
        }
        public string Type { get { return type.ToString(); } }
        public string MaxResponseTime { get { return maxResponseTime.ToString(); } }
        public string Checksum { get { return "0x" + checksum.ToString("X"); } }
        public string GroupAddress { get { return groupAddress.ToString(); } }
        #endregion   
    }
}
