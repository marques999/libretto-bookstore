using System;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return fieldPassword.Text;
            }
        }

        private bool ValidateForm()
        {
            return string.IsNullOrEmpty(fieldPassword.Text) == false;
        }

        private void buttonCancel_Click(object sender, EventArgs argse)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        private void PasswordForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }
    }
}