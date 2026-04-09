import { expect, Page } from '@playwright/test';
import { BasePage } from './BasePage';

export class HomePage extends BasePage {
  constructor(page: Page) {
    super(page);
  }

  async clicarDashboard() {
    await this.page.locator('aside').getByRole('link', { name: 'Dashboard' }).click();
    await expect(this.page).toHaveURL(/\/$/);
  }

  async clicarTransacoes() {
    await this.page.locator('aside').getByRole('link', { name: 'Transações' }).click();
    await expect(this.page).toHaveURL(/\/transacoes$/);
  }

  async clicarCategorias() {
    await this.page.locator('aside').getByRole('link', { name: 'Categorias' }).click();
    await expect(this.page).toHaveURL(/\/categorias$/);
  }

  async clicarPessoas() {
    await this.page.locator('aside').getByRole('link', { name: 'Pessoas' }).click();
    await expect(this.page).toHaveURL(/\/pessoas$/);
  }

  async clicarRelatorios() {
    await this.page.locator('aside').getByRole('link', { name: 'Relatórios' }).click();
    await expect(this.page).toHaveURL(/\/relatorios$/);
  }
}