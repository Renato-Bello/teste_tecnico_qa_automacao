# Bug: GET de transações retorna 500 devido a erro de query no banco

## Ambiente
- API: MinhasFinancas
- Execução local via Swagger/Postman
- Base URL: http://localhost:5135

## Endpoint
GET /api/v1/transacoes

## Pré-condições
- Aplicação em execução

## Passos para reproduzir
1. Realizar requisição GET para /api/v1/transacoes
2. Observar resposta da API

## Resultado esperado
- Status code: 200 OK
- Lista de transações retornada corretamente

## Resultado obtido
- Status code: 500 Internal Server Error
- Mensagem indica erro de banco (ex: coluna inexistente)

## Evidência
Erro semelhante a:
"SQLite Error: no such column: t.Data"

## Impacto
- Não é possível consultar transações
- Funcionalidade principal comprometida
- API inutilizável para consumo

## Severidade
Crítica 🔴