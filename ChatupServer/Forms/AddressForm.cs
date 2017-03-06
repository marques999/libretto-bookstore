using System;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Model;

namespace ChatupNET.Forms
{
    public partial class AddressForm : Form
    {
        public AddressForm(Address addressObject)
        {
            InitializeComponent();
            ModalData = addressObject;
        }

        public Address ModalData
        {
            get;
            private set;
        }

        private ushort ParsePort()
        {
            try
            {
                return Convert.ToUInt16(fieldPort.Text);
            }
            catch
            {
                return 0;
            }
        }

        private IPAddress ParseAddress()
        {
            try
            {
                return IPAddress.Parse(fieldAddress.Text);
            }
            catch
            {
                return IPAddress.Loopback;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(fieldAddress.Text))
            {
                return false;
            }

            ushort inputPort = 0;

            if (string.IsNullOrEmpty(fieldPort.Text))
            {
                return false;
            }

            return ushort.TryParse(fieldPort.Text, out inputPort);
        }

        private string ReadAddress(byte[] ipDigits)
        {
            return string.Format(Properties.Resources.address_Mask, ipDigits[0], ipDigits[1], ipDigits[2], ipDigits[3]);
        }

        private void RegisterForm_Load(object sender, EventArgs args)
        {
            fieldAddress.Text = ReadAddress(ModalData.Host.GetAddressBytes());
            fieldPort.Text = Convert.ToString(ModalData.Port);
            buttonConfirm.Enabled = ValidateForm();
        }

        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            ModalData = new Address(ParseAddress(), ParsePort());
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