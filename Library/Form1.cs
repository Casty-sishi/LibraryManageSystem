using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class InputUidForm : Form
    {
        public InputUidForm()
        {

            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length <= 0)
                MessageBox.Show("输入编号不能为空！");
            else this.ifClickedStored = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("取消");
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
