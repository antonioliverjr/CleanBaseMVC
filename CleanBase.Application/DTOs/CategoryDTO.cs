using System.ComponentModel.DataAnnotations;

namespace CleanBase.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Requerido")]
        [StringLength(100, ErrorMessage = "Tamanho do Nome deve ser entre 3 à 100 caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
