using System.ComponentModel.DataAnnotations;

namespace CleanBase.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email é requerido.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é requerido.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Repita a senha, para confirmação.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "Senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
