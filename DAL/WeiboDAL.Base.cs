using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using YiTu.DBUtility;
namespace SZHome.DAL
{
    /// <summary>
    /// 数据表Weibo的数据操作类
    /// </summary>
    public partial class WeiboDAL
    {
        #region ConstVariables
        private const string C_TABLE_NAME = "Weibo";
        private const string C_SP_WEIBO_FIELDS = "[UID],[UserId],[Access_Token]";
        private const string C_SP_WEIBO_INSERT = "INSERT INTO [Weibo]([UID],[UserId],[Access_Token]) VALUES(@UID,@UserId,@Access_Token);";
        private const string C_SP_WEIBO_UPDATE = "UPDATE [Weibo] SET [UID]=@UID,[UserId]=@UserId,[Access_Token]=@Access_Token WHERE [UID] = @UID";
        private const string C_SP_WEIBO_DELETE = "DELETE [Weibo] WHERE [UID] = @UID";
        private const string C_SP_WEIBO_GET = "SELECT [UID],[UserId],[Access_Token] FROM [Weibo] WHERE [UID] = @UID";
        #endregion

        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Login"].ConnectionString;
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        private WeiboDAL() { }

        /// <summary>
        /// 向数据表中插入一条新记录
        /// </summary>
        /// <param name="entity">Entity.WeiboEntity实体类</param>
        /// <remarks>如果表存在自增长字段，插入记录成功后自增长字段值会更新至实体</remarks>
        public static void Insert(Entity.WeiboEntity entity)
        {
            List<SqlParameter> commandParms = new List<SqlParameter>();
            commandParms.Add(SqlHelper.CreateParam("@UID", SqlDbType.Int, 0, ParameterDirection.Input, entity.UID));
            commandParms.Add(SqlHelper.CreateParam("@UserId", SqlDbType.Int, 0, ParameterDirection.Input, entity.UserId));
            commandParms.Add(SqlHelper.CreateParam("@Access_Token", SqlDbType.NChar, 32, ParameterDirection.Input, entity.Access_Token));

            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, C_SP_WEIBO_INSERT, commandParms);
        }

        /// <summary>
        /// 获取数据库一条记录实体(根据主键条件)
        /// </summary>
        /// <param name="uID">微博id</param>
        /// <returns>Entity.WeiboEntity实体类</returns>
        public static Entity.WeiboEntity GetByUID(int uID)
        {
            Entity.WeiboEntity entity = null;
            List<SqlParameter> commandParms = new List<SqlParameter>();
            commandParms.Add(SqlHelper.CreateParam("@UID", SqlDbType.Int, 0, ParameterDirection.Input, uID));

            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, C_SP_WEIBO_GET, commandParms))
            {
                if (reader.Read())
                {
                    entity = ConvertToEntityFromDataReader(reader);
                }
            }

            return entity;
        }

        /// <summary>
        /// 更新数据库中一条记录(根据主键条件)
        /// </summary>
        /// <param name="entity">Entity.WeiboEntity实体类</param>
        public static void Update(Entity.WeiboEntity entity)
        {
            List<SqlParameter> commandParms = new List<SqlParameter>();

            commandParms.Add(SqlHelper.CreateParam("@UID", SqlDbType.Int, 0, ParameterDirection.Input, entity.UID));
            commandParms.Add(SqlHelper.CreateParam("@UserId", SqlDbType.Int, 0, ParameterDirection.Input, entity.UserId));
            commandParms.Add(SqlHelper.CreateParam("@Access_Token", SqlDbType.NChar, 32, ParameterDirection.Input, entity.Access_Token));

            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, C_SP_WEIBO_UPDATE, commandParms);
        }

        /// <summary>
        /// 删除数据库中一条记录(根据主键条件)
        /// </summary>
        /// <param name="uID">微博id</param>
        public static void Delete(int uID)
        {
            List<SqlParameter> commandParms = new List<SqlParameter>();
            commandParms.Add(SqlHelper.CreateParam("@UID", SqlDbType.Int, 0, ParameterDirection.Input, uID));
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, C_SP_WEIBO_DELETE, commandParms);
        }

        /// <summary>
        /// 按条件查询数据表,返回DataTable类型数据
        /// </summary>
        /// <param name="whereClause">SQL条件语句(可为空)，不须带"Where"关键字</param>
        /// <param name="dataFields">需返回字段(不能为空,为"*"则返回所有字段)</param>
        /// <param name="orderBy">SQL排序语句(不能为空)，不须带"Order By"关键字</param>
        /// <param name="startRowIndex">记录开始索引，从0开始</param>
        /// <param name="maximumRows">返回记录数量</param>
        /// <returns>DataTable</returns>
        public static DataTable SearchDT(string whereClause, string dataFields, string orderBy, int startRowIndex, int maximumRows)
        {
            if (dataFields.Trim() == "*")
            {
                dataFields = C_SP_WEIBO_FIELDS;
            }
            return SqlListHepler.Search(ConnectionString, C_TABLE_NAME, dataFields, whereClause, orderBy, startRowIndex, maximumRows);
        }


        /// <summary>
        /// 按条件查询数据表,返回 Entity.WeiboEntity 数据集
        /// </summary>
        /// <param name="whereClause">SQL条件语句(可为空)，不须带"Where"关键字</param>
        /// <param name="orderBy">SQL排序语句(不能为空)，不须带"Order By"关键字</param>
        /// <param name="startRowIndex">记录开始索引，从0开始</param>
        /// <param name="maximumRows">返回记录数量</param>
        public static List<Entity.WeiboEntity> Search(string whereClause, string orderBy, int startRowIndex, int maximumRows)
        {
            List<Entity.WeiboEntity> list = new List<Entity.WeiboEntity>();
            using (SqlDataReader reader = SqlListHepler.SearchDataReader(ConnectionString, C_TABLE_NAME, C_SP_WEIBO_FIELDS, whereClause, orderBy, startRowIndex, maximumRows))
            {
                while (reader.Read())
                {
                    list.Add(ConvertToEntityFromDataReader(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 按条件查询数据表,返回DataTable类型数据
        /// </summary>
        /// <param name="whereClause">SQL条件语句(可为空)，不须带"Where"关键字</param>
        /// <param name="dataFields">需返回字段(不能为空,为"*"则返回所有字段)</param>
        /// <param name="orderBy">SQL排序语句(可为空)，不须带"Order By"关键字</param>
        /// <param name="rowsToReturn">返回记录数量</param>
        /// <returns>DataTable</returns>
        public static DataTable SearchDT(string whereClause, string dataFields, string orderBy, int rowsToReturn)
        {
            if (dataFields.Trim() == "*")
            {
                dataFields = C_SP_WEIBO_FIELDS;
            }
            return SqlListHepler.Search(ConnectionString, C_TABLE_NAME, dataFields, whereClause, orderBy, rowsToReturn);
        }

        /// <summary>
        /// 按条件查询数据表,返回 Entity.WeiboEntity 数据集
        /// </summary>
        /// <param name="whereClause">SQL条件语句(可为空)，不须带"Where"关键字</param>
        /// <param name="orderBy">SQL排序语句(可为空)，不须带"Order By"关键字</param>
        /// <param name="rowsToReturn">返回记录数量</param>
        public static List<Entity.WeiboEntity> Search(string whereClause, string orderBy, int rowsToReturn)
        {
            List<Entity.WeiboEntity> list = new List<Entity.WeiboEntity>();
            using (SqlDataReader reader = SqlListHepler.SearchDataReader(ConnectionString, C_TABLE_NAME, C_SP_WEIBO_FIELDS, whereClause, orderBy, rowsToReturn))
            {
                while (reader.Read())
                {
                    list.Add(ConvertToEntityFromDataReader(reader));
                }
            }
            return list;
        }

        /// <summary>
        /// 按条件获取记录数量
        /// </summary>
        /// <param name="whereClause">SQL条件语句(可为空)，不须带"Where"关键字</param>
        /// <returns>int整型数据</returns>
        public static int SearchCount(string whereClause)
        {
            return SqlListHepler.SearchCount(ConnectionString, C_TABLE_NAME, whereClause);
        }

        /// <summary>
        /// 转换DataRow类型数据记录为实体
        /// </summary>
        private static Entity.WeiboEntity ConvertToEntityFromDataRow(DataRow row)
        {
            Entity.WeiboEntity entity = new Entity.WeiboEntity();
            entity.UID = Convert.ToInt32(row["UID"]);
            entity.UserId = Convert.ToInt32(row["UserId"]);
            entity.Access_Token = row["Access_Token"].ToString();

            return entity;
        }

        /// <summary>
        /// 转换SqlDataReader类型数据记录为实体
        /// </summary>
        private static Entity.WeiboEntity ConvertToEntityFromDataReader(SqlDataReader reader)
        {
            Entity.WeiboEntity entity = new Entity.WeiboEntity();
            entity.UID = Convert.ToInt32(reader["UID"]);
            entity.UserId = Convert.ToInt32(reader["UserId"]);
            entity.Access_Token = reader["Access_Token"].ToString();

            return entity;
        }

    }
}
