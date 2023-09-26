namespace CodeChallenge02.Models
{
    public class Lojista : Usuario
    {
        public Lojista()
        {
            isPessoaFisica = false;
        }
        public string? CNPJ { get; set; }
    }
}
