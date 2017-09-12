/* ==============================================================================
   * 文 件 名:DALFacotry
   * 功能描述：
   * Copyright (c) 2012 武汉经纬视通科技有限公司
   * 创 建 人: gaoqiang
   * 创建时间: 2013/3/18 15:27:47
   * 修 改 人: 
   * 修改时间: 
   * 修改描述: 
   * 版    本: v1.0.0.0
   * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DBDcoumentCreater.Lib
{
    /// <summary>
    /// DALFacotry
    /// </summary>
    public class DALFacotry
    {
        public static IDAL Create(string dbType, string Conn)
        {
            switch (dbType)
            {
                case "SQL2005及以上": return new SqlDAL(Conn);
                case "Oracle": return new OracleDAL(Conn);
                default: return null;
            }
        }
    }
}