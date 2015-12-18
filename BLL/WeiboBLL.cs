using SZHome.DAL;
using SZHome.Entity;
namespace SZHome.BLL
{
    /// <summary>
    /// 数据表Weibo的业务逻辑类
    /// </summary>
    public static class WeiboBLL
    {
        public static bool Insert(WeiboEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            WeiboDAL.Insert(entity);
            return true;
        }

        public static bool IsExist(int uid)
        {
            string where = "uid=" + uid;
            int count = WeiboDAL.SearchCount(where);
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
