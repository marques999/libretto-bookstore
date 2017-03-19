using System;
using System.Windows.Forms;

using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    public partial class InsertForm : Form
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
        /// <returns></returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(fieldName.Text.Trim()))
            {
                return false;
            }

            var roomPassword = fieldPassword.Text.Trim();

            if (string.IsNullOrEmpty(roomPassword))
            {
                return true;
            }

            return roomPassword.Length > 6;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            RoomObject = new Room(-1, fieldName.Text, ChatupClient.Instance.Username, fieldPassword.Text, (int)fieldCapacity.Value);
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
    }
}