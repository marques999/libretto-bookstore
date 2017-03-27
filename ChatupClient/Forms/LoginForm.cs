using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private Address remoteHost = new Address(12480);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(fieldUsername.Text))
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(fieldPassword.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonValidate_Click(object sender, EventArgs args)
        {
            if (buttonConfigure.Enabled)
            {
                ChatupClient.Instance.InitializeRemoting(remoteHost);
            }

            var operationResult = ChatupClient.Instance.Login(fieldUsername.Text, fieldPassword.Text);

            if (operationResult == RemoteResponse.Success)
            {
                Hide();
                buttonConfigure.Enabled = false;
                new MainForm().ShowDialog();
                Show();
            }
            else
            {
                ErrorHandler.DisplayError(this, operationResult);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonConfigure_Click(object sender, EventArgs args)
        {
            var addressForm = new AddressForm(remoteHost);

            if (addressForm.ShowDialog() == DialogResult.OK)
            {
                var serverAddress = addressForm.ModalData;

                if (serverAddress != null)
                {
                    remoteHost = serverAddress;
                    ChatupClient.Instance.InitializeRemoting(remoteHost);
                    buttonConfigure.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonRegister_Click(object sender, EventArgs args)
        {
            var registrationForm = new RegisterForm();

            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
                var registrationData = registrationForm.RegistrationData;

                if (registrationData == null)
                {
                    return;
                }

                if (buttonConfigure.Enabled)
                {
                    ChatupClient.Instance.InitializeRemoting(remoteHost);
                }

                var operationResult = ChatupClient.Instance.Session.Register(registrationData);

                if (operationResult == RemoteResponse.Success)
                {
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
                else
                {
                    ErrorHandler.DisplayError(this, operationResult);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldUsername_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void LoginForm_Load(object sender, EventArgs args)
        {
            buttonConfigure.Enabled = true;
            buttonValidate.Enabled = ValidateForm();
        }
    }
}