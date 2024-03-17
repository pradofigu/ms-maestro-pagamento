using MediatR;
using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Mappings;
using PaymentService.Domain.Payments.Services;
using PaymentService.Services;

namespace PaymentService.Domain.Payments.Features;

public static class UpdatePayment
{
    public sealed record Command(Guid OrderId, PaymentForUpdateDto UpdatedPaymentData) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public Handler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var paymentToUpdate = await _paymentRepository.GetById(request.OrderId, cancellationToken: cancellationToken);
            var paymentToAdd = request.UpdatedPaymentData.ToPaymentForUpdate();
            paymentToUpdate.Update(paymentToAdd);

            _paymentRepository.Update(paymentToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}