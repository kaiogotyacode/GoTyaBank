using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge02.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; } 
        public Usuario() => Saldo = 300.00m;     

        [Required]
        [MaxLength(70)]
        public string? Nome { get; set; }

        //[Required]
        [MaxLength(14)]
        public string? CPF { get; set; }

        //[Required]
        [MaxLength(18)]
        public string? CNPJ { get; set; }

        [Required]
        public bool isPessoaFisica { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        public decimal Saldo { get; set; }


    }
}
