using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace ChatupClient
{
    public partial class LoginForm : Form
    {
        private SessionService sessionService;
        private SessionService remoteService;

        public LoginForm()
        {
            InitializeComponent();
            sessionService = new SessionService();
            ChannelServices.RegisterChannel(new TcpChannel(), false);
            //sessionService.OnJoin += UserJoined;
            //sessionService.OnLeave += UserLeft;
        }

        private SessionToken tokenStorage;

        private void UserJoined(string userName)
        {
            MessageBox.Show("UserJoined: " + userName);
        }

        private void UserLeft(string userName)
        {
            MessageBox.Show("UserLeft: " + userName);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private static string userName = "marques999";
        private static string userPasswowrd = "14191091aB";

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            if (remoteService == null)
            {
                remoteService = (SessionService)Activator.GetObject(typeof(SessionService), "tcp://127.0.0.1:12480/SessionService");

                var sessionToken = remoteService.Login(userName, userPasswowrd);

                if (sessionToken != null)
                {
                    MessageBox.Show("LoginSuccess");
                    buttonValidate.Text = "Disconnect";
                    sessionService.OnJoin += UserJoined;
                    sessionService.OnLeave += UserLeft;
                    tokenStorage = new SessionToken(userName, sessionToken);
                }
                else
                {
                    remoteService = null;
                    MessageBox.Show("LoginFailed");
                }
            }
            else
            {
                if (remoteService.Logout(tokenStorage))
                {
                    sessionService.OnJoin -= UserJoined;
                    sessionService.OnLeave -= UserLeft;
                    buttonValidate.Text = "Connect";
                    remoteService = null;
                    MessageBox.Show("LogoutSuccess");
                }
                else
                {
                    MessageBox.Show("LogoutFailed");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    class GetRemote
    {
        private static IDictionary wellKnownTypes;

        public static object New(Type type)
        {
            if (wellKnownTypes == null)
            {
                InitTypeCache();
            }

            var entry = (WellKnownClientTypeEntry)wellKnownTypes[type];

            if (entry == null)
            {
                throw new RemotingException("Type not found!");
            }

            return Activator.GetObject(type, entry.ObjectUrl);
        }

        public static void InitTypeCache()
        {
            var types = new Hashtable();

            foreach (var entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (entry.ObjectType == null)
                {
                    throw new RemotingException("A configured type could not be found!");
                }

                types.Add(entry.ObjectType, entry);
            }

            wellKnownTypes = types;
        }
    }
}