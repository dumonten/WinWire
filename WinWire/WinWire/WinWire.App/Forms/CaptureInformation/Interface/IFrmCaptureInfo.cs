using System.Net;


namespace WinWire.App.Forms.CaptureInformation.Interface
{
    public interface IFrmCaptureInfo
    {
        IPAddress SelectedIPAddress { get; }
        int SelectedBufferSize { get; set; }

        void AddIpItem(string item);
        void AddBufferSizeItem(string item);
        void ShowMessage(string message);
        void CloseDialog();
        void SetCaptureInfo(CaptureInfo info);
    }
}
