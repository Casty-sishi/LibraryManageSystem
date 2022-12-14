using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Library
{
    
    public partial class LoginForm : Form
    {
        public String adminName = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=library_db;UID=root;PWD=123456;");
            conn.Open();
            String sql = String.Format("select * from admin where aName='{0}' and apad='{1}';", this.User_Name_Text.Text, this.User_Password_Text.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
            DataTable db = new DataTable();
            adapter.Fill(db);
            if (db.Rows.Count > 0)
            {
                this.adminName = this.User_Name_Text.Text;
                SelectionForm nextform = new SelectionForm();
                nextform.SetAdminLabel(adminName);
                nextform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账户不存在或密码错误！请重新输入！");
                this.User_Name_Text.Clear();
                this.User_Password_Text.Clear();
            }
                

        }

        private void ForgetPasswordButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请联系图书馆老师！");
        }
    }
}
