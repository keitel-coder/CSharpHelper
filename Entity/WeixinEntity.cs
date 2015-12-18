using System;
namespace SZHome.Entity
{
    /// <summary>
    /// 数据表Weixin的实体类
    /// </summary>
    [Serializable]
    public class WeixinEntity
    {
        #region Private Parameters
        private int _Id;
        private int _UserId;
        #endregion

        #region Public Properties

        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        public int UserId
        {
            get { return this._UserId; }
            set { this._UserId = value; }
        }

        #endregion
    }
}
