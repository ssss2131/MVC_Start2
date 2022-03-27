using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Start.Models.ViewModels
{
    public class EditeRoleViewModel
    {
        public EditeRoleViewModel()
        {
            Users = new List<string>();
        }
        [Display(Name ="角色Id")]
        public string Id { get; set; }
        [Required(ErrorMessage ="角色名称是必须填的")]
        [Display(Name ="角色名称")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
