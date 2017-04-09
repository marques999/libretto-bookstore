using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    /// <summary>
    ///
    /// </summary>
    internal partial class RegisterForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        public UserForm RegistrationData
        {
            get;
            private set;
        } = new UserForm("dummy", "dummy", "dummy");

        /// <summary>
        ///
        /// </summary>
        private int _separatorCount;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(fieldUsername.Text) || string.IsNullOrEmpty(fieldName.Text))
            {
                return false;
            }

            return fieldName.Text.Trim().Split().Length > 1 && fieldPassword.Text.Length >= ChatupCommon.PasswordLength;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RegisterForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            RegistrationData = new UserForm(fieldUsername.Text, fieldName.Text.Trim(), fieldPassword.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldUsername_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldName_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldName_KeyPress(object sender, KeyPressEventArgs args)
        {
            if (char.IsSeparator(args.KeyChar))
            {
                if (++_separatorCount > 1)
                {
                    args.Handled = true;
                }
            }
            else if (char.IsControl(args.KeyChar) || char.IsLetterOrDigit(args.KeyChar))
            {
                _separatorCount = 0;
            }
            else
            {
                args.Handled = true;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldUsername_KeyPress(object sender, KeyPressEventArgs args)
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
        private void FieldPassword_KeyPress(object sender, KeyPressEventArgs args)
        {
            FieldUsername_KeyPress(sender, args);
        }
    }
}