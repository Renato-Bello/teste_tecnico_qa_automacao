# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: specs\pessoas.e2e.spec.ts >> Categoria pessoas >> Erro ao adicionar uma pessoa
- Location: tests\specs\pessoas.e2e.spec.ts:25:7

# Error details

```
Error: expect(locator).toBeVisible() failed

Locator: getByText('Erro ao salvar pessoa. Tente novamente.')
Expected: visible
Timeout: 5000ms
Error: element(s) not found

Call log:
  - Expect "toBeVisible" with timeout 5000ms
  - waiting for getByText('Erro ao salvar pessoa. Tente novamente.')

```

# Page snapshot

```yaml
- generic [ref=e3]:
  - banner [ref=e4]:
    - generic [ref=e5]:
      - generic [ref=e8]:
        - generic [ref=e9]: Minhas Finanças
        - generic [ref=e10]: Gerencie seu dinheiro
      - navigation "Main navigation" [ref=e11]:
        - link "Dashboard" [ref=e12] [cursor=pointer]:
          - /url: /
        - link "Transações" [ref=e13] [cursor=pointer]:
          - /url: /transacoes
        - link "Categorias" [ref=e14] [cursor=pointer]:
          - /url: /categorias
        - link "Relatórios" [ref=e15] [cursor=pointer]:
          - /url: /totais
    - navigation "breadcrumb" [ref=e18]:
      - list [ref=e19]:
        - listitem [ref=e20]:
          - link "Home" [ref=e21] [cursor=pointer]:
            - /url: /
        - listitem [ref=e22]:
          - generic [ref=e23]: /
          - link "Pessoas" [ref=e24] [cursor=pointer]:
            - /url: /pessoas
  - generic [ref=e25]:
    - complementary [ref=e26]:
      - navigation [ref=e27]:
        - list [ref=e28]:
          - listitem [ref=e29]:
            - link "Dashboard" [ref=e30] [cursor=pointer]:
              - /url: /
          - listitem [ref=e31]:
            - link "Transações" [ref=e32] [cursor=pointer]:
              - /url: /transacoes
          - listitem [ref=e33]:
            - link "Categorias" [ref=e34] [cursor=pointer]:
              - /url: /categorias
          - listitem [ref=e35]:
            - link "Pessoas" [ref=e36] [cursor=pointer]:
              - /url: /pessoas
          - listitem [ref=e37]:
            - link "Relatórios" [ref=e38] [cursor=pointer]:
              - /url: /totais
    - main [ref=e39]:
      - generic [ref=e40]:
        - generic [ref=e41]:
          - heading "Pessoas" [level=1] [ref=e42]
          - button "Adicionar Pessoa" [active] [ref=e43] [cursor=pointer]
        - generic [ref=e44]:
          - table "Tabela de dados" [ref=e45]:
            - rowgroup [ref=e46]:
              - row "Nome Data de Nascimento Idade Ações" [ref=e47]:
                - columnheader "Nome" [ref=e48]
                - columnheader "Data de Nascimento" [ref=e49]
                - columnheader "Idade" [ref=e50]
                - columnheader "Ações" [ref=e51]
            - rowgroup [ref=e52]:
              - row "AAARenato 8/10/1995 30 Editar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0 Deletar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0" [ref=e53]:
                - cell "AAARenato" [ref=e54]
                - cell "8/10/1995" [ref=e55]
                - cell "30" [ref=e56]
                - cell "Editar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0 Deletar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0" [ref=e57]:
                  - button "Editar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0" [ref=e58] [cursor=pointer]: Editar
                  - button "Deletar 019d5a5e-0af6-7b59-bc40-e8760a97fbf0" [ref=e59] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/6/2001 25 Editar 019d65ba-2a44-70c1-b78e-a37d09f4ac96 Deletar 019d65ba-2a44-70c1-b78e-a37d09f4ac96" [ref=e60]:
                - cell "Adulto Teste" [ref=e61]
                - cell "4/6/2001" [ref=e62]
                - cell "25" [ref=e63]
                - cell "Editar 019d65ba-2a44-70c1-b78e-a37d09f4ac96 Deletar 019d65ba-2a44-70c1-b78e-a37d09f4ac96" [ref=e64]:
                  - button "Editar 019d65ba-2a44-70c1-b78e-a37d09f4ac96" [ref=e65] [cursor=pointer]: Editar
                  - button "Deletar 019d65ba-2a44-70c1-b78e-a37d09f4ac96" [ref=e66] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d6948-0aee-74e2-ba25-991c66ab15d1 Deletar 019d6948-0aee-74e2-ba25-991c66ab15d1" [ref=e67]:
                - cell "Adulto Teste" [ref=e68]
                - cell "4/7/2001" [ref=e69]
                - cell "25" [ref=e70]
                - cell "Editar 019d6948-0aee-74e2-ba25-991c66ab15d1 Deletar 019d6948-0aee-74e2-ba25-991c66ab15d1" [ref=e71]:
                  - button "Editar 019d6948-0aee-74e2-ba25-991c66ab15d1" [ref=e72] [cursor=pointer]: Editar
                  - button "Deletar 019d6948-0aee-74e2-ba25-991c66ab15d1" [ref=e73] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d694e-e8e2-75ad-96c6-489c5bda3492 Deletar 019d694e-e8e2-75ad-96c6-489c5bda3492" [ref=e74]:
                - cell "Adulto Teste" [ref=e75]
                - cell "4/7/2001" [ref=e76]
                - cell "25" [ref=e77]
                - cell "Editar 019d694e-e8e2-75ad-96c6-489c5bda3492 Deletar 019d694e-e8e2-75ad-96c6-489c5bda3492" [ref=e78]:
                  - button "Editar 019d694e-e8e2-75ad-96c6-489c5bda3492" [ref=e79] [cursor=pointer]: Editar
                  - button "Deletar 019d694e-e8e2-75ad-96c6-489c5bda3492" [ref=e80] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d6988-b90a-72fc-b5a1-449aed04cc9a Deletar 019d6988-b90a-72fc-b5a1-449aed04cc9a" [ref=e81]:
                - cell "Adulto Teste" [ref=e82]
                - cell "4/7/2001" [ref=e83]
                - cell "25" [ref=e84]
                - cell "Editar 019d6988-b90a-72fc-b5a1-449aed04cc9a Deletar 019d6988-b90a-72fc-b5a1-449aed04cc9a" [ref=e85]:
                  - button "Editar 019d6988-b90a-72fc-b5a1-449aed04cc9a" [ref=e86] [cursor=pointer]: Editar
                  - button "Deletar 019d6988-b90a-72fc-b5a1-449aed04cc9a" [ref=e87] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d698a-d06b-74a7-aa27-82d49c18c37c Deletar 019d698a-d06b-74a7-aa27-82d49c18c37c" [ref=e88]:
                - cell "Adulto Teste" [ref=e89]
                - cell "4/7/2001" [ref=e90]
                - cell "25" [ref=e91]
                - cell "Editar 019d698a-d06b-74a7-aa27-82d49c18c37c Deletar 019d698a-d06b-74a7-aa27-82d49c18c37c" [ref=e92]:
                  - button "Editar 019d698a-d06b-74a7-aa27-82d49c18c37c" [ref=e93] [cursor=pointer]: Editar
                  - button "Deletar 019d698a-d06b-74a7-aa27-82d49c18c37c" [ref=e94] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d69f0-e5ac-746e-abc4-df771abd2248 Deletar 019d69f0-e5ac-746e-abc4-df771abd2248" [ref=e95]:
                - cell "Adulto Teste" [ref=e96]
                - cell "4/7/2001" [ref=e97]
                - cell "25" [ref=e98]
                - cell "Editar 019d69f0-e5ac-746e-abc4-df771abd2248 Deletar 019d69f0-e5ac-746e-abc4-df771abd2248" [ref=e99]:
                  - button "Editar 019d69f0-e5ac-746e-abc4-df771abd2248" [ref=e100] [cursor=pointer]: Editar
                  - button "Deletar 019d69f0-e5ac-746e-abc4-df771abd2248" [ref=e101] [cursor=pointer]: Deletar
              - row "Adulto Teste 4/7/2001 25 Editar 019d69f1-3841-7fe5-bd2b-cacac79f9162 Deletar 019d69f1-3841-7fe5-bd2b-cacac79f9162" [ref=e102]:
                - cell "Adulto Teste" [ref=e103]
                - cell "4/7/2001" [ref=e104]
                - cell "25" [ref=e105]
                - cell "Editar 019d69f1-3841-7fe5-bd2b-cacac79f9162 Deletar 019d69f1-3841-7fe5-bd2b-cacac79f9162" [ref=e106]:
                  - button "Editar 019d69f1-3841-7fe5-bd2b-cacac79f9162" [ref=e107] [cursor=pointer]: Editar
                  - button "Deletar 019d69f1-3841-7fe5-bd2b-cacac79f9162" [ref=e108] [cursor=pointer]: Deletar
          - generic [ref=e111]:
            - generic [ref=e112]: Mostrando 1 - 8 de 120
            - generic [ref=e113]:
              - button "Anterior" [disabled] [ref=e114] [cursor=pointer]
              - button "1" [ref=e115] [cursor=pointer]
              - button "2" [ref=e116] [cursor=pointer]
              - button "3" [ref=e117] [cursor=pointer]
              - button "Próximo" [ref=e118] [cursor=pointer]
```

# Test source

```ts
  1  | import { expect } from '@playwright/test';
  2  | import { BasePage } from './BasePage';
  3  | import { messages } from '../utils/data';
  4  | 
  5  | export class PessoasPage extends BasePage {
  6  |   
  7  | 
  8  |   async preencherNovaPessoa(nome: string, dataDeNascimento: string) { 
  9  |   await this.page.locator('input[name="nome"]').fill(nome);
  10 |   await this.page.locator('input[name="dataNascimento"]').fill(dataDeNascimento);
  11 |   }
  12 | 
  13 | 
  14 |     async clicarAdicionarPessoa() {
  15 |   await this.page.getByRole('button', { name: 'Adicionar Pessoa' }).click();
  16 | }
  17 | 
  18 |     async clicarEditarPorNome(nome: string) {
  19 |   const linha = this.page.locator('tr', { hasText: nome });
  20 |   await linha.getByRole('button', { name: 'Editar' }).click();
  21 | }
  22 | 
  23 |      async validarMensagemPessoaCadastrada() {
  24 |   await expect(this.page.getByText(messages.msgPessoaCadastrada)).toBeVisible();
  25 | }
  26 | 
  27 |      async validarMensagemPessoaAtualizada() {
  28 |   await expect(this.page.getByText(messages.msgPessoaAtualizada)).toBeVisible();
  29 | }
  30 | 
  31 |    async validarMensagemNomeObrigatorio() {
  32 |   await expect(this.page.getByText(messages.msgNomeObrigatorio)).toBeVisible();
  33 | }
  34 | 
  35 |    async validarMensagemErroAoSalvar() {
> 36 |   await expect(this.page.getByText(messages.msgErroAoSalvarPessoa)).toBeVisible();
     |                                                                     ^ Error: expect(locator).toBeVisible() failed
  37 | }
  38 | 
  39 |      async clicarEmSalvar() {
  40 |   await this.page.getByRole('button', { name: 'salvar' }).click();
  41 | }
  42 | 
  43 | 
  44 | 
  45 | 
  46 | }
  47 | 
```