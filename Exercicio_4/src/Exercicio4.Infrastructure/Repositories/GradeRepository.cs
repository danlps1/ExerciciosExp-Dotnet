using Exercicio4.Domain.Entities;
using Exercicio4.Domain.Interfaces;
using Exercicio4.Infrastructure.Database;
using Exercicio4.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Infrastructure.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;

    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SalvarAsync(Grade grade)
    {
        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Grade>> ListarAsync()
    {
        return await _context.Grades
            .Include(g => g.Materias)
            .ToListAsync();
    }

    public async Task<Grade> BuscarAsync(int id)
    {
        var grade = await _context.Grades
            .Include(g => g.Materias)
            .SingleOrDefaultAsync(g => g.Id == id);

        if (grade == null)
            throw new KeyNotFoundException($"Grade com ID {id} não encontrada.");

        return grade;
    }
}