using Exercicio4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    public DbSet<Materia> Materias { get; set; }

    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.ToTable("tb_alunos");

            entity.HasOne(a => a.Grade)
                .WithMany(g => g.Alunos)
                .HasForeignKey(a => a.GradeId);
        });

        modelBuilder.Entity<Materia>(entity => { entity.ToTable("tb_materias"); });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("tb_grades");

            entity.HasMany(g => g.Alunos)
                .WithOne(a => a.Grade)
                .HasForeignKey(a => a.GradeId);


            entity.HasMany(g => g.Materias)
                .WithMany(m => m.Grades)
                .UsingEntity(j => j.ToTable("GradeMaterias"));
        });

        base.OnModelCreating(modelBuilder);
    }
}