using System.Net;


namespace WinWire.App.Forms.CaptureInformation
{
    public class CaptureInfo
    {
        private IPAddress ip;
        private int numOfPackets;

        public CaptureInfo()
        {
            ip = null;
            numOfPackets = 0;
        }
        public CaptureInfo(IPAddress ip, int numOfPackets)
        {
            this.ip = ip;
            this.numOfPackets = numOfPackets;
        }
        public IPAddress IP { get { return ip; } }
        public int PacketsToCapture { get { return numOfPackets; } }
    }
}
