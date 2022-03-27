using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Start.Controllers
{

    public class ErrorController : Controller
    {   
        [Route("Error/{StatusCode}")]
        public IActionResult Index(int StatusCode)
        {
            switch(StatusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "页面不存在" +StatusCode;
                    break;
            }
            //var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            return View("NotFound");
        }
        [Route("Error")]
        public IActionResult Error()
        {
           

            return View("NotFound");
        }
    }
}
