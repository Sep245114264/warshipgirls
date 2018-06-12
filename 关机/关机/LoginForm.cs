using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace 关机
{
    public partial class LoginForm : Form
    {
        private String username;
        private String password;
        private int server;
        public LoginForm()
        {
            InitializeComponent();
            LodingManager manager = new LodingManager();
            manager.readUserInfo();
            usernameBox.Text = manager.UserName;
            passwordBox.Text = manager.PassWord;
            serverChoice.SelectedIndex = manager.ServerID;
        }

        private void saveDateButton_Click(object sender, EventArgs e)
        {
            username = usernameBox.Text;
            password = passwordBox.Text;
            server = serverChoice.SelectedIndex;
            DataSet ds = new DataSet("test");
            DataTable table = new DataTable("userInfo");
            ds.Tables.Add(table);
            table.Columns.Add("username", typeof(String));
            table.Columns.Add("password", typeof(String));
            table.Columns.Add("server", typeof(int));

            DataRow row = table.NewRow();
            row[0] = username;
            row[1] = password;
            row[2] = server;
            ds.Tables["userInfo"].Rows.Add(row);

            ds.WriteXml("UserData.xml");
            MessageBox.Show("保存成功", "提示");
            
            this.Hide();
        }
    }
}
