using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge02.Models
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum(Usuario usuario) => usuario.Descricao = "Usuário Comum";
        
    }
}
