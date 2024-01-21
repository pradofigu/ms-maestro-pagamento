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
    public sealed record PaymentRefusedCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<PaymentRefusedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly PaymentDbContext _db;

        public Handler(PaymentDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(PaymentRefusedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IPaymentRefused>(new { });

            return true;
        }
    }
}