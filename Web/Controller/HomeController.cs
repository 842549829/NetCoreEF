using System.Text;
using Microsoft.AspNetCore.Mvc;
using Web.Code;

namespace Web.Controller
{
    /// <summary>
    /// Home
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult Index()
        {
            var session = Code.HttpContext.Current.Session;
            session.Set("keyxx", "ssss");
            var content = session.Get<string>("keyxx");

            return this.View();
        }
    }
}