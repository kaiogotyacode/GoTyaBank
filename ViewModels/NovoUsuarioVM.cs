using System.ComponentModel.DataAnnotations;

namespace CodeChallenge02.ViewModels
{
    public class NovoUsuarioVM
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
        public string? CPF { get; set; }

        [Required]
        [MaxLength(18)]
        public string? CNPJ { get; set; }

        [Required]
        public bool isPessoaFisica { get; set; }

    }
}
