namespace Library
{
    partial class SelectionForm3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Borrow_Return_Tab_Control = new System.Windows.Forms.TabControl();
            this.Library_Book_TabPage = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Book_TabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Publisher_TabPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Admin_Info_Box = new System.Windows.Forms.GroupBox();
            this.Borrow_Return_Mangager_Button = new System.Windows.Forms.Button();
            this.Admin_Name_Label = new System.Windows.Forms.Label();
            this.Admin_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Book_Manager_Button = new System.Windows.Forms.Button();
            this.Reader_Manager_Button = new System.Windows.Forms.Button();
            this.Borrow_Return_Tab_Control.SuspendLayout();
            this.Library_Book_TabPage.SuspendLayout();
            this.Book_TabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Publisher_TabPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.Admin_Info_Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // Borrow_Return_Tab_Control
            // 
            this.Borrow_Return_Tab_Control.Controls.Add(this.Library_Book_TabPage);
            this.Borrow_Return_Tab_Control.Controls.Add(this.Book_TabPage);
            this.Borrow_Return_Tab_Control.Controls.Add(this.Publisher_TabPage);
            this.Borrow_Return_Tab_Control.Location = new System.Drawing.Point(244, 29);
            this.Borrow_Return_Tab_Control.Name = "Borrow_Return_Tab_Control";
            this.Borrow_Return_Tab_Control.SelectedIndex = 0;
            this.Borrow_Return_Tab_Control.Size = new System.Drawing.Size(545, 402);
            this.Borrow_Return_Tab_Control.TabIndex = 5;
            // 
            // Library_Book_TabPage
            // 
            this.Library_Book_TabPage.Controls.Add(this.button4);
            this.Library_Book_TabPage.Controls.Add(this.button3);
            this.Library_Book_TabPage.Controls.Add(this.groupBox2);
            this.Library_Book_TabPage.Controls.Add(this.groupBox1);
            this.Library_Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Library_Book_TabPage.Name = "Library_Book_TabPage";
            this.Library_Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Library_Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Library_Book_TabPage.TabIndex = 2;
            this.Library_Book_TabPage.Text = "图书借阅";
            this.Library_Book_TabPage.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(262, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "清空勾选";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "确认借阅";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(262, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 326);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图书";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读者";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Book_TabPage
            // 
            this.Book_TabPage.Controls.Add(this.groupBox3);
            this.Book_TabPage.Controls.Add(this.groupBox4);
            this.Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Book_TabPage.Name = "Book_TabPage";
            this.Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Book_TabPage.TabIndex = 0;
            this.Book_TabPage.Text = "图书归还";
            this.Book_TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(7, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 198);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "借阅书籍";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(511, 170);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(524, 163);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "读者";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // Publisher_TabPage
            // 
            this.Publisher_TabPage.Controls.Add(this.groupBox5);
            this.Publisher_TabPage.Controls.Add(this.groupBox6);
            this.Publisher_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Publisher_TabPage.Name = "Publisher_TabPage";
            this.Publisher_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Publisher_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Publisher_TabPage.TabIndex = 1;
            this.Publisher_TabPage.Text = "图书罚款";
            this.Publisher_TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView2);
            this.groupBox5.Location = new System.Drawing.Point(7, 169);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(524, 198);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "过期书籍";
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(6, 22);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(511, 170);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(524, 163);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "读者";
            // 
            // Admin_Info_Box
            // 
            this.Admin_Info_Box.Controls.Add(this.Borrow_Return_Mangager_Button);
            this.Admin_Info_Box.Controls.Add(this.Admin_Name_Label);
            this.Admin_Info_Box.Controls.Add(this.Admin_Picture_Box);
            this.Admin_Info_Box.Controls.Add(this.Book_Manager_Button);
            this.Admin_Info_Box.Controls.Add(this.Reader_Manager_Button);
            this.Admin_Info_Box.Location = new System.Drawing.Point(12, 20);
            this.Admin_Info_Box.Name = "Admin_Info_Box";
            this.Admin_Info_Box.Size = new System.Drawing.Size(217, 411);
            this.Admin_Info_Box.TabIndex = 4;
            this.Admin_Info_Box.TabStop = false;
            this.Admin_Info_Box.Text = "管理员";
            // 
            // Borrow_Return_Mangager_Button
            // 
            this.Borrow_Return_Mangager_Button.Location = new System.Drawing.Point(54, 327);
            this.Borrow_Return_Mangager_Button.Name = "Borrow_Return_Mangager_Button";
            this.Borrow_Return_Mangager_Button.Size = new System.Drawing.Size(119, 39);
            this.Borrow_Return_Mangager_Button.TabIndex = 4;
            this.Borrow_Return_Mangager_Button.Text = "借还管理";
            this.Borrow_Return_Mangager_Button.UseVisualStyleBackColor = true;
            // 
            // Admin_Name_Label
            // 
            this.Admin_Name_Label.AutoSize = true;
            this.Admin_Name_Label.Location = new System.Drawing.Point(69, 175);
            this.Admin_Name_Label.Name = "Admin_Name_Label";
            this.Admin_Name_Label.Size = new System.Drawing.Size(79, 15);
            this.Admin_Name_Label.TabIndex = 1;
            this.Admin_Name_Label.Text = "AdminName";
            // 
            // Admin_Picture_Box
            // 
            this.Admin_Picture_Box.Location = new System.Drawing.Point(23, 34);
            this.Admin_Picture_Box.Name = "Admin_Picture_Box";
            this.Admin_Picture_Box.Size = new System.Drawing.Size(172, 129);
            this.Admin_Picture_Box.TabIndex = 0;
            this.Admin_Picture_Box.TabStop = false;
            // 
            // Book_Manager_Button
            // 
            this.Book_Manager_Button.Location = new System.Drawing.Point(54, 266);
            this.Book_Manager_Button.Name = "Book_Manager_Button";
            this.Book_Manager_Button.Size = new System.Drawing.Size(119, 40);
            this.Book_Manager_Button.TabIndex = 3;
            this.Book_Manager_Button.Text = "图书管理";
            this.Book_Manager_Button.UseVisualStyleBackColor = true;
            // 
            // Reader_Manager_Button
            // 
            this.Reader_Manager_Button.Location = new System.Drawing.Point(54, 206);
            this.Reader_Manager_Button.Name = "Reader_Manager_Button";
            this.Reader_Manager_Button.Size = new System.Drawing.Size(119, 41);
            this.Reader_Manager_Button.TabIndex = 2;
            this.Reader_Manager_Button.Text = "读者管理";
            this.Reader_Manager_Button.UseVisualStyleBackColor = true;
            // 
            // SelectionForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Borrow_Return_Tab_Control);
            this.Controls.Add(this.Admin_Info_Box);
            this.Name = "SelectionForm3";
            this.Text = "SelectionForm3";
            this.Borrow_Return_Tab_Control.ResumeLayout(false);
            this.Library_Book_TabPage.ResumeLayout(false);
            this.Book_TabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Publisher_TabPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.Admin_Info_Box.ResumeLayout(false);
            this.Admin_Info_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl Borrow_Return_Tab_Control;
        public System.Windows.Forms.TabPage Library_Book_TabPage;
        public System.Windows.Forms.TabPage Book_TabPage;
        public System.Windows.Forms.TabPage Publisher_TabPage;
        public System.Windows.Forms.GroupBox Admin_Info_Box;
        public System.Windows.Forms.Button Borrow_Return_Mangager_Button;
        public System.Windows.Forms.Label Admin_Name_Label;
        public System.Windows.Forms.PictureBox Admin_Picture_Box;
        public System.Windows.Forms.Button Book_Manager_Button;
        public System.Windows.Forms.Button Reader_Manager_Button;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.GroupBox groupBox6;
    }
}