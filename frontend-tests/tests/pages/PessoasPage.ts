import { expect } from '@playwright/test';
import { BasePage } from './BasePage';
import { messages } from '../utils/data';

export class PessoasPage extends BasePage {
  

  async preencherNovaPessoa(nome: string, dataDeNascimento: string) { 
  await this.page.locator('input[name="nome"]').fill(nome);
  await this.page.locator('input[name="dataNascimento"]').fill(dataDeNascimento);
  }


    async clicarAdicionarPessoa() {
  await this.page.getByRole('button', { name: 'Adicionar Pessoa' }).click();
}

    async clicarEditarPorNome(nome: string) {
  const linha = this.page.locator('tr', { hasText: nome });
  await linha.getByRole('button', { name: 'Editar' }).click();
}

     async validarMensagemPessoaCadastrada() {
  await expect(this.page.getByText(messages.msgPessoaCadastrada)).toBeVisible();
}

     async validarMensagemPessoaAtualizada() {
  await expect(this.page.getByText(messages.msgPessoaAtualizada)).toBeVisible();
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
