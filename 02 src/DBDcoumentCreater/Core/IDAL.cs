/* ==============================================================================
   * 文 件 名:IDAL
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
using System.Text;

namespace DBDcoumentCreater.Lib
{
    /// <summary>
    /// IDAL
    /// </summary>
    public interface IDAL
    {
        DataTable GetTables();
        List<DataTable> GetTableStruct(List<string> tables);
        List<DataTable> GetTableData(List<string> tables);
    }
}