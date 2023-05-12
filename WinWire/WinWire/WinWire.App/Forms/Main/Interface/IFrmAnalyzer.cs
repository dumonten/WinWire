using System;
using System.Windows.Forms;
using WinWire.App.Forms.CaptureInformation;



namespace WinWire.App.Forms.Main.Interface
{
    public interface IFrmAnalyzer
    {
        CaptureInfo CaptureInformation { get; set; }
        
        ProgressBar ProgressBufferUsage { get; }
        
        string Bpf { get; }
        ListView ListReceivedPackets { get; }
        TreeView TreePackedDetails { get; }
        TextBox PacketChunkNum { get; }
        TextBox PacketCharRepresentation { get; }
        TextBox PacketByteRepresentation { get; }
       
        bool ButtonStartEnabled { get; set; }
        bool ButtonBpfEndbled { get; set; }
        bool ButtonBpfClicked { get; set; }
        bool ButtonStopEnabled { get; set; }
        bool ShowOnTopOfOtherApps { get; set; }
        bool ShowPacketPacketData { get; set; }
        bool DarkTheme { get; set; }
        

        void Invoke(Action action);
        void SetTotalPacketReceivedText(string strNumber);
        void SetBufferUsage(string strNumber);
        void SetReadyText(string text);
        void ShowErrorMessage(string message);
        void ShowWarningMessage(string message);
        void ShowDefaultErrorMessage();
        void ShowDefaultErrorMessage(Exception ex);
        void ShowErrorMessage(string message, Exception ex);
        void ApplicationClose();
    }
}
