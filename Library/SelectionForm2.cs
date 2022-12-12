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
    public partial class SelectionForm2 : Form
    {
        public SelectionForm2()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SelectionForm2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.listView3.SelectedItems.Count>0)
            {
                ListViewItem item = this.listView3.SelectedItems[0];

                this.textBox1.Text = item.SubItems[1].Text; //图书编号
                this.label1.Text = item.SubItems[0].Text; //图书ISBN
                this.textBox2.Text = item.SubItems[2].Text;//图书名字
                this.textBox3.Text = item.SubItems[3].Text;//图书状态
                this.textBox4.Text = item.SubItems[4].Text;//图书位置
                this.label7.Text = item.SubItems[5].Text;//图书入库日期
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
