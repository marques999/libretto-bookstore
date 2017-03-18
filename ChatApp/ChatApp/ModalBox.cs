using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class ModalBox : Form
    {
        Main MainWindow;
        public ModalBox(Main parent)
        {
            InitializeComponent();

            MainWindow = parent;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.createChatRoom(this.textBox1.Text, this.checkBox1.Checked);
            this.Close();
        }
    }
}
