import { expect } from '@playwright/test';
import { BasePage } from './BasePage';
import { messages } from '../utils/data';

export class CategoriasPage extends BasePage {

    async preencherNovaCategoria(descricao: string, finalidade: string) { 
  await this.page.getByRole('button', { name: 'Adicionar Categoria' }).click();
  await this.page.locator('input[name="descricao"]').fill(descricao);
  await this.page.locator('select[name="finalidade"]').selectOption(finalidade);
  }

     async clicarEmSalvar() {
  await this.page.getByRole('button', { name: 'salvar' }).click();
}

    async validarMensagemCategoriaCadastrada() {
  await expect(this.page.getByText(messages.msgCategoriaCadastrada)).toBeVisible();
}

    async validarMensagemDescricaoObrigatoria() {
  await expect(this.page.getByText(messages.msgDescricaoObrigatoria)).toBeVisible();
}


}