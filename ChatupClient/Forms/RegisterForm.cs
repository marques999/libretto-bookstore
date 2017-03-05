using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public UserForm RegistrationData
        {
            get;
            private set;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(fieldUsername.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(fieldName.Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(fieldPassword.Text))
            {
                return false;
            }

            return fieldPassword.Text.Length > 6;
        }

        private void RegisterForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            RegistrationData = new UserForm(fieldUsername.Text, fieldName.Text, fieldPassword.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fieldUsername_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        private void fieldName_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }
    }
}