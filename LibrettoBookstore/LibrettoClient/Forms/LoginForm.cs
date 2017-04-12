using System;
using System.Windows.Forms;
using Libretto.Properties;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class LoginForm : FlatDialog
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
        /// <returns></returns>
        private bool ValidateLogin()
        {
            return emailField.Text == @"admin@libretto.pt" && passwordField.Text == @"changemeplease";
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(emailField.Text) || string.IsNullOrWhiteSpace(passwordField.Text))
            {
                return false;
            }

            LibrettoClient.Instance.Login(emailField.Text);

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            Application.Exit();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonValidate_Click(object sender, EventArgs args)
        {
            if (ValidateLogin())
            {
                Hide();
                new StoreForm().ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show(this, Resources.AuthenticationFailed, Resources.AuthenticationFailed_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void FieldEmail_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = ValidateForm();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void FieldEmail_KeyPress(object sender, KeyPressEventArgs args)
        {
            if (char.IsWhiteSpace(args.KeyChar))
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
            if (char.IsControl(args.KeyChar) == false && char.IsLetterOrDigit(args.KeyChar) == false)
            {
                args.Handled = true;
            }
        }
    }
}