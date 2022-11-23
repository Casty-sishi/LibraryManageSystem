namespace Library
{
    partial class SelectionForm
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
            this.Reader_Tab_Control = new System.Windows.Forms.TabControl();
            this.Reader_Info_TabPage = new System.Windows.Forms.TabPage();
            this.Reader_Type_TabPage = new System.Windows.Forms.TabPage();
            this.Admin_Info_Box = new System.Windows.Forms.GroupBox();
            this.Borrow_Return_Mangager_Button = new System.Windows.Forms.Button();
            this.Admin_Name_Label = new System.Windows.Forms.Label();
            this.Admin_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Book_Manager_Button = new System.Windows.Forms.Button();
            this.Reader_Manager_Button = new System.Windows.Forms.Button();
            this.Readers_Info_List = new System.Windows.Forms.GroupBox();
            this.Readers_Info_Table = new System.Windows.Forms.GroupBox();
            this.Readers_Info_Data = new System.Windows.Forms.ListView();
            this.uID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Reader_Tab_Control.SuspendLayout();
            this.Reader_Info_TabPage.SuspendLayout();
            this.Admin_Info_Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).BeginInit();
            this.Readers_Info_List.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reader_Tab_Control
            // 
            this.Reader_Tab_Control.Controls.Add(this.Reader_Info_TabPage);
            this.Reader_Tab_Control.Controls.Add(this.Reader_Type_TabPage);
            this.Reader_Tab_Control.Location = new System.Drawing.Point(243, 32);
            this.Reader_Tab_Control.Name = "Reader_Tab_Control";
            this.Reader_Tab_Control.SelectedIndex = 0;
            this.Reader_Tab_Control.Size = new System.Drawing.Size(545, 402);
            this.Reader_Tab_Control.TabIndex = 1;
            // 
            // Reader_Info_TabPage
            // 
            this.Reader_Info_TabPage.Controls.Add(this.Readers_Info_Table);
            this.Reader_Info_TabPage.Controls.Add(this.Readers_Info_List);
            this.Reader_Info_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Reader_Info_TabPage.Name = "Reader_Info_TabPage";
            this.Reader_Info_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Reader_Info_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Reader_Info_TabPage.TabIndex = 0;
            this.Reader_Info_TabPage.Text = "读者信息";
            this.Reader_Info_TabPage.UseVisualStyleBackColor = true;
            // 
            // Reader_Type_TabPage
            // 
            this.Reader_Type_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Reader_Type_TabPage.Name = "Reader_Type_TabPage";
            this.Reader_Type_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Reader_Type_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Reader_Type_TabPage.TabIndex = 1;
            this.Reader_Type_TabPage.Text = "读者类别";
            this.Reader_Type_TabPage.UseVisualStyleBackColor = true;
            // 
            // Admin_Info_Box
            // 
            this.Admin_Info_Box.Controls.Add(this.Borrow_Return_Mangager_Button);
            this.Admin_Info_Box.Controls.Add(this.Admin_Name_Label);
            this.Admin_Info_Box.Controls.Add(this.Admin_Picture_Box);
            this.Admin_Info_Box.Controls.Add(this.Book_Manager_Button);
            this.Admin_Info_Box.Controls.Add(this.Reader_Manager_Button);
            this.Admin_Info_Box.Location = new System.Drawing.Point(12, 23);
            this.Admin_Info_Box.Name = "Admin_Info_Box";
            this.Admin_Info_Box.Size = new System.Drawing.Size(217, 411);
            this.Admin_Info_Box.TabIndex = 5;
            this.Admin_Info_Box.TabStop = false;
            this.Admin_Info_Box.Text = "AdminInfomation";
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
            // Readers_Info_List
            // 
            this.Readers_Info_List.Controls.Add(this.Readers_Info_Data);
            this.Readers_Info_List.Location = new System.Drawing.Point(7, 169);
            this.Readers_Info_List.Name = "Readers_Info_List";
            this.Readers_Info_List.Size = new System.Drawing.Size(524, 198);
            this.Readers_Info_List.TabIndex = 0;
            this.Readers_Info_List.TabStop = false;
            this.Readers_Info_List.Text = "读者列表";
            this.Readers_Info_List.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Readers_Info_Table
            // 
            this.Readers_Info_Table.Location = new System.Drawing.Point(7, 6);
            this.Readers_Info_Table.Name = "Readers_Info_Table";
            this.Readers_Info_Table.Size = new System.Drawing.Size(524, 163);
            this.Readers_Info_Table.TabIndex = 1;
            this.Readers_Info_Table.TabStop = false;
            this.Readers_Info_Table.Text = "读者信息";
            this.Readers_Info_Table.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Readers_Info_Data
            // 
            this.Readers_Info_Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uID,
            this.pId,
            this.uName});
            this.Readers_Info_Data.FullRowSelect = true;
            this.Readers_Info_Data.GridLines = true;
            this.Readers_Info_Data.HideSelection = false;
            this.Readers_Info_Data.Location = new System.Drawing.Point(6, 22);
            this.Readers_Info_Data.MultiSelect = false;
            this.Readers_Info_Data.Name = "Readers_Info_Data";
            this.Readers_Info_Data.Size = new System.Drawing.Size(511, 170);
            this.Readers_Info_Data.TabIndex = 0;
            this.Readers_Info_Data.UseCompatibleStateImageBehavior = false;
            this.Readers_Info_Data.View = System.Windows.Forms.View.Details;
            // 
            // uID
            // 
            this.uID.Text = "读者编号";
            this.uID.Width = 78;
            // 
            // pId
            // 
            this.pId.Text = "读者类别";
            this.pId.Width = 78;
            // 
            // uName
            // 
            this.uName.Text = "读者姓名";
            this.uName.Width = 77;
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Admin_Info_Box);
            this.Controls.Add(this.Reader_Tab_Control);
            this.Name = "SelectionForm";
            this.Text = "SelectionForm";
            this.Reader_Tab_Control.ResumeLayout(false);
            this.Reader_Info_TabPage.ResumeLayout(false);
            this.Admin_Info_Box.ResumeLayout(false);
            this.Admin_Info_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).EndInit();
            this.Readers_Info_List.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl Reader_Tab_Control;
        private System.Windows.Forms.TabPage Reader_Info_TabPage;
        private System.Windows.Forms.TabPage Reader_Type_TabPage;
        private System.Windows.Forms.GroupBox Admin_Info_Box;
        private System.Windows.Forms.Button Borrow_Return_Mangager_Button;
        private System.Windows.Forms.Label Admin_Name_Label;
        private System.Windows.Forms.PictureBox Admin_Picture_Box;
        private System.Windows.Forms.Button Book_Manager_Button;
        private System.Windows.Forms.Button Reader_Manager_Button;
        private System.Windows.Forms.GroupBox Readers_Info_Table;
        private System.Windows.Forms.GroupBox Readers_Info_List;
        private System.Windows.Forms.ListView Readers_Info_Data;
        private System.Windows.Forms.ColumnHeader uID;
        private System.Windows.Forms.ColumnHeader pId;
        private System.Windows.Forms.ColumnHeader uName;
    }
}