using MVC_Start.Models;
using System.Collections.Generic;

namespace MVC_Start.Models.ViewModels
{/// <summary>
/// ViewModel:作用是控制器中的某一action对应的视图统一使用强类型而非掺杂弱类型的方式--》使用见HomeController的Details
/// </summary>
/// 该页面负责HomeController中Details的razor页面 (DTO:数据传输对象)
    public class HomeDetailsViewModel
    {
        public Student Student { get; set; }
        public string PageTitle { get; set; }
    }
    public class HomeGetStuListViewModel
    {
        public IEnumerable<Student> StuList { get; set; }
        public string PageTitle { get; set; }
    }
}
