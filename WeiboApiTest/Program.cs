using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDimension;
using NetDimension.Weibo;
using System.IO;
using Weibo;
using Weibo.Entity;

namespace WeiboApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string appKey = "3176941170";
            string appSecret = "c8b0e575fc601fd12b1e2bd0f81801b8";

            string accessToken = "2.00ymablBcWHATDc0636778100SeTIK";
            string mid = "BrFqN2SIm";
            Int64 id = 3765941210686982;    //微博id
            string ids = "3765941210686982,3766630393333253";
            Int64 uid = 1619580180;
            string screenName = "创意吧devere";
            string client_id = "ljxlwb";
            string code = "b6f8cc89de699522847f8b2e283c646d";
            string callBackUrl = System.Web.HttpUtility.UrlEncode("http://www.wpdever.net");

            //string url = string.Format("https://api.weibo.com/oauth2/access_token?client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}", client_id, appSecret, "http://www.wpdever.net", code);
            //http://www.wpdever.net/plugin.php?id=ljxlwb&code=b6f8cc89de699522847f8b2e283c646d
            //Oauth2.Authorize(appKey, returnUrl, "", "", Weibo.Enums.DisplayType.Client, false, "");
            //Oauth2.AccessToken(appKey, appSecret, "authorization_code", code, returnUrl);
            //AccessTokenEntity token = Oauth2.ClientLogin("kugeligui", "899092ligui", appKey, callBackUrl);

            //Weibo.Entity.TimelineEntity timeline = Statuses.PublicTimeLine(accessToken);

            Statuses statuses = new Statuses(accessToken);
            //Weibo.Entity.TimelineEntity timeline = statuses.PublicTimeLine();

            //OAuth oauth = new OAuth(appKey, appSecret, callBackUrl);
            //var result = oauth.ClientLogin("kugeligui", "899092ligui");
            ////AccessToken accessToken = null;
            //if (oauth.ClientLogin("kugeligui", "899092ligui"))
            //{
            //    Console.WriteLine(oauth.AccessToken);
            //    Client client = new Client(oauth);
            //    string uids = client.API.Entity.Account.GetUID();
            //    var count = client.API.Entity.Users.Counts(uids);
            //    var face = client.API.Entity.Users;
            //    //int count = 0;
            //    //var result = face.Counts(uid);
            //    //foreach (var item in count)
            //    //{
            //    //    Console.WriteLine(item.StatusCount);
            //    //}
            //    Console.WriteLine(uid);
            //}

            //AuthorizeEntity authorize = Oauth2.Authorize(appKey, "", null, "", Display.Default);
            //Console.WriteLine(authorize.Code);

            //var result = Oauth2.GetTokenInfo(s);
            //if (result != null)
            //{
            //    Console.WriteLine(result.UID);
            //}
            //var result = Oauth2.RevokeOauth2(s);

            //var result = Statuses.Destroy(accessToken, 3767406252280130);
            //var result = Statuses.Show(accessToken, 3767408299214634);
            //var result1 = Statuses.QueryMid(accessToken, "1313");
            //var result2 = Statuses.QueryId(accessToken, "8Ras3qlz", inBase62: 1);

            //var result = Statuses.Count(accessToken, ids);

            //var result = Statuses.Update(accessToken, "今天很开心啊，有没有呢？");
            //Statuses.Destroy(accessToken, result.ID);
            //Console.WriteLine(result.favorited);

            //string str;
            //using (StreamReader reader = new StreamReader(@"D:\1.gif"))
            //{
            //    str = reader.ReadToEnd();
            //}

            //创建和删除评论
            //var result = Comments.Create(accessToken, "测试删除", id);
            //Comments.Destroy(accessToken, result.id);

            //var result = Comments.DestroyBatch(accessToken, "3724285665500142,3726593493416367,3722625597655213");
            //int count = 20;
            //while (count > 0)
            //{
            //    var result = Comments.ToMe(accessToken, count: 20);
            //    StringBuilder sb = new StringBuilder();
            //    if (result != null)
            //    {
            //        var comments = result.Comments;
            //        count = comments.Count();
            //        comments.ToList().ForEach(m => sb.Append(m.id + ","));
            //        if (sb.Length > 0)
            //        {
            //            sb.Remove(sb.Length - 1, 1);
            //        }
            //    }
            //    var destroys = Comments.DestroyBatch(accessToken, sb.ToString());
            //}
            //var result = Users.Show(accessToken, 549322842);

            //var result = Friendships.CommonFriends(accessToken, uid);
            //var result = Friendships.Friends(accessToken, uid);
            //var result = Friendships.FollowersChain(accessToken, uid);
            //var result = Friendships.Show(accessToken, uid, null, 0, "kugeligui");
            //var result = Friendships.Create(accessToken, 0, "kugeligui");
            //var result = Friendships.Destroy(accessToken, 0, "kugeligui");
            //var result = Friendships.UpdateRemark(accessToken, uid, "王八蛋");

            //var result = Account.GetPrivacySet(access Token);
            //var result = Account.GetSchoolList(accessToken, 43, 4, 0, SchoolType.高中, 'c', "c");
            //var result = Account.RateLimitStatus(accessToken);
            //var result = Account.GetUId(accessToken);
            //var result = Account.LogOut(accessToken);

            //var result = Favorites.GetFavorites(accessToken);
            //var result = Favorites.GetFavoriteIds(accessToken);
            //var result = Favorites.GetFavoritesByTag(accessToken, 0);
            //var result = Favorites.GetTags(accessToken);
            //var result = Favorites.GetFavoritesByTag(accessToken, 240);

            //var result1 = Favorites.GetFavoriteIds(accessToken);
            //var result = Favorites.Show(accessToken, result1.Favorites.ToList()[0].status);
            //var result = Favorites.Show(accessToken, 1);
            //var result = Favorites.Create(accessToken, id);
            //var result2 = Favorites.Destroy(accessToken, id);
            //var result2 = Favorites.UpdateTag(accessToken, id, "1,3");
            //var result = Favorites.GetTags(accessToken);
            //得到所有的标签
            //var tags = result.Tags;
            //获得tag内容为1的tag
            //var tag = tags.First(m => m.tag == "3");
            //更新标签
            //var result1 = Favorites.UpdateTag(accessToken, tag.id, "哈哈测试");
            //var result1 = Favorites.DestroyTag(accessToken, tag.id);
            //var result = Trends.Weekly(accessToken);
            //var result = Tags.Suggestions(accessToken);
            //var result = Statuses.Tags(accessToken);

            Console.ReadKey();
        }
    }
}
