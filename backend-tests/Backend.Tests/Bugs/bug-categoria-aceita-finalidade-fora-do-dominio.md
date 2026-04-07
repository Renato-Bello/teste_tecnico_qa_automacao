# Bug: API aceita criação de categoria com finalidade numérica fora do domínio esperado

## Ambiente
- API: MinhasFinancas
- Execução local via testes de integração em .NET e validação manual no Postman/Swagger
- Base URL: http://localhost:5135

## Endpoint
POST /api/v1/categorias

## Descrição
Ao enviar uma categoria com descrição válida e um valor numérico de finalidade fora do domínio esperado, a API cria o registro com sucesso.

Pelo comportamento do sistema, a categoria deveria representar apenas finalidades válidas de negócio, como receita e despesa. No entanto, a API aceita valores numéricos arbitrários, como `999`, sem validação.

## Pré-condições
- API em execução
- Banco disponível

## Passos para reproduzir
1. Enviar requisição `POST /api/v1/categorias`
2. Informar payload com descrição válida e finalidade numérica fora do domínio esperado:

```json
{
  "descricao": "Categoria Invalida",
  "finalidade": 999
}