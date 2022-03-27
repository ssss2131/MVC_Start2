using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Start.Models
{/// <summary>
/// 管理具体数据
/// </summary>
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="用户姓名不能为空")]
        [MaxLength(50,ErrorMessage ="用户姓名长度错误")]
        [Display(Name="姓名")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "用户专业不能为空")]
        [DisplayName("专业")]
        public MajorEnum? Major { get; set; }//主修科目
        [Required(ErrorMessage = "用户邮箱不能为空")]
    
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [Display(Name = "头像图片")]
        public string PhotoPath { get; set; }

    }
}
