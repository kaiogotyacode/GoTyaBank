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
        [MaxLength(14)]
        [MinLength(14)]
        public string? CNPJ { get; set; }
    }
}
