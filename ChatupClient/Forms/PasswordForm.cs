﻿using System;
using System.Windows.Forms;

namespace ChatupNET.Forms
{
    public partial class PasswordForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public PasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get
            {
                return fieldPassword.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            return string.IsNullOrEmpty(fieldPassword.Text) == false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="argse"></param>
        private void buttonCancel_Click(object sender, EventArgs argse)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonConfirm_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.OK;
            Close();
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
        private void PasswordForm_Load(object sender, EventArgs args)
        {
            buttonConfirm.Enabled = ValidateForm();
        }
    }
}