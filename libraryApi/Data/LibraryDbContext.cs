using Microsoft.EntityFrameworkCore;
using libraryApi.Models;

namespace libraryApi.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Carrega a string de conexão do ambiente e configura o DbContext
                var dbConnectionString = System.Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
                optionsBuilder.UseNpgsql(dbConnectionString);
            }
        }
    }
}
