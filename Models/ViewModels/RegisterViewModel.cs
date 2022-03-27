using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MVC_Start.CustomerMiddlerwares.util;

namespace MVC_Start.Models.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        [Display(Name ="邮箱地址")]
        [Remote(action:"IsEmailInUse",controller:"Account")]

        [ValidEmail(allowDomain:"qq.com",ErrorMessage ="邮箱必须以qq.com结尾")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="密码与确认密码不一致，请重新输入。")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
    }
}
