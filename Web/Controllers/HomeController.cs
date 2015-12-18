using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            string token = Request["code"];
            string result = HttpHelper.Request("https://api.weibo.com/2/users/show.json?access_token=73d03bcdce1263794d5eb289caeab953", "get", null, Encoding.UTF8);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Redirect("http://news.baidu.com");
            }
            else return Redirect("http://www.baidu.com");
        }
    }
}
