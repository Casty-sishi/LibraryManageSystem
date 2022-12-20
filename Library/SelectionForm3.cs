using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private void LoadBorrowedBooks()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,bookshelf.bksName,`start`,`end`,TO_DAYS(CURRENT_DATE)-TO_DAYS(`start`) bHasBor,borrowed.Expired,handleTime,borrowed.id\r\nfrom books \r\nnatural join borrowed \r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Expired =0;");
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            this.listView4.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["bId"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                //string bstate = GetBookState(int.Parse(dr["start"].ToString()));
                item.SubItems.Add(dr["start"].ToString().Split(' ')[0]); //状态 需要从编号转换成字符串
                item.SubItems.Add(dr["end"].ToString().Split(' ')[0]);
                //string location = GetBookLocation(int.Parse(dr["bksId"].ToString()));
                item.SubItems.Add(dr["bksName"].ToString());//图书位置 需要从编号转换成字符串
                //string date = dr["b"].ToString();
                //string[] getDate = date.Split(' ');
                //date = getDate[0];
                item.SubItems.Add(dr["bHasBor"].ToString());
                item.SubItems.Add(dr["handleTime"].ToString().Split(' ')[0]);
                item.SubItems.Add(dr["id"].ToString());
                this.listView4.Items.Add(item);
                //here to display
            }

        }
        private void LoadBorrowedBooksByUid(string uid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,bookshelf.bksName,`start`,`end`,TO_DAYS(CURRENT_DATE)-TO_DAYS(`start`) bHasBor,borrowed.Expired,handleTime,borrowed.id\r\nfrom books \r\nnatural join borrowed \r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Expired =0 and borrowed.Rea_uID = '{0}'",uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            this.listView4.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["bId"].ToString());
                item.SubItems.Add(dr["bName"].ToString());
                //string bstate = GetBookState(int.Parse(dr["start"].ToString()));
                item.SubItems.Add(dr["start"].ToString().Split(' ')[0]); //状态 需要从编号转换成字符串
                item.SubItems.Add(dr["end"].ToString().Split(' ')[0]);
                //string location = GetBookLocation(int.Parse(dr["bksId"].ToString()));
                item.SubItems.Add(dr["bksName"].ToString());//图书位置 需要从编号转换成字符串
                //string date = dr["b"].ToString();
                //string[] getDate = date.Split(' ');
                //date = getDate[0];
                item.SubItems.Add(dr["bHasBor"].ToString());
                item.SubItems.Add(dr["handleTime"].ToString().Split(' ')[0]);
                item.SubItems.Add(dr["id"].ToString());
                this.listView4.Items.Add(item);
                //here to display
            }

        }
        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView7.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView7.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox4.Text = item.SubItems[0].Text;//获得读者的编号
                    if (!check_uid(this.textBox4.Text))
                    {
                        LoadBorrowedBooksByUid(this.textBox4.Text);
                    }

            }

        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView8.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView8.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox6.Text = item.SubItems[0].Text;
                LoadViolateInfobyUid(this.textBox6.Text.Trim());
            }

        }
        private void LoadBookOnShelf()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select bIsbn,bName,bId,bState,bksId,bInDate from books natural join bookinfo where books.bState = 1;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.listView9.Items.Clear();//先将列表视图中现有行清空
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
                this.listView9.Items.Add(item);
                //here to display
            }
        }
        private void listView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView9.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView9.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox2.Text = item.SubItems[1].Text;
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
        private bool check_bid(int bid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select count(*) sum from books where books.bId={0};",bid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int result = int.Parse(db.Rows[0]["sum"].ToString());
            if (result > 0)
                return false;
            else return true;
        }
        private void button3_Click(object sender, EventArgs e) //第一次借书
        {
            String uid = this.textBox1.Text; 
            String bkid = this.textBox2.Text;
            if(uid.Length <= 0 || bkid.Length<= 0 || check_uid(uid) || check_bid(int.Parse(bkid)))
            {
                MessageBox.Show("用户编号或图书编号不存在！");
                ClearSelected();
            }
            else if (!ifUserVali(uid)) //续借需要进行用户账户状态的检查
            {
                MessageBox.Show("该用户状态处于无效状态，无法续借！");
                ClearSelected();
                this.textBox1.Clear();
                this.textBox2.Clear();
            }
            else
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    conn.Open();
                    String sql = String.Format("select maxDays m from priority  NATURAL join reader where reader.uID = \"{0}\"; ", uid);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    da.Fill(db);
                    int days = int.Parse(db.Rows[0]["m"].ToString());
                    sql = String.Format("call borrow_books('{0}', {1},{2},0);", uid, bkid, days);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int row = cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("借阅成功！");
                    LoadBookOnShelf();
                    LoadBorrowedBooks();
                } catch { MessageBox.Show("借阅失败！"); }

            }
            //else
            //{
            //    int days = GetMaxDays(uid);
            //    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            //    conn.Open();
            //    String sql = "select count(*) sum from borrowed;";
            //    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            //    DataTable db = new DataTable();
            //    adapter.Fill(db);
            //    int old_sum = int.Parse(db.Rows[0]["sum"].ToString());
            //    sql = String.Format("call borrow_books('{0}',{1}, {2}, {3});", uid,bid,days,0);
            //    adapter = new MySqlDataAdapter(sql,conn);  
            //    adapter.Fill(db);
            //    sql = "select count(*) sum from borrowed;";
            //    adapter = new MySqlDataAdapter(sql, conn);
            //    db = new DataTable();
            //    adapter.Fill(db);
            //    int new_sum = int.Parse(db.Rows[0]["sum"].ToString());
            //    if (new_sum > old_sum)
            //        MessageBox.Show("借阅成功！");
            //    else
            //    {
            //        MessageBox.Show("借阅失败！");
            //    }
            //    conn.Close();//查询到数据之后就可以关掉了
            //    LoadBookInLibrary(this.listView9);
            //    LoadUserInfo(this.Readers_Info_Data);

            //}
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
        private void LoadUserInfo(System.Windows.Forms.ListView curview) //对应curview的读者信息
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
            LoadUserInfo(this.Readers_Info_Data);
            LoadBookOnShelf();
        }
        private void LoadBookInLibrary(System.Windows.Forms.ListView curList) //Todo 对应form2的馆藏信息 有个逻辑处理(bid->bname)
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

        private bool check_uid(string uid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select count(*) m from reader where uID = '{0}';", uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int rows = int.Parse(db.Rows[0]["m"].ToString());
            if (rows > 0)
                return false;
            else return true;

        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Visible == false || this.textBox1.Text.Length <= 0)
            {
                MessageBox.Show("请输入读者编号！");
            }
            else
            {
                String uid = this.textBox1.Text;
                if (check_uid(uid)) MessageBox.Show("该用户编号不存在！");
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                    conn.Open();
                    string sql = String.Format("select * from reader where uID = '{0}';", uid);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    adapter.Fill(db);
                    conn.Close();//查询到数据之后就可以关掉了
                    this.Readers_Info_Data.Items.Clear();//先将列表视图中现有行清空
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
                        Readers_Info_Data.Items.Add(item);
                        //here to display
                    }
                }

            }

        }

        private void button6_Click(object sender, EventArgs e) //图书借阅界面查询图书
        {
            if (this.textBox2.ReadOnly == true || this.textBox2.Text.Length <= 0)
            {
                MessageBox.Show("请清空界面并双击图书编号以输入待查图书编号！");
            }
            else
            {
                string bkindex = this.textBox2.Text;
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("select bIsbn,bName,bId,bState,bksId,bInDate from books natural join bookinfo where books.bId = '{0}' and books.bState=1;", int.Parse(bkindex));
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView9.Items.Clear();
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
                    listView9.Items.Add(item);
                    //here to display
                }
            }
        }
        private void LoadViolateInfo() //这个是展示所有的违规记录 
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select violateinfo.`index`,time,violateinfo.uid,bkid,bookinfo.bName,bookinfo.bPrice,ifFined,finedMoney,violateevent.vName,violateinfo.borrowedid\r\nfrom violateinfo\r\njoin violateevent on violateinfo.violateid = violateevent.vid\r\njoin books on violateinfo.bkid = books.bId\r\njoin bookinfo on books.bIsbn = bookinfo.bIsbn;");
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            this.listView1.Items.Clear();
            foreach(DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["index"].ToString());
                item.SubItems.Add(dr["time"].ToString().Split(' ')[0]);
                item.SubItems.Add(dr["uid"].ToString());
                item.SubItems.Add(dr["bkid"].ToString());
                //string returnDate = dr["end"].ToString().Split(' ')[0];
                //item.SubItems.Add(returnDate);//归还日期
                item.SubItems.Add(dr["bName"].ToString());
                item.SubItems.Add(dr["bPrice"].ToString());
                item.SubItems.Add(dr["vName"].ToString());
                item.SubItems.Add(dr["finedMoney"].ToString());
                int iffined = int.Parse(dr["ifFined"].ToString());
                string finedstate;
                if (iffined == 1)
                {
                    finedstate = "已缴清罚款";
                }
                else finedstate = "未缴清罚款";
                item.SubItems.Add(finedstate);
                item.SubItems.Add(dr["borrowedid"].ToString());
                this.listView1.Items.Add(item);
            }
        }

        private void Reader_Manager_Button_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox4.Clear();
            this.textBox3.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            this.label10.Text = "序号";
            LoadBorrowedBooks();
            LoadUserInfo(this.listView7);
        }

        private bool ifUserVali(string uid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select count(*) sum from reader where reader.uId = '{0}' and reader.uState = 1;",uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db); 
            conn.Close();
            int rows = int.Parse(db.Rows[0]["sum"].ToString());
            if (rows > 0)
                return true;
            else return false;
        }
        private void button1_Click(object sender, EventArgs e) //还书
        {
            string bkid = this.textBox3.Text.Trim();
            string uid = this.textBox4.Text.Trim();
            string startdate = this.textBox7.Text.Trim();
            string enddate = this.textBox8.Text.Trim();
            //todo
            if (bkid.Length <= 0 || uid.Length <= 0 || check_uid(uid) || check_bid(int.Parse(bkid)) || startdate.Length<=0)
            {
                MessageBox.Show("请选中对应记录！");
            }
            //else if (!ifUserVali(uid)) //还书不需要进行用户账户状态的检查
            //{
            //    MessageBox.Show("用户")
            //}
            else
            {
                DateTime bkOut;
                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";
                bkOut = Convert.ToDateTime(startdate, dtFormat);
                string start = bkOut.Year.ToString() + "/" + bkOut.Month.ToString() + "/" + bkOut.Day.ToString();
                bkOut = Convert.ToDateTime(enddate, dtFormat);
                string end = bkOut.Year.ToString() + "/" + bkOut.Month.ToString() + "/" + bkOut.Day.ToString();
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    conn.Open();
                    String sql = String.Format("set @s = -2;\r\ncall return_books({0},'{1}','{2}','{3}',0,@s); #还书测试\r\nselect @s `out`;", int.Parse(bkid), uid, end, start);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    da.Fill(db);
                    conn.Close();
                    int status = int.Parse(db.Rows[0]["out"].ToString());
                    if(status == 3 )
                    {
                        MessageBox.Show("还书成功！");
                        ClearSelected();
                        this.textBox4.Clear();
                        this.textBox3.Clear();
                        this.textBox7.Clear();
                        this.textBox8.Clear();
                        LoadBorrowedBooks();
                        LoadBookOnShelf();
                    }
                    else if (status == -1)
                {
                    MessageBox.Show("该借阅记录不存在，还书失败！");
                    ClearSelected();
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    LoadBorrowedBooks();
                       
                    }
                    else if(status == -2)
                {
                    MessageBox.Show("系统错误，还书失败！");
                    ClearSelected();
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    LoadBorrowedBooks();
                }
                }
                catch
                {
                    MessageBox.Show("系统错误，还书失败！");
                    ClearSelected();
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    LoadBorrowedBooks();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)//续借
        {
            string bkid = this.textBox3.Text.Trim();
            string uid = this.textBox4.Text.Trim();
            string startdate = this.textBox7.Text.Trim();
            string enddate = this.textBox8.Text.Trim();
            //todo
            if (bkid.Length <= 0 || uid.Length <= 0 || check_uid(uid) || check_bid(int.Parse(bkid)) || startdate.Length <= 0)
            {
                MessageBox.Show("请选中对应记录！");
            }
            else if (!ifUserVali(uid)) //续借需要进行用户账户状态的检查
            {
                MessageBox.Show("该用户状态处于无效状态，无法续借！");
                ClearSelected();
                this.textBox4.Clear();
                this.textBox3.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                LoadBorrowedBooks();
            }
            else
            {
                DateTime bkOut;
                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";
                bkOut = Convert.ToDateTime(startdate, dtFormat);
                string start = bkOut.Year.ToString() + "/" + bkOut.Month.ToString() + "/" + bkOut.Day.ToString();
                bkOut = Convert.ToDateTime(enddate, dtFormat);
                string end = bkOut.Year.ToString() + "/" + bkOut.Month.ToString() + "/" + bkOut.Day.ToString();
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    conn.Open();
                    String sql = String.Format("set @s = -2;\r\ncall return_books({0},'{1}','{2}','{3}',1,@s); #还书测试\r\nselect @s `out`;", int.Parse(bkid), uid, end, start);
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    da.Fill(db);
                    conn.Close();
                    int status = int.Parse(db.Rows[0]["out"].ToString());
                    if (status == 1)
                    {
                        MessageBox.Show("续借成功！");
                        ClearSelected();
                        this.textBox4.Clear();
                        this.textBox3.Clear();
                        this.textBox7.Clear();
                        this.textBox8.Clear();
                        LoadBorrowedBooks();
                    }
                    else if (status == -1)
                    {
                        MessageBox.Show("该借阅记录不存在，续借失败！");
                        ClearSelected();
                        this.textBox4.Clear();
                        this.textBox3.Clear();
                        this.textBox7.Clear();
                        this.textBox8.Clear();
                        LoadBorrowedBooks();
                    }
                    else if (status == -2)
                    {
                        MessageBox.Show("系统错误，续借失败！");
                        ClearSelected();
                        this.textBox4.Clear();
                        this.textBox3.Clear();
                        this.textBox7.Clear();
                        this.textBox8.Clear();
                        LoadBorrowedBooks();
                    }else if (status == 2)
                    {
                        MessageBox.Show("该用户已达最大借阅次数，不可再次续借！");
                        ClearSelected();
                        this.textBox4.Clear();
                        this.textBox3.Clear();
                        this.textBox7.Clear();
                        this.textBox8.Clear();
                        LoadBorrowedBooks();
                    }
                }
                catch
                {
                    MessageBox.Show("系统错误，续借失败！");
                    ClearSelected();
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    LoadBorrowedBooks();
                }

            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView4.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView4.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox3.Text = item.SubItems[0].Text;//获得图书的编号
                this.textBox7.Text = item.SubItems[2].Text;
                this.textBox8.Text = item.SubItems[3].Text;
                this.label10.Text = item.SubItems[7].Text;
            }
        }

        private void button12_Click(object sender, EventArgs e)//查询读者
        {
            if (this.textBox1.Visible == false || this.textBox1.Text.Length <= 0)
            {
                MessageBox.Show("请输入读者编号！");
            }
            else
            {
                String uid = this.textBox1.Text;
                if (check_uid(uid)) MessageBox.Show("该用户编号不存在！");
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                    conn.Open();
                    string sql = String.Format("select * from reader where uID = '{0}';", uid);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    adapter.Fill(db);
                    conn.Close();//查询到数据之后就可以关掉了
                    this.listView7.Items.Clear();//先将列表视图中现有行清空
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
                        this.listView7.Items.Add(item);
                        //here to display
                    }
                }

            }
        }

        private void button9_Click(object sender, EventArgs e)//查询borrwed图书
        {
            if (this.textBox3.Text.Length <= 0 || this.textBox4.Text.Length<=0)
            {
                MessageBox.Show("请输入待查图书编号和读者编号！");
            }
            else
            {
                string uid = this.textBox4.Text.Trim();
                string bkindex = this.textBox3.Text;
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("select borrowed.bId,bookinfo.bName,bookshelf.bksName,`start`,`end`,TO_DAYS(CURRENT_DATE)-TO_DAYS(`start`) bHasBor,borrowed.Expired,handleTime\r\nfrom books \r\nnatural join borrowed \r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Expired =0 and books.bId={0} and borrowed.Rea_uID ='{1}';", int.Parse(bkindex),uid);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView4.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["bId"].ToString());
                    item.SubItems.Add(dr["bName"].ToString());
                    //string bstate = GetBookState(int.Parse(dr["start"].ToString()));
                    item.SubItems.Add(dr["start"].ToString().Split(' ')[0]); //状态 需要从编号转换成字符串
                    item.SubItems.Add(dr["end"].ToString().Split(' ')[0]);
                    //string location = GetBookLocation(int.Parse(dr["bksId"].ToString()));
                    item.SubItems.Add(dr["bksName"].ToString());//图书位置 需要从编号转换成字符串
                                                                //string date = dr["b"].ToString();
                                                                //string[] getDate = date.Split(' ');
                                                                //date = getDate[0];
                    item.SubItems.Add(dr["bHasBor"].ToString());
                    item.SubItems.Add(dr["handleTime"].ToString().Split(' ')[0]);
                    this.listView4.Items.Add(item);
                    //here to display
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadViolateInfobyUid(string uid)//展示所有人的违规记录
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select violateinfo.`index`,time,violateinfo.uid,bkid,bookinfo.bName,bookinfo.bPrice,ifFined,finedMoney,violateevent.vName,violateinfo.borrowedid\r\nfrom violateinfo\r\njoin violateevent on violateinfo.violateid = violateevent.vid\r\njoin books on violateinfo.bkid = books.bId\r\njoin bookinfo on books.bIsbn = bookinfo.bIsbn where violateinfo.uid='{0}';",uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            this.listView1.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["index"].ToString());
                item.SubItems.Add(dr["time"].ToString().Split(' ')[0]);
                item.SubItems.Add(dr["uid"].ToString());
                item.SubItems.Add(dr["bkid"].ToString());
                //string returnDate = dr["end"].ToString().Split(' ')[0];
                //item.SubItems.Add(returnDate);//归还日期
                item.SubItems.Add(dr["bName"].ToString());
                item.SubItems.Add(dr["bPrice"].ToString());
                item.SubItems.Add(dr["vName"].ToString());
                item.SubItems.Add(dr["finedMoney"].ToString());
                int iffined= int.Parse(dr["ifFined"].ToString());
                string finedstate;
                if (iffined == 1)
                {
                    finedstate = "已缴清罚款";
                }
                else finedstate = "未缴清罚款";
                item.SubItems.Add(finedstate);
                item.SubItems.Add(dr["borrowedid"].ToString());
                this.listView1.Items.Add(item);
            }

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                this.textBox5.Text = item.SubItems[3].Text;
                this.label9.Text = item.SubItems[0].Text;
                this.textBox6.Text= item.SubItems[2].Text;
                this.label11.Text= item.SubItems[9].Text;//借阅序号
                //下面的注释是想设置visible,但是也有点麻烦，但弄完主体功能再说吧。
                //if (item.SubItems[6].Text == "逾期未还") { 
                    
                //}
                //else
                //{

                //}
            }
        }

        private void clearall()
        {
            this.label11.Text = "借阅序号";
            this.label9.Text = "事件序号";
            this.textBox6.Clear();
            this.textBox5.Clear();
            LoadViolateInfo();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            clearall();
            LoadUserInfo(this.listView8);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.textBox6.Text.Length <= 0)
            {
                MessageBox.Show("请输入读者编号！");
            }
            else
            {
                String uid = this.textBox6.Text.Trim();
                if (check_uid(uid)) MessageBox.Show("该用户编号不存在！");
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                    conn.Open();
                    string sql = String.Format("select * from reader where uID = '{0}';", uid);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    adapter.Fill(db);
                    conn.Close();//查询到数据之后就可以关掉了
                    this.listView8.Items.Clear();//先将列表视图中现有行清空
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
                        this.listView8.Items.Add(item);
                        //here to display
                    }
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)//逾期罚款
        {
            //如果书过期，还钱。总的思路和return_books差不多，但是要改一下
            string violatekey = this.label9.Text.Trim();
            string borrowedkey = this.label11.Text.Trim();
            string uid = this.textBox6.Text.Trim();
            string bkid = this.textBox5.Text.Trim();
            if(violatekey.Length==0 || borrowedkey.Length==0 || uid.Length == 0 || bkid.Length == 0)
            {
                MessageBox.Show("请选中记录再进行操作！");
            }
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = 0;\r\ncall overflow_violate({0},{1},{2},'{3}',@s);\r\nselect @s `out`;", int.Parse(violatekey),int.Parse(borrowedkey),int.Parse(bkid),uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["out"].ToString());
            if(status == -1)
            {
                MessageBox.Show("系统错误！逾期缴款失败！");
            }else if (status == 1)
            {
                MessageBox.Show("逾期缴款成功！");
                this.label9.Text = "事件序号";
                this.label11.Text = "借阅序号";
                this.textBox6.Clear();
                this.textBox5.Clear();
                LoadViolateInfo();
            }
        }

        private void button14_Click(object sender, EventArgs e)//丢失罚款，
        {
            //这里有两种情况，如果书过期了，那么逾期的钱+丢失的钱都要还，分别还
            //如果书没过期，就还丢失的钱。总的思路和return_books差不多，但是要改一下
            //如果书过期，还钱。总的思路和return_books差不多，但是要改一下
            string violatekey = this.label9.Text.Trim();
            string borrowedkey = this.label11.Text.Trim();
            string uid = this.textBox6.Text.Trim();
            string bkid = this.textBox5.Text.Trim();
            if (violatekey.Length == 0 || borrowedkey.Length == 0 || uid.Length == 0 || bkid.Length == 0)
            {
                MessageBox.Show("请选中记录再进行操作！");
            }
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = 0;\r\ncall lost_violate({0},{1},{2},'{3}',@s);\r\nselect @s `out`;", int.Parse(violatekey), int.Parse(borrowedkey),int.Parse(bkid),uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["out"].ToString());
            if (status == -1)
            {
                MessageBox.Show("系统错误！丢失缴款失败！");
            }
            else if (status == 1)
            {
                MessageBox.Show("丢失缴款成功！");
                this.label9.Text = "事件序号";
                this.label11.Text = "借阅序号";
                this.textBox6.Clear();
                this.textBox5.Clear();
                LoadViolateInfo();
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //如果书过期，还钱。总的思路和return_books差不多，但是要改一下
            string violatekey = this.label9.Text.Trim();
            string borrowedkey = this.label11.Text.Trim();
            string uid = this.textBox6.Text.Trim();
            string bkid = this.textBox5.Text.Trim();
            if (violatekey.Length == 0 || borrowedkey.Length == 0 || uid.Length == 0 || bkid.Length == 0)
            {
                MessageBox.Show("请选中记录再进行操作！");
            }
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = 0;\r\ncall delete_violate({0},{1},{2},'{3}',@s);\r\nselect @s `out`;", int.Parse(violatekey), int.Parse(borrowedkey),int.Parse(bkid),uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["out"].ToString());
            if (status == -1)
            {
                MessageBox.Show("系统错误！删除记录失败！");
            }
            else if (status == 1)
            {
                MessageBox.Show("删除记录成功！");
                this.label9.Text = "事件序号";
                this.label11.Text = "借阅序号";
               this.textBox6.Clear();
                this.textBox5.Clear();
                LoadViolateInfo();
            }
        }

        private void button10_Click(object sender, EventArgs e)//查询违规记录的图书
        {
            string bkid = this.textBox5.Text.Trim();
            if(bkid.Length == 0)
            {
                MessageBox.Show("请输入图书编号！");
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                conn.Open();
                String sql = String.Format("select violateinfo.`index`,time,violateinfo.uid,bkid,bookinfo.bName,bookinfo.bPrice,ifFined,finedMoney,violateevent.vName,violateinfo.borrowedid\r\nfrom violateinfo\r\njoin violateevent on violateinfo.violateid = violateevent.vid\r\njoin books on violateinfo.bkid = books.bId\r\njoin bookinfo on books.bIsbn = bookinfo.bIsbn where violateinfo.bkid = {0};",int.Parse(bkid));
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView1.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["index"].ToString());
                    item.SubItems.Add(dr["time"].ToString().Split(' ')[0]);
                    item.SubItems.Add(dr["uid"].ToString());
                    item.SubItems.Add(dr["bkid"].ToString());
                    //string returnDate = dr["end"].ToString().Split(' ')[0];
                    //item.SubItems.Add(returnDate);//归还日期
                    item.SubItems.Add(dr["bName"].ToString());
                    item.SubItems.Add(dr["bPrice"].ToString());
                    item.SubItems.Add(dr["vName"].ToString());
                    item.SubItems.Add(dr["finedMoney"].ToString());
                    int iffined = int.Parse(dr["ifFined"].ToString());
                    string finedstate;
                    if (iffined == 1)
                    {
                        finedstate = "已缴清罚款";
                    }
                    else finedstate = "未缴清罚款";
                    item.SubItems.Add(finedstate);
                    item.SubItems.Add(dr["borrowedid"].ToString());
                    this.listView1.Items.Add(item);
                }

            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            // 图书挂失，是给来登记挂失，但是暂时没有因为各种原因
            //不能当场给钱的，逾期的日子也登记到今天。

            string uid = this.textBox4.Text.Trim();
            string bkid = this.textBox3.Text.Trim();
            string index = this.label10.Text.Trim();
            if(uid.Length == 0 || bkid.Length == 0 || index.Length==0 || check_uid(uid) || check_bid(int.Parse(bkid))){
                MessageBox.Show("请选中记录！");
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                conn.Open();
                String sql = String.Format(" set @s = 3;\r\n call handle_book_lost({0},@s);\r\n select @s `out`;",int.Parse(index));
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                int status = int.Parse((db.Rows[0]["out"].ToString()));
                if(status == 1)
                {
                    MessageBox.Show("挂失成功！请于违规界面处理该违规事件！");
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    this.label10.Text = "序号";
                    LoadBorrowedBooks();
                }
                else
                {
                    MessageBox.Show("系统错误，挂失失败！");
                    this.textBox4.Clear();
                    this.textBox3.Clear();
                    this.textBox7.Clear();
                    this.textBox8.Clear();
                    this.label10.Text = "序号";
                }


            }
        }
    }
}
