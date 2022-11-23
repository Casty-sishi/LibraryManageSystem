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
            this.Book_TabPage = new System.Windows.Forms.TabPage();
            this.Publisher_TabPage = new System.Windows.Forms.TabPage();
            this.Library_Book_TabPage = new System.Windows.Forms.TabPage();
            this.Admin_Info_Box = new System.Windows.Forms.GroupBox();
            this.Borrow_Return_Mangager_Button = new System.Windows.Forms.Button();
            this.Admin_Name_Label = new System.Windows.Forms.Label();
            this.Admin_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Book_Manager_Button = new System.Windows.Forms.Button();
            this.Reader_Manager_Button = new System.Windows.Forms.Button();
            this.Book_Tab_Control.SuspendLayout();
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
            // Book_TabPage
            // 
            this.Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Book_TabPage.Name = "Book_TabPage";
            this.Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Book_TabPage.TabIndex = 0;
            this.Book_TabPage.Text = "图书信息";
            this.Book_TabPage.UseVisualStyleBackColor = true;
            // 
            // Publisher_TabPage
            // 
            this.Publisher_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Publisher_TabPage.Name = "Publisher_TabPage";
            this.Publisher_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Publisher_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Publisher_TabPage.TabIndex = 1;
            this.Publisher_TabPage.Text = "出版社信息";
            this.Publisher_TabPage.UseVisualStyleBackColor = true;
            // 
            // Library_Book_TabPage
            // 
            this.Library_Book_TabPage.Location = new System.Drawing.Point(4, 25);
            this.Library_Book_TabPage.Name = "Library_Book_TabPage";
            this.Library_Book_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Library_Book_TabPage.Size = new System.Drawing.Size(537, 373);
            this.Library_Book_TabPage.TabIndex = 2;
            this.Library_Book_TabPage.Text = "馆藏信息";
            this.Library_Book_TabPage.UseVisualStyleBackColor = true;
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
            // SelectionForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Admin_Info_Box);
            this.Controls.Add(this.Book_Tab_Control);
            this.Name = "SelectionForm2";
            this.Text = "SelectionForm2";
            this.Book_Tab_Control.ResumeLayout(false);
            this.Admin_Info_Box.ResumeLayout(false);
            this.Admin_Info_Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin_Picture_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Book_Tab_Control;
        private System.Windows.Forms.TabPage Book_TabPage;
        private System.Windows.Forms.TabPage Publisher_TabPage;
        private System.Windows.Forms.TabPage Library_Book_TabPage;
        private System.Windows.Forms.GroupBox Admin_Info_Box;
        private System.Windows.Forms.Button Borrow_Return_Mangager_Button;
        private System.Windows.Forms.Label Admin_Name_Label;
        private System.Windows.Forms.PictureBox Admin_Picture_Box;
        private System.Windows.Forms.Button Book_Manager_Button;
        private System.Windows.Forms.Button Reader_Manager_Button;
    }
}