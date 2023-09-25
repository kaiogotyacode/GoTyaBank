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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => new { u.CPF })
                .IsUnique().HasFilter("[isPessoaFisica] = 1");
            
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => new { u.CNPJ })
                .IsUnique().HasFilter("[isPessoaFisica] = 0");
        }
    }
}
