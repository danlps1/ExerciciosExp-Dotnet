using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Exercicio4.Application.Dtos;
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

    [Fact]
    public async Task Deve_Cadastrar_Materia_Sucesso()
    {
        // Arrange
        var materia = new MateriaDto { Nome = "Test" };

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/Materia", materia);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = await response.Content.ReadFromJsonAsync<MateriaDto>();
        responseData.Should().NotBeNull();
        responseData!.Nome.Should().Be("Test");
    }

}