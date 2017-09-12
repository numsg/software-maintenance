/* ==============================================================================
   * 文 件 名:OracleDAL
   * 功能描述：
   * Copyright (c) 2012 武汉经纬视通科技有限公司
   * 创 建 人: gaoqiang
   * 创建时间: 2013/3/18 15:25:39
   * 修 改 人: 
   * 修改时间: 
   * 修改描述: 
   * 版    本: v1.0.0.0
   * ==============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Text;
using gq.DB;
using gq.Ext;
namespace DBDcoumentCreater.Lib
{
    /// <summary>
    /// OracleDAL
    /// </summary>
    public class OracleDAL : IDAL
    {
        private OracleHelp help;
        private DataTable dtStruct;//表以及字段详情表
        private DataTable dt;//表以及对应的描述信息

        //Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.3.22)  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pcuenca)));Persist Security Info=True;User Id=cawy_cas; Password=ECU911_db

        public OracleDAL(string conn)
        {
            //conn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=issdb.amb.ecu911.gob)  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=r4th)));Persist Security Info=True;User Id=cawy_cas; Password=ECU911_db";
            //conn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=issdb.santd.ecu911.gob)  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pmorona)));Persist Security Info=True;User Id=cawy_cas; Password=ECU911_db";
            //conn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=issdb.esme.ECU911.GOB)  (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pesmeral)));Persist Security Info=True;User Id=cawy_cas; Password=ECU911_db";
            help = new OracleHelp(conn);

            //var strSql = "select ROWNUM as \"序号\" ,ut.table_name \"表名\",utc.comments \"表说明\" from user_tables ut left join user_tab_comments utc on ut.table_name = utc.table_name order by ut.table_name";
            //dt = help.ExecuteSql(strSql);
            //strSql = " select  row_number()over( partition by utc.table_name order by utc.COLUMN_ID, ROWNUM ) as \"序号\"," +
            //    " utc.table_name as \"表名\"," +
            //    " utc.column_name as \"列名\", " +
            //    " utc.data_type as \"数据类型\", " +
            //    " utc.data_length as \"长度\", " +
            //    " utc.data_precision as \"精度\"," +
            //    " utc.data_Scale \"小数位数\", " +
            //    " case when  exists ( select   col.column_name   from   user_constraints con,user_cons_columns col " +
            //    "   where  con.constraint_name=col.constraint_name and con.constraint_type='P' and col.table_name=ucc.table_name and col.column_name =  utc.column_name ) " +
            //     "   then '√' else '' end as \"主键\", " +
            //    " case when utc.nullable = 'Y' then '√' else '' end as \"允许空\", " +
            //    " utc.data_default as \"默认值\", " +
            //    " ucc.comments as \"列说明\" " +
            //    " from " +
            //    " user_tab_columns utc,user_col_comments ucc " +
            //    " where  utc.table_name = ucc.table_name and utc.column_name = ucc.column_name  " +
            //    " order by   utc.table_name,\"序号\" ";
            var strSql = "select ROWNUM as \"序号\" ,ut.table_name  \"表名\",utc.comments \"表说明\" from user_tables ut left join user_tab_comments utc on ut.table_name = utc.table_name order by ut.table_name";
            //var strSql = "select ROWNUM  ,ut.table_name ,utc.comments  from user_tables ut left join user_tab_comments utc on ut.table_name = utc.table_name order by ut.table_name";
            dt = help.ExecuteSql(strSql);
            strSql = " select  row_number()over( partition by utc.table_name order by utc.COLUMN_ID, ROWNUM ) as \"序号\"," +
                " utc.table_name as \"表名\"," +
                " utc.column_name as \"列名\", " +
                " utc.data_type as \"数据类型\", " +
                " utc.data_length as \"长度\", " +
                " utc.data_precision as \"精度\"," +
                " utc.data_Scale \"小数位数\", " +
                " case when  exists ( select   col.column_name   from   user_constraints con,user_cons_columns col " +
                "   where  con.constraint_name=col.constraint_name and con.constraint_type='P' and col.table_name=ucc.table_name and col.column_name =  utc.column_name ) " +
                 "   then '√' else '' end as \"主键\", " +
                " case when utc.nullable = 'Y' then '√' else '' end as \"允许空\", " +
                " utc.data_default as \"默认值\", " +
                " ucc.comments as \"列说明\" " +
                " from " +
                " user_tab_columns utc,user_col_comments ucc " +
                " where  utc.table_name = ucc.table_name and utc.column_name = ucc.column_name  " +
                " order by   utc.table_name,\"序号\" ";
//            strSql = @" select  row_number()over( partition by utc.table_name order by utc.COLUMN_ID, ROWNUM ) as xh,
//                utc.table_name as bm,
//                 utc.column_name as lm, 
//                 utc.data_type as sjlx, 
//                 utc.data_length as cl, 
//                 utc.data_precision as jl,
//                 utc.data_Scale xsws, 
//                 case when  exists ( select   col.column_name   from   user_constraints con,user_cons_columns col 
//                    where  con.constraint_name=col.constraint_name and con.constraint_type='P' and col.table_name=ucc.table_name and col.column_name =  utc.column_name ) 
//                    then 'Y' else '' end as zj, 
//                 case when utc.nullable = 'Y' then 'Y' else '' end as yxk, 
//                 utc.data_default as mrzh, 
//                 ucc.comments as lshm 
//                 from 
//                 user_tab_columns utc,user_col_comments ucc 
//                 where  utc.table_name = ucc.table_name and utc.column_name = ucc.column_name  
//                 order by   utc.table_name,xh";
            dtStruct = help.ExecuteSql(strSql);
        }

        public DataTable GetTables()
        {
            return dt;
        }

        public List<DataTable> GetTableStruct(List<string> tables)
        {
            List<DataTable> lst = new List<DataTable>();
            foreach (var table in tables)
            {
                var dtData = dtStruct.GetNewDataTable("表名='" + table + "'");
                dtData.TableName = table;
                dtData.Columns.Remove("表名");
                lst.Add(dtData);
            }
            return lst;
        }

        public List<DataTable> GetTableData(List<string> tables)
        {
            List<DataTable> lst = new List<DataTable>();
            foreach (var table in tables)
            {
                //避免取出来的数据过大
                var dt = help.ExecuteSql("select  * from \"" + table+"\" where ROWNUM < 100 ");
                dt.TableName = table;
                lst.Add(dt);
            }
            return lst;
        }
    }
}


namespace gq.DB
{
    /// <summary>
    /// Oracle数据库访问类
    /// </summary>
    public class OracleHelp : IDisposable
    {
        #region 成员定义
        //连接字符串
        public string OracleConnectionString;
        //连接对象
        private OracleConnection OracleConn;
        //存储过程参数列表
        public IList OracleParameterList = new List<OracleParameter>();
        #endregion

        public OracleHelp(string str)
        {
            OracleConnectionString = str;
        }

        #region 测试是否能否建立连接
        /// <summary>
        /// 测试是否能否建立连接
        /// </summary>
        /// <returns></returns>
        public bool HasConnection
        {
            get
            {

                bool flag;
                try
                {
                    //打开数据库 
                    OracleConn = new OracleConnection(OracleConnectionString);
                    OracleConn.Open();
                    flag = true;

                }
                catch
                {
                    //打开不成功 则连接不成功 
                    flag = false;
                    //throw ex;
                }
                finally
                {
                    //关闭数据库连接 
                    OracleConn.Close();
                    Dispose();
                }
                return flag;
            }
        }
        #endregion

        #region 执行Sql，返回 DataTable
        /// <summary>
        /// 执行Sql，返回 DataTable
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteSql(string strSql)
        {
            using (OracleConn = new OracleConnection(OracleConnectionString))
            {
                using (OracleCommand OraCMD = new OracleCommand())
                {
                    try
                    {
                        OracleConn.Open();
                        OraCMD.CommandText = strSql;
                        OraCMD.CommandType = CommandType.Text;
                        OraCMD.Connection = OracleConn;
                        if (OracleParameterList.Count != 0)
                        {
                            foreach (OracleParameter Para in OracleParameterList)//循环添加数据到SqlCommand对象里面
                            {
                                OraCMD.Parameters.Add(Para);
                            }
                        }
                        OracleParameterList.Clear();
                        using (OracleDataAdapter Oraadapter = new OracleDataAdapter(OraCMD))
                        {
                            DataTable dt = new DataTable();
                            Oraadapter.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        OracleConn.Close();
                        throw ex;
                    }
                    finally
                    {
                        Dispose();
                    }
                }
            }
        }
        #endregion

        #region 释放资源
        /// <summary>
        /// 释放资源接口
        /// </summary>
        public void Dispose()
        {
            if (OracleConn != null)
            {
                if (OracleConn.State == ConnectionState.Open)//判断数据库连接池是否打开
                {
                    OracleConn.Close();
                }

                if (OracleParameterList.Count > 0)//判断参数列表是否清空
                {
                    OracleParameterList.Clear();
                }
                OracleConn.Dispose();//释放连接池资源
                GC.SuppressFinalize(this);//垃圾回收
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~OracleHelp()
        {
            Dispose();
        }
        #endregion
    }
}