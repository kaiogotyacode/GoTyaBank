using System.ComponentModel.DataAnnotations;

namespace CodeChallenge02.ViewModels
{
    public class LojistaVM
    {
        [Required]
        [MaxLength(70)]
        public string? Nome { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "CNPJ inválido, verifique os campos e tente novamente")]
        [MinLength(14, ErrorMessage = "CNPJ inválido, verifique os campos e tente novamente")]
        public string? CNPJ { get; set; }
    }
}
