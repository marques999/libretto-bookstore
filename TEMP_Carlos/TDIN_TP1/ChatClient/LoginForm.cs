using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        private IChat chatServer;
        private Guid id;
        private string addr;

        public LoginForm()
        {           
            RemotingConfiguration.Configure("ChatClient.exe.config", false);
            InitializeComponent();
            chatServer = (IChat)RemoteNew.New(typeof(IChat));
            addr = startTcpChannel();
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            id = chatServer.authenticate(usernameTextBox.Text, pwTextBox.Text, addr);

            if (id.Equals(Guid.Empty))
            {
                MessageBox.Show("Username or Password incorrect.", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();

                MessageManager msgm = (MessageManager)RemotingServices.Connect(typeof(MessageManager), addr);
                msgm.setUsername(usernameTextBox.Text);

                new MainForm(chatServer, id, usernameTextBox.Text, this).Show();
            }
        }


        private string startTcpChannel()
        {
            IDictionary props = new Hashtable();
            props["port"] = 0;  // let the system choose a free port
            props["name"] = "";
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            TcpChannel chan = new TcpChannel(props, clientProvider, serverProvider);  // instantiate the channel
            ChannelServices.RegisterChannel(chan, false);                             // register the channel

            ChannelDataStore data = (ChannelDataStore)chan.ChannelData;
            int port = new Uri(data.ChannelUris[0]).Port;                            // get the port
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessageManager), "MessageManager", WellKnownObjectMode.Singleton);  // register my remote object for service

            string addr = "tcp://localhost:" + port.ToString() + "/MessageManager";

            return addr;
        }
    }
}
