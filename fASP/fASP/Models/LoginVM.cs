using System.ComponentModel.DataAnnotations;

namespace fASP.Models
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberUSer { get; set; }
    }
}
