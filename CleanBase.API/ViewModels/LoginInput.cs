using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanBase.API.ViewModels
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Email é requerido.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password é requerido.")]
        [StringLength(20, ErrorMessage = "O {0} deve conter entre {2} até {1}", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
