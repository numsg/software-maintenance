using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using gq.Common;
using gq.DB;
using DBDcoumentCreater.Lib;
using gq.Ext;
using System.Threading;
namespace DBDcoumentCreater
{
    public partial class Form1 : Form
    {
        private string defaultHtml = "数据库表目录.html";
        private IniFileHelp ini = new IniFileHelp(".//set.ini");
        private IDAL dal;

        public Form1()
        {
            InitializeComponent();
            txtTitle.Text = ini.GetString("Set", "title", "数据库帮助文档");
            cbbDbtype.SelectedIndex = ini.GetInt32("Set", "index", 0);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (txtConn.Text.Length == 0)
            {
                lblMessage.Text = "连接字符串不能为空";
                return;
            }
            try
            {
                dal = DALFacotry.Create(cbbDbtype.Text, "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=issdb.iba.ECU911.GOB)  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pimbabu.iba.ecu911.gob)));Persist Security Info=True;User Id=cawy_cas; Password=ECU911_db");
                if (dal == null)
                {
                    lblMessage.Text = "暂时不支持该数据库 敬请期待";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "数据库异常 请确认";
                return;
            }

            lblMessage.Text = "成功连接数据库";
            //成功连接之后将配置保存
            ini.WriteValue("Set", "index", cbbDbtype.SelectedIndex);
            ini.WriteValue("Set", "index_" + cbbDbtype.SelectedIndex, txtConn.Text);
            //加载表信息
            ckbTables.Items.Clear();
            ckbData.Items.Clear();
            var dt = dal.GetTables();
            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "查询表信息异常，请选择正确的数据库!";
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                ckbTables.Items.Add(dr["表名"].ToString());
                ckbData.Items.Add(dr["表名"].ToString());
            }
            groupBox1.Enabled = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //输入验证
            if (ckbData.CheckedItems.Count == 0 && ckbTables.CheckedItems.Count == 0)
            {
                lblMessage.Text = "请至少选择一张表";
                return;
            }
            if (txtTitle.Text.Length == 0)
            {
                lblMessage.Text = "请输入CHM文件标题";
                return;
            }
            //保存配置
            ini.WriteValue("Set", "title", txtTitle.Text);
            //使用后台线程去导出
            var del = new ThreadStart(Export);
            del.BeginInvoke(null, null);
            this.EnableControl(false);
        }

        public void Export()
        {
            Directory.CreateDirectory(".//tmp");

            //定义目录DataTable 结构
            var dtMenus = new DataTable("<b>数据库表目录</b>");
            dtMenus.Columns.Add("序号", typeof(int));
            dtMenus.Columns.Add("表名", typeof(string));
            dtMenus.Columns.Add("表说明", typeof(string));

            //将选中项的总数 设置为进度条最大值 +1项是表目录文件
            tpbExport.Value = 0;
            tpbExport.Maximum = ckbData.CheckedItems.Count
                + ckbTables.CheckedItems.Count + 1;

            //获取需要导出的表结构 选中项
            List<string> lst = new List<string>();
            foreach (var item in ckbTables.CheckedItems)
            {
                lst.Add(item.ToString());
            }

            #region 导出表结构
            if (lst.Count > 0)
            {
                lblMessage.Text = "准备表结构文件...";
                //得到选中的表结构的字段信息
                var lstDt = dal.GetTableStruct(lst);
                var pathTables = "./tmp/表结构";
                Directory.CreateDirectory(pathTables);
                var tableIndex = 1;
                foreach (var dt in lstDt)
                {
                    //得到表描述
                    var drs = dal.GetTables().Select("表名='" + dt.TableName + "'");
                    var desp = string.Empty;
                    if (drs.Length > 0) desp = drs[0]["表说明"].ToString();
                    //创建表字段信息的html
                    DbCommon.CreateHtml(dt, true, Path.Combine(pathTables, dt.TableName + "  " + desp + ".html"), true, desp);
                    //构建表目录
                    DataRow dr = dtMenus.NewRow();
                    dr["序号"] = tableIndex++;
                    dr["表说明"] = desp;
                    dr["表名"] = "<a href=\"表结构\\{0}  {1}.html\">{0}</a>".FormatString(dt.TableName, desp);
                    dtMenus.Rows.Add(dr);
                    //改变进度
                    tpbExport.Value++;
                }
                //导出表目录
                DbCommon.CreateHtml(dtMenus, false, "./tmp/" + defaultHtml, false);
                tpbExport.Value++;
            }
            #endregion

            #region 导出表数据
            //传递需要导出数据的table选中项  得到数据内容
            lst.Clear();
            foreach (var item in ckbData.CheckedItems)
            {
                lst.Add(item.ToString());
            }
            if (lst.Count > 0)
            {
                lblMessage.Text = "正在生成表数据数据...";
                var lstDt = dal.GetTableData(lst);
                //创建常用数据的html
                var pathTables = "./tmp/常用数据";
                Directory.CreateDirectory(pathTables);
                foreach (var dt in lstDt)
                {
                    DbCommon.CreateHtml2(dt, true, Path.Combine(pathTables, dt.TableName + ".html"));
                    tpbExport.Value++;
                }
            }
            #endregion

            try
            {
                lblMessage.Text = "正在编译CHM文件...";
                //编译CHM文档
                ChmHelp c3 = new ChmHelp();
                c3.DefaultPage = defaultHtml;
                c3.Title = txtTitle.Text;
                c3.ChmFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), c3.Title + ".chm");
                c3.RootPath = @"./tmp";
                c3.Compile();
                lblMessage.Text = "导出完毕 文件存储在:" + c3.ChmFileName;
                Directory.Delete("./tmp", true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "导出发生异常";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.EnableControl(true);
            }
        }

        private void txtConn_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        #region 全选控制
        private void btnChoseAll2_Click(object sender, EventArgs e)
        {
            ckbData.SelectedAll();
        }

        private void btnChoseReverse2_Click(object sender, EventArgs e)
        {
            ckbData.SelectedReverse();
        }

        private void btnChoseAll_Click(object sender, EventArgs e)
        {
            ckbTables.SelectedAll();
        }

        private void btnChoseReverse_Click(object sender, EventArgs e)
        {
            ckbTables.SelectedReverse();
        }

        #endregion

        private void cbbDbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConn.Text = ini.GetString("Set", "index_" + cbbDbtype.SelectedIndex, "");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmConn fc = new frmConn(cbbDbtype.SelectedIndex);
            fc.ShowDialog();
            if (fc.chosed)
            {
                cbbDbtype.SelectedIndex = fc.index;
                txtConn.Text = fc.conn;
            }
        }
    }
}
