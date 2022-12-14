using MySql.Data.MySqlClient;
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

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                this.textBox5.Text = item.SubItems[5].Text; //图书名称
                this.label8.Text = item.SubItems[0].Text; //图书ISBN
                this.comboBox2.Text = item.SubItems[4].Text;//图书版本
                this.comboBox3.Text = item.SubItems[1].Text;//出版社名字
                this.comboBox1.Text = item.SubItems[2].Text;//图书类型
                this.richTextBox1.Text = item.SubItems[8].Text;//图书简介
                this.textBox13.Text = item.SubItems[3].Text;//图书作者
                this.textBox7.Text = item.SubItems[7].Text;//图书价格
                this.textBox6.Text = item.SubItems[6].Text;//图书出版日期
            }
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.listView2.SelectedItems.Count>0)
            {
                ListViewItem item = this.listView2.SelectedItems[0];

                this.textBox8.Text = item.SubItems[0].Text; //出版社编号
                this.textBox9.Text = item.SubItems[1].Text;//出版社名称
                this.textBox10.Text = item.SubItems[2].Text;//出版社地址
                this.textBox11.Text = item.SubItems[3].Text;//出版社邮箱
                this.textBox12.Text = item.SubItems[4].Text;//出版社联系方式
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.textBox8.Clear(); //出版社编号
            this.textBox9.Clear();//出版社名称
            this.textBox10.Clear();//出版社地址
            this.textBox11.Clear();//出版社邮箱
            this.textBox12.Clear();//出版社联系方式
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.textBox5.Clear(); //图书名称
            this.label8.Text = "Isbn"; //图书ISBN
            this.comboBox2.Text=null;//图书版本
            this.comboBox3.Text = null;//出版社名字
            this.comboBox1.Text = null;//图书类型
            this.richTextBox1.Clear();//图书简介
            this.textBox13.Clear();//图书作者
            this.textBox7.Clear();//图书价格
            this.textBox6.Clear();//图书出版日期

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear(); //图书编号
            this.label1.Text = "Isbn"; //图书ISBN
            this.textBox2.Clear();//图书名字
            this.textBox3.Clear();//图书状态
            this.textBox4.Clear();//图书位置
            this.label7.Text = "/"; ;//图书入库日期
        }

        private void button5_Click(object sender, EventArgs e) //馆藏信息的修改，图书名字不能修改
        {

        }

        private void button9_Click(object sender, EventArgs e) //馆藏信息添加
        {

        }

        private void button10_Click(object sender, EventArgs e)//馆藏信息删除
        {
            //注意如果这本书是在借状态，不能删除
        }
        private void DeleteBookInfo(int bkid) //馆藏删除图书信息-sql
        {

        }
        private void InsertBookInfo(int bkid,string Location) //馆藏增加图书信息 -sql
        {
            

        }
        private void UpdateBookInfo(int bkid,string Location) //馆藏更新图书信息 -sql
        { }

        private void button3_Click(object sender, EventArgs e)//图书信息修改
        {

        }
        private void UpdateBook(string isbn,string authorName,string bkName,string Location,string bookType, int bookVersion, string publisherName, double bkPrice,String outDate, String profile ) { }//图书信息修改 -sql
        private void AddBook(string isbn, string authorName, string bkName, string Location, string bookType, int bookVersion, string publisherName, double bkPrice, String outDate, String profile) { }//图书信息增加 -sql

        private void DeleteBook(string isbn) { }//删除图书信息 -sql
        private void button8_Click(object sender, EventArgs e)//增加图书信息
        {

        }

        private void button11_Click(object sender, EventArgs e)//删除图书信息
        {
            //注意如果现在有人借阅这本书的，不能删除（这个Isbn对应的书）
        }

        private void button12_Click(object sender, EventArgs e)//删除出版社信息 
        {//注意如果现有书本有这个出版社的，不能删除。

        }

        private void button7_Click(object sender, EventArgs e)//添加出版社信息
        {

        }

        private void button1_Click(object sender, EventArgs e)//更新出版社信息
        {

        }

        private void Reader_Manager_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
