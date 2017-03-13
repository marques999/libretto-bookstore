namespace ChatClient
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatLogTextBox = new System.Windows.Forms.TextBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatLogTextBox
            // 
            this.chatLogTextBox.Location = new System.Drawing.Point(12, 12);
            this.chatLogTextBox.Multiline = true;
            this.chatLogTextBox.Name = "chatLogTextBox";
            this.chatLogTextBox.ReadOnly = true;
            this.chatLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatLogTextBox.Size = new System.Drawing.Size(397, 204);
            this.chatLogTextBox.TabIndex = 0;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(85, 229);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(233, 20);
            this.chatTextBox.TabIndex = 1;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(12, 232);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(56, 13);
            this.textLabel.TabIndex = 2;
            this.textLabel.Text = "Enter Text";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.chatLogTextBox);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox chatLogTextBox;
        protected System.Windows.Forms.TextBox chatTextBox;
        protected System.Windows.Forms.Label textLabel;
        protected System.Windows.Forms.Button button1;
    }
}