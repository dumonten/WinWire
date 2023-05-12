using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinWire.App.Forms.CaptureInformation;
using WinWire.App.Forms.Main.Interface;
using WinWire.Core.PacketData;


namespace WinWire.App.Forms.Main.Logic
{
    public class FrmAnalyzerLogic
    {
        Socket socket;
        private IPAddress ip;
        byte[] binaryIn = new byte[4] { 1, 0, 0, 0 };
        byte[] binaryOut = new byte[4];

        byte[] bBuffer = new byte[65537];
        BerkeleyPacketFilter filter;
        bool filterIsApplied = false;

        public CaptureInfo Info { get; set; }

        Thread threadStartCapturing = null;
        Thread threadPacketSector = null;
        bool stopCapturing = false;

        Dictionary<string, PacketInfo> packageBuffer = null;
        decimal nTotalPackages;

        public struct ListViewItemData
        {
            public string no;
            public string time;
            public string srcIp;
            public string srcPort;
            public string destIp;
            public string destPort;
            public string protocol;
            public string packageSize;
            public string key;
        }
        private IFrmAnalyzer view;

        public delegate void EventAddToList(ListViewItem item);
        public delegate void EventRemoveFromList();
        public delegate void EventDeleteAll();
        public event EventAddToList AddToList;
        public event EventRemoveFromList RemoveFromList;
        public event EventDeleteAll DeleteAll;


        public FrmAnalyzerLogic(IFrmAnalyzer view) => this.view = view;
        public void ApplicationStarted()
        {
            view.ButtonStopEnabled = false;
            AddToList += OnAddToList;
            RemoveFromList += OnRemoveFromList;
            DeleteAll += OnDeleteAll;
        }
        private void StartCapturing()
        {
            view.ProgressBufferUsage.Maximum = Info.PacketsToCapture;
            view.ProgressBufferUsage.Minimum = 0;
            try
            {
                socket = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                socket.Bind(new IPEndPoint(Info.IP, 0));
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
                socket.IOControl(IOControlCode.ReceiveAll, binaryIn, binaryOut);

                threadStartCapturing = new Thread(StartReceiving);
                threadStartCapturing.IsBackground = true;
                threadStartCapturing.Name = "Capture Thread";
                threadStartCapturing.Start();
            }
            catch (Exception ex)
            {
                view.ShowDefaultErrorMessage(ex);
                view.ButtonStartEnabled = true;
                view.ButtonStopEnabled = false;
            }

        }
        private void StartReceiving()
        {
            while (!stopCapturing)
            {
                int bytesReceived = socket.Receive(bBuffer, 0, bBuffer.Length, SocketFlags.None);
                if (bytesReceived > 0)
                {
                    nTotalPackages++;
                    ConvertReceivedData(bBuffer, bytesReceived);
                }
                Array.Clear(bBuffer, 0, bBuffer.Length);
            }
        }

        #region TableAndTreeInitialization
        public void ConvertReceivedData(byte[] bBuffer, int lengthRecieved)
        {
            view.Invoke(() => view.SetTotalPacketReceivedText(nTotalPackages.ToString()));
            bool isCorrectForBpf = false;
            if (view.Bpf.Length == 0)
            {
                isCorrectForBpf = true;
                filterIsApplied = false;
            }
            if (filterIsApplied || view.ButtonBpfClicked)
            {
                if (view.ButtonBpfClicked)
                {
                    filter = new BerkeleyPacketFilter(view.Bpf, lengthRecieved, PcapDotNet.Packets.DataLinkKind.IpV4);
                    view.Invoke(() => packageBuffer.Clear());
                    view.ListReceivedPackets.Invoke(DeleteAll);
                    filterIsApplied = true;
                    view.ButtonBpfClicked = false;
                }
                PcapDotNet.Packets.Packet packet = new PcapDotNet.Packets.Packet(bBuffer, DateTime.Now, PcapDotNet.Packets.DataLinkKind.IpV4);
                if (filter.Test(packet)) isCorrectForBpf = true;
            }
            else isCorrectForBpf = true;

            string key = nTotalPackages.ToString();

            PacketIp ipPacket = new PacketIp(bBuffer, lengthRecieved);
            PacketInfo pkgInfo = null;

            ListViewItemData itemData = new ListViewItemData
            {
                no = key,
                time = DateTime.Now.ToString("HH:mm:ss:") + DateTime.Now.Millisecond.ToString(),
                srcIp = ipPacket.SourceAddress.ToString(),
                destIp = ipPacket.DestinationAddress.ToString(),
                protocol = ipPacket.Protocol,
                packageSize = ipPacket.TotalLength,
                key = key
            };

            switch (ipPacket.Protocol)
            {
                case "TCP":
                    {
                        PacketTcp tcpPacket = new PacketTcp(ipPacket.Payload, ipPacket.MessageLength);
                        pkgInfo = new PacketInfo(ipPacket, tcpPacket);
                        itemData.destPort = tcpPacket.DestinationPort;
                        itemData.srcPort = tcpPacket.SourcePort;
                    }
                    break;
                case "UDP":
                    {
                        PacketUdp udpPacket = new PacketUdp(ipPacket.Payload, ipPacket.MessageLength);
                        pkgInfo = new PacketInfo(ipPacket, udpPacket);
                        itemData.destPort = udpPacket.DestinationPort;
                        itemData.srcPort = udpPacket.SourcePort;
                    }
                    break;
                case "ICMP":
                    {
                        PacketIcmp icmpPacket = new PacketIcmp(ipPacket.Payload, ipPacket.MessageLength);
                        pkgInfo = new PacketInfo(ipPacket, icmpPacket);
                        itemData.destPort = "0";
                        itemData.srcPort = "0";
                    }
                    break;
                case "IGMP":
                    {
                        PacketIgmp igmpPacket = new PacketIgmp(ipPacket.Payload, ipPacket.MessageLength);
                        pkgInfo = new PacketInfo(ipPacket, igmpPacket);
                        itemData.destPort = "0";
                        itemData.srcPort = "0";
                    }
                    break;
                case "Unknown":
                    {
                        pkgInfo = new PacketInfo(ipPacket);
                        packageBuffer.Add(key, pkgInfo);
                        itemData.destPort = "0";
                        itemData.srcPort = "0";
                    }
                    break;
            }
            if (isCorrectForBpf)
            {
                ListViewItem item = GetItem(itemData);
                if (packageBuffer.Count == Info.PacketsToCapture)
                {
                    view.Invoke(() => packageBuffer.Remove(view.ListReceivedPackets.Items[0].SubItems[8].Text));
                    view.ListReceivedPackets.Invoke(RemoveFromList);
                }
                packageBuffer.Add(key, pkgInfo);
                view.ListReceivedPackets.Invoke(AddToList, new object[] { item });

                view.Invoke(() => view.ProgressBufferUsage.Value = packageBuffer.Count);
                view.Invoke(() => view.SetBufferUsage(packageBuffer.Count.ToString()));
            }
        }
        public ListViewItem GetItem(ListViewItemData data)
        {
            ListViewItem item = new ListViewItem(data.no);
            item.SubItems.Add(data.time);
            item.SubItems.Add(data.srcIp);
            item.SubItems.Add(data.srcPort);
            item.SubItems.Add(data.destIp);
            item.SubItems.Add(data.destPort);
            item.SubItems.Add(data.protocol);
            item.SubItems.Add(data.packageSize);
            item.SubItems.Add(data.key);
            return item;
        }
        
        
        public void CreateDetailedTree()
        {
            ListView.SelectedIndexCollection indexCollection = view.ListReceivedPackets.SelectedIndices;
            if (indexCollection.Count > 0)
            {
                int index = indexCollection[0];
                string strKey = view.ListReceivedPackets.Items[index].SubItems[0].Text;

                PacketInfo pkgInfo = new PacketInfo();
                if (packageBuffer.TryGetValue(strKey, out pkgInfo))
                {
                    view.TreePackedDetails.Nodes.Clear();

                    #region FillPacketInformatonSector 
                    view.PacketByteRepresentation.Clear();
                    view.PacketCharRepresentation.Clear();
                    view.PacketChunkNum.Clear();
                    if (view.ShowPacketPacketData)
                    {
                        if (threadPacketSector != null && threadPacketSector.IsAlive) threadPacketSector.Abort();
                        threadPacketSector = new Thread(FillPacketInformatonSector);
                        threadPacketSector.IsBackground = true;
                        threadPacketSector.Name = "Fill Packet Informaton Sector Thread";
                        threadPacketSector.Start(pkgInfo);
                    }
                    #endregion

                    TreeNode node = GetNode("IP", pkgInfo.IP.TreeViewData);
                    node.ForeColor = Color.Green;
                    switch (pkgInfo.IP.Protocol)
                    {
                        case "TCP":
                            {
                                node.Nodes.Add(String.Format("Source address: {0}:{1}", pkgInfo.IP.SourceAddress, pkgInfo.TCP.SourcePort));
                                node.Nodes.Add(String.Format("Destination address: {0}:{1}", pkgInfo.IP.DestinationAddress, pkgInfo.TCP.DestinationPort));

                                TreeNode subNode = GetNode("TCP", pkgInfo.TCP.TreeViewData);
                                subNode.ForeColor = Color.Red;
                                node.Nodes.Add(subNode);
                            }
                            break;
                        case "UDP":
                            {
                                node.Nodes.Add(String.Format("Source address: {0}:{1}", pkgInfo.IP.SourceAddress, pkgInfo.UDP.SourcePort));
                                node.Nodes.Add(String.Format("Destination address: {0}:{1}", pkgInfo.IP.DestinationAddress, pkgInfo.UDP.DestinationPort));

                                TreeNode subNode = GetNode("UDP", pkgInfo.UDP.TreeViewData);
                                subNode.ForeColor = Color.Blue;
                                node.Nodes.Add(subNode);
                            }
                            break;
                        case "ICMP":
                            {

                                node.Nodes.Add("Source address: " + pkgInfo.IP.SourceAddress.ToString());
                                node.Nodes.Add("Destination address: " + pkgInfo.IP.DestinationAddress.ToString());

                                TreeNode subNode = GetNode("ICMP", pkgInfo.ICMP.TreeViewData);
                                subNode.ForeColor = Color.Violet;
                                node.Nodes.Add(subNode);
                            }
                            break;
                        case "IGMP":
                            {

                                node.Nodes.Add("Source address: " + pkgInfo.IP.SourceAddress.ToString());
                                node.Nodes.Add("Destination address: " + pkgInfo.IP.DestinationAddress.ToString());

                                TreeNode subNode = GetNode("IGMP", pkgInfo.IGMP.TreeViewData);
                                subNode.ForeColor = Color.DarkSeaGreen;
                                node.Nodes.Add(subNode);
                            }
                            break;
                    }
                    view.TreePackedDetails.Nodes.Add(node);
                    view.TreePackedDetails.ExpandAll();
                }
            }
        }
        public void FillPacketInformatonSector(object o)
        {
            PacketInfo pkgInfo = (PacketInfo)o;
            int messageLength = Int32.Parse(pkgInfo.IP.TotalLength);
            int numOfLines = messageLength % 16 == 0 ? messageLength / 16 : messageLength / 16 + 1;
            for (int line = 0; line < numOfLines - 1; line++)
                view.PacketChunkNum.AppendText((string.Format("{0,4}", (16 * line).ToString("X")).Replace(" ", "0") + "\r\n"));
            view.PacketChunkNum.AppendText((string.Format("{0,4}", (16 * (numOfLines - 1)).ToString("X")).Replace(" ", "0")));

            char[] chars = Encoding.ASCII.GetChars(pkgInfo.IP.Payload);
            byte[] bytes = pkgInfo.IP.Payload;
            for (int i = 1, n = messageLength; i <= n; i++)
            {
                view.PacketByteRepresentation.AppendText(string.Format("{0,-4}", bytes[i - 1].ToString("X")));
                if ((bytes[i - 1] >= 0 && bytes[i - 1] <= 31) || bytes[i - 1] == 127)
                    view.PacketCharRepresentation.AppendText(string.Format("{0,-4}", "."));
                else
                    view.PacketCharRepresentation.AppendText(string.Format("{0,-4}", chars[i - 1].ToString()));

                if (i != 0 && i % 16 == 0)
                {
                    view.PacketByteRepresentation.AppendText("\r\n");
                    view.PacketCharRepresentation.AppendText("\r\n");
                }
                if (i % 16 == 8)
                {
                    view.PacketByteRepresentation.AppendText("  ");
                    view.PacketCharRepresentation.AppendText("  ");
                }
            }
        }
        public TreeNode GetNode(string name, string[] data)
        {
            TreeNode node = new TreeNode(name);
            foreach (string s in data)
                node.Nodes.Add(s);
            return node;
        }
        #endregion

        #region ClickHandlers
        public void StartClicked()
        {
            Info = new CaptureInfo();
            using (FrmCaptureInfo startWindow = new FrmCaptureInfo(view))
            {
                startWindow.ShowDialog();
                if (Info != null && Info.PacketsToCapture > 0)
                {
                    packageBuffer = new Dictionary<string, PacketInfo>();
                    nTotalPackages = 0;
                    ip = Info.IP;
                    ClearAllFields();
                    stopCapturing = false;
                    view.ButtonStopEnabled = true;
                    view.ButtonStartEnabled = false;
                    view.SetReadyText("Running...");

                    StartCapturing();
                }
            }
        }
        public void StopClicked()
        {
            stopCapturing = true;

            view.ButtonStopEnabled = false;
            view.ButtonStartEnabled = true;
            view.SetReadyText("Stopped");
            nTotalPackages = 0;

            if (threadStartCapturing != null && threadStartCapturing.IsAlive) threadStartCapturing.Abort();
            if (threadPacketSector != null && threadPacketSector.IsAlive) threadPacketSector.Abort();

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        #endregion

        #region DelegateFunctions
        public void OnAddToList(ListViewItem item) => view.ListReceivedPackets.Items.Add(item);
        public void OnRemoveFromList() { if (view.ListReceivedPackets.Items[0] != null) view.ListReceivedPackets.Items.Remove(view.ListReceivedPackets.Items[0]); }
        public void OnDeleteAll() { if (view.ListReceivedPackets.Items.Count > 0) view.ListReceivedPackets.Items.Clear(); }
        #endregion

        public void ClearAllFields()
        {
            if (view.ListReceivedPackets.Items.Count > 0) view.ListReceivedPackets.Items.Clear();
            if (view.TreePackedDetails.Nodes.Count > 0) view.TreePackedDetails.Nodes.Clear();

            if (view.PacketByteRepresentation.Text.Length != 0) view.PacketByteRepresentation.Clear();
            if (view.PacketCharRepresentation.Text.Length != 0) view.PacketCharRepresentation.Clear();
            if (view.PacketChunkNum.Text.Length != 0) view.PacketChunkNum.Clear();


            if (packageBuffer.Count > 0)
            {
                packageBuffer.Clear();
                view.ProgressBufferUsage.Value = 0;
                view.Invoke(() => view.SetBufferUsage("0"));
                view.Invoke(() => view.SetTotalPacketReceivedText("0"));
            }
        }
    }
}
