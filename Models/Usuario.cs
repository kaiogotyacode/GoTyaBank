using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge02.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Saldo = 300m;    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string? Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string?  CPF_CNPJ { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        public string? Descricao { get; set; }

        public decimal Saldo { get; set; }


    }
}
