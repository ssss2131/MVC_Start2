using System.ComponentModel.DataAnnotations;

namespace MVC_Start.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name ="记住我")]
        public bool RememberMe { get; set; }
    }
}
