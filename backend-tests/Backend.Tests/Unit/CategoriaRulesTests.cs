using MinhasFinancas.Domain.Entities;
using Xunit;


namespace Backend.Tests.Unit;

public class CategoriaRulesTests
{

     [Fact]
    public void Categoria_Despesa_Nao_Deve_Aceitar_Transacao_De_Receita()
    {
        var categoria = new Categoria
        {
            Descricao = "Moradia",
            Finalidade = Categoria.EFinalidade.Despesa
        };

        var resultado = categoria.PermiteTipo(Transacao.ETipo.Receita);

        Assert.False(resultado);
    }

    [Fact]
    public void Categoria_Ambas_Deve_Aceitar_Receita_E_Despesa()
    {
        var categoria = new Categoria
        {
            Descricao = "Geral",
            Finalidade = Categoria.EFinalidade.Ambas
        };

        var aceitaReceita = categoria.PermiteTipo(Transacao.ETipo.Receita);
        var aceitaDespesa = categoria.PermiteTipo(Transacao.ETipo.Despesa);

        Assert.True(aceitaReceita);
        Assert.True(aceitaDespesa);
    }

    [Fact]
public void Categoria_Receita_Nao_Deve_Aceitar_Transacao_De_Despesa()
{
    var categoria = new Categoria
    {
        Descricao = "Salário",
        Finalidade = Categoria.EFinalidade.Receita
    };

    var resultado = categoria.PermiteTipo(Transacao.ETipo.Despesa);

    Assert.False(resultado);
}

[Fact]
public void Categoria_Receita_Deve_Aceitar_Transacao_De_Receita()
{
    var categoria = new Categoria
    {
        Descricao = "Salário",
        Finalidade = Categoria.EFinalidade.Receita
    };

    var resultado = categoria.PermiteTipo(Transacao.ETipo.Receita);

    Assert.True(resultado);
}
    
}