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
    /// ���ݿ���񹤳���
    /// 
    /// �޸ļ�¼
    /// 
    ///		2009.07.23 �汾��1.2 JiRiGaLa ÿ�ζ���ȡһ���µ����ݿ����ӣ���������������⡣
    ///		2008.09.23 �汾��1.1 JiRiGaLa �Ż��Ľ�Ϊ��ʵ��ģʽ��
    ///		2008.08.26 �汾��1.0 JiRiGaLa �������ݿ���񹤳���
    /// 
    /// �汾��1.2
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
            // д�������Ϣ
            #if (DEBUG)
                //����ÿ�ζ����Ѿ���ȡ�������ݿ�����
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
                // ������ÿ�ζ���ȡ�µ����ݿ�����
                IDbHelper dbHelper = (IDbHelper)Assembly.Load(DbHelperAssmely).CreateInstance(DbHelperClass, true);
                // dbHelper.ConnectionString = DbHelper.ConnectionString;
                return dbHelper;
            #endif
        }
    }
}