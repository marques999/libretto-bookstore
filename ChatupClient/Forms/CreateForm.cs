using System;
using System.Windows.Forms;

using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        public Room RoomObject
        {
            get;
            private set;
        }

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

        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            RoomObject = new Room(fieldName.Text, ChatupClient.Instance.Username, fieldPassword.Text, fieldCapacity.SelectedIndex);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CreateForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
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