using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WinWire.App.Forms.CaptureInformation.Interface;
using WinWire.App.Forms.CaptureInformation.Logic;
using WinWire.App.Forms.Main.Interface;


namespace WinWire.App.Forms.CaptureInformation
{
    public partial class FrmCaptureInfo : Form, IFrmCaptureInfo
    {
        private CaptureInfoLogic logic;
        private IFrmAnalyzer mainView;
        public IPAddress SelectedIPAddress
        {
            get
            {
                if (comboIp.SelectedIndex != -1)
                    return IPAddress.Parse(comboIp.SelectedItem.ToString());
                return null;
            }
        }
        public int SelectedBufferSize
        {
            get
            {
                if (comboBuffer.SelectedIndex != -1)
                    return int.Parse(comboBuffer.SelectedItem.ToString());
                return -1;
            }
            set
            {
                if (comboBuffer.Items.Count > 0) comboBuffer.SelectedItem = value.ToString();
            }
        }


        public FrmCaptureInfo(IFrmAnalyzer mainView)
        {
            InitializeComponent();
            this.mainView = mainView;
            logic = new CaptureInfoLogic(this);
        }
        public void SetCaptureInfo(CaptureInfo info) => mainView.CaptureInformation = info;
        public void AddIpItem(string item) => comboIp.Items.Add(item);
        public void AddBufferSizeItem(string item) => comboBuffer.Items.Add(item);
        public void ShowMessage(string message) => MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void CloseDialog() => this.Close();
        private void btnStart_Click(object sender, EventArgs e) => logic.Start();
    }
}
