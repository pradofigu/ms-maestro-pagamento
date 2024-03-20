using PaymentService.Domain.Payments;

namespace PaymentService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using PaymentService.Databases;

public static class PaymentRefused
{
    public sealed record PaymentRefusedCommand(Payment Payment) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<PaymentRefusedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(PaymentRefusedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IPaymentRefused>(new { });

            await _publishEndpoint.Publish<IPaymentRefused>(new
            {
                PaymentId = request.Payment.Id,
                request.Payment.CorrelationId,
                request.Payment.Status
            }, cancellationToken);

            return true;
        }
    }
}