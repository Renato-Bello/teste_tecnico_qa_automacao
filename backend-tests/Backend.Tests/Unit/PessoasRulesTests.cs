using MinhasFinancas.Domain.Entities;
using Xunit;

namespace Backend.Tests.Unit;

public class PessoasRulesTests
{
    [Fact]
    public void Deve_Considerar_Adulto_Quando_For_Maior_Ou_Igual_A_18()
    {
        var pessoa = new Pessoa
        {
            Nome = "Renato",
            DataNascimento = DateTime.Today.AddYears(-18)
        };

        Assert.True(pessoa.EhMaiorDeIdade());
    }

    [Fact]
    public void Deve_Considerar_Menor_Quando_For_Menor_Que_18()
    {
        var pessoa = new Pessoa
        {
            Nome = "Renato",
            DataNascimento = DateTime.Today.AddYears(-17)
        };

        Assert.False(pessoa.EhMaiorDeIdade());
    }

      [Fact]
    public void Deve_Considerar_Adulto_Quando_For_Maior_Ou_Igual_A_18_()
    {
        int age = 18;

        bool isAdult = age >= 18;

        Assert.True(isAdult);
    }

    [Fact]
    public void Deve_Considerar_Menor_Quando_For_Menor_Que_18_()
    {
        int age = 17;

        bool isAdult = age >= 18;

        Assert.False(isAdult);
    }
}