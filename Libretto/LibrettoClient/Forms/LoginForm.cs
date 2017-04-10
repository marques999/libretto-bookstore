using System;
using System.Windows.Forms;
using Libretto.Forms;

namespace LibrettoClient
{
    public partial class LoginForm : Form

    {
        /// <summary>
        ///
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            buttonConfigure.Enabled = true;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm() => !string.IsNullOrWhiteSpace(fieldEmail.Text) && !string.IsNullOrWhiteSpace(fieldPassword.Text);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonValidate_Click(object sender, EventArgs args)
        {
            Hide();
            new StoreForm().ShowDialog();
            Show();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfigure_Click(object sender, EventArgs args)
        {
            /*var addressForm = new SettingsForm(_remoteHost);

            if (addressForm.ShowDialog() == DialogResult.OK)
            {
                _remoteHost = addressForm.ModalData;
            }*/
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonRegister_Click(object sender, EventArgs args)
        {
            /*var registrationForm = new RegisterForm();

            if (registrationForm.ShowDialog() != DialogResult.OK)
            {
            }*/
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
        private void LoginForm_Load(object sender, EventArgs args)
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
            FieldEmail_KeyPress(sender, args);
        }
    }
}
