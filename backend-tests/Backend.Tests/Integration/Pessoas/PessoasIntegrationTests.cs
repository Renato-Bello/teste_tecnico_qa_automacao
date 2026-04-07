using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests.Integration.Pessoas;

public class PessoasIntegrationTests
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("http://localhost:5135")
    };

    [Fact]
    public async Task Deve_Criar_Pessoa_Valida()
    {
        var request = new
        {
            Nome = "Pessoa Valida",
            DataNascimento = new DateTime(2000, 5, 15)
        };

        var response = await _client.PostAsJsonAsync("/api/v1/pessoas", request);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Created,
            $"Esperado 200 ou 201, mas veio {(int)response.StatusCode}. Body: {body}"
        );

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var pessoaResponse = JsonSerializer.Deserialize<PessoaResponseDto>(body, options);

        Assert.NotNull(pessoaResponse);
        Assert.NotEqual(Guid.Empty, pessoaResponse!.Id);
        Assert.Equal("Pessoa Valida", pessoaResponse.Nome);
        Assert.Equal(new DateTime(2000, 5, 15), pessoaResponse.DataNascimento);
        Assert.True(pessoaResponse.Idade > 0);
    }

    [Fact]
    public async Task Deve_Atualizar_Pessoa_Valida()
    {
        var pessoaCriada = await CriarPessoaAsync("Pessoa Atualizar", new DateTime(2000, 5, 15));

        var request = new
        {
            Nome = "Pessoa Atualizada",
            DataNascimento = new DateTime(1999, 6, 20)
        };

        var response = await _client.PutAsJsonAsync($"/api/v1/pessoas/{pessoaCriada.Id}", request);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        var buscaResponse = await _client.GetAsync($"/api/v1/pessoas/{pessoaCriada.Id}");
        var buscaBody = await buscaResponse.Content.ReadAsStringAsync();

        Console.WriteLine(buscaBody);

        Assert.Equal(HttpStatusCode.OK, buscaResponse.StatusCode);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var pessoaAtualizada = JsonSerializer.Deserialize<PessoaResponseDto>(buscaBody, options);

        Assert.NotNull(pessoaAtualizada);
        Assert.Equal(pessoaCriada.Id, pessoaAtualizada!.Id);
        Assert.Equal("Pessoa Atualizada", pessoaAtualizada.Nome);
        Assert.Equal(new DateTime(1999, 6, 20), pessoaAtualizada.DataNascimento);
        Assert.True(pessoaAtualizada.Idade > 0);
    }

    [Fact]
    public async Task Deve_Buscar_Pessoa_Existente()
    {
        var pessoaCriada = await CriarPessoaAsync("Pessoa Buscar", new DateTime(2001, 1, 10));

        var response = await _client.GetAsync($"/api/v1/pessoas/{pessoaCriada.Id}");
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var pessoa = JsonSerializer.Deserialize<PessoaResponseDto>(body, options);

        Assert.NotNull(pessoa);
        Assert.Equal(pessoaCriada.Id, pessoa!.Id);
        Assert.Equal("Pessoa Buscar", pessoa.Nome);
        Assert.Equal(new DateTime(2001, 1, 10), pessoa.DataNascimento);
        Assert.True(pessoa.Idade > 0);
    }

    [Fact]
    public async Task Deve_Excluir_Pessoa_Valida()
    {
        var pessoaCriada = await CriarPessoaAsync("Pessoa Excluir", new DateTime(1998, 8, 8));

        var response = await _client.DeleteAsync($"/api/v1/pessoas/{pessoaCriada.Id}");
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Deve_Confirmar_Exclusao_Pessoa_Valida()
    {
        var pessoaCriada = await CriarPessoaAsync("Pessoa Confirmar Exclusao", new DateTime(1997, 7, 7));

        var deleteResponse = await _client.DeleteAsync($"/api/v1/pessoas/{pessoaCriada.Id}");
        var deleteBody = await deleteResponse.Content.ReadAsStringAsync();

        Console.WriteLine(deleteBody);

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        var buscaResponse = await _client.GetAsync($"/api/v1/pessoas/{pessoaCriada.Id}");
        var buscaBody = await buscaResponse.Content.ReadAsStringAsync();

        Console.WriteLine(buscaBody);

        Assert.Equal(HttpStatusCode.NotFound, buscaResponse.StatusCode);
    }

    [Fact]
    public async Task Nao_Deve_Criar_Pessoa_Sem_Nome()
    {
        var request = new
        {
            Nome = "",
            DataNascimento = DateTime.Now.AddYears(-25)
        };

        var response = await _client.PostAsJsonAsync("/api/v1/pessoas", request);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Nome", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Nao_Deve_Criar_Pessoa_Com_Data_Invalida()
    {
        var request = new
        {
            Nome = "Pessoa Data Invalida",
            DataNascimento = DateTime.Now.AddYears(1)
        };

        var response = await _client.PostAsJsonAsync("/api/v1/pessoas", request);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("DataNascimento", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Nao_Deve_Buscar_Pessoa_Inexistente()
    {
        var idInexistente = Guid.NewGuid();

        var response = await _client.GetAsync($"/api/v1/pessoas/{idInexistente}");
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.True(
            response.StatusCode == HttpStatusCode.BadRequest ||
            response.StatusCode == HttpStatusCode.NotFound,
            $"Esperado 400 ou 404, mas veio {(int)response.StatusCode}. Body: {body}"
        );
    }

    private async Task<PessoaResponseDto> CriarPessoaAsync(string nome, DateTime dataNascimento)
    {
        var request = new
        {
            Nome = nome,
            DataNascimento = dataNascimento
        };

        var response = await _client.PostAsJsonAsync("/api/v1/pessoas", request);
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        Assert.True(
            response.StatusCode == HttpStatusCode.OK ||
            response.StatusCode == HttpStatusCode.Created,
            $"Falha ao criar pessoa de apoio. Status: {(int)response.StatusCode}. Body: {body}"
        );

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var pessoa = JsonSerializer.Deserialize<PessoaResponseDto>(body, options);

        Assert.NotNull(pessoa);
        return pessoa!;
    }
}

public class PessoaResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
}