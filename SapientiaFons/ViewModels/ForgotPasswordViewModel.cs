using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}