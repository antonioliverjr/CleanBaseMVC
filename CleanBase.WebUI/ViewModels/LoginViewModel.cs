using System.ComponentModel.DataAnnotations;

namespace CleanBase.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é requerido.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password é requerido.")]
        [StringLength(20, ErrorMessage = "O {0} deve conter entre {2} até {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
