# Bug: Erro ao salvar transação válida devido a falha no banco

## Ambiente
- API: MinhasFinancas
- Execução local via Swagger/Postman e testes de integração (.NET)
- Base URL: http://localhost:5135

## Endpoint
POST /api/v1/transacoes

## Pré-condições
- Pessoa válida cadastrada
- Categoria válida cadastrada

## Passos para reproduzir
1. Criar uma pessoa válida
2. Criar uma categoria válida
3. Enviar requisição POST para /api/v1/transacoes com dados válidos
4. Observar resposta

## Resultado esperado
- Status code: 200 OK ou 201 Created
- Transação criada com sucesso

## Resultado obtido
- Status code: 500 Internal Server Error
- Mensagem:
"An error occurred while saving the entity changes"

- Possível erro adicional:
"SQLite Error 1: table Transacoes has no column named CategoriaId"

## Evidência
- Falha reproduzida via Postman e testes de integração

## Impacto
- Nenhuma transação pode ser criada
- Funcionalidade principal indisponível
- Regras de negócio não são executadas

## Severidade
Crítica 🔴