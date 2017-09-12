namespace DBDcoumentCreater
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ckbTables = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.btnConn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChoseReverse2 = new System.Windows.Forms.Button();
            this.btnChoseReverse = new System.Windows.Forms.Button();
            this.btnChoseAll2 = new System.Windows.Forms.Button();
            this.btnChoseAll = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.ckbData = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tpbExport = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbbDbtype = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbTables
            // 
            this.ckbTables.FormattingEnabled = true;
            this.ckbTables.Location = new System.Drawing.Point(12, 35);
            this.ckbTables.Name = "ckbTables";
            this.ckbTables.Size = new System.Drawing.Size(205, 260);
            this.ckbTables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库连接字符串:";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(147, 27);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(410, 21);
            this.txtConn.TabIndex = 2;
            this.txtConn.Text = "Data Source=itdb99;User ID=jwst;Password=jwst;";
            this.txtConn.TextChanged += new System.EventHandler(this.txtConn_TextChanged);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(563, 27);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(50, 23);
            this.btnConn.TabIndex = 3;
            this.btnConn.Text = "连  接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnChoseReverse2);
            this.groupBox1.Controls.Add(this.btnChoseReverse);
            this.groupBox1.Controls.Add(this.btnChoseAll2);
            this.groupBox1.Controls.Add(this.btnChoseAll);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.ckbData);
            this.groupBox1.Controls.Add(this.ckbTables);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 389);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(121, 319);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(237, 21);
            this.txtTitle.TabIndex = 8;
            this.txtTitle.Text = "数据库帮助文档";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "设置CHM文件标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "选择导出表数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择导出表结构";
            // 
            // btnChoseReverse2
            // 
            this.btnChoseReverse2.Location = new System.Drawing.Point(515, 80);
            this.btnChoseReverse2.Name = "btnChoseReverse2";
            this.btnChoseReverse2.Size = new System.Drawing.Size(75, 23);
            this.btnChoseReverse2.TabIndex = 3;
            this.btnChoseReverse2.Text = "反  选";
            this.btnChoseReverse2.UseVisualStyleBackColor = true;
            this.btnChoseReverse2.Click += new System.EventHandler(this.btnChoseReverse2_Click);
            // 
            // btnChoseReverse
            // 
            this.btnChoseReverse.Location = new System.Drawing.Point(223, 80);
            this.btnChoseReverse.Name = "btnChoseReverse";
            this.btnChoseReverse.Size = new System.Drawing.Size(75, 23);
            this.btnChoseReverse.TabIndex = 3;
            this.btnChoseReverse.Text = "反  选";
            this.btnChoseReverse.UseVisualStyleBackColor = true;
            this.btnChoseReverse.Click += new System.EventHandler(this.btnChoseReverse_Click);
            // 
            // btnChoseAll2
            // 
            this.btnChoseAll2.Location = new System.Drawing.Point(515, 35);
            this.btnChoseAll2.Name = "btnChoseAll2";
            this.btnChoseAll2.Size = new System.Drawing.Size(75, 23);
            this.btnChoseAll2.TabIndex = 2;
            this.btnChoseAll2.Text = "全  选";
            this.btnChoseAll2.UseVisualStyleBackColor = true;
            this.btnChoseAll2.Click += new System.EventHandler(this.btnChoseAll2_Click);
            // 
            // btnChoseAll
            // 
            this.btnChoseAll.Location = new System.Drawing.Point(223, 35);
            this.btnChoseAll.Name = "btnChoseAll";
            this.btnChoseAll.Size = new System.Drawing.Size(75, 23);
            this.btnChoseAll.TabIndex = 2;
            this.btnChoseAll.Text = "全  选";
            this.btnChoseAll.UseVisualStyleBackColor = true;
            this.btnChoseAll.Click += new System.EventHandler(this.btnChoseAll_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(434, 322);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出文档";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ckbData
            // 
            this.ckbData.FormattingEnabled = true;
            this.ckbData.Location = new System.Drawing.Point(304, 36);
            this.ckbData.Name = "ckbData";
            this.ckbData.Size = new System.Drawing.Size(205, 260);
            this.ckbData.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tpbExport,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tpbExport
            // 
            this.tpbExport.Name = "tpbExport";
            this.tpbExport.Size = new System.Drawing.Size(100, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(95, 17);
            this.lblMessage.Text = "等待连接数据库.";
            // 
            // cbbDbtype
            // 
            this.cbbDbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDbtype.FormattingEnabled = true;
            this.cbbDbtype.Items.AddRange(new object[] {
            "SQL2005及以上",
            "Oracle"});
            this.cbbDbtype.Location = new System.Drawing.Point(24, 28);
            this.cbbDbtype.Name = "cbbDbtype";
            this.cbbDbtype.Size = new System.Drawing.Size(117, 20);
            this.cbbDbtype.TabIndex = 6;
            this.cbbDbtype.SelectedIndexChanged += new System.EventHandler(this.cbbDbtype_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(622, 28);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(26, 23);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "+";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 468);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cbbDbtype);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBtoolCHM";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ckbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Button btnChoseReverse;
        private System.Windows.Forms.Button btnChoseAll;
        private System.Windows.Forms.Button btnChoseReverse2;
        private System.Windows.Forms.Button btnChoseAll2;
        private System.Windows.Forms.CheckedListBox ckbData;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbDbtype;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolStripProgressBar tpbExport;
    }
}

