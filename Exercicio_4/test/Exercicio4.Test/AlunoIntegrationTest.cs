using System.Net;
using System.Net.Http.Json;
using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;
using Exercicio4.Test.Factory;
using FluentAssertions;

namespace Exercicio4.Test;

public class AlunoIntegrationTest : IntegrationTestBase
{
    private readonly HttpClient _httpClient;

    public AlunoIntegrationTest(Exercicio4WebApplicationFactory factory) : base(factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Deve_Cadastrar_Aluno_Sucesso()
    {
        var grade = await CriarGradeAsync();
        var aluno = new AlunoDto() { Nome = "Teste", GradeId = grade.Id };

        var response = await _httpClient.PostAsJsonAsync("/api/Aluno", aluno);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = await response.Content.ReadFromJsonAsync<Aluno>();
        responseData.Should().NotBeNull();
        responseData.Nome.Should().Be("Teste");
        responseData.Id.Should().BeGreaterThan(0);
        responseData.Grade.Id.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public async Task Deve_Exibir_Historico_Alunos_Sucesso()
    {
        await CriarAlunoAsync();
        await CriarAlunoAsync();

        var response = await _httpClient.GetAsync("/api/Aluno/historico");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseData = await response.Content.ReadFromJsonAsync<List<Aluno>>();
        responseData.Should().NotBeNull();
        responseData.Count.Should().Be(2);
        responseData[0].Id.Should().BeGreaterThan(0);
    }
}