using System;
using System.Windows.Forms;
using WinWire.App.Forms.Main;


namespace Network.Packet.Analyzer.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAnalyzer());
        }
    }
}
