# 📌 Projeto: Teste Técnico QA

### Este projeto foi desenvolvido como parte de um teste técnico para a vaga de Analista de Qualidade de Software.


## 🎯 Estratégia de Testes

O objetivo foi validar a aplicação fornecida, criando testes automatizados em diferentes níveis da pirâmide de testes:

- 🔹 Testes Unitários:
  - Validação de regras de negócio nas entidades e serviços
  - Execução isolada em relação a API e banco de dados, utilizando diretamente as classes de domínio do projeto
  - Utilização de xUnit

- 🔹 Backend (Integração):
  - Testes de integração utilizando .NET e C#
  - Execução de requisições reais com HttpClient
  - Validação de status code e response body

- 🔹 Frontend (E2E):
  - Testes End-to-End utilizando Playwright + TypeScript
  - Aplicação do padrão Page Object Model (POM)
  - Uso de fixtures para organização dos testes

---

## 📋 Cenários de Teste

### 🔹 Testes Unitários
- Validação de regras de negócio das entidades:
  - Pessoas
  - Categorias
  - Transações
- Verificação de comportamentos esperados e cenários inválidos

---

### 🔹 Testes de Integração (API)
- Criação de entidades via API
- Validação de status codes (200, 201, 500)
- Validação do conteúdo das respostas (response body)
- Testes de cenários negativos (dados inválidos)

---

### 🔹 Testes End-to-End (E2E)
- Navegação entre páginas
- Criação de transações
- Validação de exibição no dashboard
- Validação de mensagens quando não há dados
- Interações com elementos da interface

---

## 🛠 Tecnologias utilizadas

### Backend
- .NET 9
- xUnit
- HttpClient

### Frontend
- Playwright
- TypeScript

### Ferramentas adicionais
- Postman

---

## 📁 Estrutura do Projeto

```
backend-tests/
└── Backend.Tests/
├── Unit/
├── Integration/
└── Bugs/

frontend-tests/
├── tests/
│ ├── pages/
│ ├── specs/
│ └── fixtures/

```

---

## 🚀 Como executar o projeto

Para executar os testes corretamente, é necessário subir tanto a API quanto o frontend antes de rodar os testes.

---

### 🔹 1. Subir a API (.NET)

```bash
cd api/MinhasFinancas.API
dotnet run
```

A API estará disponível em:
👉 http://localhost:5135

---

### 🔹 2. Executar os testes de Backend

```bash
cd backend-tests/Backend.Tests
dotnet test
```

---

### 🔹 3. Subir o Frontend

```bash
cd web
npm install
npm run dev
```

O frontend estará disponível em:
👉 http://localhost:5173

---

### 🔹 4. Executar os testes E2E (Frontend)

```bash
cd frontend-tests
npm install
npx playwright test
```

---

## ⚠️ Observações importantes

Para a execução correta dos testes, é necessário considerar os seguintes pontos:

### 🔹 Execução da aplicação

- Os testes E2E dependem do frontend e da API em execução
- Certifique-se de que ambas as aplicações estejam rodando antes de iniciar os testes

Portas utilizadas:

- Frontend: http://localhost:5173  
- API: http://localhost:5135  

---

### 🔹 Testes unitários

Os testes unitários foram implementados utilizando diretamente as classes de domínio do projeto base fornecido (`MinhasFinancas.Domain`).

Essa abordagem permite validar as regras de negócio reais da aplicação, sem dependência de API ou banco de dados.

---

### 🔧 Importante para execução dos testes unitários

Atualmente, a referência ao projeto de domínio está configurada com um caminho absoluto (local), por exemplo:

```
C:\Users\...\MinhasFinancas.Domain.csproj
```

Por esse motivo, ao executar o projeto em outra máquina, é necessário:

- Ajustar o caminho do `<ProjectReference>` para um caminho válido localmente  
ou  
- Garantir que o projeto `MinhasFinancas.Domain` esteja presente na mesma estrutura de diretórios  

---

## 🐞 Bugs identificados

Durante a execução dos testes, foram identificadas inconsistências no tratamento de erros da aplicação:

- A API retorna status **500 (Internal Server Error)** em cenários de entrada inválida, indicando ausência de tratamento adequado de exceções (esperado: 400 - Bad Request)
- Falta de validação consistente dos dados recebidos, permitindo que entradas inválidas cheguem às camadas internas da aplicação
- No frontend, os erros são apresentados de forma genérica (ex: "Erro ao salvar pessoa"), sem detalhamento da causa, prejudicando a experiência do usuário e o diagnóstico de falhas

---


## 🔍 Observações Técnicas

Durante a execução dos testes, foram identificadas inconsistências entre o comportamento da API e o frontend.

Alguns fluxos que funcionam corretamente via API não apresentam o mesmo comportamento no frontend, como:

- Cadastro de pessoas
- Cadastro de categorias

Ao realizar essas ações pela interface, são exibidas mensagens de erro como:
> "Erro ao salvar pessoa. Tente novamente."

Uma possível causa para esse comportamento é a divergência de configuração entre as portas utilizadas:

- API em execução local: http://localhost:5135
- Frontend configurado para consumir: http://localhost:5000

---

Além disso, também foram realizados testes de integração utilizando o Postman, por meio da criação de collections e requests para os principais endpoints da API.

Para isso, foi utilizada a documentação disponibilizada via Swagger, que auxiliou na compreensão dos endpoints, parâmetros e estruturas de requisição e resposta.

Essa abordagem foi utilizada com o objetivo de:

- Obter um melhor entendimento do funcionamento da API
- Validar os endpoints de forma isolada
- Praticar e aprimorar habilidades em testes de API
- Comparar o comportamento da API com o frontend, auxiliando na identificação de inconsistências