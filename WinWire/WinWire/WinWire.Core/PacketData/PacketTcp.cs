using System;
using System.IO;
using System.Net;

namespace WinWire.Core.PacketData
{
    public class PacketTcp
    {
        private ushort srcPort;
        private ushort destPort;
        private uint sequenceNumber;
        private uint acknowledgementNumber;
        private ushort dataOffsetAndFlags;
        private ushort windowSize;
        private short checksum;
        private ushort urgentPointer;
        private byte headerLength;
        private ushort messageLength;
        private byte[] payload = new byte[65537];


        public PacketTcp(byte[] bBuffer, int iReceived)
        {
            MemoryStream memoryStream = null;
            BinaryReader binaryReader = null;
            try
            {
                memoryStream = new MemoryStream(bBuffer, 0, iReceived);
                binaryReader = new BinaryReader(memoryStream);
                srcPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                destPort = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                sequenceNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
                acknowledgementNumber = (uint)IPAddress.NetworkToHostOrder(binaryReader.ReadInt32());
                dataOffsetAndFlags = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                windowSize = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                checksum = (short)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                urgentPointer = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                headerLength = (byte)(dataOffsetAndFlags >> 12);
                headerLength *= 4;
                messageLength = (ushort)(iReceived - headerLength);

                Array.Copy(bBuffer, headerLength, payload, 0, iReceived - headerLength);
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
                data[0] = "Sequence NO: " + SequenceNumber;
                data[1] = "Acknowledgement NO: " + AcknowledgementNumber;
                data[2] = "Header lenght: " + HeaderLength;
                data[3] = "Window size: " + WindowSize;
                data[4] = "Urgent Pointer: " + UrgentPointer;
                data[5] = "Flags: " + Flags;
                data[6] = "Checksum: " + Checksum;
                data[7] = "Message lenght: " + MessageLength;
                return data;
            }
        }
        public string SourcePort { get { return srcPort.ToString(); } }
        public string DestinationPort { get { return destPort.ToString(); } }
        public string SequenceNumber { get { return sequenceNumber.ToString(); } }
        public string AcknowledgementNumber
        {
            get
            {
                if ((dataOffsetAndFlags & 0x10) != 0)
                    return acknowledgementNumber.ToString();
                else
                    return "";
            }
        }
        public string HeaderLength { get { return headerLength.ToString(); } }
        public string WindowSize { get { return windowSize.ToString(); } }
        public string UrgentPointer
        {
            get
            {
                if ((dataOffsetAndFlags & 0x20) != 0)
                    return urgentPointer.ToString();
                else
                    return "";
            }
        }
        public string Flags
        {
            get
            {
                int iFlags = dataOffsetAndFlags & 0x3F;
                string strFlags = string.Format("0x{0:x2} ", iFlags);
                if ((iFlags & 0x01) != 0)
                    strFlags += "FIN  ";
                if ((iFlags & 0x02) != 0)
                    strFlags += "SYN  ";
                if ((iFlags & 0x04) != 0)
                    strFlags += "RST  ";
                if ((iFlags & 0x08) != 0)
                    strFlags += "PSH  ";
                if ((iFlags & 0x10) != 0)
                    strFlags += "ACK  ";
                if ((iFlags & 0x20) != 0)
                    strFlags += "URG ";
                if (strFlags.Contains("()"))
                    strFlags = strFlags.Remove(strFlags.Length - 3);
                else if (strFlags.Contains(", )"))
                    strFlags = strFlags.Remove(strFlags.Length - 3, 2);
                return strFlags;
            }
        }
        public string Checksum { get { return "0x" + checksum.ToString("x"); } }
        public byte[] Data { get { return payload; } }
        public string MessageLength { get { return messageLength.ToString(); } }
        #endregion
    }
}
