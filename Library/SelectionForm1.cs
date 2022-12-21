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
        InputUidForm input_uid_form = new InputUidForm();
        SelectionForm2 bookform = new SelectionForm2 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        SelectionForm3 borrowreturnform = new SelectionForm3 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
        public SelectionForm()
        {
            InitializeComponent();
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
        private int GetPriorityId(string priority)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select pId from priority where pName = '{0}';", priority);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            DataRow dr = db.Rows[0];
            return int.Parse(dr["pId"].ToString());
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
        private string GetPublisherName(int pubid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select pName from publisher where pubId ={0} ", pubid);
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
        private void LoadUserBookInfo(string userid, int type) //对用form1的历史已借 type=1说明显示的是在借的，type=0说明显示的是已还的，type=2说明是过期的
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,books.bIsbn,bookshelf.bksName,`end`,books.bksId,TO_DAYS(CURRENT_DATE)-TO_DAYS(`start`) bHasBor,borrowed.Expired,borrowed.handleTime \r\nfrom books\r\nnatural join borrowed\r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Rea_uID = '{0}'and borrowed.Expired <> 0;", userid);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.listView1.Items.Clear();//先将列表视图中现有行清空
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
                else if (dr["Expired"].ToString() == "2") //已归还
                    item.SubItems.Add("已归还");
                else if (dr["Expired"].ToString() == "3")
                    item.SubItems.Add("已丢失且欠费");
                else if (dr["Expired"].ToString() == "5")
                    item.SubItems.Add("逾期已缴费");
                else item.SubItems.Add("已丢失");
                item.SubItems.Add(dr["handleTime"].ToString().Split(' ')[0]);
                this.listView1.Items.Add(item);
                //here to display 这里考虑的是历史已借，不能显示正在借的。
            }
        }
        private void LoadPriorityToUserState()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;uid=root;pwd=123456;");
            conn.Open();
            string sql = string.Format("select pname from priority;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();
            foreach (DataRow dr in db.Rows)
            {
                this.textBox4.Items.Add(dr["pName"].ToString());
            }
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
        public void SetAdminLabel(String admName) //设置登录界面跳转过来的管理员名字
        {
            this.Admin_Name_Label.Text = admName;
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
            bookform.LoadTypeCombox();
            bookform.LoadPublisherCombox();
            bookform.Show();
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
            borrowreturnform.listView9.Items.Clear();//先将列表视图中现有行清空
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
                borrowreturnform.listView9.Items.Add(item);
                //here to display
            }
        }
        private void LoadBorrowedBooks()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select borrowed.bId,bookinfo.bName,bookshelf.bksName,`start`,`end`,TO_DAYS(CURRENT_DATE)-TO_DAYS(`start`) bHasBor,borrowed.Expired,handleTime,borrowed.id,borrowed.reTimes,borrowed.Rea_uID \r\nfrom books \r\nnatural join borrowed \r\nnatural join bookshelf\r\nnatural join bookinfo\r\nwhere borrowed.Expired =0;");
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            borrowreturnform.listView4.Items.Clear();
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
                item.SubItems.Add(dr["reTimes"].ToString());
                item.SubItems.Add(dr["Rea_uID"].ToString());
                borrowreturnform.listView4.Items.Add(item);
                //here to display
            }

        }

        private void LoadViolateInfo()//展示所有人的违规记录
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("select violateinfo.`index`,time,violateinfo.uid,bkid,bookinfo.bName,bookinfo.bPrice,ifFined,finedMoney,violateevent.vName,violateinfo.borrowedid\r\nfrom violateinfo\r\njoin violateevent on violateinfo.violateid = violateevent.vid\r\njoin books on violateinfo.bkid = books.bId\r\njoin bookinfo on books.bIsbn = bookinfo.bIsbn;");
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            borrowreturnform.listView1.Items.Clear();
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
                borrowreturnform.listView1.Items.Add(item);
            }

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
            LoadBookOnShelf();
            LoadBorrowedBooks();
            LoadViolateInfo();
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
            ClearUserInfo();
            LoadUserInfo(this.Readers_Info_Data);
        }
        private void ClearUserInfo()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox8.Clear();
            this.textBox9.Clear();
            this.textBox7.Text = "";
            this.textBox4.Text = "";
            this.label9.Text = "读者编号";
        }
        private void LoadBorrwoedBook(int userid) //SelectionForm3的图书罚款
        {
            //MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            //conn.Open();
            //String sql = "select * from borrowed ";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            //DataTable db = new DataTable();
            //adapter.Fill(db);
            //conn.Close();//查询到数据之后就可以关掉了
            //borrowreturnform.listView1.Items.Clear();//先将列表视图中现有行清空
            //foreach (DataRow dr in db.Rows)
            //{
            //    ListViewItem item = new ListViewItem(dr["bId"].ToString());
            //    item.SubItems.Add(dr["uName"].ToString());
            //    string priority = GetPriorityName(int.Parse(dr["pId"].ToString()));
            //    item.SubItems.Add(priority);
            //    item.SubItems.Add(dr["uRegistry"].ToString());
            //    string status = getStatusName(dr["uState"].ToString());
            //    item.SubItems.Add(status);
            //    item.SubItems.Add(dr["uViolatedTimes"].ToString());
            //    item.SubItems.Add(dr["uContact"].ToString());
            //    item.SubItems.Add(dr["uSex"].ToString());
            //    item.SubItems.Add(dr["uValiDate"].ToString());
            //    item.SubItems.Add(dr["uCurbor"].ToString());
            //    item.SubItems.Add(dr["uHasBor"].ToString());
            //    item.SubItems.Add(dr["remark"].ToString());
            //    curview.Items.Add(item);
            //    //here to display
            //}
        }
        private void SelectionForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo(this.Readers_Info_Data); // 一开始Load的时候应该是form1的ListView
            LoadPriorityToUserState();
        }

        private void Readers_Info_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label9.Visible = true;
            this.textBox9.Visible = false;
            if (this.Readers_Info_Data.SelectedItems.Count > 0)
            {
                ListViewItem item = this.Readers_Info_Data.SelectedItems[0];//获取选中的第一行（一次只能选中一行）
                if (!item.SubItems[4].Text.Equals("有效"))
                {
                    foreach (TextBoxBase c in this.Readers_Info_Table.Controls.OfType<TextBoxBase>())
                    {
                        c.ReadOnly = true;
                    }
                    this.textBox4.DropDownStyle = ComboBoxStyle.DropDownList;

                }
                else
                {
                    this.textBox5.ReadOnly = false;
                    this.textBox4.DropDownStyle = ComboBoxStyle.DropDown;
                    this.textBox1.ReadOnly = false;
                    this.textBox3.ReadOnly = false;
                }
                this.textBox5.Text = item.SubItems[7].Text;//性别 可改
                this.textBox4.Text = item.SubItems[2].Text; //读者类别 可改
                this.textBox1.Text = item.SubItems[1].Text;//读者姓名 可改
                this.textBox7.Text = item.SubItems[4].Text;//状态 只读
                this.textBox2.Text = item.SubItems[5].Text;//违规次数 只读
                this.textBox6.Text = item.SubItems[8].Text;//有效期 只读
                this.textBox3.Text = item.SubItems[6].Text;//联系方式 可改
                this.label9.Text = item.SubItems[0].Text;//读者编号 只读
                this.textBox8.Text = item.SubItems[12].Text;//罚款金额 只读 }

                LoadUserBookInfo(this.label9.Text, 0);

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.label9.Visible = false;
            this.textBox9.Visible = true;

        }

        private void Reader_Tab_Control_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) //保存修改
        {
            this.label9.Visible = true;
            this.textBox9.Visible = false;
            if (this.textBox7.Text.Equals("有效"))
            {
                try
                {
                    String uName = this.textBox1.Text; //用户名字可改 varchar
                    String uSex = this.textBox5.Text; //用户性别可改 int
                    int sexid;
                    if (uSex.Contains('男'))
                        sexid = 0;
                    else sexid = 1;
                    String uPriority = this.textBox4.Text;//用户类别可改 int
                    int uPid = GetPriorityId(uPriority);
                    String uContact = this.textBox3.Text;//用户联系方式可改 varchar
                    String uid = this.label9.Text;
                    if (uName.Length > 0 && uContact.Length > 0 && !uid.Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                        conn.Open();
                        String sql = String.Format("update reader set uName='{0}',uContact='{1}', pId ={2},uSex={3} where uID ='{4}';", uName, uContact, uPid, sexid, uid);
                        MySqlCommand command = new MySqlCommand(sql, conn);
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("已经成功修改！");
                            LoadUserInfo(this.Readers_Info_Data);
                        }
                        else
                        {
                            MessageBox.Show("修改失败，请检查输入是否符合规范！");
                        }
                        conn.Close();//查询到数据之后就可以关掉了

                    }
                    else
                    {
                        MessageBox.Show("输入为空，请重新输入！");
                    }
                }
                catch(Exception ex) { MessageBox.Show("系统错误！" + ex); }

            }
            else
            {
                MessageBox.Show("用户状态无效，无法修改保存！");
            }


        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private bool check_uid(string uid)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select count(*) m from reader where uID = '{0}';", uid);
            MySqlDataAdapter da = new MySqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (int.Parse(dt.Rows[0]["m"].ToString()) > 0)
                return false;
            else return true;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            String uid = this.textBox9.Text;
            if (check_uid(uid))
            {
                String uName = this.textBox1.Text;
                String uSex = this.textBox5.Text;
                int sexid;
                if (uSex.Contains('男'))
                    sexid = 0;
                else sexid = 1;
                int priorityIndex = this.textBox4.SelectedIndex;
                int pid = priorityIndex + 1;
                String uContact = this.textBox3.Text;
                conn.Open();
                try
                {
                    String sql = String.Format("insert into reader values('{0}',{1},'{2}',CURRENT_DATE,1,0,'{3}',{4},DATE_ADD(CURRENT_DATE, INTERVAL 1 YEAR),0,0,NULL,0); ", uid, pid, uName, uContact, sexid);
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("用户信息添加成功！");
                        LoadUserInfo(this.Readers_Info_Data);
                    }
                    else
                    {
                        MessageBox.Show("用户信息添加失败，请检查输入是否符合标准。");
                        ClearUserInfo();
                    }

                }
                catch
                {
                    MessageBox.Show("用户信息添加失败，请检查输入是否符合标准。");
                    ClearUserInfo();
                }
            }
            else { MessageBox.Show("读者编号已存在！"); }

            this.label9.Visible = true;
            this.textBox9.Visible = false;

        }

        private void textBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_VisibleChanged(object sender, EventArgs e)
        {
            this.textBox9.ReadOnly = false;
            this.textBox5.ReadOnly = false;
            this.textBox4.DropDownStyle = ComboBoxStyle.DropDown;
            this.textBox1.ReadOnly = false;
            this.textBox3.ReadOnly = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.label9.Visible = true;
            this.textBox9.Visible = false;
            if (this.textBox7.Text.Contains("无效"))
            {
                MessageBox.Show("该用户已处于无效状态！");
            }
            else
            {
                if (this.label9.Text.Length > 0)
                {
                    
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    String sql = String.Format("set @tmp = 10;call cancel_user('{0}',@tmp);select @tmp as tmp_out;", this.label9.Text);
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0]["tmp_out"].ToString().Equals("0") || dt.Rows[0]["tmp_out"].ToString().Equals("-1")) //成功设置
                    {
                        MessageBox.Show("该用户成功注销！");
                    }
                    else
                    {
                        MessageBox.Show("该用户无法注销！");
                    }
                    LoadUserInfo(this.Readers_Info_Data);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.label9.Visible = true;
            this.textBox9.Visible = false;
            if (this.textBox7.Text.Equals("有效"))
            {
                MessageBox.Show("该用户状态为有效，无需更新！");
            }
            else
            {
                if (this.label9.Text.Length == 0)
                    MessageBox.Show("用户编号不能为零！");
                else
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                    conn.Open();
                    String sql = String.Format("call change_uState('{0}',1)", this.label9.Text);
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    int rows = command.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("修改成功！");
                        LoadUserInfo(this.Readers_Info_Data);
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.textBox9.Visible == false || this.textBox9.Text.Length <= 0)
            {
                MessageBox.Show("请清空界面并输入读者编号！");
            }
            else
            {
                String uid = this.textBox9.Text;
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

        private void button7_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();

        }
    }
}
