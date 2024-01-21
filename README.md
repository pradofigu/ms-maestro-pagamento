<h1 align="center">
    <br>Microservice - Maestro Pagamentos<br/> 
</h1>

## Descrição
Microserviço responsável por receber as mensagens de pedidos enviados pelo broker, processar o pagamento de forma isolada
e enviar as mensagens relacioadas ao pagamento após resposta do webhook para os serviços de Pedido e Backoffice.

## Tech Stack

- **Languages**
    - C#, SQL
- **Frameworks**
    - EntityFramework Code-First and Migrations
    - NET Core 8.x
    - Testcontainers, XUnit, FluentAssertions, NSubstitute
- **Message Broker**
    - RabbitMQ
- **Observability**
    - Jaeger Dashboard
- **Architecture**
    - Clean source code
    - Domain Driven Design + Vertical Slice Architecture
    - Dependency injection

## Application

- **Host**: http://localhost:5001
- **Swagger API**: http://localhost:5001/swagger/index.html

## Usage

1. Clone the repo
2. Execute ```docker compose -f docker-compose.yaml```
3. Use Application.