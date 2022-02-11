using CleanBase.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanBase.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Requerido")]
        [StringLength(100, ErrorMessage = "Tamanho do Nome deve ser entre 3 à 100 caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descrição é Requerido")]
        [StringLength(250, ErrorMessage = "Tamanho da Descrição deve ser entre 5 à 250 caracteres.", MinimumLength = 5)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Preço é Requerido")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Estoque é Requerido")]
        [Range(1, 9999)]
        [Display(Name = "Estoque")]
        public int Stock { get; set; }
        [MaxLength(250, ErrorMessage = "Nome da Imagem deve ter até 250 caracteres.")]
        [Display(Name = "Imagem Produto")]
        public string Image { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
    }
}
