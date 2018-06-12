namespace 关机
{
    partial class Frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.btn_ShutDown = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenMainPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.ShutDown = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fifthTime = new System.Windows.Forms.TextBox();
            this.expeditionTimer5 = new System.Windows.Forms.Timer(this.components);
            this.fifthTeam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sixthTeam = new System.Windows.Forms.ComboBox();
            this.seventhTeam = new System.Windows.Forms.ComboBox();
            this.eighthTeam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sixthTime = new System.Windows.Forms.TextBox();
            this.seventhTime = new System.Windows.Forms.TextBox();
            this.eighthTime = new System.Windows.Forms.TextBox();
            this.expeditionTimer6 = new System.Windows.Forms.Timer(this.components);
            this.expeditionTimer7 = new System.Windows.Forms.Timer(this.components);
            this.expeditionTimer8 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ShutDown
            // 
            this.btn_ShutDown.Location = new System.Drawing.Point(345, 12);
            this.btn_ShutDown.Name = "btn_ShutDown";
            this.btn_ShutDown.Size = new System.Drawing.Size(75, 53);
            this.btn_ShutDown.TabIndex = 0;
            this.btn_ShutDown.Text = "关机";
            this.btn_ShutDown.UseVisualStyleBackColor = true;
            this.btn_ShutDown.Click += new System.EventHandler(this.btn_ShutDown_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMainPanel,
            this.ShutDown,
            this.ExitProgram});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // OpenMainPanel
            // 
            this.OpenMainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenMainPanel.Image = ((System.Drawing.Image)(resources.GetObject("OpenMainPanel.Image")));
            this.OpenMainPanel.Name = "OpenMainPanel";
            this.OpenMainPanel.Size = new System.Drawing.Size(124, 22);
            this.OpenMainPanel.Text = "打开窗口";
            this.OpenMainPanel.Click += new System.EventHandler(this.OpenMainPanel_Click);
            // 
            // ShutDown
            // 
            this.ShutDown.Name = "ShutDown";
            this.ShutDown.Size = new System.Drawing.Size(124, 22);
            this.ShutDown.Text = "关机";
            this.ShutDown.Click += new System.EventHandler(this.ShutDown_Click);
            // 
            // ExitProgram
            // 
            this.ExitProgram.Name = "ExitProgram";
            this.ExitProgram.Size = new System.Drawing.Size(124, 22);
            this.ExitProgram.Text = "退出程序";
            this.ExitProgram.Click += new System.EventHandler(this.ExitProgram_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "关机";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // fifthTime
            // 
            this.fifthTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fifthTime.Location = new System.Drawing.Point(224, 93);
            this.fifthTime.Name = "fifthTime";
            this.fifthTime.Size = new System.Drawing.Size(100, 23);
            this.fifthTime.TabIndex = 1;
            // 
            // expeditionTimer5
            // 
            this.expeditionTimer5.Interval = 1000;
            this.expeditionTimer5.Tick += new System.EventHandler(this.expeditionTimer5_Tick);
            // 
            // fifthTeam
            // 
            this.fifthTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fifthTeam.FormattingEnabled = true;
            this.fifthTeam.Items.AddRange(new object[] {
            "1-1.舰炮演练",
            "1-2.作战演练",
            "1-3.近海巡逻",
            "1-4.反潜演练",
            "2-1.护航任务",
            "2-2.远航训练",
            "2-3.编队演习",
            "2-4.大规模编队演习",
            "3-1.远洋护航",
            "3-2.舰队前哨侦察",
            "3-3.巡洋舰编队演习",
            "3-4.运输船队护航",
            "4-1.突破封锁线",
            "4-2.火力支援",
            "4-3.封锁航线",
            "4-4.联合登陆行动",
            "5-1.武装侦察",
            "5-2.主力舰出动",
            "5-3.航空援护",
            "5-4.夜间强袭",
            "6-1.北冰洋航线",
            "6-2.战列舰作战",
            "6-3.海航强攻",
            "6-4.莱茵演习",
            "7-1.强击潜艇洞库",
            "7-2.大西洋反潜护航",
            "7-3.突袭军港",
            "7-4.航空封锁战"});
            this.fifthTeam.Location = new System.Drawing.Point(77, 94);
            this.fifthTeam.Name = "fifthTeam";
            this.fifthTeam.Size = new System.Drawing.Size(141, 20);
            this.fifthTeam.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "第五舰队：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "第六舰队：";
            // 
            // sixthTeam
            // 
            this.sixthTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sixthTeam.FormattingEnabled = true;
            this.sixthTeam.Items.AddRange(new object[] {
            "1-1.舰炮演练",
            "1-2.作战演练",
            "1-3.近海巡逻",
            "1-4.反潜演练",
            "2-1.护航任务",
            "2-2.远航训练",
            "2-3.编队演习",
            "2-4.大规模编队演习",
            "3-1.远洋护航",
            "3-2.舰队前哨侦察",
            "3-3.巡洋舰编队演习",
            "3-4.运输船队护航",
            "4-1.突破封锁线",
            "4-2.火力支援",
            "4-3.封锁航线",
            "4-4.联合登陆行动",
            "5-1.武装侦察",
            "5-2.主力舰出动",
            "5-3.航空援护",
            "5-4.夜间强袭",
            "6-1.北冰洋航线",
            "6-2.战列舰作战",
            "6-3.海航强攻",
            "6-4.莱茵演习",
            "7-1.强击潜艇洞库",
            "7-2.大西洋反潜护航",
            "7-3.突袭军港",
            "7-4.航空封锁战"});
            this.sixthTeam.Location = new System.Drawing.Point(77, 137);
            this.sixthTeam.Name = "sixthTeam";
            this.sixthTeam.Size = new System.Drawing.Size(141, 20);
            this.sixthTeam.TabIndex = 5;
            // 
            // seventhTeam
            // 
            this.seventhTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seventhTeam.FormattingEnabled = true;
            this.seventhTeam.Items.AddRange(new object[] {
            "1-1.舰炮演练",
            "1-2.作战演练",
            "1-3.近海巡逻",
            "1-4.反潜演练",
            "2-1.护航任务",
            "2-2.远航训练",
            "2-3.编队演习",
            "2-4.大规模编队演习",
            "3-1.远洋护航",
            "3-2.舰队前哨侦察",
            "3-3.巡洋舰编队演习",
            "3-4.运输船队护航",
            "4-1.突破封锁线",
            "4-2.火力支援",
            "4-3.封锁航线",
            "4-4.联合登陆行动",
            "5-1.武装侦察",
            "5-2.主力舰出动",
            "5-3.航空援护",
            "5-4.夜间强袭",
            "6-1.北冰洋航线",
            "6-2.战列舰作战",
            "6-3.海航强攻",
            "6-4.莱茵演习",
            "7-1.强击潜艇洞库",
            "7-2.大西洋反潜护航",
            "7-3.突袭军港",
            "7-4.航空封锁战"});
            this.seventhTeam.Location = new System.Drawing.Point(77, 183);
            this.seventhTeam.Name = "seventhTeam";
            this.seventhTeam.Size = new System.Drawing.Size(141, 20);
            this.seventhTeam.TabIndex = 6;
            // 
            // eighthTeam
            // 
            this.eighthTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eighthTeam.FormattingEnabled = true;
            this.eighthTeam.Items.AddRange(new object[] {
            "1-1.舰炮演练",
            "1-2.作战演练",
            "1-3.近海巡逻",
            "1-4.反潜演练",
            "2-1.护航任务",
            "2-2.远航训练",
            "2-3.编队演习",
            "2-4.大规模编队演习",
            "3-1.远洋护航",
            "3-2.舰队前哨侦察",
            "3-3.巡洋舰编队演习",
            "3-4.运输船队护航",
            "4-1.突破封锁线",
            "4-2.火力支援",
            "4-3.封锁航线",
            "4-4.联合登陆行动",
            "5-1.武装侦察",
            "5-2.主力舰出动",
            "5-3.航空援护",
            "5-4.夜间强袭",
            "6-1.北冰洋航线",
            "6-2.战列舰作战",
            "6-3.海航强攻",
            "6-4.莱茵演习",
            "7-1.强击潜艇洞库",
            "7-2.大西洋反潜护航",
            "7-3.突袭军港",
            "7-4.航空封锁战"});
            this.eighthTeam.Location = new System.Drawing.Point(77, 231);
            this.eighthTeam.Name = "eighthTeam";
            this.eighthTeam.Size = new System.Drawing.Size(141, 20);
            this.eighthTeam.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "第七舰队：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "第八舰队：";
            // 
            // sixthTime
            // 
            this.sixthTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sixthTime.Location = new System.Drawing.Point(224, 136);
            this.sixthTime.Name = "sixthTime";
            this.sixthTime.Size = new System.Drawing.Size(100, 23);
            this.sixthTime.TabIndex = 10;
            // 
            // seventhTime
            // 
            this.seventhTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.seventhTime.Location = new System.Drawing.Point(224, 182);
            this.seventhTime.Name = "seventhTime";
            this.seventhTime.Size = new System.Drawing.Size(100, 23);
            this.seventhTime.TabIndex = 11;
            // 
            // eighthTime
            // 
            this.eighthTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.eighthTime.Location = new System.Drawing.Point(224, 231);
            this.eighthTime.Name = "eighthTime";
            this.eighthTime.Size = new System.Drawing.Size(100, 23);
            this.eighthTime.TabIndex = 12;
            // 
            // expeditionTimer6
            // 
            this.expeditionTimer6.Interval = 1000;
            this.expeditionTimer6.Tick += new System.EventHandler(this.expeditionTimer6_Tick);
            // 
            // expeditionTimer7
            // 
            this.expeditionTimer7.Interval = 1000;
            this.expeditionTimer7.Tick += new System.EventHandler(this.expeditionTimer7_Tick);
            // 
            // expeditionTimer8
            // 
            this.expeditionTimer8.Interval = 1000;
            this.expeditionTimer8.Tick += new System.EventHandler(this.expeditionTimer8_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(120, 27);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 18;
            this.button_login.Text = "账户信息";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.eighthTime);
            this.Controls.Add(this.seventhTime);
            this.Controls.Add(this.sixthTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eighthTeam);
            this.Controls.Add(this.seventhTeam);
            this.Controls.Add(this.sixthTeam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fifthTeam);
            this.Controls.Add(this.fifthTime);
            this.Controls.Add(this.btn_ShutDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "桌面提醒工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosed);
            this.Shown += new System.EventHandler(this.Frm_Main_Shown);
            this.Resize += new System.EventHandler(this.Frm_Main_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ShutDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenMainPanel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem ShutDown;
        private System.Windows.Forms.ToolStripMenuItem ExitProgram;
        private System.Windows.Forms.TextBox fifthTime;
        private System.Windows.Forms.Timer expeditionTimer5;
        private System.Windows.Forms.ComboBox fifthTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sixthTeam;
        private System.Windows.Forms.ComboBox seventhTeam;
        private System.Windows.Forms.ComboBox eighthTeam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sixthTime;
        private System.Windows.Forms.TextBox seventhTime;
        private System.Windows.Forms.TextBox eighthTime;
        private System.Windows.Forms.Timer expeditionTimer6;
        private System.Windows.Forms.Timer expeditionTimer7;
        private System.Windows.Forms.Timer expeditionTimer8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button1;
    }
}

