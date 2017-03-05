using System;
using System.Windows.Forms;

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
            if (ChatupClient.Instance.Login(fieldUsername.Text, fieldPassword.Text))
            {
                Hide();
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
            var registrationForm = new RegisterForm();

            if (registrationForm.ShowDialog() == DialogResult.OK)
            {
                var registrationData = registrationForm.RegistrationData;

                if (registrationData == null)
                {
                    return;
                }

                if (ChatupClient.Instance.Session.Register(registrationData))
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