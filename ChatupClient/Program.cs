using System;
using System.Windows.Forms;

using ChatupNET.Forms;

static class Program
{
    [STAThread]
    private static void Main()
    {
        ChatupClient.Instance.Equals("");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LoginForm());
    }
}