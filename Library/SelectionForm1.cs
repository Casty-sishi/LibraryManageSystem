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
        public SelectionForm()
        {
            InitializeComponent();
        }
        private void LoadUserInfo(object sender,EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = "select * from reader;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            //foreach(DataRow dr in db.Rows)
            //{
                //here to display
            //}
            conn.Close();
           

        }
        public void SetAdminLabel(String admName)
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

        private void Book_Manager_Button_Click(object sender, EventArgs e)
        {
            this.Reader_Tab_Control.Controls.Clear();
            SelectionForm2 bookform = new SelectionForm2 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            this.Reader_Tab_Control.Controls.Add(bookform.Book_TabPage);
            this.Reader_Tab_Control.Controls.Add(bookform.Publisher_TabPage);
            this.Reader_Tab_Control.Controls.Add(bookform.Library_Book_TabPage);
            bookform.Show();
        }

        private void Borrow_Return_Mangager_Button_Click(object sender, EventArgs e)
        {
            this.Reader_Tab_Control.Controls.Clear();
            SelectionForm3 borrowreturnform = new SelectionForm3 { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
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

        }
    }
}
