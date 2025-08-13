using System.Net;
using System.Net.Http.Json;
using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;
using Exercicio4.Test.Factory;
using FluentAssertions;

namespace Exercicio4.Test;

public class NotaIntegrationTest : IntegrationTestBase
{
    private readonly HttpClient _httpClient;
    
    public NotaIntegrationTest(Exercicio4WebApplicationFactory factory) : base(factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Deve_Cadastrar_Nota_Sucesso()
    {
        var aluno = await CriarAlunoAsync();
        var materia = await CriarMateriaAsync();

        var nota = new NotaDto() { AlunoId = aluno.Id, MateriaId = materia.Id, Nota = 80 };

        var response = await _httpClient.PostAsJsonAsync("/api/Nota", nota);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        var responseData = await response.Content.ReadFromJsonAsync<List<Nota>>();
        responseData.Should().NotBeNull();
        responseData[0].Id.Should().BeGreaterThan(0);
        responseData[0].AlunoId.Should().Be(nota.AlunoId);
        responseData[0].MateriaId.Should().Be(nota.MateriaId);
        responseData[0].Valor.Should().Be(nota.Nota);
    }
}