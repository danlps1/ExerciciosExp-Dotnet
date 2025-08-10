using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Exercicio4.Application.Dtos;
using Exercicio4.Domain.Entities;
using Exercicio4.Test.Factory;
using FluentAssertions;

namespace Exercicio4.Test;

public class MateriaIntegrationTest : IClassFixture<Exercicio4WebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public MateriaIntegrationTest(Exercicio4WebApplicationFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    private async Task CriarMateriaAsync(string nome = "Teste")
    {
        var materia = new MateriaDto { Nome = nome };
        await _httpClient.PostAsJsonAsync("/api/Materia", materia);
    }

    [Fact]
    public async Task Deve_Cadastrar_Materia_Sucesso()
    {
        var materia = new MateriaDto { Nome = "Test" };

        var response = await _httpClient.PostAsJsonAsync("/api/Materia", materia);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = await response.Content.ReadFromJsonAsync<Materia>();
        responseData.Should().NotBeNull();
        responseData.Nome.Should().Be("Test");
    }

    [Fact]
    public async Task Deve_Listar_Materias_Sucesso()
    {
        await CriarMateriaAsync();

        var response = await _httpClient.GetAsync("/api/Materia");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseData = await response.Content.ReadFromJsonAsync<List<Materia>>();
        responseData.Should().NotBeNull();
        responseData.Should().ContainSingle("Teste");
    }

    [Fact]
    public async Task Deve_Buscar_Materia_Por_Id_Sucesso()
    {
        await CriarMateriaAsync();

        var response = await _httpClient.GetAsync($"/api/Materia/1");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseData = await response.Content.ReadFromJsonAsync<Materia>();
        responseData.Should().NotBeNull();
        responseData.Id.Should().Be(1);
        responseData.Nome.Should().Be("Teste");
    }
}