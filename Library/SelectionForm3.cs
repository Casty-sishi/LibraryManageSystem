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
    }
}
