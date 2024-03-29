using Microsoft.EntityFrameworkCore;

namespace PaymentService.Domain.Payments.Services;

using PaymentService.Domain.Payments;
using PaymentService.Databases;
using PaymentService.Services;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    public Task<Payment> GetByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default);
}

public sealed class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    private readonly PaymentDbContext _dbContext;

    public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Payment> GetByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Payments
            .Where(x => x.CorrelationId == correlationId)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
