using Microsoft.AspNetCore.Http;
using MVC_Start.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Start.Models.ViewModels
{   
    /// <summary>
    /// 创建用户界面的DTO
    /// </summary>
    public class CreateStuViewMode
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "用户姓名不能为空")]
        [MaxLength(50, ErrorMessage = "用户姓名长度错误")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "用户专业不能为空")]
        [Display(Name="专业")]
        public MajorEnum? Major { get; set; }//主修科目
        [Required(ErrorMessage = "用户邮箱不能为空")]

        [Display(Name="邮箱")]
        public string Email { get; set; }

        [Display(Name = "头像图片")]
        public IFormFile Photo { get; set; }//单文件删除
        //public List<IFormFile> Photos { get; set; }//多文件上传
    }
}
