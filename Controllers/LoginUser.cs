using Microsoft.AspNetCore.Mvc;

namespace MVC_Start.Controllers
{
    [Route("[controller]/[action]")] 

    public class LoginUser : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Index(string username, string password)
        {
            if (username == "sa" && password == "123456")
            {
                return Content("<script>alert('登录成功!')</script>");
            }
            else
            {
                return Content("<script>alert('用户名或者密码不对！')</script>");
            }
        }

       
    }
    
}
