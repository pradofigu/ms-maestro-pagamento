namespace PaymentService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class PaymentCompleteddEndpointRegistration
{
    public static void PaymentCompleteddEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IPaymentCompleted>(e => e.SetEntityName("payment-completed")); // name of the primary exchange
        cfg.Publish<IPaymentCompleted>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}