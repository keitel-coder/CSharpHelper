using System;
namespace SZHome.Entity
{
    /// <summary>
    /// 数据表Weibo的实体类
    /// </summary>
    [Serializable]
    public class WeiboEntity
    {
        #region Private Parameters
        private int _UID;
        private int _UserId;
        private string _Access_Token;
        #endregion

        #region Public Properties

        /// <summary>
        /// 微博id
        /// </summary>
        public int UID
        {
            get { return this._UID; }
            set { this._UID = value; }
        }

        /// <summary>
        /// 网站账号id
        /// </summary>
        public int UserId
        {
            get { return this._UserId; }
            set { this._UserId = value; }
        }

        /// <summary>
        /// 授权token
        /// </summary>
        public string Access_Token
        {
            get { return this._Access_Token; }
            set { this._Access_Token = value; }
        }

        #endregion
    }
}
