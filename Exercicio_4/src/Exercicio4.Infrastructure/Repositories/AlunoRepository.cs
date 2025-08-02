using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;
using Exercicio4.Infrastructure.Database;
using Exercicio4.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SalvarAsync(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Aluno>> ListarAsync()
    {
        return await _context.Alunos
            .Include(a => a.Grade.Materias)
            .ToListAsync();
    }

    public async Task<Aluno> BuscarAsync(int id)
    {
        var aluno = await _context.Alunos
            .Include(a => a.Grade.Materias)
            .SingleOrDefaultAsync(a => a.Id == id);

        if (aluno == null)
            throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");

        return aluno;
    }
}