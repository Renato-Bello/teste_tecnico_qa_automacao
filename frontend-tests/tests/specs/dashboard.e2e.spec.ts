import { test } from '../fixtures/test-base';

test.describe('Categoria Dashboard', () => {
  test.beforeEach(async ({ basePage }) => {
    await basePage.goto('/');
  });


  test('Deve exibir valores numéricos nos cards principais', async ({ dashboardPage }) => {
    await dashboardPage.validarCardsComValoresNumericos();
  });

   test('Deve exibir mensagem quando não houver transações', async ({ dashboardPage }) => {
    await dashboardPage.validarMensagemSemTransacoes();
  });
});