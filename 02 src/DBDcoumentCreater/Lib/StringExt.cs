using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public class ExtensionAttribute : Attribute { }
}

namespace gq.Ext
{
    /// <summary>
    /// 字符串拓展方法
    /// </summary>
    public static partial class ExtendMethod
    {
        #region 重写Format方法
        /// <summary>
        /// 重写Format方法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatString(this string s, params object[] args)
        {
            return string.Format(s, args);
        }
        #endregion

        //全选
        public static void SelectedAll(this CheckedListBox ckb)
        {
            //如果选中项等于所有项总数则表示已经全选了
            if (ckb.CheckedItems.Count == ckb.Items.Count)
            {
                for (var i = 0; i < ckb.Items.Count; i++)
                {
                    //ckb.SetItemCheckState(i, CheckState.Unchecked);
                    ckb.SetItemChecked(i, false);
                }
            }
            else //则所有项均选中
            {
                for (var i = 0; i < ckb.Items.Count; i++)
                {
                    //ckb.SetItemCheckState(i, CheckState.Checked);
                    ckb.SetItemChecked(i, true);
                }
            }
        }
        //反选
        public static void SelectedReverse(this CheckedListBox ckb)
        {
            for (var i = 0; i < ckb.Items.Count; i++)
            {
                bool check = ckb.GetItemChecked(i);
                ckb.SetItemChecked(i, !check);
            }
        }

        #region DataTable条件查询获取子DataTable
        /// <summary>
        /// DataTable条件查询获取子DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(this DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }

        #endregion

        public static void EnableControl(this Form frm, bool enabled)
        {
            foreach (Control control in frm.Controls)
            {
                control.Enabled = enabled;
            }
        }

    }
}
