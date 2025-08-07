using Exercicio4.Domain.Entities;
using Exercicio4.Infrastructure.Database;
using Exercicio4.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Infrastructure.Repositories;

public class NotaRepository : INotaRepository
{
    private readonly AppDbContext _context;

    public NotaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SalvarAsync(Nota nota)
    {
        _context.Notas.Add(nota);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Nota>> ListarAsync()
    {
        return await _context.Notas
            .Include(n => n.Materia)
            .ToListAsync();
    }

    public async Task<Nota> BuscarAsync(int id)
    {
        var nota = await _context.Notas
            .Include(n => n.Materia)
            .SingleOrDefaultAsync();

        if (nota == null)
            throw new KeyNotFoundException($"Grade com ID {id} não encontrada.");

        return nota;
    }

    public async Task<List<Nota>> BuscarPorMateria(int materiaId, int alunoId)
    {
        var notas = await _context.Notas
            .Where(n => n.AlunoId == alunoId)
            .Where(n => n.MateriaId == materiaId)
            .ToListAsync();
            
        return notas;
    }
}