using System.IO;
using System.Net;


namespace WinWire.Core.PacketData
{
    public class PacketIcmp
    {
        private byte type;
        private byte code;
        private short checksum;
        private ushort id;
        private ushort sequenceNumber;
        private int addressMask;


        public PacketIcmp(byte[] bBuffer, int lengthReceived)
        {
            MemoryStream memoryStream = null;
            BinaryReader binaryReader = null;
            try
            {
                memoryStream = new MemoryStream(bBuffer, 0, lengthReceived);
                binaryReader = new BinaryReader(memoryStream);

                type = binaryReader.ReadByte();
                code = binaryReader.ReadByte();
                checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                id = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                sequenceNumber = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                addressMask = IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
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
                string[] data = new string[6];
                data[0] = "Type No: " + Type;
                data[1] = "Code No: " + Code;
                data[2] = "Checksum: " + Checksum;
                data[3] = "Identifier: " + ID;
                data[4] = "Sequence number: " + SequenceNumber;
                data[5] = "Address mask: " + AddressMask;
                return data;
            }
        }
        public string Type { get { return type.ToString(); } }
        public string Code { get { return code.ToString(); } }
        public string Checksum { get { return "0x" + checksum.ToString("X"); } }
        public string ID { get { return id.ToString(); } }
        public string SequenceNumber { get { return sequenceNumber.ToString(); } }
        public string AddressMask { get { return "0x" + addressMask.ToString("X"); } }
        #endregion
    }
}
