namespace Library
{
    partial class SelectionForm2
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
            this.Book_Tab_Control = new System.Windows.Forms.TabControl();
            this.Library_Book_TabPage = new System.Windows.Forms.TabPage();
            this.Readers_Info_Table = new System.Windows.Forms.GroupBox();
            this.Readers_Info_List = new System.Windows.Forms.GroupBox();
            this.Book_TabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Publisher_TabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Admin_Info_Box = new System.Windows.Forms.GroupBox();
            this.Borrow_Return_Mangager_Button = new System.Windows.Forms.Button();
            this.Admin_Name_Label = new System.Windows.Forms.Label();
            this.Admin_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Book_Manager_Button = new System.Windows.Forms.Button();
            this.Reader_Manager_Button = new System.Windows.Forms.Button();
            this.TwoPanel = new System.Windows.Forms.Panel();
            this.Book_Tab_Control.SuspendLayout();
            this.Library_Book_TabPage.SuspendLayout();
            this.Book_TabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Publisher_TabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Admin_Info_Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // Book_Tab_Control
            // 
            this.Book_Tab_Control.Controls.Add(this.Library_Book_TabPage);
            this.Book_Tab_Control.Controls.Add(this.Book_TabPage);
            this.Book_Tab_Control.Controls.Add(this.Publisher_TabPage);
            this.Book_Tab_Control.Location = new System.Drawing.Point(244, 29);
            this.Book_Tab_Control.Name = "Book_Tab_Control";
            this.Book_Tab_Control.SelectedIndex = 0;
            this.Book_Tab_Control.Size = new System.Drawing.Size(545, 402);
            this.Book_Tab_Control.TabIndex = 3;
            // 
            // Library_Book_TabPage
            // 
            this.Library_Book_TabPage.Controls.Add(this.Readers_Info_Table);
            this.Library_Book_TabPage.Controls.Add(this.Readers_Info_List);
            this.Library_Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Library_Book_TabPage.Name = "Library_Book_TabPage";
            this.Library_Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Library_Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Library_Book_TabPage.TabIndex = 3;
            this.Library_Book_TabPage.Text = "馆藏信息";
            this.Library_Book_TabPage.UseVisualStyleBackColor = true;
            // 
            // Readers_Info_Table
            // 
            this.Readers_Info_Table.Location = new System.Drawing.Point(6, 6);
            this.Readers_Info_Table.Name = "Readers_Info_Table";
            this.Readers_Info_Table.Size = new System.Drawing.Size(524, 163);
            this.Readers_Info_Table.TabIndex = 1;
            this.Readers_Info_Table.TabStop = false;
            this.Readers_Info_Table.Text = "馆藏信息";
            // 
            // Readers_Info_List
            // 
            this.Readers_Info_List.Location = new System.Drawing.Point(7, 169);
            this.Readers_Info_List.Name = "Readers_Info_List";
            this.Readers_Info_List.Size = new System.Drawing.Size(524, 198);
            this.Readers_Info_List.TabIndex = 0;
            this.Readers_Info_List.TabStop = false;
            this.Readers_Info_List.Text = "馆藏列表";
            // 
            // Book_TabPage
            // 
            this.Book_TabPage.Controls.Add(this.groupBox1);
            this.Book_TabPage.Controls.Add(this.groupBox2);
            this.Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Book_TabPage.Name = "Book_TabPage";
            this.Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Book_TabPage.TabIndex = 0;
            this.Book_TabPage.Text = "图书信息";
            this.Book_TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(7, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图书列表";
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 163);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细信息";
            // 
            // Publisher_TabPage
            // 
            this.Publisher_TabPage.Controls.Add(this.groupBox3);
            this.Publisher_TabPage.Controls.Add(this.groupBox4);
            this.Publisher_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Publisher_TabPage.Name = "Publisher_TabPage";
            this.Publisher_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Publisher_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Publisher_TabPage.TabIndex = 1;
            this.Publisher_TabPage.Text = "出版社信息";
            this.Publisher_TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView2);
            this.groupBox3.Location = new System.Drawing.Point(7, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 198);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出版社列表";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
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
            // columnHeader13
            // 
            this.columnHeader13.Text = "读者编号";
            this.columnHeader13.Width = 76;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DisplayIndex = 2;
            this.columnHeader14.Text = "读者姓名";
            this.columnHeader14.Width = 76;
            // 
            // columnHeader15
            // 
            this.columnHeader15.DisplayIndex = 1;
            this.columnHeader15.Text = "读者类别";
            this.columnHeader15.Width = 76;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "注册日期";
            this.columnHeader16.Width = 76;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "帐号状态";
            this.columnHeader17.Width = 76;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "违规次数";
            this.columnHeader18.Width = 76;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "联系方式";
            this.columnHeader19.Width = 76;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "用户性别";
            this.columnHeader20.Width = 76;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "有效期";
            this.columnHeader21.Width = 76;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "历史借阅";
            this.columnHeader22.Width = 76;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "在借书籍";
            this.columnHeader23.Width = 76;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "备注";
            this.columnHeader24.Width = 76;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(524, 163);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "详细信息";
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
            this.Admin_Info_Box.TabIndex = 5;
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
            // TwoPanel
            // 
            this.TwoPanel.Location = new System.Drawing.Point(244, 29);
            this.TwoPanel.Name = "TwoPanel";
            this.TwoPanel.Size = new System.Drawing.Size(544, 401);
            this.TwoPanel.TabIndex = 6;
            // 
            // SelectionForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Admin_Info_Box);
            this.Controls.Add(this.Book_Tab_Control);
            this.Controls.Add(this.TwoPanel);
            this.Name = "SelectionForm2";
            this.Text = "SelectionForm2";
            this.Book_Tab_Control.ResumeLayout(false);
            this.Library_Book_TabPage.ResumeLayout(false);
            this.Book_TabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.Publisher_TabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Admin_Info_Box.ResumeLayout(false);
            this.Admin_Info_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl Book_Tab_Control;
        public System.Windows.Forms.TabPage Book_TabPage;
        public System.Windows.Forms.TabPage Publisher_TabPage;
        private System.Windows.Forms.GroupBox Admin_Info_Box;
        private System.Windows.Forms.Button Borrow_Return_Mangager_Button;
        private System.Windows.Forms.Label Admin_Name_Label;
        private System.Windows.Forms.PictureBox Admin_Picture_Box;
        private System.Windows.Forms.Button Book_Manager_Button;
        private System.Windows.Forms.Button Reader_Manager_Button;
        public System.Windows.Forms.TabPage Library_Book_TabPage;
        private System.Windows.Forms.GroupBox Readers_Info_Table;
        private System.Windows.Forms.GroupBox Readers_Info_List;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel TwoPanel;
    }
}