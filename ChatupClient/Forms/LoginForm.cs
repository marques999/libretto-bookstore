using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(fieldUsername.Text))
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(fieldPassword.Text);
        }

        private void buttonValidate_Click(object sender, EventArgs args)
        {
            var operationResult = ChatupClient.Instance.Login(fieldUsername.Text, fieldPassword.Text);

            if (operationResult == RemoteResponse.Success)
            {
                Hide();
                new MainForm().ShowDialog();
                Show();
            }
            else
            {
                ErrorHandler.DisplayError(this, operationResult);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

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