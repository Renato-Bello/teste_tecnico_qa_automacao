import { expect } from '@playwright/test';
import { BasePage } from './BasePage';
import { messages } from '../utils/data';

export class PessoasPage extends BasePage {
  

  async preencherNovaPessoa(nome: string, dataDeNascimento: string) { 
  await this.page.getByRole('button', { name: 'Adicionar Pessoa' }).click();
  await this.page.locator('input[name="nome"]').fill(nome);
  await this.page.locator('input[name="dataNascimento"]').fill(dataDeNascimento);
  }

   async validarMensagemNomeObrigatorio() {
  await expect(this.page.getByText(messages.msgNomeObrigatorio)).toBeVisible();
}

   async validarMensagemErroAoSalvar() {
  await expect(this.page.getByText(messages.msgErroAoSalvarPessoa)).toBeVisible();
}

     async clicarEmSalvar() {
  await this.page.getByRole('button', { name: 'salvar' }).click();
}

}