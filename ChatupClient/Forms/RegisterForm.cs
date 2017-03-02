using System;
using System.Windows.Forms;

using ChatupNET.Session;

namespace ChatupNET
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public RegisterObject RegistrationData
        {
            get;
            private set;
        }

        private bool ValidateForm()
        {
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
            fieldCapacity.DataSource = TimeZoneInfo.GetSystemTimeZones();
        }

        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            RegistrationData = new RegisterObject(fieldName.Text, fieldPassword.Text, null);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fieldName_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }
    }
}