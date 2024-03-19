using PaymentService.Domain.Payments;

namespace PaymentService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PaymentService.Databases;

public static class PaymentCompleted
{
    public sealed record PaymentCompletedCommand(Payment Payment) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<PaymentCompletedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(PaymentCompletedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IPaymentCompleted>(new
            {
                PaymentId = request.Payment.Id,
                request.Payment.CorrelationId,
                request.Payment.Status
            }, cancellationToken);

            return true;
        }
    }
}