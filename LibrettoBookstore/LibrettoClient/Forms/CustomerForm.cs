using System;
using System.Windows.Forms;
using Libretto.Model;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class CustomerForm : FlatDialog
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public Customer CustomerInformation
        {
            get;
        } = new Customer();

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
            return string.IsNullOrEmpty(nameField.Text) == false
                && string.IsNullOrEmpty(emailField.Text) == false
                && string.IsNullOrEmpty(locationField.Text) == false
                && nameField.Text.Trim().Split().Length > 1
                && LibrettoCommon.VerifyEmail(emailField.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            CustomerInformation.Name = nameField.Text.Trim();
            CustomerInformation.Email = emailField.Text.Trim();
            CustomerInformation.Location = locationField.Text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void EmailField_KeyPress(object sender, KeyPressEventArgs args)
        {
            if (char.IsSeparator(args.KeyChar))
            {
                args.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NameField_KeyPress(object sender, KeyPressEventArgs args)
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
        private void CustomerForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
            guidField.Text = LibrettoCommon.FormatGuid(CustomerInformation.Identifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NameField_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void EmailField_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void LocationField_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }
    }
}