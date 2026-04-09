import { expect, Locator, Page } from '@playwright/test';
import { BasePage } from './BasePage';
import { messages } from '../utils/data';

export class DashBoardPage extends BasePage {
  readonly saldoAtualValor: Locator;
  readonly receitasMesValor: Locator;
  readonly despesasMesValor: Locator;
  readonly mensagemSemTransacoes: Locator;

  constructor(page: Page) {
    super(page);

    this.saldoAtualValor = page.locator('text=Saldo Atual').locator('..').locator('div.text-2xl');
    this.receitasMesValor = page.locator('text=Receitas do Mês').locator('..').locator('div.text-2xl');
    this.despesasMesValor = page.locator('text=Despesas do Mês').locator('..').locator('div.text-2xl');

    this.mensagemSemTransacoes = page.getByText(messages.msgTransacoesInexistentes);
  }

  async validarValorMonetario(locator: Locator) {
    await expect(locator).toBeVisible();
    await expect(locator).not.toHaveText(/Carregando\.\.\./, { timeout: 10000 });

    const texto = (await locator.textContent())?.trim() ?? '';
    expect(texto).toMatch(/^R\$\s?\d{1,3}(\.\d{3})*,\d{2}$|^R\$\s?\d+,\d{2}$/);
  }

  async validarCardsComValoresNumericos() {
    await this.validarValorMonetario(this.saldoAtualValor);
    await this.validarValorMonetario(this.receitasMesValor);
    await this.validarValorMonetario(this.despesasMesValor);
  }

  async validarMensagemSemTransacoes() {
    await this.page.waitForLoadState('networkidle');

    await expect(this.page.getByText('Carregando...')).toHaveCount(0, { timeout: 10000 });

    await expect(this.mensagemSemTransacoes).toBeVisible({ timeout: 10000 });
    await expect(this.mensagemSemTransacoes).toHaveText('Nenhuma transação encontrada');
  }
}