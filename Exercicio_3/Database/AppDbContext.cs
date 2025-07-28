using Exercicio_3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_3.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.ToTable("tb_veiculos");

            entity
                .HasOne(v => v.Categoria)
                .WithMany(c => c.Veiculos)
                .HasForeignKey(v => v.CategoriaId);

            entity
                .HasOne(v => v.Marca)
                .WithMany(m => m.Veiculos)
                .HasForeignKey(v => v.MarcaId);
        });

        modelBuilder.Entity<Marca>(entity =>
            entity.ToTable("tb_marcas"));

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("tb_categorias");

            entity.Property(c => c.TipoCategoria)
                .HasConversion<string>();
        });

        base.OnModelCreating(modelBuilder);
    }
}