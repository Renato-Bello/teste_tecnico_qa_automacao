import { test } from '../fixtures/test-base';


test.describe('Categoria categorias', () => {
  test.beforeEach(async ({ basePage }) => {
    await basePage.goto('/');
  });

  test('Adicionar categoria com sucesso', async ({ homePage, categoriasPage }) => {
    await homePage.clicarCategorias();
    await categoriasPage.preencherNovaCategoria('Mercado','Despesa');
    await categoriasPage.clicarEmSalvar();
    await categoriasPage.validarMensagemCategoriaCadastrada();
  });

    test('Adicionar categoria sem descrição', async ({ homePage, categoriasPage }) => {
    await homePage.clicarCategorias();
    await categoriasPage.preencherNovaCategoria('','Despesa');
    await categoriasPage.clicarEmSalvar();
    await categoriasPage.validarMensagemDescricaoObrigatoria();
  });


});