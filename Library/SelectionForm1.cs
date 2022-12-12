using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class SelectionForm : Form
    {
        //ListView curViewOne = new ListView();
        //ListView curViewTwo = new ListView();
        SelectionForm2 bookform = new SelectionForm2 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        SelectionForm3 borrowreturnform = new SelectionForm3 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        public SelectionForm()
        {
            InitializeComponent();
        }
        
        private String getStatusName(string i)
        {
            switch (i)
            {
                case "0":
                    return "离校";
                case "1":
                    return "在校";
                default:
                    return "退休";
            }
        }
        private String GetPriorityName(int i)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select pName from priority where pId = {0};",i);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["pName"].ToString();
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
        private string GetBookState(int bState)
        {
            if(bState == 0)
            {
                return "外借中";
            }
            else
            {
                return "在架上";
            }
        }
        private string GetBookLocation(int bksId)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select bksName from bookshelf where bksId = {0};", bksId);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["bksName"].ToString();
        }
        private void LoadBookInLibrary(ListView curList) //Todo 对应form2的馆藏信息 有个逻辑处理(bid->bname)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select bIsbn,bName,bId,bState,bksId,bInDate from books natural join bookinfo;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            curList.Items.Clear();//先将列表视图中现有行清空
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["bIsbn"].ToString());
                item.SubItems.Add(dr["bId"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                string bstate = GetBookState(int.Parse(dr["bState"].ToString()));
                item.SubItems.Add(bstate); //状态 需要从编号转换成字符串
                string location = GetBookLocation(int.Parse(dr["bksId"].ToString()));
                item.SubItems.Add(location)  ;//图书位置 需要从编号转换成字符串
                string date = dr["bInDate"].ToString();
                string[] getDate = date.Split(' ');
                date = getDate[0];
                item.SubItems.Add(date);
                curList.Items.Add(item);
                //here to display
            }
        }
        private string GetPublisherName(int pubid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select pName from publisher where pubId ={0} ",pubid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["pName"].ToString();
        }
        private string GetTypeName(int tid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select tName from typeinfo where tId ={0} ", tid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["tName"].ToString();
        }
        private string GetWriterName(int wid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select wName from author where wId ={0} ", wid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["wName"].ToString();
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
                string pname = GetPublisherName(int.Parse(dr["pubId"].ToString()));
                item.SubItems.Add(pname);
                string tname = GetTypeName(int.Parse(dr["tId"].ToString()));
                item.SubItems.Add(tname);
                string wname = GetWriterName(int.Parse(dr["wId"].ToString()));
                item.SubItems.Add(wname);
                item.SubItems.Add(dr["bVersion"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                string date = dr["bOutDate"].ToString();
                string[] getDate = date.Split(' ');
                date = getDate[0];
                item.SubItems.Add(date);
                item.SubItems.Add(dr["bPrice"].ToString());
                item.SubItems.Add(dr["bIntro"].ToString());
                bookform.listView1.Items.Add(item);
                //here to display
            }
        }
        private void LoadUserBookInfo(string userid,int type) //对用form1的历史已借 type=1说明显示的是在借的，type=0说明显示的是已还的，type=2说明是过期的
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,books.bIsbn,bookshelf.bksName,`end`,books.bksId,TO_DAYS(`end`)-TO_DAYS(`start`) bHasBor,borrowed.Expired\r\nfrom books\r\nnatural join borrowed\r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Rea_uID = '{0}';", userid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.listView1.Items.Clear();//先将列表视图中现有行清空
            foreach (DataRow dr in db.Rows)
            {
                if (type == 1 && dr["Expired"].ToString() == "1")//显示在借的，0表示未过期，1表示已过期，
                    continue;
                else if(type ==0 && dr["Expired"].ToString() == "0")  
                    continue; 
                ListViewItem item = new ListViewItem(dr["bId"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                item.SubItems.Add(dr["bIsbn"].ToString());
                item.SubItems.Add(dr["bksName"].ToString());
                item.SubItems.Add(dr["end"].ToString());
                item.SubItems.Add(dr["bHasBor"].ToString());
                this.listView1.Items.Add(item);
                //here to display 这里考虑的是历史已借，不能显示正在借的。
            }
        }
        private void LoadUserInfo(ListView curview) //对应curview的读者信息
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = "select * from reader;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            curview.Items.Clear();//先将列表视图中现有行清空
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["uID"].ToString());
                item.SubItems.Add(dr["uName"].ToString());
                string priority = GetPriorityName(int.Parse(dr["pId"].ToString()));
                item.SubItems.Add(priority);
                item.SubItems.Add(dr["uRegistry"].ToString());
                string status = getStatusName(dr["uState"].ToString());
                item.SubItems.Add(status);
                item.SubItems.Add(dr["uViolatedTimes"].ToString());
                item.SubItems.Add(dr["uContact"].ToString());
                item.SubItems.Add(dr["uSex"].ToString());
                item.SubItems.Add(dr["uValiDate"].ToString());
                item.SubItems.Add(dr["uCurbor"].ToString());
                item.SubItems.Add(dr["uHasBor"].ToString());
                item.SubItems.Add(dr["remark"].ToString());
                curview.Items.Add(item);
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
            LoadBookInLibrary(bookform.listView3);
            bookform.Show();
        }

        private void Borrow_Return_Mangager_Button_Click(object sender, EventArgs e) //跳转至借还管理
        {
            this.Reader_Tab_Control.Controls.Clear();
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Library_Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(borrowreturnform.Publisher_TabPage);
            LoadUserInfo(borrowreturnform.Readers_Info_Data);
            LoadUserInfo(borrowreturnform.listView7);
            LoadUserInfo(borrowreturnform.listView8);
            LoadBookInLibrary(borrowreturnform.listView9);
            borrowreturnform.Show();
        }

        private void Reader_Manager_Button_Click(object sender, EventArgs e)
        {
            this.Reader_Tab_Control.Controls.Clear();
            this.Reader_Tab_Control.Controls.Add(this.Reader_Info_TabPage);
            this.Reader_Tab_Control.Controls.Add(this.tabPage1);
            this.Reader_Tab_Control.Show();
            LoadUserInfo(this.Readers_Info_Data);//加载读者信息
            //LoadUserBookInfo();//加载历史已借信息
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
            this.textBox7.Text="";
            this.textBox4.Text="";
            this.label9.Text = "";

        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo(this.Readers_Info_Data); // 一开始Load的时候应该是form1的ListView

        }

        private void Readers_Info_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Readers_Info_Data.SelectedItems.Count > 0)
            {
                ListViewItem item = this.Readers_Info_Data.SelectedItems[0];//获取选中的第一行（一次只能选中一行）

                this.textBox4.Text = item.SubItems[2].Text; //读者类别
                this.textBox1.Text = item.SubItems[1].Text;//读者姓名
                this.textBox7.Text = item.SubItems[4].Text;//状态
                this.textBox2.Text = item.SubItems[5].Text;//违规次数
                this.textBox6.Text = item.SubItems[8].Text;//有效期
                this.textBox5.Text = item.SubItems[3].Text;//注册日期
                this.textBox3.Text = item.SubItems[6].Text;//联系方式
                this.label9.Text = item.SubItems[0].Text;
                LoadUserBookInfo(this.label9.Text,0);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Reader_Tab_Control_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            String uViolatedTimes = this.textBox2.Text;
            String uvalidate = this.textBox6.Text;
            if(uViolatedTimes.Length > 0 && uvalidate.Length > 0)
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("update reader set uViolatedTimes={0},uValiDate='{1}' where uID ='{2}';",uViolatedTimes,uvalidate,this.label9.Text);
                MySqlCommand command = new MySqlCommand(sql, conn);
                int rows = command.ExecuteNonQuery();
                if(rows> 0)
                {
                    MessageBox.Show("已经成功修改！");
                    LoadUserInfo(this.Readers_Info_Data);
                }
                conn.Close();//查询到数据之后就可以关掉了
            }
            else
            {
                MessageBox.Show("输入为空，请重新输入！");
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
