using System.ComponentModel.DataAnnotations;

namespace MovieStore.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnURL { get; set; } = "";
    }
}
