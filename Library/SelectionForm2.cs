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
            this.label8.Visible = true;
            this.textBox14.Visible = false;
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
            this.label8.Visible = true;
            this.textBox14.Visible = false;
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
            this.label1.Visible = true;
            this.textBox15.Visible = false;
            this.textBox1.Clear(); //图书编号
            this.label1.Text = "Isbn"; //图书ISBN
            this.textBox2.Clear();//图书名字
            this.textBox3.Clear();//图书状态
            this.textBox4.Clear();//图书位置
            this.label7.Text = "/"; ;//图书入库日期
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
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable db = new DataTable();
            da.Fill(db);
            conn.Close();
            return db.Rows[0]["wId"] == null ? false : true;

        }
        private void button9_Click(object sender, EventArgs e) //馆藏信息添加
        {
            if(this.label1.Visible == true)
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
                        String sql = String.Format("set @nbid = -1;\r\ncall insert_blank_books(@nbid);\r\nselect @nbid `out`;");
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
            this.label1.Visible = true;
            this.textBox15.Visible = false;
        }
        private void UpdateBook(string isbn,string authorName,string bkName,string Location,string bookType, int bookVersion, string publisherName, double bkPrice,String outDate, String profile ) { }//图书信息修改 -sql
        private void AddBook(string isbn, string authorName, string bkName, string Location, string bookType, int bookVersion, string publisherName, double bkPrice, String outDate, String profile) { }//图书信息增加 -sql

        private void DeleteBook(string isbn) { }//删除图书信息 -sql
        private void button8_Click(object sender, EventArgs e)//增加图书信息
        {
            if(this.label8.Visible = true && this.textBox14.Visible == false)
            {
                MessageBox.Show("请清空界面并双击ISBN输入ISBN！");
            }
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

        private void label8_Click(object sender, EventArgs e)
        {
            ;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.label1.Visible = false;
            this.textBox15.Visible = true;
        }
    }
}
