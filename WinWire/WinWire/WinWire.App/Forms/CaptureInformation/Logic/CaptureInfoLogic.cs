using System.Net;
using System.Net.Sockets;
using WinWire.App.Forms.CaptureInformation.Interface;


namespace WinWire.App.Forms.CaptureInformation.Logic
{
    public class CaptureInfoLogic
    {
        private IFrmCaptureInfo view;


        public CaptureInfoLogic(IFrmCaptureInfo view)
        {
            this.view = view;
            InitComboBuffer();
            InitComboIp();
        }
        private void InitComboIp()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
                /*ipv4 only*/
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    view.AddIpItem(ip.ToString());
        }
        private void InitComboBuffer()
        {
            for (int i = 100; i < 1000; i += 100)
                view.AddBufferSizeItem(i.ToString());
            for (int j = 1000; j < 100000; j += 1000)
                view.AddBufferSizeItem(j.ToString());
        }
        public void Start()
        {
            CaptureInfo captureInfo = null;
            if (view.SelectedBufferSize != -1 && view.SelectedIPAddress != null)
            {
                captureInfo = new CaptureInfo(view.SelectedIPAddress, view.SelectedBufferSize);
                view.SetCaptureInfo(captureInfo);
                view.CloseDialog();
            }
            else
                view.ShowMessage("Ошибка: убедитесь, что выбраны ip-адрес и размер буфера.");
        }
    }
}
