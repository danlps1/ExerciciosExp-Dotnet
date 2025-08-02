    using Exercicio4.Domain.Entities;
    using Exercicio4.Domain.Interfaces;
    using Exercicio4.Infrastructure.Database;
    using Exercicio4.Infrastructure.Repositories.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;

    namespace Exercicio4.Infrastructure.Repositories;

    public class MateriaRepository : IMateriaRepository
    {
        private readonly AppDbContext _context;

        public MateriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Materia>> ListarAsync()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task<Materia> BuscarAsync(int id)
        {
            var materia = await _context.Materias.SingleOrDefaultAsync(m => m.Id == id);

            if (materia == null)
                throw new KeyNotFoundException($"Matéria com ID {id} não encontrada.");

            return materia;
        }

        public async Task<List<Materia>> BuscarListaPorIds(List<int> materiasIds)
        {
            {
                var materias = await _context.Materias
                    .Where(m => materiasIds.Contains(m.Id))
                    .ToListAsync();

                if (materias.Count <= 0)
                    throw new KeyNotFoundException("Matérias não encontradas");

                return materias;
            }
        }
    }