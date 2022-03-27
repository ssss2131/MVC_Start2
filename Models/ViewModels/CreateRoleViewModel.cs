using System.ComponentModel.DataAnnotations;

namespace MVC_Start.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="角色名字")]
        public string RoleName { get; set; }
    }
}
