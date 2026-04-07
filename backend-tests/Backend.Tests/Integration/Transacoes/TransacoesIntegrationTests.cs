using System.Net;
using System.Net.Http.Json;
using Xunit;
using System.Text.Json;

namespace Backend.Tests.Integration.Transacoes;

public class TransacoesIntegrationTests
{
    [Fact]
    public async Task Nao_Deve_Permitir_Menor_Criar_Transacao_De_Receita()
    {
       
        var client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5135") 
        };

        
        var pessoa = new
        {
            Nome = "Menor Teste",
            DataNascimento = DateTime.Now.AddYears(-16)
        };

      var pessoaResponse = await client.PostAsJsonAsync("/api/v1/pessoas", pessoa);
var pessoaJson = await pessoaResponse.Content.ReadAsStringAsync();

Console.WriteLine("Pessoa response:");
Console.WriteLine(pessoaJson);

var pessoaCriada = JsonSerializer.Deserialize<JsonElement>(pessoaJson);

Guid pessoaId = pessoaCriada.TryGetProperty("id", out var pId)
    ? pId.GetGuid()
    : pessoaCriada.GetProperty("Id").GetGuid();

        
       var categoria = new
{
    Descricao = "Salário",
    Finalidade = 1 
};

        var categoriaResponse = await client.PostAsJsonAsync("/api/v1/categorias", categoria);
var categoriaJson = await categoriaResponse.Content.ReadAsStringAsync();

Console.WriteLine("Categoria response:");
Console.WriteLine(categoriaJson);

Assert.True(categoriaResponse.IsSuccessStatusCode, categoriaJson);

var categoriaCriada = JsonSerializer.Deserialize<JsonElement>(categoriaJson);

Guid categoriaId = categoriaCriada.TryGetProperty("id", out var cId)
    ? cId.GetGuid()
    : categoriaCriada.GetProperty("Id").GetGuid();

        
        var transacao = new
        {
            Descricao = "Teste receita menor",
            Valor = 100,
            Data = DateTime.Now,
            Tipo = 1,
            CategoriaId = categoriaId,
            PessoaId = pessoaId
        };

        var response = await client.PostAsJsonAsync("/api/v1/transacoes", transacao);

        var transacaoJson = await response.Content.ReadAsStringAsync();

Console.WriteLine("Transacao response:");
Console.WriteLine(transacaoJson);
Console.WriteLine($"Status code: {(int)response.StatusCode}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }


    
[Fact]
public async Task Nao_Deve_Permitir_Transacao_Com_Categoria_E_Tipo_Incompativeis()
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5135")
    };

    var pessoa = new
    {
        Nome = "Adulto Teste",
        DataNascimento = DateTime.Now.AddYears(-25)
    };

    var pessoaResponse = await client.PostAsJsonAsync("/api/v1/pessoas", pessoa);
    var pessoaJson = await pessoaResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Pessoa response:");
    Console.WriteLine(pessoaJson);

    var pessoaCriada = JsonSerializer.Deserialize<JsonElement>(pessoaJson);

    Guid pessoaId = pessoaCriada.TryGetProperty("id", out var pId)
        ? pId.GetGuid()
        : pessoaCriada.GetProperty("Id").GetGuid();

    var categoria = new
    {
        Descricao = "Alimentação",
        Finalidade = 0
    };

    var categoriaResponse = await client.PostAsJsonAsync("/api/v1/categorias", categoria);
    var categoriaJson = await categoriaResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Categoria response:");
    Console.WriteLine(categoriaJson);

    Assert.True(categoriaResponse.IsSuccessStatusCode, categoriaJson);

    var categoriaCriada = JsonSerializer.Deserialize<JsonElement>(categoriaJson);

    Guid categoriaId = categoriaCriada.TryGetProperty("id", out var cId)
        ? cId.GetGuid()
        : categoriaCriada.GetProperty("Id").GetGuid();

    var transacao = new
    {
        Descricao = "Teste incompatível",
        Valor = 100,
        Data = DateTime.Now,
        Tipo = 1,
        CategoriaId = categoriaId,
        PessoaId = pessoaId
    };

    var response = await client.PostAsJsonAsync("/api/v1/transacoes", transacao);
    var responseBody = await response.Content.ReadAsStringAsync();

    Console.WriteLine("Transacao response:");
    Console.WriteLine(responseBody);
    Console.WriteLine($"Status code: {(int)response.StatusCode}");

    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
}

[Fact]
public async Task Deve_Criar_Transacao_De_Receita_Para_Adulto()
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5135")
    };

    var pessoa = new
    {
        Nome = "Adulto Válido",
        DataNascimento = DateTime.Now.AddYears(-25)
    };

    var pessoaResponse = await client.PostAsJsonAsync("/api/v1/pessoas", pessoa);
    var pessoaJson = await pessoaResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Pessoa response:");
    Console.WriteLine(pessoaJson);

    Assert.True(pessoaResponse.IsSuccessStatusCode, pessoaJson);

    var pessoaCriada = JsonSerializer.Deserialize<JsonElement>(pessoaJson);

    Guid pessoaId = pessoaCriada.TryGetProperty("id", out var pId)
        ? pId.GetGuid()
        : pessoaCriada.GetProperty("Id").GetGuid();

    var categoria = new
    {
        Descricao = "Salário Válido",
        Finalidade = 1
    };

    var categoriaResponse = await client.PostAsJsonAsync("/api/v1/categorias", categoria);
    var categoriaJson = await categoriaResponse.Content.ReadAsStringAsync();

    Console.WriteLine("Categoria response:");
    Console.WriteLine(categoriaJson);

    Assert.True(categoriaResponse.IsSuccessStatusCode, categoriaJson);

    var categoriaCriada = JsonSerializer.Deserialize<JsonElement>(categoriaJson);

    Guid categoriaId = categoriaCriada.TryGetProperty("id", out var cId)
        ? cId.GetGuid()
        : categoriaCriada.GetProperty("Id").GetGuid();

    var transacao = new
    {
        Descricao = "Receita válida",
        Valor = 2500,
        Data = DateTime.Now,
        Tipo = 1,
        CategoriaId = categoriaId,
        PessoaId = pessoaId
    };

    var response = await client.PostAsJsonAsync("/api/v1/transacoes", transacao);
    var responseBody = await response.Content.ReadAsStringAsync();

    Console.WriteLine("Transacao response:");
    Console.WriteLine(responseBody);
    Console.WriteLine($"Status code: {(int)response.StatusCode}");

    Assert.True(
        response.StatusCode == HttpStatusCode.Created ||
        response.StatusCode == HttpStatusCode.OK,
        $"Esperado 200 ou 201, mas veio {(int)response.StatusCode}. Body: {responseBody}"
    );
}
}