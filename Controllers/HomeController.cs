using System;
using System.IO;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using MVC_Start.Models;
using MVC_Start.Models.ViewModels;


namespace MVC_Start.Controllers
{
    /* [Route("WWC/Index")]*///(规定通用路由)提取公有内容  --mark 属性路由:使用特性的方式去操作浏览器的URL=>!!自定义路由方式
    
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;



        //依赖注入 松耦合 第一步 然后去startup=>
        public HomeController(IStudentRepository studentRepository,IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }
     
        //[Route("Index")]   //属性路由参数与控制器非强关联
        public JsonResult Index()//不遵守请求协商 ObjectResult()
        {
            return Json(_studentRepository.GetStudent(1));
        }

        public IActionResult Details(int Id)
        {
            //使用ViewModel方式
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(Id),
                PageTitle = "学生页面"
            };

            return View(homeDetailsViewModel);
        }
        //当URL为空时使用
        [Route("~/")]
        [Route("")]
        //[Authorize]
        public IActionResult GetStuList()
        {                     
            return View(_studentRepository.GetStuList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStuViewMode mode)
        {
            string unqiueFileName = null;//定义唯一的文件名
            #region  多文件上传
            //if (mode.Photos != null && mode.Photos.Count>0) {

            //    foreach (var item in mode.Photos)
            //    {
            //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            //        unqiueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;

            //        string filePath = Path.Combine(uploadsFolder, unqiueFileName);

            //        item.CopyTo(new FileStream(filePath, FileMode.Create));
            //    }

            //}
            #endregion
            if (mode.Photo != null) { 
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                unqiueFileName = Guid.NewGuid().ToString() + "_" + mode.Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, unqiueFileName);

                mode.Photo.CopyTo(new FileStream(filePath, FileMode.Create)); 
            }
                Student stu = new Student()
                {
                    Name = mode.Name,
                    Email = mode.Email,
                    Major = mode.Major,
                    PhotoPath = unqiueFileName,
                };
           
            if (!ModelState.IsValid)
            { 
                return View(mode); 
            }
            else
            { 
                _studentRepository.AddStu(stu);
                return RedirectToAction("Details", new { id = stu.Id});
            }
           
        }
        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return RedirectToAction("GetStuList");
        }

        [HttpGet]
        public IActionResult Editor(int id)
        {
            Student stu = _studentRepository.GetStudent(id);
            UpdateViewModel updateViewModel = new UpdateViewModel()
            {
                Name = stu.Name,
                Id = stu.Id,
                Email = stu.Email,
                Major = stu.Major,
                ExistingPhotoPath = stu.PhotoPath
            };
            return View(updateViewModel);
        }

        [HttpPost]
        public IActionResult Editor(UpdateViewModel mode)
        {
            string unqiueFileName = null;//定义唯一的文件名

            if (ModelState.IsValid)
            {
                Student stu = _studentRepository.GetStudent(mode.Id);
                stu.Name = mode.Name;
                stu.Email = mode.Email;
                stu.Major = mode.Major;
                if (mode.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", mode.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                if (mode.Photo!=null)
                {
                    
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    unqiueFileName = Guid.NewGuid().ToString() + "_" + mode.Photo.FileName;

                    string filePath = Path.Combine(uploadsFolder, unqiueFileName);

                    //mode.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        mode.Photo.CopyTo(fileStream);
                    }

                }
                
               
                stu.PhotoPath = unqiueFileName;

                _studentRepository.Update(stu);

                return RedirectToAction("Details", new { id = stu.Id });


            }
            else
                return View(mode);
        }

    }
}
