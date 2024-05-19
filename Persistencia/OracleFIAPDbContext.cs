using DaVinci.Models;
using DaVinci.Persistencia.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace DaVinci.Persistencia
{
    public class OracleFIAPDbContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }

        public OracleFIAPDbContext(DbContextOptions<OracleFIAPDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new FeedbackMapeamento());
        }
    }
}