import { test } from '../fixtures/test-base';


test.describe('Categoria pessoas', () => {
  test.beforeEach(async ({ basePage }) => {
    await basePage.goto('/');
  });


  test('Adicionar pessoa com nome em branco', async ({ homePage, pessoasPage }) => {
    await homePage.clicarPessoas();
    await pessoasPage.preencherNovaPessoa('','1995-08-10');
    await pessoasPage.clicarEmSalvar();
    await pessoasPage.validarMensagemNomeObrigatorio();
  });

  test('Erro ao adicionar uma pessoa', async ({ homePage, pessoasPage }) => {
    await homePage.clicarPessoas();
    await pessoasPage.preencherNovaPessoa('Renato','1995-08-10');
    await pessoasPage.clicarEmSalvar();
    await pessoasPage.validarMensagemErroAoSalvar();
  });
   
});