namespace 关机
{
    partial class LoginForm
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.saveDateButton = new System.Windows.Forms.Button();
            this.serverChoice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(121, 12);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 21);
            this.usernameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(121, 57);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 21);
            this.passwordBox.TabIndex = 3;
            // 
            // saveDateButton
            // 
            this.saveDateButton.Location = new System.Drawing.Point(103, 150);
            this.saveDateButton.Name = "saveDateButton";
            this.saveDateButton.Size = new System.Drawing.Size(75, 23);
            this.saveDateButton.TabIndex = 8;
            this.saveDateButton.Text = "保存";
            this.saveDateButton.UseVisualStyleBackColor = true;
            this.saveDateButton.Click += new System.EventHandler(this.saveDateButton_Click);
            // 
            // serverChoice
            // 
            this.serverChoice.FormattingEnabled = true;
            this.serverChoice.Items.AddRange(new object[] {
            "胡德",
            "萨拉托加",
            "俾斯麦",
            "声望",
            "纳尔逊",
            "空想",
            "海伦娜",
            "突击者",
            "黎赛留",
            "贝尔法斯特",
            "埃塞克斯",
            "昆西",
            "长春"});
            this.serverChoice.Location = new System.Drawing.Point(103, 99);
            this.serverChoice.Name = "serverChoice";
            this.serverChoice.Size = new System.Drawing.Size(121, 20);
            this.serverChoice.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "服务器：";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverChoice);
            this.Controls.Add(this.saveDateButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameBox);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button saveDateButton;
        private System.Windows.Forms.ComboBox serverChoice;
        private System.Windows.Forms.Label label3;
    }
}