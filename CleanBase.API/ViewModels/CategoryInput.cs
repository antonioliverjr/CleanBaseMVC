using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanBase.API.ViewModels
{
    public class CategoryInput
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Requerido")]
        [StringLength(100, ErrorMessage = "Tamanho do Nome deve ser entre 3 à 100 caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
