using PaymentService.Domain.Payments;
using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Mappings;
using PaymentService.Domain.Payments.Services;
using PaymentService.Services;

namespace PaymentService.Domain;

using MassTransit;
using SharedKernel.Messages;
using System.Threading.Tasks;

public sealed class OrderCreated : IConsumer<IOrderCreated>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreated(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<IOrderCreated> context)
    {
        var request = new PaymentForCreationDto
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
        
        var paymentToAdd = request.ToPaymentForCreation();
        var payment = Payment.Create(paymentToAdd);

        await _paymentRepository.Add(payment);
        await _unitOfWork.CommitChanges();
    }
}