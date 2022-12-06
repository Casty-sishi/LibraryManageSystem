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
    public partial class SelectionForm : Form
    {
        SelectionForm2 bookform = new SelectionForm2 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        SelectionForm3 borrowreturnform = new SelectionForm3 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        public SelectionForm()
        {
            InitializeComponent();
        }
        private void LoadPubilsherInfo() //对应form2的出版社信息 Done
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select * from publisher;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            bookform.listView2.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["pubId"].ToString());
                item.SubItems.Add(dr["pName"].ToString());
                item.SubItems.Add(dr["pLocate"].ToString());
                item.SubItems.Add(dr["pEmailAddr"].ToString());
                item.SubItems.Add(dr["pContact"].ToString());
                bookform.listView2.Items.Add(item);
                //here to display
            }

        }
        private void LoadBookInLibrary() //Todo 对应form2的馆藏信息 有个逻辑处理(bid->bname)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select ");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.Readers_Info_Data.Items.Clear();//先将列表视图中现有行清空
        }
        private void LoadBookInfo() //对应form2的图书信息
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select * from bookinfo");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            bookform.listView1.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["bIsbn"].ToString());
                item.SubItems.Add(dr["pubId"].ToString());
                item.SubItems.Add(dr["tId"].ToString());
                item.SubItems.Add(dr["wId"].ToString());
                item.SubItems.Add(dr["bVersion"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                item.SubItems.Add(dr["bOutDate"].ToString());
                item.SubItems.Add(dr["bPrice"].ToString());
                item.SubItems.Add(dr["bIntro"].ToString());
                bookform.listView1.Items.Add(item);
                //here to display
            }
        }
        private void LoadUserBookInfo() //对用form1的历史已借
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("", this.label9.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.Readers_Info_Data.Items.Clear();//先将列表视图中现有行清空
        }
        private void LoadUserInfo() //对应form1的读者列表
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = "select * from reader;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.Readers_Info_Data.Items.Clear();//先将列表视图中现有行清空
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["uID"].ToString());
                item.SubItems.Add(dr["uName"].ToString());
                item.SubItems.Add(dr["pId"].ToString());
                item.SubItems.Add(dr["uRegistry"].ToString());
                item.SubItems.Add(dr["uState"].ToString());
                item.SubItems.Add(dr["uViolatedTimes"].ToString());
                item.SubItems.Add(dr["uContact"].ToString());
                item.SubItems.Add(dr["uSex"].ToString());
                item.SubItems.Add(dr["uValiDate"].ToString());
                item.SubItems.Add(dr["uCurbor"].ToString());
                item.SubItems.Add(dr["uHasBor"].ToString());
                item.SubItems.Add(dr["remark"].ToString());
                Readers_Info_Data.Items.Add(item);
                //here to display
            }
        }
        public void SetAdminLabel(String admName) //设置登录界面跳转过来的管理员名字
        {
            this.Admin_Name_Label.Text=  admName;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Book_Manager_Button_Click(object sender, EventArgs e) //跳转至图书管理
        {
            this.Reader_Tab_Control.Controls.Clear();
            this.Reader_Tab_Control.Controls.Add(bookform.Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(bookform.Publisher_TabPage);
            this.Reader_Tab_Control.Controls.Add(bookform.Library_Book_TabPage);
            LoadPubilsherInfo();
            LoadBookInfo();
            bookform.Show();
        }

        private void Borrow_Return_Mangager_Button_Click(object sender, EventArgs e) //跳转至借还管理
        {
            this.Reader_Tab_Control.Controls.Clear();
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Library_Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Publisher_TabPage);
            borrowreturnform.Show();
        }

        private void Reader_Manager_Button_Click(object sender, EventArgs e)
        {
            this.Reader_Tab_Control.Controls.Clear();
            this.Reader_Tab_Control.Controls.Add(this.Reader_Info_TabPage);
            this.Reader_Tab_Control.Controls.Add(this.tabPage1);
            this.Reader_Tab_Control.Show();
            LoadUserInfo();//加载读者信息
        }

        private void Admin_Name_Label_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Picture_Box_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.comboBox1.Text="";
            this.comboBox2.Text="";
            this.label9.Text = "";

        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void Readers_Info_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Readers_Info_Data.SelectedItems.Count > 0)
            {
                ListViewItem item = this.Readers_Info_Data.SelectedItems[0];//获取选中的第一行（一次只能选中一行）

                this.comboBox1.Text = item.SubItems[2].Text; //读者类别
                this.textBox1.Text = item.SubItems[1].Text;//读者姓名
                this.comboBox2.Text = item.SubItems[4].Text;//状态
                this.textBox2.Text = item.SubItems[5].Text;//违规次数
                this.textBox6.Text = item.SubItems[8].Text;//有效期
                this.textBox5.Text = item.SubItems[3].Text;//注册日期
                this.textBox3.Text = item.SubItems[6].Text;//联系方式
                this.label9.Text = item.SubItems[0].Text;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Reader_Tab_Control_Click(object sender, EventArgs e)
        {

        }
    }
}
