using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar constraseña")]
        [Compare("Password", ErrorMessage = "No coinciden las contraseñas.")]
        public string ConfirmPassword { get; set; }
    }
}