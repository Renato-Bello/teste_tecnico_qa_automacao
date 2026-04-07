using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace Backend.Tests.Integration.Categoria;

public class CategoriasIntegrationTests
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("http://localhost:5135")
    };

    [Fact]
    public async Task Deve_Criar_Categoria_Receita_Valida()
    {
        var categoria = new
        {
            Descricao = "Salario",
            Finalidade = 1
        };

        var response = await _client.PostAsJsonAsync("/api/v1/categorias", categoria);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Created,
            $"Esperado 200 ou 201, mas veio {(int)response.StatusCode}. Body: {body}"
        );

        var json = JsonDocument.Parse(body);
        var root = json.RootElement;

        Assert.True(root.TryGetProperty("id", out var idProp), "Resposta não contém 'id'.");
        Assert.False(string.IsNullOrWhiteSpace(idProp.GetString()));

        Assert.Equal("Salario", root.GetProperty("descricao").GetString());
        Assert.Equal(1, root.GetProperty("finalidade").GetInt32());
    }

    [Fact]
    public async Task Deve_Criar_Categoria_Despesa_Valida()
    {
        var categoria = new
        {
            Descricao = "Alimentacao",
            Finalidade = 0
        };

        var response = await _client.PostAsJsonAsync("/api/v1/categorias", categoria);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Created,
            $"Esperado 200 ou 201, mas veio {(int)response.StatusCode}. Body: {body}"
        );

        var json = JsonDocument.Parse(body);
        var root = json.RootElement;

        Assert.True(root.TryGetProperty("id", out var idProp), "Resposta não contém 'id'.");
        Assert.False(string.IsNullOrWhiteSpace(idProp.GetString()));

        Assert.Equal("Alimentacao", root.GetProperty("descricao").GetString());
        Assert.Equal(0, root.GetProperty("finalidade").GetInt32());
    }


    [Fact]
    public async Task Nao_Deve_Criar_Categoria_Sem_Descricao()
    {
        var categoria = new
        {
            Descricao = "",
            Finalidade = 1
        };

        var response = await _client.PostAsJsonAsync("/api/v1/categorias", categoria);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Descricao", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Nao_Deve_Criar_Categoria_Com_Finalidade_Invalida()
    {
        var categoria = new
        {
            Descricao = "Categoria Invalida",
            Finalidade = 999
        };

        var response = await _client.PostAsJsonAsync("/api/v1/categorias", categoria);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}