# Bug: Menor de idade ao registrar receita retorna 500 em vez de 400

## Ambiente
- API: MinhasFinancas
- Execução via Swagger/Postman e testes de integração
- Base URL: http://localhost:5135

## Endpoint
POST /api/v1/transacoes

## Pré-condições
- Pessoa menor de 18 anos cadastrada
- Categoria válida de receita

## Passos para reproduzir
1. Criar pessoa com menos de 18 anos
2. Criar categoria de receita
3. Enviar POST de transação do tipo Receita
4. Observar resposta

## Resultado esperado
- Status code: 400 BadRequest
- Mensagem:
"Menores de 18 anos não podem registrar receitas"

## Resultado obtido
- Status code: 500 Internal Server Error

## Evidência
Resposta da API:
{
  "StatusCode": 500,
  "Message": "Ocorreu um erro interno no servidor.",
  "Detailed": "Menores de 18 anos não podem registrar receitas."
}

## Impacto
- Regra de negócio existe, mas é tratada como erro interno
- Quebra contrato da API
- Pode confundir consumidores da API

## Severidade
Alta 🟠