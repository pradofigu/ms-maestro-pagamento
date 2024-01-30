namespace PaymentService.Domain.Payments.Features;

using PaymentService.Domain.Payments.Dtos;
using PaymentService.Domain.Payments.Services;
using PaymentService.Exceptions;
using PaymentService.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetPaymentList
{
    public sealed record Query(PaymentParametersDto QueryParameters) : IRequest<PagedList<PaymentDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public Handler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PagedList<PaymentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _paymentRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToPaymentDtoQueryable();

            return await PagedList<PaymentDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}