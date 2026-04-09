import { expect } from '@playwright/test';
import { BasePage } from './BasePage';
import { messages } from '../utils/data';

export class TransacoesPage extends BasePage {
  

  async preencherNovaTransacao(descricao: string, valor: string, data: string, tipo: string) { 
  await this.page.getByRole('button', { name: 'Adicionar Transação' }).click();
  await this.page.locator('input[name="descricao"]').fill(descricao);
  await this.page.locator('input[name="valor"]').fill(valor);
  await this.page.locator('input[name="data"]').fill(data);
  await this.page.locator('#tipo').selectOption(tipo);
  }

   async validarMensagemDescricaoObrigatoria() {
  await expect(this.page.getByText(messages.msgDescricaoObrigatoria)).toBeVisible();
}

   async validarMensagemValorInvalido() {
  await expect(this.page.getByText(messages.msgValorInvalido)).toBeVisible();
}


  async validarMensagemDataInvalida() {
  await expect(this.page.getByText(messages.msgDataInvalida)).toBeVisible();
}

async validarMensagemPessoaObrigatoria(){
     await expect(this.page.getByText(messages.msgPessoaObrigatoria).first()).toBeVisible();
  }

     async clicarEmSalvar() {
  await this.page.getByRole('button', { name: 'salvar' }).click();
}

}