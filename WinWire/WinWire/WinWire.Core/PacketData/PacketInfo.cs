namespace WinWire.Core.PacketData
{
    public class PacketInfo
    {
        private PacketIp ip;
        private PacketTcp tcp;
        private PacketUdp udp;
        private PacketIcmp icmp;
        private PacketIgmp igmp;

        public PacketInfo()
        {
        }
        public PacketInfo(PacketIp ip)
        {
            this.ip = ip;
        }

        public PacketInfo(PacketIp ip, PacketTcp tcp)
        {
            this.ip = ip;
            this.tcp = tcp;
        }
        public PacketInfo(PacketIp ip, PacketUdp udp)
        {
            this.ip = ip;
            this.udp = udp;
        }
        public PacketInfo(PacketIp ip, PacketIcmp icmp)
        {
            this.ip = ip;
            this.icmp = icmp;
        }
        public PacketInfo(PacketIp ip, PacketIgmp igmp)
        {
            this.ip = ip;
            this.igmp = igmp;
        }

        #region Properties
        public PacketIp IP { get { return ip; } }
        public PacketTcp TCP { get { return tcp; } }
        public PacketUdp UDP { get { return udp; } }
        public PacketIcmp ICMP { get { return icmp; } }
        public PacketIgmp IGMP { get { return igmp; } }
        #endregion
    }
}
