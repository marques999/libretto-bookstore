using System;
using System.Windows.Forms;

using ChatupNET.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ChatupServer.Instance.Equals("");
        Application.Run(new MainForm());
    }
}