//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System.Reflection;

namespace DotNet.DbUtilities
{
    using DotNet.Utilities;
    using System;

    /// <summary>
    /// DbHelperFactory
    /// 数据库服务工厂。
    /// 
    /// 修改纪录
    /// 
    ///		2009.07.23 版本：1.2 JiRiGaLa 每次都获取一个新的数据库连接，解决并发错误问题。
    ///		2008.09.23 版本：1.1 JiRiGaLa 优化改进为单实例模式。
    ///		2008.08.26 版本：1.0 JiRiGaLa 创建数据库服务工厂。
    /// 
    /// 版本：1.2
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.07.23</date>
    /// </author> 
    /// </summary>
    public class DbHelperFactory
    {
        private static readonly string DbHelperAssmely = BaseSystemInfo.DbHelperAssmely;
        private static readonly string DbHelperClass = BaseSystemInfo.DbHelperClass;

        #if (DEBUG)
            private static IDbHelper helper;
            private static object locker = new Object();
        #endif

        public static IDbHelper GetHelper()
        {
            // 写入调试信息
            #if (DEBUG)
                //这是每次都会已经获取过的数据库连接
                if (helper == null)
                {
                    lock (locker)
                    {
                        if (helper == null)
                        {
                            helper = (IDbHelper)Assembly.Load(DbHelperAssmely).CreateInstance(DbHelperClass, true);
                        }
                    }
                }
                return helper;
            #else
                // 这里是每次都获取新的数据库连接
                IDbHelper dbHelper = (IDbHelper)Assembly.Load(DbHelperAssmely).CreateInstance(DbHelperClass, true);
                // dbHelper.ConnectionString = DbHelper.ConnectionString;
                return dbHelper;
            #endif
        }
    }
}