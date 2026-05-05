import { test } from '../fixtures/test-base';


test.describe('Categoria pessoas', () => {
  test.beforeEach(async ({ basePage }) => {
    await basePage.goto('/');
  });

  test('Adicionar pessoa com sucesso', async ({ homePage, pessoasPage }) => {
    await homePage.clicarPessoas();
    await pessoasPage.clicarAdicionarPessoa();
    await pessoasPage.preencherNovaPessoa('Renato','1995-08-10');
    await pessoasPage.clicarEmSalvar();
    await pessoasPage.validarMensagemPessoaCadastrada();
  });

  test('Adicionar pessoa com nome em branco', async ({ homePage, pessoasPage }) => {
    await homePage.clicarPessoas();
    await pessoasPage.clicarAdicionarPessoa();
    await pessoasPage.preencherNovaPessoa('','1995-08-10');
    await pessoasPage.clicarEmSalvar();
    await pessoasPage.validarMensagemNomeObrigatorio();
  });

  test('Atualizar Pessoa', async ({ homePage, pessoasPage }) => {
    await homePage.clicarPessoas();
    await pessoasPage.clicarEditarPorNome('AAA');
    await pessoasPage.preencherNovaPessoa('AAARenato','1995-08-10');
    await pessoasPage.clicarEmSalvar();
    await pessoasPage.validarMensagemPessoaAtualizada();
  });
   
});