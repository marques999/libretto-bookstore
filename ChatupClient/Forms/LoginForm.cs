using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

using ChatupNET.Session;

namespace ChatupNET.Forms
{
    public partial class LoginForm : Form
    {
        private SessionService sessionService;
        private SessionService remoteService;
        private SessionToken tokenStorage;

        public LoginForm()
        {
            InitializeComponent();
            sessionService = new SessionService();
            ChannelServices.RegisterChannel(new TcpChannel(), false);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(fieldUsername.Text))
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(fieldPassword.Text);
        }

        private void UserJoined(string userName)
        {
            MessageBox.Show("UserJoined: " + userName);
        }

        private void UserLeft(string userName)
        {
            MessageBox.Show("UserLeft: " + userName);
        }

        private const string userName = "marques999";
        private const string userPassword = "lerolero";

        private void buttonValidate_Click(object sender, EventArgs args)
        {
            /*if (remoteService == null)
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
            }*/

            if (fieldUsername.Text.Equals(userName) && fieldPassword.Text.Equals(userPassword))
            {
                Hide();
                ChatupClient.Instance.Username = userName;
                new MainForm().ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show(this,
                    Properties.Resources.LoginError,
                    Properties.Resources.LoginErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonCancel_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

        private void buttonRegister_Click(object sender, EventArgs args)
        {
            var registrationForm = new ChatupNET.RegisterForm();

            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
                var registrationData = registrationForm.RegistrationData;

                if (MessageBox.Show(this,
                    Properties.Resources.InfoRegister,
                    Properties.Resources.InfoRegisterTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information) == DialogResult.OK)
                {
                    fieldUsername.Text = registrationData.Username;
                    fieldPassword.Text = registrationData.Password;
                }
            }
        }

        private void fieldUsername_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        private void LoginForm_Load(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }
    }
}