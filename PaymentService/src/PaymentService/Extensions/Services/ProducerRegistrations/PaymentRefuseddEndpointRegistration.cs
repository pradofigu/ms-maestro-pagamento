namespace PaymentService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class PaymentRefuseddEndpointRegistration
{
    public static void PaymentRefuseddEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IPaymentRefused>(e => e.SetEntityName("payment-refused")); // name of the primary exchange
        cfg.Publish<IPaymentRefused>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}