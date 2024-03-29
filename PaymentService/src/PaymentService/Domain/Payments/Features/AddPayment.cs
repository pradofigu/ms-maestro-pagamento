using MediatR;
using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Mappings;
using PaymentService.Domain.Payments.Services;
using PaymentService.Services;

namespace PaymentService.Domain.Payments.Features;

public static class AddPayment
{
    public sealed record Command(PaymentForCreationDto PaymentToAdd) : IRequest<PaymentDto>;

    public sealed class Handler : IRequestHandler<Command, PaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _mediator;
        
        public Handler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, ISender mediator)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        
        public async Task<PaymentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var paymentToAdd = request.PaymentToAdd.ToPaymentForCreation();
            var payment = Payment.Create(paymentToAdd);

            await _paymentRepository.Add(payment, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);
            
            return payment.ToPaymentDto();
        }
    }
}