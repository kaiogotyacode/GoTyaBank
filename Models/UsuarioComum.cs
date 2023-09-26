namespace CodeChallenge02.Models
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum()
        {
            isPessoaFisica = true;
        }
        public string? CPF { get; set; }
    }
}
