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

    public Task<List<Veiculo>> ListarVeiculos()
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo> BuscarVeiculoPorId(int veiculoId)
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo> EditarVeiculo(int veiculoId, VeiculoDto veiculo)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeletarVeiculo(int veiculoId)
    {
        throw new NotImplementedException();
    }
}