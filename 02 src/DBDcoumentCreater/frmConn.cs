using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gq.Ext;
namespace DBDcoumentCreater
{
    public partial class frmConn : Form
    {
        public bool chosed { get; set; }
        public int index { get; set; }
        public string conn { get; set; }
        public frmConn(int index)
        {
            InitializeComponent();
            this.index = index;
            cbbDbType.SelectedIndex = index;
        }

        private void frmConn_Load(object sender, EventArgs e)
        {
            //设置各控件的失去焦点事件
            txtDbName.LostFocus += SetConn;
            txtPassword.LostFocus += SetConn;
            txtUserID.LostFocus += SetConn;
            txtServer.LostFocus += SetConn;
            ckbSimple.LostFocus += SetConn;
            ckbWindow.LostFocus += SetConn;
        }

        private void cbbDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDbType.Text.StartsWith("Oracle"))
            {
                ckbSimple.Checked = true;
                ckbSimple.Visible = true;
                ckbWindow.Visible = false;
                txtServer.ReadOnly = true;
            }
            else
            {
                txtServer.ReadOnly = false;
                ckbSimple.Visible = false;
                ckbWindow.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            chosed = false;
            this.Close();
        }


        private void SetConn(object sender, EventArgs e)
        {
            if (cbbDbType.Text.StartsWith("SQL"))
            {
                if (ckbWindow.Checked)
                {
                    var template = "server={0};database={1};integrated security=sspi;";
                    txtConn.Text = template.FormatString(txtServer.Text, txtDbName.Text);
                }
                else
                {
                    var template = "server={0};database={1};uid={2};pwd={3}";
                    txtConn.Text = template.FormatString(txtServer.Text, txtDbName.Text
                   , txtUserID.Text, txtPassword.Text);
                }
            }
            else if (cbbDbType.Text.StartsWith("Oracle"))
            {
                if (ckbSimple.Checked)
                {
                    var template = "Data Source={0};User ID={1};pwd={2}";
                    txtConn.Text = template.FormatString(txtDbName.Text
              , txtUserID.Text, txtPassword.Text);
                }
                else
                {
                    var template = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME={1})));Persist Security Info=True;User Id={2}; Password={3}";
                    txtConn.Text = template.FormatString(txtServer.Text, txtDbName.Text
               , txtUserID.Text, txtPassword.Text);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetConn(sender, e);
            chosed = true;
            conn = txtConn.Text; ;
            index = cbbDbType.SelectedIndex;
            this.Close();
        }

        private void ckbSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSimple.Checked)
            {
                txtServer.ReadOnly = true;
            }
            else
            {
                txtServer.ReadOnly = false;
            }
            SetConn(sender, e);
        }

        private void ckbWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbWindow.Checked)
            {
                txtUserID.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }
            else
            {
                txtUserID.ReadOnly = false;
                txtPassword.ReadOnly = false;
            }
            SetConn(sender, e);
        }
    }
}
