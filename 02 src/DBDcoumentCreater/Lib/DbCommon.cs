/* ==============================================================================
   * 文 件 名:DbCommon
   * 功能描述：
   * Copyright (c) 2012 武汉经纬视通科技有限公司
   * 创 建 人: gaoqiang
   * 创建时间: 2013/3/18 15:21:25
   * 修 改 人: 
   * 修改时间: 
   * 修改描述: 
   * 版    本: v1.0.0.0
   * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using gq.Ext;
namespace gq.DB
{
    /// <summary>
    /// 常用功能类
    /// </summary>
    public class DbCommon
    {
        #region 导出表数据为html格式
        /// <summary>
        ///  导出表数据为html格式 居中表格样式
        /// </summary>
        /// <param name="dt">DataTable，需要给TableName赋值</param>
        /// <param name="KeepNull">保持Null为Null值，否则为空</param>
        /// <param name="Path">保存路径</param>
        /// <param name="hasReturn">携带返回目录链接</param>
        /// <param name="tableDesc">携带返回目录链接</param>
        public static void CreateHtml(DataTable dt, bool KeepNull, string Path, bool hasReturn = true, string tableDesc = "")
        {
            var code = new StringBuilder();
            code.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            code.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            code.AppendLine("<head>");
            code.AppendLine("    <META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"> ");
            code.AppendLine("    <title>{0}</title>".FormatString(dt.TableName));
            code.AppendLine("    <style type=\"text/css\">");
            code.AppendLine("        body");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 9pt;");
            code.AppendLine("        }");
            code.AppendLine("        .styledb");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 14px;");
            code.AppendLine("        }");
            code.AppendLine("        .styletab");
            code.AppendLine("        {");
            code.AppendLine("            font-size: 14px;");
            code.AppendLine("            padding-top: 15px;");
            code.AppendLine("        }");
            code.AppendLine("        a");
            code.AppendLine("        {");
            code.AppendLine("            color: #015FB6;");
            code.AppendLine("        }");
            code.AppendLine("        a:link, a:visited, a:active");
            code.AppendLine("        {");
            code.AppendLine("            color: #015FB6;");
            code.AppendLine("            text-decoration: none;");
            code.AppendLine("        }");
            code.AppendLine("        a:hover");
            code.AppendLine("        {");
            code.AppendLine("            color: #E33E06;");
            code.AppendLine("        }");
            code.AppendLine("    </style>");
            code.AppendLine("</head>");
            code.AppendLine("<body>");
            code.AppendLine("    <div style=\"text-align: center\">");
            code.AppendLine("        <div>");
            code.AppendLine("            <table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");
            code.AppendLine("                <tr>");
            code.AppendLine("                    <td bgcolor=\"#FBFBFB\">");
            code.AppendLine("                        <table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
            code.AppendLine("                        <caption>");
            code.AppendLine("        <div class=\"styletab\">{0}{1}{2}</div>".FormatString(
                dt.TableName,
                tableDesc.Length == 0 ? string.Empty : "  （" + tableDesc + "） ",
                hasReturn ? "<a href='../数据库表目录.html' style='float: right; margin-top: 6px;'>返回目录</a>" : string.Empty));
            code.AppendLine("                        </caption>");
            code.AppendLine("                        <tr bgcolor=\"#F0F0F0\">");
            //构建表头
            foreach (DataColumn dc in dt.Columns)
            {
                code.AppendLine("            <td>{0}</td>".FormatString(dc.ColumnName));
            }
            code.AppendLine("                         </tr>");
            //构建数据行
            foreach (DataRow dr in dt.Rows)
            {
                code.AppendLine("            <tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    if (KeepNull && dr[dc.ColumnName] == DBNull.Value)
                    {
                        code.AppendLine("            <td>&nbsp;</td>");
                    }
                    else
                    {
                        code.AppendLine("            <td>{0}</td>".FormatString(
                              dr[dc.ColumnName].ToString().Trim().Length > 0 ? dr[dc.ColumnName].ToString() : "&nbsp;"));
                    }
                }
                code.AppendLine("            </tr>");
            }
            code.AppendLine("                        </table>");
            code.AppendLine("                    </td>");
            code.AppendLine("                </tr>");
            code.AppendLine("            </table>");
            code.AppendLine("        </div>");
            code.AppendLine("    </div>");
            code.AppendLine("</body>");
            code.AppendLine("</html>");
            File.WriteAllText(Path, code.ToString(), Encoding.GetEncoding("gb2312"));
            //File.WriteAllText(Path, code.ToString(), Encoding.UTF8);
        }

        /// <summary>
        ///  导出表数据为html格式 Oracle导出格式 带搜索框
        /// </summary>
        /// <param name="dt">DataTable，需要给TableName赋值</param>
        /// <param name="KeepNull">保持Null为Null值，否则为空</param>
        /// <param name="Path">保存路径</param>
        public static void CreateHtml2(DataTable dt, bool KeepNull, string Path)
        {
            var code = new StringBuilder();
            code.AppendLine("<html>");
            code.AppendLine("<head>");
            code.AppendLine("    <META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"> ");
            code.AppendLine("    <title>J{0}</title>".FormatString(dt.TableName));
            code.AppendLine("    <meta http-equiv=\"content-type\" content=\"text/html; charset=GBK\">");
            code.AppendLine("    <style type=\"text/css\">");
            code.AppendLine("        table");
            code.AppendLine("        {");
            code.AppendLine("            background-color: #F2F2F5;");
            code.AppendLine("            border-width: 1px 1px 0px 1px;");
            code.AppendLine("            border-color: #C9CBD3;");
            code.AppendLine("            border-style: solid;");
            code.AppendLine("        }");
            code.AppendLine();
            code.AppendLine("        td");
            code.AppendLine("        {");
            code.AppendLine("            color: #000000;");
            code.AppendLine("            font-family: Tahoma,Arial,Helvetica,Geneva,sans-serif;");
            code.AppendLine("            font-size: 9pt;");
            code.AppendLine("            background-color: #EAEFF5;");
            code.AppendLine("            padding: 8px;");
            code.AppendLine("            background-color: #F2F2F5;");
            code.AppendLine("            border-color: #ffffff #ffffff #cccccc #ffffff;");
            code.AppendLine("            border-style: solid solid solid solid;");
            code.AppendLine("            border-width: 1px 0px 1px 0px;");
            code.AppendLine("        }");
            code.AppendLine();
            code.AppendLine("        th");
            code.AppendLine("        {");
            code.AppendLine("            font-family: Tahoma,Arial,Helvetica,Geneva,sans-serif;");
            code.AppendLine("            font-size: 9pt;");
            code.AppendLine("            padding: 8px;");
            code.AppendLine("            background-color: #CFE0F1;");
            code.AppendLine("            border-color: #ffffff #ffffff #cccccc #ffffff;");
            code.AppendLine("            border-style: solid solid solid none;");
            code.AppendLine("            border-width: 1px 0px 1px 0px;");
            code.AppendLine("            white-space: nowrap;");
            code.AppendLine("        }");
            code.AppendLine("        a:link, a:visited, a:active");
            code.AppendLine("        {");
            code.AppendLine("            color: #015FB6;");
            code.AppendLine("            text-decoration: none;");
            code.AppendLine("        }");
            code.AppendLine("        a:hover");
            code.AppendLine("        {");
            code.AppendLine("            color: #E33E06;");
            code.AppendLine("        }");
            code.AppendLine("    </style>");
            code.AppendLine("    <script type=\"text/javascript\">");
            code.AppendLine("        window.apex_search = {};");
            code.AppendLine("        apex_search.init = function () {");
            code.AppendLine("            this.rows = document.getElementById('data').getElementsByTagName('TR');");
            code.AppendLine("            this.rows_length = apex_search.rows.length;");
            code.AppendLine("            this.rows_text = [];");
            code.AppendLine("            for (var i = 0; i < apex_search.rows_length; i++) {");
            code.AppendLine("                this.rows_text[i] = (apex_search.rows[i].innerText) ? apex_search.rows[i].innerText.toUpperCase() : apex_search.rows[i].textContent.toUpperCase();");
            code.AppendLine("            }");
            code.AppendLine("            this.time = false;");
            code.AppendLine("        }");
            code.AppendLine();
            code.AppendLine("        apex_search.lsearch = function () {");
            code.AppendLine("            this.term = document.getElementById('S').value.toUpperCase();");
            code.AppendLine("            for (var i = 0, row; row = this.rows[i], row_text = this.rows_text[i]; i++) {");
            code.AppendLine("                row.style.display = ((row_text.indexOf(this.term) != -1) || this.term === '') ? '' : 'none';");
            code.AppendLine("            }");
            code.AppendLine("            this.time = false;");
            code.AppendLine("        }");
            code.AppendLine();
            code.AppendLine("        apex_search.search = function (e) {");
            code.AppendLine("            var keycode;");
            code.AppendLine("            if (window.event) { keycode = window.event.keyCode; }");
            code.AppendLine("            else if (e) { keycode = e.which; }");
            code.AppendLine("            else { return false; }");
            code.AppendLine("            if (keycode == 13) {");
            code.AppendLine("                apex_search.lsearch();");
            code.AppendLine("            }");
            code.AppendLine("            else { return false; }");
            code.AppendLine("        }</script>");
            code.AppendLine("</head>");
            code.AppendLine("<body onload=\"apex_search.init();\">");
            code.AppendLine("    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
            code.AppendLine("        <tbody>");
            code.AppendLine("            <tr>    ");
            code.AppendLine("                <td>");
            code.AppendLine("                    <input type=\"text\" size=\"30\" maxlength=\"1000\" value=\"\" id=\"S\" onkeyup=\"apex_search.search(event);\" /><input type=\"button\" value=\"Search\" onclick=\"apex_search.lsearch();\" />");
            code.AppendLine("                </td>");
            code.AppendLine("                <td>");
            code.AppendLine("                        " + dt.TableName);
            code.AppendLine("                </td>");
            code.AppendLine("            </tr>");
            code.AppendLine("        </tbody>");
            code.AppendLine("    </table>");
            code.AppendLine("    <br />");
            code.AppendLine("    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
            code.AppendLine("        <tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                code.AppendLine("            <th>{0}</th>".FormatString(dc.ColumnName));
            }
            code.AppendLine("        </tr>");
            code.AppendLine("        <tbody id=\"data\">");
            foreach (DataRow dr in dt.Rows)
            {
                code.AppendLine("            <tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    if (KeepNull && dr[dc.ColumnName] == DBNull.Value)
                    {
                        //code.AppendLine("            <td>{0}</td>".FormatString(dr[dc.ColumnName].ToString()));
                        code.AppendLine("            <td>&nbsp;</td>");
                    }
                    else//  align=\"right\"
                    {
                        code.AppendLine("            <td>{0}</td>".FormatString(
                            dr[dc.ColumnName].ToString().Length > 0 ? dr[dc.ColumnName].ToString() : "&nbsp;"));
                    }
                }
                code.AppendLine("            </tr>");
            }
            code.AppendLine("        </tbody>");
            code.AppendLine("    </table>");
            code.AppendLine("</body>");
            code.AppendLine("</html>");
            File.WriteAllText(Path, code.ToString(), Encoding.GetEncoding("gb2312"));
        }
        #endregion
    }
}
