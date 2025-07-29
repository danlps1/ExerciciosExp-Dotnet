using Exercicio_3.Database;
using Exercicio_3.Entities;
using Exercicio_3.Services.Dtos;
using Exercicio_3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_3.Services;

public class VeiculoService : IVeiculoService
{
    private readonly AppDbContext _context;

    public VeiculoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Veiculo> CadastrarVeiculo(VeiculoDto veiculoDto)
    {
        Veiculo novoVeiculo = new Veiculo();

        try
        {
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == veiculoDto.CategoriaId);

            if (categoria == null)
            {
                throw new BadHttpRequestException("Categoria não encontrada");
            }

            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.Id == veiculoDto.MarcaId);


            if (marca == null)
            {
                throw new BadHttpRequestException("Marca não encontrada");
            }

            novoVeiculo.Nome = veiculoDto.Nome;
            novoVeiculo.Modelo = veiculoDto.Modelo;
            novoVeiculo.Cor = veiculoDto.Cor;
            novoVeiculo.Ano = veiculoDto.Ano;
            novoVeiculo.Categoria = categoria;
            novoVeiculo.Marca = marca;

            _context.Veiculos.Add(novoVeiculo);
            await _context.SaveChangesAsync();

            return novoVeiculo;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao cadastrar veículo: {e.Message}");
        }
    }

    public async Task<List<Veiculo>> ListarVeiculos()
    {
        try
        {
            var veiculos = await _context.Veiculos
                .Include(v => v.Marca)
                .Include(v => v.Categoria)
                .ToListAsync();

            return veiculos;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao listar veículos: {e.Message}");
        }
    }

    public async Task<Veiculo> BuscarVeiculoPorId(int veiculoId)
    {
        try
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.Marca)
                .Include(v => v.Categoria)
                .FirstOrDefaultAsync(v => v.Id == veiculoId);

            if (veiculo == null)
            {
                throw new ArgumentException("Veículo não encontrado");
            }

            return veiculo;
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao buscar veículo: {e.Message}");
        }
    }

    public Task<Veiculo> EditarVeiculo(int veiculoId, VeiculoDto veiculo)
    {
        throw new NotImplementedException();
    }

    public async Task<string> DeletarVeiculo(int veiculoId)
    {
        try
        {
            var veiculo = await BuscarVeiculoPorId(veiculoId);

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return "Veículo deletado com sucesso.";
        }
        catch (Exception e)
        {
            throw new BadHttpRequestException($"Erro ao deletar veículo: {e.Message}");
        }
    }
}