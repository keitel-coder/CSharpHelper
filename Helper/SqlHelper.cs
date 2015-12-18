using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class SqlHelper
    {
        /// <summary>
        /// 执行数据库操作并返回第一行第一列的结果
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="paras">sql参数</param>
        /// <param name="commandType">sql语句类型</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(string connectionString, string cmdText, IEnumerable<SqlParameter> paras, CommandType commandType = CommandType.Text)
        {
            //检查传入参数
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(cmdText))
            {
                return null;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText))
                {
                    //添加参数
                    if (paras != null && paras.Count() > 0)
                    {
                        cmd.Parameters.AddRange(paras.ToArray());
                    }

                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    return obj;
                }
            }
        }

        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="paras">sql参数</param>
        /// <param name="commandType">sql语句类型</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText, IEnumerable<SqlParameter> paras, CommandType commandType = CommandType.Text)
        {
            //检查传入参数
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(cmdText))
            {
                return 0;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText))
                {
                    //添加参数
                    if (paras != null && paras.Count() > 0)
                    {
                        cmd.Parameters.AddRange(paras.ToArray());
                    }

                    conn.Open();
                    int count = cmd.ExecuteNonQuery();
                    conn.Close();
                    return count;
                }
            }
        }

        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到 System.Data.SqlClient.SqlCommand.Connection，并使用System.Data.CommandBehavior 值之一生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="paras">sql参数</param>
        /// <param name="commandType">sql语句类型</param>
        /// <returns>受影响的行数</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string cmdText, IEnumerable<SqlParameter> paras, CommandType commandType = CommandType.Text, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            //检查传入参数
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(cmdText))
            {
                return null;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText))
                {
                    //添加参数
                    if (paras != null && paras.Count() > 0)
                    {
                        cmd.Parameters.AddRange(paras.ToArray());
                    }

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(commandBehavior);
                    conn.Close();
                    return reader;
                }
            }
        }

        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到 System.Data.SqlClient.SqlCommand.Connection，并使用System.Data.CommandBehavior 值之一生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">要执行的sql语句</param>
        /// <param name="paras">sql参数</param>
        /// <param name="commandType">sql语句类型</param>
        /// <returns>受影响的行数</returns>
        public static DataTable ExecuteTable(string connectionString, string cmdText, IEnumerable<SqlParameter> paras, CommandType commandType = CommandType.Text, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            //检查传入参数
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(cmdText))
            {
                return null;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText))
                {
                    //添加参数
                    if (paras != null && paras.Count() > 0)
                    {
                        cmd.Parameters.AddRange(paras.ToArray());
                    }

                    DataTable table = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <returns>是否已关闭</returns>
        public static bool CloseConnetion(SqlConnection conn)
        {
            if (conn == null)
            {
                return false;
            }
            if (conn.State == ConnectionState.Closed)
            {
                return true;
            }
            else if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <returns>是否已打开</returns>
        public static bool OpenConnetion(SqlConnection conn)
        {
            if (conn == null)
            {
                return false;
            }
            if (conn.State == ConnectionState.Open)
            {
                return true;
            }
            else if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                return true;
            }
            else return false;
        }
    }
}
