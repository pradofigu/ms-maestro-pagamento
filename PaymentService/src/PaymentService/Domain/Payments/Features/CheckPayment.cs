using MediatR;
using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Mappings;
using PaymentService.Domain.Payments.Services;
using PaymentService.Services;

namespace PaymentService.Domain.Payments.Features;

public static class CheckPayment
{
    public sealed record Command(PaymentForWebHookCreationDto PaymentForWebHook) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        public Handler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, ISender mediator)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _mediator;
        
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var paymentToUpdate = await _paymentRepository.GetByCorrelationIdAsync(request.PaymentForWebHook.TransactionId, cancellationToken: cancellationToken);
            var paymentToAdd = request.PaymentForWebHook.ToPaymentForWebHookUpdate();
            paymentToUpdate.Update(paymentToAdd);
            
            _paymentRepository.Update(paymentToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
            
            if (request.PaymentForWebHook.Success)
            {
                var commandPaymentComplete = new PaymentCompleted.PaymentCompletedCommand(paymentToUpdate);
                await _mediator.Send(commandPaymentComplete, cancellationToken);    
            }
            
            var commandPaymentCanceled = new PaymentRefused.PaymentRefusedCommand(paymentToUpdate);
            await _mediator.Send(commandPaymentCanceled, cancellationToken);
        }
    }
}