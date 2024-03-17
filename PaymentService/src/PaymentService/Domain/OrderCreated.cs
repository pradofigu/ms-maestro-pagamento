using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Dtos;

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
        var payment = new PaymentForCreationDto
        {
            CorrelationId = context.Message.CorrelationId,
            CardNumber = context.Message.CardNumber,
            CardToken = context.Message.CardToken,
            CardHolderName = context.Message.CardHolderName,
            ExpiryDate = context.Message.ExpiryDate,
            CVV = context.Message.CVV,
            TotalAmount = context.Message.TotalAmount,
            Currency = context.Message.Currency,
            Status = context.Message.Status,
            
        };
        
        return Task.CompletedTask;
    }
}