using System.ComponentModel.DataAnnotations;

namespace CodeChallenge02.ViewModels
{
    public class TransferenciaVM
    {
        [Required]
        [MaxLength(14, ErrorMessage = "CPF inválido, verifique os campo e tente novamente")]
        [MinLength(14, ErrorMessage = "CPF inválido, verifique os campo e tente novamente")]
        public string? payerID { get; set; }

        [Required]
        [MaxLength(18, ErrorMessage = "CPF ou CNPJ inválido, verifique os campo e tente novamente")]
        [MinLength(14, ErrorMessage = "CPF ou CNPJ inválido, verifique os campo e tente novamente")]
        public string? payeeID { get; set; }

        [Required]        
        public decimal Amount { get; set; }

    }
}
