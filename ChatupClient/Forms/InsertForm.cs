using System;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class InsertForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public InsertForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public Room RoomObject
        {
            get;
            private set;
        }

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
            return string.IsNullOrEmpty(fieldName.Text.Trim()) == false && fieldPassword.Text.Length > 6;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            RoomObject = new Room(-1, fieldName.Text.Trim(), ChatupClient.Instance.Username, fieldPassword.Text, (int)fieldCapacity.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CreateForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldName_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldPassword_TextChanged(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void fieldPassword_KeyPress(object sender, KeyPressEventArgs args)
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
        private void fieldName_KeyPress(object sender, KeyPressEventArgs args)
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
    }
}