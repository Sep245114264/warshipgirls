using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;

namespace 关机
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_ShutDown_Click(object sender, EventArgs e)
        {
            //播放音频
            SoundPlayer player = new SoundPlayer("lun_sp07.wav");
            player.Load();
            player.Play();
            //关机
            Process.Start("SlideToShutDown.exe");
        }

        //通过托盘右键菜单，打开窗口
        private void OpenMainPanel_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        //通过左键托盘，打开窗口
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }
        //最小化隐藏到托盘
        private void Frm_Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Frm_Main_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出程序吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //右键菜单关机
        private void ShutDown_Click(object sender, EventArgs e)
        {
            btn_ShutDown_Click(sender, e);
        }
        //
        private void Frm_Main_Shown(object sender, EventArgs e)
        {
            //this.Hide();
        }
        //右键菜单关闭窗口
        private void ExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        int[] strTime = new int[4];

        Remind remind = new Remind();
        private void expeditionTimer5_Tick(object sender, EventArgs e)
        {
            if (--strTime[0] <= 0)
            {
                expeditionTimer5.Enabled = false;
                this.notifyIcon.ShowBalloonTip(5000, "长官", "第五舰队远征完成", ToolTipIcon.Info);
                remind.expeditionRemind();
                strTime[0] = 0;
            }
            fifthTime.Text = Transform.calTime(strTime[0], false);
        }

        private void expeditionTimer6_Tick(object sender, EventArgs e)
        {
            if (--strTime[1] <= 0)
            {
                expeditionTimer6.Enabled = false;
                this.notifyIcon.ShowBalloonTip(5000, "长官", "第六舰队远征完成", ToolTipIcon.Info);
                remind.expeditionRemind();
                strTime[1] = 0;
            }
            sixthTime.Text = Transform.calTime(strTime[1], false);
        }

        private void expeditionTimer7_Tick(object sender, EventArgs e)
        {
            if (--strTime[2] <= 0)
            {
                expeditionTimer7.Enabled = false;
                this.notifyIcon.ShowBalloonTip(5000, "长官", "第七舰队远征完成", ToolTipIcon.Info);
                remind.expeditionRemind();
                strTime[2] = 0;
            }
            seventhTime.Text = Transform.calTime(strTime[2], false);
        }

        private void expeditionTimer8_Tick(object sender, EventArgs e)
        {
             if (--strTime[3] <= 0)
             {
                 expeditionTimer8.Enabled = false;
                 this.notifyIcon.ShowBalloonTip(5000, "长官", "第八舰队远征完成", ToolTipIcon.Info);
                 remind.expeditionRemind();
                strTime[3] = 0;
             }
            eighthTime.Text = Transform.calTime(strTime[3], false);
        }

        //弹出提示气泡，单击气泡会恢复主窗口
        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private LoginForm loginForm;
        private void button_login_Click(object sender, EventArgs e)
        {
            if (loginForm == null || loginForm.IsDisposed )
            {
                loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                loginForm.Show();
                loginForm.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkManager.JsonParse jsonParse = new NetworkManager.JsonParse();
            jsonParse = NetworkManager.openConnection();

            TextBox[] exploreTeam = { fifthTime, sixthTime, seventhTime, eighthTime };
            ComboBox[] exploreId = { fifthTeam, sixthTeam, seventhTeam, eighthTeam };
            Timer[] exploreTimer = { expeditionTimer5, expeditionTimer6, expeditionTimer7, expeditionTimer8 };
            int i = 0;
            
            foreach (NetworkManager.Levels s in jsonParse.pveExploreVo.levels)
            {
                int fleetId = Convert.ToInt16(s.fleetId) - 5;
                exploreTeam[fleetId].Text = Transform.calTime(s.endTime, true);
                exploreId[fleetId].SelectedIndex = Transform.parseExploreId(Convert.ToInt32( s.exploreId ));
                strTime[fleetId] = Transform.calSpanTime(s.endTime);
            }
            for (i = 0; i < 4; ++i)
            {
                exploreTeam[i].ReadOnly = true;
                exploreId[i].Enabled = false;
                exploreTimer[i].Enabled = true;
            }

        }
    }
}
