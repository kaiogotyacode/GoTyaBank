using CodeChallenge02.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge02.Database
{
    public class PicPayContext : DbContext
    {
        public PicPayContext(DbContextOptions<PicPayContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioComum> UsuariosComuns { get; set; }
        public DbSet<Lojista> Lojistas { get; set; }
     
    }
}
