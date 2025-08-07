using Exercicio4.Application.Dtos;
using Exercicio4.Application.Interfaces;
using Exercicio4.Domain.Entities;
using Exercicio4.Infrastructure.Repositories.Interfaces;

namespace Exercicio4.Application.Services;

public class NotaService : INotaService
{
    private readonly INotaRepository _notaRepository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMateriaRepository _materiaRepository;

    public NotaService(INotaRepository notaRepository, IAlunoRepository alunoRepository,
        IMateriaRepository materiaRepository)
    {
        _notaRepository = notaRepository;
        _alunoRepository = alunoRepository;
        _materiaRepository = materiaRepository;
    }

    public async Task<List<Nota>> Cadastrar(NotaDto notaDto)
    {
        List<Nota> list = new List<Nota>();

        try
        {
            var aluno = await _alunoRepository.BuscarAsync(notaDto.AlunoId);
            var materia = await _materiaRepository.BuscarAsync(notaDto.MateriaId);

            var notas = await _notaRepository.BuscarPorMateria(notaDto.MateriaId, notaDto.AlunoId);

            // Conta quantas notas com valor >= 80
            int materiasConcluidas = notas.Count(n => n.Valor >= 80);

            if (materiasConcluidas >= 3)
            {
                throw new ApplicationException("Matéria já concluída. Não é permitido cadastrar mais notas.");
            }

            var novaNota = new Nota()
            {
                Valor = notaDto.Nota,
                Materia = materia,
                Aluno = aluno
            };

            await _notaRepository.SalvarAsync(novaNota);
            list.Add(novaNota);

            return list;
        }
        catch (Exception e)
        {
            throw new ApplicationException("Erro ao cadastrar nota: ", e);
        }
    }
}