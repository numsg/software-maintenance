namespace DBDcoumentCreater
{
    partial class frmConn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbDbType = new System.Windows.Forms.ComboBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.ckbSimple = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckbWindow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库实例:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "用 户 名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "密  码:";
            // 
            // cbbDbType
            // 
            this.cbbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDbType.FormattingEnabled = true;
            this.cbbDbType.Items.AddRange(new object[] {
            "SQL2005及以上",
            "Oracle"});
            this.cbbDbType.Location = new System.Drawing.Point(123, 18);
            this.cbbDbType.Name = "cbbDbType";
            this.cbbDbType.Size = new System.Drawing.Size(143, 20);
            this.cbbDbType.TabIndex = 1;
            this.cbbDbType.SelectedIndexChanged += new System.EventHandler(this.cbbDbType_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(123, 46);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(186, 21);
            this.txtServer.TabIndex = 3;
            this.txtServer.Text = "172.18.3.22";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(123, 78);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(186, 21);
            this.txtDbName.TabIndex = 4;
            this.txtDbName.Text = "Pcuenca";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(123, 110);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(186, 21);
            this.txtUserID.TabIndex = 5;
            this.txtUserID.Text = "cawy_cas";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(186, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "ECU911_db";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(320, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(48, 183);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.ReadOnly = true;
            this.txtConn.Size = new System.Drawing.Size(261, 74);
            this.txtConn.TabIndex = 8;
            // 
            // ckbSimple
            // 
            this.ckbSimple.AutoSize = true;
            this.ckbSimple.Location = new System.Drawing.Point(283, 21);
            this.ckbSimple.Name = "ckbSimple";
            this.ckbSimple.Size = new System.Drawing.Size(48, 16);
            this.ckbSimple.TabIndex = 2;
            this.ckbSimple.Text = "简单";
            this.ckbSimple.UseVisualStyleBackColor = true;
            this.ckbSimple.Visible = false;
            this.ckbSimple.CheckedChanged += new System.EventHandler(this.ckbSimple_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ckbWindow
            // 
            this.ckbWindow.AutoSize = true;
            this.ckbWindow.Location = new System.Drawing.Point(320, 114);
            this.ckbWindow.Name = "ckbWindow";
            this.ckbWindow.Size = new System.Drawing.Size(114, 16);
            this.ckbWindow.TabIndex = 10;
            this.ckbWindow.Text = "windows身份认证";
            this.ckbWindow.UseVisualStyleBackColor = true;
            this.ckbWindow.Visible = false;
            this.ckbWindow.CheckedChanged += new System.EventHandler(this.ckbWindow_CheckedChanged);
            // 
            // frmConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 260);
            this.Controls.Add(this.ckbWindow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ckbSimple);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.cbbDbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成连接字符串";
            this.Load += new System.EventHandler(this.frmConn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbDbType;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.CheckBox ckbSimple;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckbWindow;
    }
}