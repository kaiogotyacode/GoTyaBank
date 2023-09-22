using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge02.Models
{
    public class Lojista : Usuario
    {

        public Lojista(Usuario usuario) => usuario.Descricao = "Lojista";


    }
}
