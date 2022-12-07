namespace Library
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginButton = new System.Windows.Forms.Button();
            this.User_Name_Text = new System.Windows.Forms.TextBox();
            this.User_Password_Text = new System.Windows.Forms.TextBox();
            this.ForgetPasswordButton = new System.Windows.Forms.Button();
            this.User_Name_Label = new System.Windows.Forms.Label();
            this.User_Password_Label = new System.Windows.Forms.Label();
            this.User_Image_Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.User_Image_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(233, 317);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(150, 40);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // User_Name_Text
            // 
            this.User_Name_Text.Location = new System.Drawing.Point(233, 198);
            this.User_Name_Text.Name = "User_Name_Text";
            this.User_Name_Text.Size = new System.Drawing.Size(353, 25);
            this.User_Name_Text.TabIndex = 1;
            // 
            // User_Password_Text
            // 
            this.User_Password_Text.Location = new System.Drawing.Point(233, 259);
            this.User_Password_Text.Name = "User_Password_Text";
            this.User_Password_Text.PasswordChar = '*';
            this.User_Password_Text.Size = new System.Drawing.Size(353, 25);
            this.User_Password_Text.TabIndex = 2;
            // 
            // ForgetPasswordButton
            // 
            this.ForgetPasswordButton.Location = new System.Drawing.Point(436, 317);
            this.ForgetPasswordButton.Name = "ForgetPasswordButton";
            this.ForgetPasswordButton.Size = new System.Drawing.Size(150, 40);
            this.ForgetPasswordButton.TabIndex = 3;
            this.ForgetPasswordButton.Text = "忘记密码";
            this.ForgetPasswordButton.UseVisualStyleBackColor = true;
            // 
            // User_Name_Label
            // 
            this.User_Name_Label.AutoSize = true;
            this.User_Name_Label.Location = new System.Drawing.Point(152, 201);
            this.User_Name_Label.Name = "User_Name_Label";
            this.User_Name_Label.Size = new System.Drawing.Size(52, 15);
            this.User_Name_Label.TabIndex = 4;
            this.User_Name_Label.Text = "用户名";
            // 
            // User_Password_Label
            // 
            this.User_Password_Label.AutoSize = true;
            this.User_Password_Label.Location = new System.Drawing.Point(152, 262);
            this.User_Password_Label.Name = "User_Password_Label";
            this.User_Password_Label.Size = new System.Drawing.Size(37, 15);
            this.User_Password_Label.TabIndex = 5;
            this.User_Password_Label.Text = "密码";
            this.User_Password_Label.Click += new System.EventHandler(this.label2_Click);
            // 
            // User_Image_Box
            // 
            this.User_Image_Box.Image = ((System.Drawing.Image)(resources.GetObject("User_Image_Box.Image")));
            this.User_Image_Box.Location = new System.Drawing.Point(321, 12);
            this.User_Image_Box.Name = "User_Image_Box";
            this.User_Image_Box.Size = new System.Drawing.Size(154, 165);
            this.User_Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.User_Image_Box.TabIndex = 6;
            this.User_Image_Box.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.User_Image_Box);
            this.Controls.Add(this.User_Password_Label);
            this.Controls.Add(this.User_Name_Label);
            this.Controls.Add(this.ForgetPasswordButton);
            this.Controls.Add(this.User_Password_Text);
            this.Controls.Add(this.User_Name_Text);
            this.Controls.Add(this.LoginButton);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_Image_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox User_Name_Text;
        private System.Windows.Forms.TextBox User_Password_Text;
        private System.Windows.Forms.Button ForgetPasswordButton;
        private System.Windows.Forms.Label User_Name_Label;
        private System.Windows.Forms.Label User_Password_Label;
        private System.Windows.Forms.PictureBox User_Image_Box;
    }
}

