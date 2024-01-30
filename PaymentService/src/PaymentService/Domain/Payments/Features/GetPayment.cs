namespace PaymentService.Domain.Payments.Features;

using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Services;
using PaymentService.Exceptions;
using Mappings;
using MediatR;

public static class GetPayment
{
    public sealed record Query(Guid PaymentId) : IRequest<PaymentDto>;

    public sealed class Handler : IRequestHandler<Query, PaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public Handler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetById(request.PaymentId, cancellationToken: cancellationToken);
            return result.ToPaymentDto();
        }
    }
}