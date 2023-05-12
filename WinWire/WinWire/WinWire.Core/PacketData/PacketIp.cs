using System;
using System.IO;
using System.Net;


namespace WinWire.Core.PacketData
{
    public class PacketIp
    {
        private byte versionAndHeader;
        private byte typeOfService;
        private ushort totaLenght;
        private ushort id;
        private ushort flagsAndOffset;
        private byte ttl;
        private byte protocol;
        private short checksum;
        private uint srcIp;
        private uint destIp;
        private byte[] payload = new byte[65537];
        private byte headerLength;


        public PacketIp(byte[] bBuffer, int lengthRecieved)
        {
            MemoryStream memoryStream = null;
            BinaryReader binaryReader = null;
            try
            {
                memoryStream = new MemoryStream(bBuffer, 0, lengthRecieved);
                binaryReader = new BinaryReader(memoryStream);

                versionAndHeader = binaryReader.ReadByte();
                typeOfService = binaryReader.ReadByte();
                totaLenght = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                id = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                flagsAndOffset = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                ttl = binaryReader.ReadByte();
                protocol = binaryReader.ReadByte();
                checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());
                srcIp = (uint)(binaryReader.ReadInt32());
                destIp = (uint)(binaryReader.ReadInt32());

                headerLength = versionAndHeader;
                headerLength <<= 4;
                headerLength >>= 4;
                headerLength *= 4;

                Array.Copy(bBuffer, headerLength, payload, 0, totaLenght - headerLength);
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
                string[] data = new string[9];
                data[0] = "Protocol version: " + Version;
                data[1] = "Header lenght: " + HeaderLength;
                data[2] = "Type ofservice: " + TypeOfService;
                data[3] = "Total lenght: " + TotalLength;
                data[4] = "Identification No: " + ID;
                data[5] = "Flags: " + Flags;
                data[6] = "Fragmentation offset: " + FragmentationOffset;
                data[7] = "TTL: " + TTL;
                data[8] = "Checksum: " + Checksum;
                return data;
            }
        }
        public string Version
        {
            get
            {
                if ((versionAndHeader >> 4) == 4) return "IPv4";
                else if ((versionAndHeader >> 4) == 6) return "IPv6";
                else return "Unknown";
            }
        }
        public string HeaderLength { get { return headerLength.ToString(); } }
        public ushort MessageLength { get { return (ushort)(totaLenght - headerLength); } }
        public string TypeOfService { get { return string.Format("0x{0:x2} ({1})", typeOfService, typeOfService); } }
        public string Flags
        {
            get
            {
                if (flagsAndOffset >> 13 == 2) return "Not fragmented";
                else if (flagsAndOffset >> 13 == 1) return "Fragmented";
                else return (flagsAndOffset >> 13).ToString();
            }
        }
        public string FragmentationOffset
        {
            get
            {
                int iOffset = flagsAndOffset << 3;
                iOffset >>= 3;
                return iOffset.ToString();
            }
        }
        public string TTL { get { return ttl.ToString(); } }
        public string Protocol
        {
            get
            {
                if (protocol == 6) return "TCP";
                else if (protocol == 17) return "UDP";
                else if (protocol == 1) return "ICMP";
                else if (protocol == 2) return "IGMP";
                else return "Unknown";
            }
        }
        public string Checksum { get { return "0x" + checksum.ToString("x"); } }
        public IPAddress SourceAddress { get { return new IPAddress(srcIp); } }
        public IPAddress DestinationAddress { get { return new IPAddress(destIp); } }
        public string TotalLength { get { return totaLenght.ToString(); } }
        public string ID { get { return id.ToString(); } }
        public byte[] Payload { get { return payload; } }
        #endregion
    }
}
