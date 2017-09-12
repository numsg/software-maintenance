/* ==============================================================================
   * 文 件 名:SqlDAL
   * 功能描述：
   * Copyright (c) 2012 武汉经纬视通科技有限公司
   * 创 建 人: gaoqiang
   * 创建时间: 2013/3/18 15:22:18
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
using System.Data.SqlClient;
using Chen.DB;
using gq.Ext;
namespace DBDcoumentCreater.Lib
{
    /// <summary>
    /// SqlDAL
    /// </summary>
    public class SqlDAL : IDAL
    {
        private SqlHelp help;
        private DataTable dtStruct;//表以及字段详情表
        private DataTable dt;//表以及对应的描述信息


        public SqlDAL(string conn, int type = 2012)
        {
            help = new SqlHelp(conn);
            var strSql = @" SELECT TOP 100 PERCENT 
					d.name as bm,
                    a.colorder AS xh,  
                    a.name AS lm,  
                    b.name AS sjlx,  
                    a.length AS cl, 
                    ISNULL(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0) AS xsws,  
                    CASE WHEN COLUMNPROPERTY(a.id,a.name, 'IsIdentity') = 1 THEN '是' ELSE '' END AS 标识,  
                    CASE WHEN EXISTS 
                        (SELECT 1 FROM dbo.sysindexes si  
                          INNER JOIN dbo.sysindexkeys sik ON si.id = sik.id AND si.indid = sik.indid   
                          INNER JOIN dbo.syscolumns sc ON sc.id = sik.id AND sc.colid = sik.colid   
                          INNER JOIN dbo.sysobjects so ON so.name = si.name AND so.xtype = 'PK'  
                       WHERE sc.id = a.id AND sc.colid = a.colid) THEN '√' ELSE '' END AS zj,   
                    CASE WHEN a.isnullable = 1 THEN '√' ELSE '' END AS yxk,  
                     ISNULL(e.text, '') AS mrzh,  
                        ISNULL(g.[value], '') AS lshm 
              FROM dbo.syscolumns a  
                    LEFT OUTER JOIN dbo.systypes b ON a.xtype = b.xusertype  
                    INNER JOIN dbo.sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.status >= 0 
                    LEFT OUTER JOIN dbo.syscomments e ON a.cdefault = e.id  
                    LEFT OUTER JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id AND g.name = 'MS_Description'  
                    LEFT OUTER JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0 AND f.name = 'MS_Description'  
              ORDER BY d.name, xh ";
            dtStruct = help.ExecuteSql(strSql);
            //            if (type == 2012)
            //                strSql = @"select Row_Number() over ( order by getdate() )  as xh, t1.name as bm,
            // case when t2.minor_id = 0 then isnull(t2.value, '') else '' end as bshm
            //from sysobjects t1 
            //left join sys.extended_properties t2 on t1.id=t2.major_id
            //where type='u'  and ( minor_id=0 or minor_id is null )";
            //            else if (type == 2008 || type == 2005)
            strSql = @"SELECT  Row_Number() over ( order by getdate() )  as xh, case when a.colorder = 1 then d.name 
                   else '' end as bm, 
        case when a.colorder = 1 then isnull(f.value, '') 
                     else '' end as bshm
FROM syscolumns a 
       inner join sysobjects d 
          on a.id = d.id 
             and d.xtype = 'U' 
             and d.name <> 'sys.extended_properties'
       left join sys.extended_properties   f 
         on a.id = f.major_id 
            and f.minor_id = 0
 where a.colorder = 1 and d.name<>'sysdiagrams'";
            dt = help.ExecuteSql(strSql);
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
                var dtData = dtStruct.GetNewDataTable("bm='" + table + "'");
                dtData.TableName = table;
                dtData.Columns.Remove("bm");
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
                var dt = help.ExecuteSql("select top 100 * from " + table);
                dt.TableName = table;
                lst.Add(dt);
            }
            return lst;
        }
    }
}


namespace Chen.DB
{
    /// <summary>
    /// Sql数据库访问类
    /// </summary>
    public class SqlHelp : IDisposable
    {
        #region 成员定义
        //定义SqlServer链接字符串
        public string SqlConnectionString;
        //定义存储过程参数列表
        public IList SqlParameterList = new List<SqlParameter>();
        //定义SqlServer连接对象
        private SqlConnection SqlCon;
        #endregion

        #region 构造方法，实例化连接字符串

        /// <summary>
        /// 读取WebConfig链接字符串
        /// <summary>
        public SqlHelp()
        {
            SqlConnectionString = //将AppConfig链接字符串的值给SqlConnectionString变量
                //" server = .;database = hwitdb;Integrated security=SSPI;";
            "";
        }

        /// <summary>
        /// 有参构造，实例化连接字符串
        /// </summary>
        /// <param name="str">连接字符串</param>
        public SqlHelp(string connectionString)
        {
            SqlConnectionString = connectionString;
        }

        /// <summary>
        /// 有参构造，实例化连接字符串
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="intance">数据库名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public SqlHelp(string server, string intance, string userName, string password)
        {
            SqlConnectionString = string.Format("server={0};database={1};uid={2};pwd={3}", server, intance, userName, password);
        }
        #endregion

        #region 实现接口IDisposable
        /// <释放资源接口>
        /// 实现接口IDisposable
        /// </释放资源接口>
        public void Dispose()
        {
            if (SqlCon != null)
            {
                if (SqlCon.State == ConnectionState.Open)//判断数据库连接池是否打开
                {
                    SqlCon.Close();
                }

                if (SqlParameterList.Count > 0)//判断参数列表是否清空
                {
                    SqlParameterList.Clear();
                }
                SqlCon.Dispose();//释放连接池资源
                GC.SuppressFinalize(this);//垃圾回收
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 执行Sql文本查询，返回DataTable
        /// <summary>
        /// 执行Sql文本查询，返回DataTable
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public DataTable ExecuteSql(string strSql)
        {
            using (SqlCon = new SqlConnection(SqlConnectionString))
            {
                using (SqlCommand SqlCMD = new SqlCommand())
                {
                    try
                    {
                        SqlCon.Open();//打开数据库连接池
                        SqlCMD.Connection = SqlCon;
                        SqlCMD.CommandTimeout = 0;
                        SqlCMD.CommandType = CommandType.Text;
                        SqlCMD.CommandText = strSql;
                        if (SqlParameterList.Count != 0)
                        {
                            foreach (SqlParameter Para in SqlParameterList)
                            {
                                SqlCMD.Parameters.Add(Para);
                            }
                        }
                        SqlParameterList.Clear();
                        using (SqlDataAdapter Sqladapter = new SqlDataAdapter(SqlCMD))//创建适配器
                        {
                            DataTable SqlDataTable = new DataTable();
                            Sqladapter.SelectCommand.CommandTimeout = 0;
                            Sqladapter.Fill(SqlDataTable);
                            return SqlDataTable;//返回结果集
                        }

                    }
                    catch (Exception ex)
                    {
                        SqlCon.Close();//执行失败则立刻关闭链接
                        throw ex;
                    }
                    finally
                    {
                        Dispose();//释放资源
                    }
                }
            }
        }
        #endregion

        #region 测试连接是否成功
        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns></returns>
        public bool HasConnection
        {
            get
            {
                bool flag;
                try
                {
                    SqlCon = new SqlConnection(SqlConnectionString);
                    SqlCon.Open();
                    flag = true;
                }
                catch
                {
                    flag = false;
                    //throw ex;
                }
                finally
                {
                    SqlCon.Close();
                    Dispose();
                }
                return flag;
            }
        }
        #endregion
    }
}
