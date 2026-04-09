import { test } from '../fixtures/test-base';

test.describe('Categoria transações', () => {
  test.beforeEach(async ({ basePage }) => {
    await basePage.goto('/');
  });


  test('validar adicionar transação com todos os dados em branco', async ({ homePage, transacoesPage }) => {
    await homePage.clicarTransacoes();
    await transacoesPage.preencherNovaTransacao('','','','Despesa');
    await transacoesPage.clicarEmSalvar();
    await transacoesPage.validarMensagemDescricaoObrigatoria();
    await transacoesPage.validarMensagemValorInvalido();
    await transacoesPage.validarMensagemDataInvalida();
    await transacoesPage.validarMensagemPessoaObrigatoria();
  });

  test('validar adicionar transação com campo Pessoa em branco', async ({ homePage, transacoesPage }) => {
    await homePage.clicarTransacoes();
    await transacoesPage.preencherNovaTransacao('Salario','1000','2026-05-20','Despesa');
    await transacoesPage.clicarEmSalvar();
    await transacoesPage.validarMensagemPessoaObrigatoria();
  });
   
});