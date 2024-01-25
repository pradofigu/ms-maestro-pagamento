namespace PaymentService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using PaymentService.Databases;

public static class PaymentCompleted
{
    public sealed record PaymentCompletedCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<PaymentCompletedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly PaymentDbContext _db;

        public Handler(PaymentDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(PaymentCompletedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IPaymentCompleted>(new { });

            return true;
        }
    }
}