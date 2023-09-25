using System.ComponentModel.DataAnnotations;

namespace CodeChallenge02.ViewModels
{
    public class UsuarioTransferenciaVM
    {
        [Required]
        [MaxLength(18)]
        public string? CadastroPagador { get; set; }

        [Required]
        [MaxLength(18)]
        public string? CadastroBeneficiario { get; set; }

        [Required]        
        public decimal ValorTransferencia { get; set; }

    }
}
