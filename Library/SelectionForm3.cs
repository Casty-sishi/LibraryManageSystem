using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
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
    public partial class SelectionForm3 : Form
    {
        public SelectionForm3()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Readers_Info_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Readers_Info_Data.SelectedItems.Count > 0)
            {
                ListViewItem item = this.Readers_Info_Data.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox1.Text = item.SubItems[0].Text;
            }
        }
        private void LoadUserBookInfo(string userid,int type)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,books.bIsbn,bookshelf.bksName,`end`,books.bksId,TO_DAYS(`end`)-TO_DAYS(`start`) bHasBor,borrowed.Expired\r\nfrom books\r\nnatural join borrowed\r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Rea_uID = '{0}';", userid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.listView8.Items.Clear();//先将列表视图中现有行清空
            foreach (DataRow dr in db.Rows)
            {
                //if (type == 1 && dr["Expired"].ToString() == "1")//显示在借的，0表示未过期，1表示已过期，
                //    continue;
                //else if(type ==0 && dr["Expired"].ToString() == "0")  
                //    continue; 
                ListViewItem item = new ListViewItem(dr["bId"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                item.SubItems.Add(dr["bIsbn"].ToString());
                item.SubItems.Add(dr["bksName"].ToString());
                string returnDate = dr["end"].ToString().Split(' ')[0];
                item.SubItems.Add(returnDate);//归还日期
                item.SubItems.Add(dr["bHasBor"].ToString());
                if (dr["Expired"].ToString() == "1") //过期未还
                    item.SubItems.Add("逾期未还");
                else if (dr["Expired"].ToString() == "0") //未过期
                    item.SubItems.Add("借阅中"); //这个还得设置已归还和在借状态
                else if (dr["Expired"].ToString() == "-1") //已归还
                    item.SubItems.Add("已归还");
                this.listView1.Items.Add(item);
                //here to display 这里考虑的是历史已借，不能显示正在借的。
            }
        }
        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView7.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView7.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox4.Text = item.SubItems[0].Text;
            }

        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView8.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView8.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox6.Text = item.SubItems[0].Text;
            }

        }

        private void listView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView9.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView9.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox2.Text = item.SubItems[0].Text;
            }
        }
        private int GetMaxDays(string uid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select maxDays \r\nfrom priority\r\nnatural join reader\r\nwhere reader.uID ={0}", uid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            return int.Parse(db.Rows[0]["maxDays"].ToString());

        }
        private int GetRetimes(string uid) //比较权限和已经借过的次数，如果不能再续借则返回-1 否则返回应该加上这一次的续借次数
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select reMaxTimes \r\nfrom priority\r\nnatural join reader\r\nwhere reader.uID ={0}", uid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            int maxtime = int.Parse(db.Rows[0]["reMaxTimes"].ToString());
            sql = String.Format("select reTimes \r\nfrom borrowed\r\nwhere borrowed.bId = 1 \r\nand Rea_uID = '{0}'\r\nand Expired = 0;", uid);
            adapter = new MySqlDataAdapter(sql, conn);
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            int hasre = int.Parse(db.Rows[0]["reTimes"].ToString());
            if (hasre >= maxtime) return -1;
            else return hasre + 1;
        }
        private void button3_Click(object sender, EventArgs e) //第一次借书
        {
            String uid = this.textBox1.Text; 
            String bid = this.textBox2.Text;
            if(uid.Length <= 0 || bid.Length<= 0)
            {
                MessageBox.Show("用户编号和图书编号均不能为空！");
                ClearSelected();
            }
            else
            {
                int days = GetMaxDays(uid);
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = "select count(*) sum from borrowed;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                adapter.Fill(db);
                int old_sum = int.Parse(db.Rows[0]["sum"].ToString());
                sql = String.Format("call borrow_books('{0}',{1}, {2}, {3});", uid,bid,days,0);
                adapter = new MySqlDataAdapter(sql,conn);  
                adapter.Fill(db);
                sql = "select count(*) sum from borrowed;";
                adapter = new MySqlDataAdapter(sql, conn);
                db = new DataTable();
                adapter.Fill(db);
                int new_sum = int.Parse(db.Rows[0]["sum"].ToString());
                if (new_sum > old_sum)
                    MessageBox.Show("借阅成功！");
                else
                {
                    MessageBox.Show("借阅失败！");
                }
                conn.Close();//查询到数据之后就可以关掉了
                LoadBookInLibrary(this.listView9);
                LoadUserInfo(this.Readers_Info_Data);

            }
        }
        private String GetPriorityName(int i)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select pName from priority where pId = {0};", i);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return dr["pName"].ToString();
        }
        public void LoadUserInfo(ListView curview) //对应curview的读者信息
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = "select * from reader;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
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
                string status = getUserStatusName(dr["uState"].ToString());
                item.SubItems.Add(status);
                item.SubItems.Add(dr["uViolatedTimes"].ToString());
                item.SubItems.Add(dr["uContact"].ToString());

                string sexstr;
                if (dr["uSex"].ToString().Equals("0"))
                    sexstr = "男";
                else sexstr = "女";
                item.SubItems.Add(sexstr);
                item.SubItems.Add(dr["uValiDate"].ToString().Split()[0]);
                item.SubItems.Add(dr["uCurbor"].ToString());
                item.SubItems.Add(dr["uHasBor"].ToString());
                item.SubItems.Add(dr["remark"].ToString());
                item.SubItems.Add(dr["curViolate"].ToString());
                curview.Items.Add(item);
                //here to display
            }
        }
        private String getUserStatusName(string i)
        {
            switch (i)
            {
                case "0":
                    return "无效";
                case "1":
                    return "有效";
                default:
                    return "违规无效";
            }
        }
        private void ClearSelected()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearSelected();
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
                item.SubItems.Add(location);//图书位置 需要从编号转换成字符串
                string date = dr["bInDate"].ToString();
                string[] getDate = date.Split(' ');
                date = getDate[0];
                item.SubItems.Add(date);
                curList.Items.Add(item);
                //here to display
            }
        }
        private string GetBookState(int bState)
        {
            if (bState == 0)
            {
                return "已丢失";
            }
            else if (bState == 1)
            {
                return "在架上";
            }
            else
            {
                return "外借中";
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

        private void Library_Book_TabPage_Click(object sender, EventArgs e)
        {

        }
    }
}
