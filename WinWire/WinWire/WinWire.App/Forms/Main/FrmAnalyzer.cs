using PcapDotNet.Core;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinWire.App.Forms.CaptureInformation;
using WinWire.App.Forms.Main.Interface;
using WinWire.App.Forms.Main.Logic;


namespace WinWire.App.Forms.Main
{
    public partial class FrmAnalyzer : Form, IFrmAnalyzer
    {
        private bool buttonBpfClicked = false;
        private bool showPacketData = false;
        private bool darkTheme = false; 
        public FrmAnalyzerLogic logic;


        public FrmAnalyzer()
        {
            InitializeComponent();
            logic = new FrmAnalyzerLogic(this);
            //
            Font myfont = new Font("Anonymous Pro", 10.0f);
            packetByteRepresentation.Font = myfont;
            packetCharRepresentation.Font = myfont;
            packetChunkNum.Font = myfont;
        }

        #region InterfaceImplementation
        public CaptureInfo CaptureInformation { get { return logic.Info; } set { logic.Info = value; } }
 
        public ProgressBar ProgressBufferUsage { get { return progressBufferUsage; } }
       
        public string Bpf { get { return bpfField.Text; } }
        public ListView ListReceivedPackets { get { return lstReceivedPackets; } }
        public TreeView TreePackedDetails { get { return treePacketDetails; } }
        public TextBox PacketChunkNum { get { return packetChunkNum; } }
        public TextBox PacketCharRepresentation { get { return packetCharRepresentation; } }
        public TextBox PacketByteRepresentation { get { return packetByteRepresentation; } }

        public bool ButtonStartEnabled { get { return tbtnStart.Enabled; } set { tbtnStart.Enabled = value; } }
        public bool ButtonBpfClicked { get { return buttonBpfClicked; } set { buttonBpfClicked = value; } }
        public bool ButtonBpfEndbled { get { return tbtnFilterOn.Enabled; } set { tbtnFilterOn.Enabled = value; } }
        public bool ButtonStopEnabled { get { return tbtnStop.Enabled; } set { tbtnStop.Enabled = value; } }
        public bool ShowOnTopOfOtherApps { get { return this.TopMost; } set { topMostMenuItem.Checked = value; this.TopMost = value; } }
        public bool ShowPacketPacketData { get { return showPacketData; } set { dataAboutPacketMenuItem.Checked = value; showPacketData = value; } }
        public bool DarkTheme { get { return darkTheme; } set { darkThemeMenuItem.Checked = value; darkTheme = value; } }

        public void Invoke(Action act) => this.Invoke(new MethodInvoker(delegate { act(); }));
        public void SetTotalPacketReceivedText(string strNumber) { if (strNumber != null) lblTotalPkgsReceived.Text = strNumber; }
        public void SetBufferUsage(string strNumber) { if (strNumber != null) lblBufferUsage.Text = strNumber; }
        public void SetReadyText(string text) { if (text != null) lblStripReady.Text = text; }
        #region ErrorBlock
        public void ShowErrorMessage(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void ShowWarningMessage(string message) => MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void ShowDefaultErrorMessage() => MessageBox.Show("Unexpected error has acquired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void ShowDefaultErrorMessage(Exception ex) => MessageBox.Show(String.Format("Unexpected error has acquired. Error message: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void ShowErrorMessage(string message, Exception ex) => MessageBox.Show(String.Format("{0}. Error message: {1}", message, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        #endregion
        public void ApplicationClose() => this.Close();
        #endregion

        #region EventsOnForm
        private void FrmAnalyzer_Load(object sender, EventArgs e) => logic.ApplicationStarted();
        private void lstReceivedPackets_SelectedIndexChanged(object sender, EventArgs e) => logic.CreateDetailedTree();
        private void bpfField_TextChanged(object sender, EventArgs e)
        {
            ButtonBpfClicked = false;
            if (bpfField.Text.Length != 0)
            {
                try
                {
                    BerkeleyPacketFilter tempFilter = new BerkeleyPacketFilter(bpfField.Text, 1, PcapDotNet.Packets.DataLinkKind.IpV4);
                    bpfField.BackColor = Color.FromArgb(192, 255, 192);
                    ButtonBpfEndbled = true;
                }
                catch
                {
                    ButtonBpfEndbled = false;
                    bpfField.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            else
            {
                bpfField.BackColor = Color.White;
                ButtonBpfEndbled = true;
            }
        }

        #region Clicked
        private void tbtnStart_Click(object sender, EventArgs e) => logic.StartClicked();
        private void tbtnStop_Click(object sender, EventArgs e) => logic.StopClicked(); 
        private void tbtnClearAll_Click(object sender, EventArgs e) => logic.ClearAllFields();
        private void tbtnFilterOn_Click(object sender, EventArgs e) => ButtonBpfClicked = true;

        #region MenuItems
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => ApplicationClose();
        private void topMostMenuItem_Click(object sender, EventArgs e) => ShowOnTopOfOtherApps = ShowOnTopOfOtherApps ? false : true;
        private void dataAboutPacketMenuItem_Click(object sender, EventArgs e) => ShowPacketPacketData = ShowPacketPacketData ? false : true;
        private void darkThemeMenuItem_Click(object sender, EventArgs e) => DarkTheme = DarkTheme ? false : true;
        #endregion

        #endregion
        
        #endregion

    }
}
