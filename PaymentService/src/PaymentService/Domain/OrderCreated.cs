namespace PaymentService.Domain;

using MassTransit;
using SharedKernel.Messages;
using System.Threading.Tasks;
using PaymentService.Databases;

public sealed class OrderCreated : IConsumer<IOrderCreated>
{
    private readonly PaymentDbContext _db;

    public OrderCreated(PaymentDbContext db)
    {
        _db = db;
    }

    public Task Consume(ConsumeContext<IOrderCreated> context)
    {
        // do work here

        return Task.CompletedTask;
    }
}