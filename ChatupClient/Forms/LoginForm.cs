using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class LoginForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            buttonConfigure.Enabled = true;
            _errorHandler = new ErrorHandler(this);
        }

        /// <summary>
        ///
        /// </summary>
        private readonly ErrorHandler _errorHandler;

        /// <summary>
        ///
        /// </summary>
        private Address _remoteHost = new Address(ChatupCommon.DefaultPort);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm() => !string.IsNullOrWhiteSpace(fieldUsername.Text) && !string.IsNullOrWhiteSpace(fieldPassword.Text);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonValidate_Click(object sender, EventArgs args)
        {
            if (buttonConfigure.Enabled)
            {
                buttonConfigure.Enabled = false;
                ChatupClient.Instance.InitializeRemoting(_remoteHost);
            }

            var operationResult = ChatupClient.Instance.Login(fieldUsername.Text, fieldPassword.Text);

            if (operationResult == RemoteResponse.Success)
            {
                Hide();
                new MainForm().ShowDialog();
                Show();
            }
            else
            {
                _errorHandler.DisplayError(operationResult);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonConfigure_Click(object sender, EventArgs args)
        {
            var addressForm = new AddressForm(_remoteHost);

            if (addressForm.ShowDialog() == DialogResult.OK)
            {
                _remoteHost = addressForm.ModalData;
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

            if (registrationForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (buttonConfigure.Enabled)
            {
                buttonConfigure.Enabled = false;
                ChatupClient.Instance.InitializeRemoting(_remoteHost);
            }

            var registrationInfo = registrationForm.RegistrationData;
            var operationResult = ChatupClient.Instance.Session.Register(registrationInfo);

            if (operationResult == RemoteResponse.Success)
            {
                if (MessageBox.Show(this,
                    Properties.Resources.InfoRegister,
                    Properties.Resources.InfoRegisterTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information) == DialogResult.OK)
                {
                    fieldUsername.Text = registrationInfo.Username;
                    fieldPassword.Text = registrationInfo.Password;
                }
            }
            else
            {
                _errorHandler.DisplayError(operationResult);
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
            buttonValidate.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldUsername_KeyPress(object sender, KeyPressEventArgs args)
        {
            if (char.IsControl(args.KeyChar) == false && char.IsLetterOrDigit(args.KeyChar) == false)
            {
                args.Handled = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldPassword_KeyPress(object sender, KeyPressEventArgs args)
        {
            fieldUsername_KeyPress(sender, args);
        }
    }
}