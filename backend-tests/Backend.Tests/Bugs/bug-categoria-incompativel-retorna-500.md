# Bug: Transação com categoria incompatível retorna 500 em vez de 400

## Ambiente
- API: MinhasFinancas
- Execução via Swagger/Postman e testes de integração
- Base URL: http://localhost:5135

## Endpoint
POST /api/v1/transacoes

## Pré-condições
- Categoria cadastrada como Despesa
- Pessoa válida cadastrada

## Passos para reproduzir
1. Criar categoria do tipo Despesa
2. Criar pessoa válida
3. Enviar POST de transação do tipo Receita usando essa categoria
4. Observar resposta

## Resultado esperado
- Status code: 400 BadRequest
- Mensagem indicando violação de regra de negócio

## Resultado obtido
- Status code: 500 Internal Server Error

## Evidência
Mensagem indica erro interno mesmo com regra válida sendo aplicada

## Impacto
- API responde incorretamente para erro de negócio
- Quebra contrato da API
- Dificulta tratamento pelo cliente (frontend ou consumidor)

## Severidade
Alta 🟠