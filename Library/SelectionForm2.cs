using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
            this.label8.Visible = true;
            this.textBox14.Visible = false;
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                this.textBox5.Text = item.SubItems[5].Text; //图书名称
                this.label8.Text = item.SubItems[0].Text; //图书ISBN
                this.textBox16.Text = item.SubItems[4].Text;//图书版本
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
            this.textBox1.ReadOnly = true;
            this.label1.Visible = true;
            this.textBox15.Visible = false;
            if (this.listView3.SelectedItems.Count>0)
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

        private void button2_Click(object sender, EventArgs e) //清空出版社信息
        {
            this.textBox8.Clear(); //出版社编号
            this.textBox9.Clear();//出版社名称
            this.textBox10.Clear();//出版社地址
            this.textBox11.Clear();//出版社邮箱
            this.textBox12.Clear();//出版社联系方式
            LoadPubilsherInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.label8.Visible = true;
            this.textBox14.Visible = false;
            this.textBox5.Clear(); //图书名称
            this.label8.Text = "Isbn"; //图书ISBN
            this.textBox16.Text=null;//图书版本
            this.comboBox3.Text = null;//出版社名字
            this.comboBox1.Text = null;//图书类型
            this.richTextBox1.Clear();//图书简介
            this.textBox13.Clear();//图书作者
            this.textBox7.Clear();//图书价格
            this.textBox6.Clear();//图书出版日期
            LoadBookInfo();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;
            this.label1.Visible = true;
            this.textBox15.Visible = false;
            this.textBox1.Clear(); //图书编号
            this.label1.Text = "Isbn"; //图书ISBN
            this.textBox2.Clear();//图书名字
            this.textBox3.Clear();//图书状态
            this.textBox4.Clear();//图书位置
            this.label7.Text = "/"; ;//图书入库日期
            LoadBookInLibrary();
        }
        //如果输入位置已有书籍，则返回true
        //如果输入位置没有书籍，则直接插入
        private int InsertBookLocations(string location,int bkid)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                conn.Open();
                String sql = String.Format("set @st = 0;\r\ncall insert_into_bookshelf('{0}',{1},@st);\r\nselect @st as`out`;", location,bkid);
                MySqlDataAdapter da = new MySqlDataAdapter(sql,conn);
                DataTable db = new DataTable();
                da.Fill(db);
                return int.Parse(db.Rows[0]["out"].ToString());
            }
            catch
            {
                return 0;
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
        private void LoadBookInLibrary() //Todo 对应form2的馆藏信息 有个逻辑处理(bid->bname)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select bIsbn,bName,bId,bState,bksId,bInDate from books natural join bookinfo;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();//查询到数据之后就可以关掉了
            this.listView3.Items.Clear();//先将列表视图中现有行清空
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
                listView3.Items.Add(item);
                //here to display
            }
        }
        private void button5_Click(object sender, EventArgs e) //馆藏信息的修改，图书名字不能修改
        {
            this.textBox1.ReadOnly =true;
            this.label1.Visible = true;
            this.textBox15.Visible = false;
            if (this.textBox4.Text.Length>0 && this.textBox1.Text.Length>0 && this.textBox2.Text.Length>0 )
            {
                string locate = this.textBox4.Text;
                int bkid = int.Parse(this.textBox1.Text);
                int s = InsertBookLocations(locate,bkid);//这里一起处理修改书籍位置的逻辑
                if (s == 1)
                {
                    MessageBox.Show("成功修改!");//还要reload一下
                    LoadBookInLibrary();
                }
                else if(s == 0){
                    MessageBox.Show("该图书位置已有图书，请更改至其余位置！");
                    this.textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("系统内部错误，插入失败，请尝试其余位置！");
                    this.textBox4.Clear();
                }
            }
            else
            {
                MessageBox.Show("请选中图书并输入图书位置！");
            }
        }
        private bool ifHasBook(string isbn)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select wId from bookinfo where bIsbn = '{0}'", isbn);
            MySqlDataAdapter da = new MySqlDataAdapter(sql,conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            return db.Rows[0]["wId"] == null ? false : true;

        }
        private void button9_Click(object sender, EventArgs e) //馆藏信息添加
        {
            this.textBox1.ReadOnly = true;
            if (this.label1.Visible == true)
            {
                MessageBox.Show("请清空界面并双击Isbn输入该书的Isbn！");
            }
            else
            {
                string newIsbn = this.textBox15.Text.ToString();
                bool flag = ifHasBook(newIsbn);
                if (flag) //存在这本书 因为要插入图书位置，所以差不多也是和
                {
                    if(this.textBox4.Text.Length>0)
                    {
                        string location = this.textBox4.Text.ToString();
                        MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                        conn.Open();
                        String sql = String.Format("set @nbid = -1;\r\ncall insert_blank_books('{0}',@nbid);\r\nselect @nbid `out`;",newIsbn);
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                        DataTable db = new DataTable();
                        da.Fill(db);
                        conn.Close();
                        int newbkid = int.Parse(db.Rows[0]["out"].ToString());
                        if(newbkid == -1)
                        {
                            MessageBox.Show("系统错误，请稍后再试！");
                        }
                        else
                        {
                            int s = InsertBookLocations(location, newbkid);
                            if (s == 1)
                            {
                                MessageBox.Show("成功添加!");//还要reload一下
                                LoadBookInLibrary();
                            }
                            else if (s == 0)
                            {
                                MessageBox.Show("该图书位置已有图书，请更改至其余位置！");
                                this.textBox4.Clear();
                            }
                            else
                            {
                                MessageBox.Show("系统内部错误，插入失败，请尝试其余位置！");
                                this.textBox4.Clear();
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("该ISBN对应的图书并不存在，请先添加图书信息！");
                }

            }
        }
        private int BookStateFromName(string name)
        {
            if (name.Equals("已丢失"))
            {
                return 0;

            }else if (name.Equals("在架上"))
            {
                return 1;
            }
            else if(name.Equals("外借中"))
            {
                return 2;//"外借中"
            }
            else
            {
                return -1;//出错
            }
        }
        private void button10_Click(object sender, EventArgs e)//馆藏信息删除
        {
            this.textBox1.ReadOnly = true;
            this.label1.Visible = true;
            this.textBox15.Visible = false;
            //注意如果这本书是在借状态，不能删除
            if (this.textBox3.Text.Length>0 && this.textBox1.Text.Length>0)
            {
                int sindex = BookStateFromName(this.textBox3.Text);
                if(sindex ==1) //只有在架上的时候才能删除而且borrowed表不能有记录
                {
                    //先看borrowed表上是不是有过记录，如果有过就不能删除
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                    conn.Open();
                    String sql = String.Format("select count(*) cc from borrowed where bId = {0} ", int.Parse(this.textBox1.Text.ToString()));
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable db = new DataTable();
                    da.Fill(db);
                    int numbers = int.Parse(db.Rows[0]["cc"].ToString());
                    if (numbers > 0) { 
                        conn.Close(); 
                        MessageBox.Show("该书已有借阅记录，不能删除！");
                    }
                    else
                    {
                        try
                        {
                            sql = String.Format("delete from books where bId = {0} ", int.Parse(this.textBox1.Text.ToString()));
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            numbers = cmd.ExecuteNonQuery();
                            if(numbers > 0) {
                                MessageBox.Show("成功删除！");
                            }
                            else
                            {
                                MessageBox.Show("系统错误，删除失败！");
                            }

                        }
                        catch
                        {
                            MessageBox.Show("系统错误，删除失败！");
                        }
                        LoadBookInLibrary();
                    }
                }
            }
            else
            {
                MessageBox.Show("该图书不能删除！");
            }
                
        }
        private int insert_publisher(string pubName)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = -1;\r\ncall insert_publisher('{0}',@s);\r\nselect @s `out`;",pubName );
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["out"].ToString());
            return status;

        }
        private int insert_author(string authorName)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = -1;\r\ncall insert_writer('{0}',@s);\r\nselect @s `out`;",authorName );
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["wId"].ToString());
            return status;
        }
        private int insert_type(string typeName)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = -1;\r\ncall insert_typeinfo('{0}',@s);\r\nselect @s `out`;",typeName );
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int status = int.Parse(db.Rows[0]["out"].ToString());
            return status;
        }


        private void button3_Click(object sender, EventArgs e)//图书信息修改
        {
            this.label8.Visible = true;
            this.textBox14.Visible = false;
            if (this.label8.Text.Length == 0)
            {
                MessageBox.Show("图书的ISBN不可为空！");
            }
            else
            {
                String this_isbn = this.label8.Text;
                int wid, publisherid, typeid;
                string author = this.textBox13.Text.Trim();
                wid = insert_author(author);
                string bkname = this.textBox5.Text.Trim();
                int bkversion = int.Parse(this.textBox16.Text.Trim());
                string publisherName = this.comboBox3.Text.Trim();
                publisherid = insert_publisher(publisherName);
                double bkPrice = double.Parse(this.textBox7.Text.Trim());
                string bktype = this.comboBox1.Text.Trim();
                typeid = insert_type(bktype);
                string profile = this.richTextBox1.Text.Trim();
                DateTime bkOut;
                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";
                bkOut = Convert.ToDateTime(this.textBox6.Text.Trim(), dtFormat);
                string bkOutDate = bkOut.Year.ToString()+"/"+bkOut.Month.ToString()+"/"+bkOut.Day.ToString();
                try
                {
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    conn.Open();
                    String sql = String.Format("update bookinfo set pubId ={0},tId ={1},wId ={2},bVersion ={3},bName = \"{4}\",bOutDate ='{5}',bPrice ={6},bIntro = \"{7} \" where bIsbn = '{8}'; ", publisherid, typeid, wid, bkversion, bkname, bkOutDate, bkPrice, profile, this_isbn);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("已成功保存！");
                        LoadBookInfo();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                } catch { MessageBox.Show("保存失败！请检查输入格式是否有误，日期格式为\"xxxx/xx/xx\"!"); }
            }
        }
        private void button8_Click(object sender, EventArgs e)//增加图书信息
        {
            if(this.label8.Visible = true && this.textBox14.Visible == false)
            {
                MessageBox.Show("请清空界面并双击ISBN输入ISBN！");
            }
            else
            {
                String this_isbn = this.textBox14.Text;
                int wid, publisherid, typeid;
                String bName = this.textBox5.Text.Trim();
                string author = this.textBox13.Text.Trim();
                wid = insert_author(author);
                string bkname = this.textBox5.Text.Trim();
                int bkversion = int.Parse(this.textBox16.Text.Trim());
                string publisherName = this.comboBox3.Text.Trim();
                publisherid = insert_publisher(publisherName);
                double bkPrice = double.Parse(this.textBox7.Text.Trim());
                string bktype = this.comboBox1.Text.Trim();
                typeid = insert_type(bktype);
                string profile = this.richTextBox1.Text.Trim();
                DateTime bkOut;
                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd";
                bkOut = Convert.ToDateTime(this.textBox6.Text.Trim(), dtFormat);
                string bkOutDate = bkOut.Year.ToString() + "/" + bkOut.Month.ToString() + "/" + bkOut.Day.ToString();
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                    conn.Open();
                    String sql = String.Format("insert into bookinfo \r\nvalues('{0}',{1},{2},{3},{4},'{5}','{6}',{7},'{8}',NULL);\r\n", this_isbn, publisherid, typeid, wid, bkversion, bName, bkOutDate, bkPrice, profile);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("已成功添加！");
                        LoadBookInfo();
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                } catch { MessageBox.Show("添加失败！请检查录入信息是否有误或ISBN是否重复！"); }

            }
        }

        private void button11_Click(object sender, EventArgs e)//删除图书信息
        {
            //this.label8.Visible = true;
            //this.textBox14.Visible = false;
            if (this.label8.Visible == false || this.label8.Text.Length == 0)
            {
                MessageBox.Show("请选中要删除的图书！");
            }
            else
            {
                string isbn = this.label8.Text.Trim();
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                conn.Open();
                String sql = String.Format("set @s = 2;call delete_book('{0}', @s);select @s `out`; ", isbn);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                int state = int.Parse(db.Rows[0]["out"].ToString());
                if(state == 1)
                {
                    MessageBox.Show("成功删除！");
                    LoadBookInfo();
                }else if(state == 2)
                {
                    MessageBox.Show("系统错误，删除失败！");
                }else if(state == 0)
                {
                    MessageBox.Show("系统内无法查询该isbn对应的书！请检查isbn是否错误！");
                }else if(state == -1)
                {
                    MessageBox.Show("馆藏仍有该ISBN对应的书若干，请先在馆藏信息界面对这部分书进行删除！");
                }

            }
            //注意如果现在有人借阅这本书的，不能删除（这个Isbn对应的书）
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
            this.listView2.Items.Clear();
            foreach (DataRow dr in db.Rows)
            {
                ListViewItem item = new ListViewItem(dr["pubId"].ToString());
                item.SubItems.Add(dr["pName"].ToString());
                item.SubItems.Add(dr["pLocate"].ToString());
                item.SubItems.Add(dr["pEmailAddr"].ToString());
                item.SubItems.Add(dr["pContact"].ToString());
                this.listView2.Items.Add(item);
                //here to display
            }

        }
        private void button12_Click(object sender, EventArgs e)//删除出版社信息 
        {//注意如果现有书本有这个出版社的，不能删除。
            string pid = this.textBox8.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
            conn.Open();
            String sql = String.Format("set @s = -1;\r\ncall delete_publisher({0},@s);\r\nselect @s `out`;",int.Parse(pid));
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            int result = int.Parse(db.Rows[0]["out"].ToString());
            if (result == 1)
            {
                MessageBox.Show("删除成功！");
                LoadPubilsherInfo();
            }
            else
            {
                String tmp;
                if(result == 0)
                {
                    tmp = "存在对应该出版社的图书，请先删除该图书后，再删除出版社信息！";
                }else if(result == -1) {
                    tmp = "系统错误";
                }
                else
                {
                    tmp = "该出版社编号不存在！";
                }
                MessageBox.Show(tmp,"删除失败!");
            }
        }

        private void button7_Click(object sender, EventArgs e)//添加出版社信息
        {
            if (this.textBox9.Text.Length > 0 && this.textBox10.Text.Length > 0 && this.textBox11.Text.Length > 0 && this.textBox12.Text.Length > 0)
            {
                string pubName = this.textBox9.Text.Trim();
                string locate = this.textBox10.Text.Trim();
                string mail = this.textBox11.Text.Trim();
                string contact = this.textBox12.Text.Trim();
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("insert into publisher\r\nvalues(NULL,'{0}','{1}','{2}','{3}');", pubName, locate, mail, contact);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("成功添加！");
                    LoadPubilsherInfo();
                }
                else
                {
                    MessageBox.Show("系统错误，添加失败！");
                }
            }
            else
            {
                MessageBox.Show("出版社信息不能有空，请重新填写！");
            }
        }

        private void button1_Click(object sender, EventArgs e)//更新出版社信息
        {
            if(this.textBox9.Text.Length>0 && this.textBox10.Text.Length>0 && this.textBox11.Text.Length>0 && this.textBox12.Text.Length > 0)
            {
                string pid = this.textBox8.Text;
                string pubName = this.textBox9.Text.Trim();
                string locate = this.textBox10.Text.Trim();
                string mail = this.textBox11.Text.Trim();
                string contact = this.textBox12.Text.Trim();
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("update publisher \r\nset pName = '{0}', pEmailAddr=\"{1}\",pContact=\"{2}\",pLocate = \'{3}\'\r\nwhere pubId = {4};", pubName, mail, contact,locate,pid);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("成功保存！");
                    LoadPubilsherInfo();
                }
                else
                {
                    MessageBox.Show("系统错误，保存失败！");
                }
            }
            else
            {
                MessageBox.Show("出版社信息不能有空，请重新填写！");
            }
        }

        private void Reader_Manager_Button_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.label8.Visible = false;
            this.textBox14.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.label1.Visible = false;
            this.textBox15.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(this.textBox1.ReadOnly == true || this.textBox1.Text.Length <= 0)
            {
                MessageBox.Show("请清空界面并双击图书编号以输入待查图书编号！");
            }
            else
            {
                string bkindex = this.textBox1.Text;
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("select bIsbn,bName,bId,bState,bksId,bInDate from books natural join bookinfo where books.bId = '{0}'", int.Parse(bkindex));
                MySqlDataAdapter da = new MySqlDataAdapter(sql,conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView3.Items.Clear();
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
                    listView3.Items.Add(item);
                    //here to display
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox1.ReadOnly = false;
        }

        private void button15_Click(object sender, EventArgs e) //查询出版社
        {
            if(this.textBox9.Text.Length<=0)
            {
                MessageBox.Show("请清空界面并输入待查询出版社名称！");
            }
            else
            {
                string pubName = this.textBox9.Text;
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
                conn.Open();
                String sql = String.Format("select * \r\nfrom publisher\r\nwhere pName like \"%{0}%\";", pubName);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView2.Items.Clear();
                foreach (DataRow dr in db.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["pubId"].ToString());
                    item.SubItems.Add(dr["pName"].ToString());
                    item.SubItems.Add(dr["pLocate"].ToString());
                    item.SubItems.Add(dr["pEmailAddr"].ToString());
                    item.SubItems.Add(dr["pContact"].ToString());
                    this.listView2.Items.Add(item);
                    //here to display
                }

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
            this.listView1.Items.Clear();
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
                this.listView1.Items.Add(item);
                //here to display
            }
        }
        public void LoadPublisherCombox()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;uid=root;pwd=123456;");
            conn.Open();
            string sql = string.Format("select pName from publisher;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();
            foreach (DataRow dr in db.Rows)
            {
                this.comboBox3.Items.Add(dr["pName"].ToString());
            }
        }
        public void LoadTypeCombox()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;uid=root;pwd=123456;");
            conn.Open();
            string sql = string.Format("select tName from typeinfo;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            conn.Close();
            foreach (DataRow dr in db.Rows)
            {
                this.comboBox1.Items.Add(dr["tName"].ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)//图书界面查找图书
        {
            if(this.textBox14.Visible == false || this.textBox14.Text.Length <= 0)
            {
                MessageBox.Show("请清空界面并双击ISBN以输入待导入图书的ISBN！");
            }
            else
            {
                string newisbn = this.textBox14.Text.Trim();
                MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;allowuservariables=True;");
                conn.Open();
                String sql = String.Format("select * from bookinfo where bIsbn = '{0}'", newisbn);
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable db = new DataTable();
                da.Fill(db);
                conn.Close();
                this.listView1.Items.Clear();
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
                    this.listView1.Items.Add(item);
                    //here to display
                }
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Borrow_Return_Mangager_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
